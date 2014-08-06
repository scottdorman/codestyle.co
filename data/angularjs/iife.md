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
