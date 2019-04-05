---
layout: guideline
title: AngularJS
icon: "icon-angularjs"
attribution:
   url: "https://github.com/johnpapa/angularjs-styleguide"
   title: "Adapted from John Papa's Angular Style Guide"
---

# Contents
{:.no_toc}
* TOC
{:toc}

# Single Responsibility
Defining a single component per file helps with code maintenance. Rather than defining a module (and its dependencies), a controller, and a factory all in the same file, separate each one into their own files.

# Immediately Invoked Function Expressions (IIFE)
Wrapping your AngularJS components in an Immediately Invoked Function Expression (IIFE). This helps to prevent
variables and function declarations from living longer than expected in the global scope, which also helps avoid variable collisions.

This becomes even more important when your code is minified and bundled into a single file for deployment to a production server by providing variable scope for each file.
  
```javascript
/* recommended */
// logger.js
(function () {
   angular
   .module('app')
   .factory('logger', logger);

   function logger () { }
})();

// storage.js
(function () {
   angular
   .module('app')
   .factory('storage', storage);

   function storage () { }
})();
```

{:.alert .alert-info}
For brevity only, the rest of the examples in this guide may omit the IIFE syntax.

# Modules
## Definitions (aka Setters)

When you include only a single component per file, there is rarely a need to introduce a variable for the module. Instead, use the simple getter syntax.
   
```javascript
/* avoid */
var app = angular.module('app', [
  'ngAnimate',
  'ngRoute',
  'app.shared'
  'app.dashboard'
]);


/* recommended */
angular
   .module('app', [
     'ngAnimate',
     'ngRoute',
     'app.shared'
     'app.dashboard'
   ]);
```

## Getters
 
When using a module, using chaining with the getter syntax produces more readable code and avoids variables collisions or leaks.

```javascript
/* avoid */
var app = angular.module('app');
app.controller('SomeController' , SomeController);

function SomeController() { }


/* recommended */
angular
   .module('app')
   .controller('SomeController' , SomeController);

function SomeController() { }
```

## Setting vs Getting

A module should only be created once. Use `angular.module('app', []);` to set a module and `angular.module('app');` to get a module.

## Named vs Anonymous Functions

Using named functions for callbacks produces more readable code, is much easier to debug, and reduces the amount of nested callback code.

```javascript
/* avoid */
angular
   .module('app')
   .controller('Dashboard', function () { });
   .factory('logger', function () { });


/* recommended */
// dashboard.js
angular
   .module('app')
   .controller('Dashboard', Dashboard);

function Dashboard () { }

// logger.js
angular
   .module('app')
   .factory('logger', logger);

function logger () { }
```

# Controllers

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

{:.alert .alert-info}
**Note** If a View is loaded via another means besides a route, then use the `ng-controller="Avengers as vm"` syntax.

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

