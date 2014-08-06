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
