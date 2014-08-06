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
