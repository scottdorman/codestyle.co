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
