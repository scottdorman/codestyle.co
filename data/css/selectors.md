- Use classes over generic element tag for optimum rendering performance.
- Avoid using several attribute selectors (e.g., ``[class^="..."]``) on commonly occurring components. Browser performance is known to be impacted by these.
- Keep selectors short and strive to limit the number of elements in each selector to three.
- Scope classes to the closest parent **only** when necessary (e.g., when not using prefixed classes).

```css
 /* Bad example */
 span { ... }
 .page-container #stream .stream-item .tweet .tweet-header .username { ... }
 .avatar { ... }
  
 /* Good example */
 .avatar { ... }
 .tweet-header .username { ... }
 .tweet .avatar { ... }
```