Using `ng-annotate` for Gulp or Grunt by commenting functions that need automated dependency injection with `/** @ngInject */` will safeguard your code from any dependencies that may not be using minification-safe practices.

<div class="panel panel-warning">
   <div class="panel-heading">
        <div class="panel-title">
            <span class="fa fa-info-circle"></span> Note
        </div>      
   </div>
   <div class="panel-body">
   Starting from AngularJS 1.3 use the <code>ngStrictDi</code> parameter on the <code>ng-app</code> directive: <code><body ng-app="APP" ng-strict-di></code> to create the injector in "strict-di" mode. This causes the application to fail to invoke functions which do not use explicit function annotation (these may not be minification safe). Debugging info will be logged to the console to help track down the offending code.
   </div>
</div>