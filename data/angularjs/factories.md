Factories are singletons which should have a single responsibility that is encapsulated by its context. Declaring all of the callable members of the service at the top makes it easy to read and helps you instantly identify which members of the service can be called and must be unit tested (and/or mocked). 

```javascript
function dataService () {
   var someValue = '';
   var service = {
      save: save,
      someValue: someValue,
      validate: validate
   };
   return service;

   ////////////
   function save () { 
      /* */
   };

   function validate () { 
      /* */
   };
}
```
