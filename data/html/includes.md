Per HTML5 spec, typically there is no need to specify a type when including CSS and JavaScript files as text/css and text/javascript are their respective defaults.

```html
<!-- External CSS -->
<link rel="stylesheet" href="code-guide.css">
 
<!-- In-document CSS -->
<style>
  /* ... */
</style>
 
<!-- JavaScript -->
<script src="code-guide.js"></script>
```