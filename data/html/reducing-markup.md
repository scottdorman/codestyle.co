Whenever possible, avoid superfluous parent elements when writing HTML. Many times this requires iteration and refactoring, but produces less HTML. Take the following example:

```html
<!-- Not so great -->
<span class="avatar">
  <img src="...">
</span>
 
<!-- Better -->
<img class="avatar" src="...">
```