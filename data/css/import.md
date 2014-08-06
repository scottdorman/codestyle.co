Compared to ``<link>``s, ``@import`` is slower, adds extra page requests, and can cause other unforeseen problems. Avoid them and instead opt for an alternate approach:

- Use multiple ``<link>`` elements
- Compile your CSS with a preprocessor like Sass or Less into a single file
- Concatenate your CSS files with features provided in Rails, Jekyll, and other environments

```html
<!-- Use link elements -->
<link rel="stylesheet" href="core.css">
 
<!-- Avoid @imports -->
<style>
  @import url("more.css");
</style>
```