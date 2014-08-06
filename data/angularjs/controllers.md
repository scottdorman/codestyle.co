## `controllerAs` syntax in the view
Use the `controllerAs` syntax over the `classic controller with $scope` syntax. This syntax is closer to that of a JavaScript constructor and it promotes the use of binding to a "dotted" object in the View (e.g. `customer.name` instead of `name`), which is more contextual, easier to read, and avoids any reference issues that may occur without "dotting". It can also help avoid using `$parent` calls in Views with nested controllers.

```html
<!-- avoid -->
<div ng-controller="Customer">
   {{ name }}
</div>


<!-- recommended -->
<div ng-controller="Customer as customer">
   {{ customer.name }}
</div>
```

## `controllerAs` syntax in the controller

Using the `controllerAs` syntax instead of the `classic controller with $scope` syntax helps avoid the temptation of using `$scope` methods inside a controller when it might be better to avoid them or move them to a factory. Consider using `$scope` in a factory, or if in a controller just when needed. For example when publishing and subscribing events using `$emit`, `$broadcast`, or `$on` consider moving these uses to a factory and invoke form the controller. 

Inside the controller, the `controllerAs` syntax uses `this`, which gets bound to `$scope` and is syntactic sugar over `$scope`. You can still bind to the View and still access `$scope` methods.

```javascript
/* avoid */
function Customer ($scope) {
   $scope.name = {};
   $scope.sendMessage = function () { };
}


/* recommended - but see next section */
function Customer () {
   this.name = {};
   this.sendMessage = function () { };
}
```

## controllerAs with the view model

The `this` keyword is contextual and, when used within a function inside a controller, may change its context. Capturing the context of `this` avoids the problem. Choose a consistent variable name such as `vm`, which stands for ViewModel.

```javascript
/* avoid */
function Customer () {
   this.name = {};
   this.sendMessage = function () { };
}


/* recommended */
function Customer () {
   /* jshint validthis: true */
   var vm = this;
   vm.name = {};
   vm.sendMessage = function () { };
}
```

<div class="panel panel-warning">
   <div class="panel-heading">
        <div class="panel-title">
            <span class="fa fa-info-circle"></span> Note
        </div>      
   </div>
   <div class="panel-body">
   The <code>/* jshint validthis: true */</code> comment avoids any jshint warnings.
   </div>
</div>

## Bindable Members Up Top

Placing bindable memnbers at the top of the controller in alphabetical order makes it easy to ready and helps you instantly identify which members of the controller can be bound and used in the View. 

When inline anonymous functions are more than 1 line of code they can reduce the readability. Defining the functions below the bindable members (the functions will be hoisted) moves the implementation details down, keeps the bindable members up top, and makes it easier to read. 

```javascript
/* avoid */
function Sessions() {
   var vm = this;

   vm.gotoSession = function() {
      /* ... */
   };
   vm.refresh = function() {
      /* ... */
   };
   vm.search = function() {
      /* ... */
   };
   vm.sessions = [];
   vm.title = 'Sessions';
}


/* recommended */
function Sessions() {
   var vm = this;

   vm.gotoSession = gotoSession;
   vm.refresh = refresh;
   vm.search = search;
   vm.sessions = [];
   vm.title = 'Sessions';

   function gotoSession() {
      /* */
   }

   function refresh() {
      /* */
   }

   function search() {
      /* */
   }
}
```

## Defer Controller Logic

Placing logic in a service or a factory, rather than directly in the controller, can lead to better resuse across multiple controllers. It is also easier to isolate in a unit test and allows the calling logic in the controller to be easily mocked. It also helps remove dependencies and hides implementation details from the controller. 

```javascript
/* avoid */
function Order ($http, $q) {
   var vm = this;
   vm.checkCredit = checkCredit;
   vm.total = 0;

   function checkCredit () { 
      var orderTotal = vm.total;
      return $http.get('api/creditcheck').then(function (data) {
         var remaining = data.remaining;
         return $q.when(!!(remaining > orderTotal));
      });
   };
}


/* recommended */
function Order (creditService) {
   var vm = this;
   vm.checkCredit = checkCredit;
   vm.total = 0;

   function checkCredit () { 
      return creditService.check();
   };
}
```

## Assigning Controllers

Pairing the controller in the route allows different routes to invoke different pairs of controllers and views. When controllers are assigned in the view using `ng-controller`, that view is always associated with the same controller. 

<div class="panel panel-warning">
   <div class="panel-heading">
        <div class="panel-title">
            <span class="fa fa-info-circle"></span> Note
        </div>      
   </div>
   <div class="panel-body">
   If a View is loaded via another means besides a route, then use the <code>ng-controller="Avengers as vm"</code> syntax.
   </div>
</div>

```javascript
// route-config.js
angular
.module('app')
.config(config);

function config ($routeProvider) {
$routeProvider
  .when('/avengers', {
    templateUrl: 'avengers.html',
    controller: 'Avengers',
    controllerAs: 'vm'
  });
}
```

```html
<!-- avengers.html -->
<div>
</div>
```
