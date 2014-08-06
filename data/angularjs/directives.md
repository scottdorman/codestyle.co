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
