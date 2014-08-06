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

<div class="panel panel-warning">
   <div class="panel-heading">
        <div class="panel-title">
            <span class="fa fa-info-circle"></span> Note
        </div>      
   </div>
   <div class="panel-body">
   If you need to conditionally cancel the route before you start using the controller or before it's activated, use a route resolver instead.
   </div>
</div>
