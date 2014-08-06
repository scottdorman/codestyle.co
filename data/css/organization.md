- Organize sections of code by component.
- Develop a consistent commenting hierarchy.
- Use consistent white space to your advantage when separating sections of code for scanning larger documents.
- When using multiple CSS files, break them down by component instead of page. Pages can be rearranged and components moved.

```css
/*
 * Component section heading
 */
 
.element { ... }
 
 
/*
 * Component section heading
 *
 * Sometimes you need to include optional context for the entire component. Do that up here if it's important enough.
 */
 
.element { ... }
 
/* Contextual sub-component or modifer */
.element-heading { ... }
```