**See also**
* [Do you like your Angular controllers with or without sugar?](http://www.johnpapa.net/do-you-like-your-angular-controllers-with-or-without-sugar/)
* [https://docs.angularjs.org/api/ng/type/$rootScope.Scope#$emit](https://docs.angularjs.org/api/ng/type/$rootScope.Scope#$emit)
* [https://docs.angularjs.org/api/ng/type/$rootScope.Scope#$broadcat](https://docs.angularjs.org/api/ng/type/$rootScope.Scope#$broadcat)
* [https://docs.angularjs.org/api/ng/type/$rootScope.Scope#$on](https://docs.angularjs.org/api/ng/type/$rootScope.Scope#$on)
* [https://docs.angularjs.org/api/ng/directive/ngController](https://docs.angularjs.org/api/ng/directive/ngController)

# Services
All AngularJS services are singletons, which means that there is only one instance of a given service per injector. Services are instantiated with the `new` keyword. Use `this` for public methods and variables. You can also use a factory instead of a service, which can introduce greater consistency.
  
```javascript
// service
angular
   .module('app')
   .service('logger', logger);

function logger () {
   this.logError = function (msg) {
      /* */
   };
}


// factory
angular
  .module('app')
  .factory('logger', logger);

function logger () {
   return {
      logError: function (msg) {
         /* */
      }
   };
}
```

# Factories
Factories are singletons which should have a single responsibility that is encapsulated by its context. Declaring all of the callable members of the service at the top makes it easy to read and helps you instantly identify which members of the service can be called and must be unit tested (and/or mocked). 

```javascript
function dataService () {
   var someValue = '';
   var service = {
      save: save,
      someValue: someValue,
      validate: validate
   };
   return service;

   ////////////
   function save () { 
      /* */
   };

   function validate () { 
      /* */
   };
}
```

**See also**
* [http://en.wikipedia.org/wiki/Single_responsibility_principle](http://en.wikipedia.org/wiki/Single_responsibility_principle)
* [Revealing Module Pattern](http://addyosmani.com/resources/essentialjsdesignpatterns/book/#revealingmodulepatternjavascript)

# Directives
## One directive per file
Creating one directive per file, with the name the file matching the directive, makes them easier to maintain.

```javascript
/**
* @desc order directive that is specific to the order module at a company named Acme
* @file calendarRange.directive.js
* @example <div acme-order-calendar-range></div>
*/
angular
   .module('sales.order')
   .directive('acmeOrderCalendarRange', orderCalendarRange)

/**
* @desc spinner directive that can be used anywhere across the sales app at a company named Acme
* @file customerInfo.directive.js
* @example <div acme-sales-customer-info></div>
*/    
angular
   .module('sales.widgets')
   .directive('acmeSalesCustomerInfo', salesCustomerInfo);

/**
* @desc spinner directive that can be used anywhere across apps at a company named Acme
* @file spinner.directive.js
* @example <div acme-shared-spinner></div>
*/
angular
   .module('shared.widgets')
   .directive('acmeSharedSpinner', sharedSpinner);
```

## Limit DOM Manipulation

DOM manipulation can be difficult to test and debug. If you must manipulate the DOM directly, use a directive. However, if alternative ways can be used, such as using CSS to set styles or the animation services, Angular templating, `ngShow` or `ngHide`, use those instead.

## Restrict to Elements and Attributes

If the directive makes sense as a standalone element, allow restrict `E` (custom element) and optionally restrict `A` (custom attribute). Generally, `E` is appropriate if it could be its own control. In general, allow `EA` but prefer `E` when its standalone and `A` when it enhances its existing DOM element.

```html
<!-- recommended -->
<my-calendar-range></my-calendar-range>
<div my-calendar-range></div>
```

```javascript
/* recommended */
angular
   .module('app.widgets')
   .directive('myCalendarRange', myCalendarRange);

function myCalendarRange () {
   var directive = {
      link: link,
      templateUrl: '/template/is/located/here.html',
      restrict: 'EA'
   };
   return directive;

   function link(scope, element, attrs) {
      /* */
   }
}
```

**See also**
* [https://docs.angularjs.org/api/ngAnimate](https://docs.angularjs.org/api/ngAnimate)
* [https://docs.angularjs.org/api/ng/directive/ngShow](https://docs.angularjs.org/api/ng/directive/ngShow)
* [https://docs.angularjs.org/api/ng/directive/ngHide](https://docs.angularjs.org/api/ng/directive/ngHide)

# Resolving Promises for a Controller
## Controller Activation Promises
Placing start-up logic in a consistent place in the controller makes it easier to locate, more consistent to test, and helps avoid spreading out the activation logic across the controller. Typically this should be done in an `activate` function.
    
```javascript
function Avengers(dataservice) {
   var vm = this;
   vm.avengers = [];
   vm.title = 'Avengers';

   activate();

   ////////////

   function activate() {
      return dataservice.getAvengers().then(function(data) {
         vm.avengers = data;
         return vm.avengers;
      });
   }
}
```

## Route Resolve Promises

When a controller depends on a promise to be resolved, resolve those dependencies in the `$routeProvider` before the controller logic is executed. Using a route resolve allows the promise to resolve before the controller logic executes.

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
         controllerAs: 'vm',
         resolve: {
            moviesPrepService: function (movieService) {
               return movieService.getMovies();
            }
         }
      });
}

// avengers.js
angular
   .module('app')
   .controller('Avengers', Avengers);

function Avengers (moviesPrepService) {
   var vm = this;
   vm.movies = moviesPrepService.movies;
}
```

{:.alert .alert-info}
**Note** If you need to conditionally cancel the route before you start using the controller or before it's activated, use a route resolver instead.

**See also**
* [https://docs.angularjs.org/api/ngRoute/provider/$routeProvider](https://docs.angularjs.org/api/ngRoute/provider/$routeProvider)

# Manual Dependency Injection
To prevent parameters from being converted to mangled variables, avoid using the shortcut syntax of declaring dependencies without using a minification-safe approach.

Using `$inject` to manually identify your dependencies mirros the technique used by `ng-annotate` and safeguards your dependencies from being vulernable to minification issues when parameters may be mangled.

```javascript
angular
   .module('app')
   .controller('Dashboard', Dashboard);

Dashboard.$inject = ['$location', '$routeParams', 'common', 'dataservice'];

function Dashboard($location, $routeParams, common, dataservice) {
}
```

**See also**
* [https://github.com/olov/ng-annotate](https://github.com/olov/ng-annotate)

# Minification and Annotation

Using `ng-annotate` for Gulp or Grunt by commenting functions that need automated dependency injection with `/** @ngInject */` will safeguard your code from any dependencies that may not be using minification-safe practices.

{:.alert .alert-info}
**Note** Starting from AngularJS 1.3 use the `ngStrictDi` parameter on the `ng-app` directive: `<body ng-app="APP" ng-strict-di>` to create the injector in "strict-di" mode. This causes the application to fail to invoke functions which do not use explicit function annotation (these may not be minification safe). Debugging info will be logged to the console to help track down the offending code.

**See also**
* [https://github.com/olov/ng-annotate](https://github.com/olov/ng-annotate)
* [http://gulpjs.com](http://gulpjs.com)
* [http://gruntjs.com](http://gruntjs.com)
* [https://docs.angularjs.org/api/ng/directive/ngApp](https://docs.angularjs.org/api/ng/directive/ngApp)
* [https://www.npmjs.org/package/gulp-ng-annotate](https://www.npmjs.org/package/gulp-ng-annotate)
* [https://www.npmjs.org/package/grunt-ng-annotate](https://www.npmjs.org/package/grunt-ng-annotate)

# Exception Handling
To provide a consistent manner for customizing how exeptions are handled, use a [decorator](https://docs.angularjs.org/api/auto/service/$provide#decorator) at configuration time using the [`$provide`](https://docs.angularjs.org/api/auto/service/$provide) service on the [`$exceptionHandler`](https://docs.angularjs.org/api/ng/service/$exceptionHandler) service to perform custom actions when exceptions occur.

```javascript
angular
   .module('app.exception')
   .config(['$provide', exceptionConfig]);

function exceptionConfig($provide) {
   $provide.decorator('$exceptionHandler', ['$delegate', '$log', extendExceptionHandler]);
}

function extendExceptionHandler($delegate, $log) {
   return function (exception, cause) {
      $delegate(exception, cause);
      var errorData = {
         exception: exception,
         cause: cause
      };
      var msg = 'ERROR PREFIX' + exception.message;
      $log.error(msg, errorData);

      // Log during dev with http://toastrjs.com 
      // or any other technique you prefer
      toastr.error(msg);
   };
}
```

# Application Structure
## Follow the LIFT Principle

Providing a consistent structure that scales well, is modular, and makes it easy to find code quickly increases developer efficiency and productivity. You can achieve this by following the LIFT principle:

1. `L`ocate your code quickly
2. `I`dentify the code at a glance
3. Keep the `F`lattest structure you can
4. `T`ry to follow the `Don't Repeat Yourself` (DRY) pattern

# Angular $ Wrapper Services
Use [`$document`](https://docs.angularjs.org/api/ng/service/$document) and [`$window`](https://docs.angularjs.org/api/ng/service/$window) instead of `document` and `window`. They are more easily testable than using `document` and `window`.

Use [`$timeout`](https://docs.angularjs.org/api/ng/service/$timeout) and [`$interval`](https://docs.angularjs.org/api/ng/service/$interval) instead of `setTimeout` and `setInterval`. They are more easily testable and handle AngularJS's digest cycle, thereby keeping data binding in sync.

# Comments
Using [`jsDoc`](http://usejsdoc.org/) syntax to document function names, description, params and returns allows you to generate documentation from your code rather than writing it from scratch and provides consistency by using a common tool.

```javascript
angular
   .module('app')
   .factory('logger', logger);

/**
* @name logger
* @desc Application wide logger
*/
function logger ($log) {
   var service = {
   logError: logError
   };
   return service;

   ////////////

   /**
   * @name logError
   * @desc Logs errors
   * @param {String} msg Message to log 
   * @returns {String}
   */
   function logError(msg) {
      var loggedMsg = 'Error: ' + msg;
      $log.error(loggedMsg);
      return loggedMsg;
   };
}
```

# JSHint
Using JS Hint for linting your JavaScript provides a first alert prior to commiting any code changes and helps promote consistency across the team. Be sure to customize the JS Hint options file and include it in source control. An example `.jshintrc` file is shown below.

```javascript
{
   "bitwise": true,
   "camelcase": true,
   "curly": true,
   "eqeqeq": true,
   "es3": false,
   "forin": true,
   "freeze": true,
   "immed": true,
   "indent": 4,
   "latedef": "nofunc",
   "newcap": true,
   "noarg": true,
   "noempty": true,
   "nonbsp": true,
   "nonew": true,
   "plusplus": false,
   "quotmark": "single",
   "undef": true,
   "unused": false,
   "strict": false,
   "maxparams": 10,
   "maxdepth": 5,
   "maxstatements": 40,
   "maxcomplexity": 8,
   "maxlen": 120,
   "asi": false,
   "boss": false,
   "debug": false,
   "eqnull": true,
   "esnext": false,
   "evil": false,
   "expr": false,
   "funcscope": false,
   "globalstrict": false,
   "iterator": false,
   "lastsemic": false,
   "laxbreak": false,
   "laxcomma": false,
   "loopfunc": true,
   "maxerr": false,
   "moz": false,
   "multistr": false,
   "notypeof": false,
   "proto": false,
   "scripturl": false,
   "shadow": false,
   "sub": true,
   "supernew": false,
   "validthis": false,
   "noyield": false,
   "browser": true,
   "node": true,
   "globals": {
       "angular": false,
       "$": false
   }
}
```

**See also**
* [JS Hint docsumentation](http://www.jshint.com/docs/)

# Constants
Creating an AngularJS Constant for vendor libraries' global variables provides a way to inject vendor libraries that otherwise are globals. This improves code testability by allowing you to more easily know what the dependencies of your components are (avoids leaky abstractions). 

```javascript
// constants.js

/* global toastr:false, moment:false */
(function () {
   'use strict';

   angular
      .module('app.core')
      .constant('toastr', toastr)
      .constant('moment', moment);
})();
```
