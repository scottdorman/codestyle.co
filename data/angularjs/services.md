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
