A boolean attribute is one that needs no declared value. XHTML required you to declare a value, but HTML5 has no such requirement.

If you *must* include the attribute's value, and **you don't need to**, follow this WhatWG guideline:

> If the attribute is present, its value must either be the empty string or [...] the attribute's canonical name, with no leading or trailing whitespace.

**In short, don't add a value.**

```html
<input type="text" disabled>
 
<input type="checkbox" value="1" checked>
 
<select>
  <option value="1" selected>1</option>
</select>
```