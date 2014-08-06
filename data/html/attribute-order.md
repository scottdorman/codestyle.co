HTML attributes should come in this particular order for easier reading of code.

* `class`
* `id`, `name`
* `data-*`
* `src`, `for`, `type`, `href`
* `title`, `alt`
* `aria-*`, `role`

Classes make for great reusable components, so they come first. Ids are more specific and should be used sparingly (e.g., for in-page bookmarks), so they come second.

```html
<a class="..." id="..." data-modal="toggle" href="#">
    Example link
</a>
    
<input class="form-control" type="text">
    
<img src="..." alt="...">
```