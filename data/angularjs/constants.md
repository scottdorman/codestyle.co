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
