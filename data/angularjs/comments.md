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
