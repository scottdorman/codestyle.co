Avoid unnecessary nesting. Just because you can nest, doesn't mean you always should. Consider nesting only if you must scope styles to a parent and if there are multiple elements to be nested.

```css
// Without nesting
.table > thead > tr > th { &hellip; }
.table > thead > tr > td { &hellip; }
 
// With nesting
.table > thead > tr {
  > th { &hellip; }
  > td { &hellip; }
}
```