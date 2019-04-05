---
layout: guideline
title: HTML
icon: "icon-html5-01"
attribution:
   url: "http://codeguide.co/#html"
   title: "Adapted from codeguide.co"
---

# Contents
{:.no_toc}
* TOC
{:toc}

# Syntax

- Use soft tabs with two spaces&mdash;they're the only way to guarantee code renders the same in any environment.
- Nested elements should be indented once (two spaces).
- Always use double quotes, never single quotes, on attributes.
- Don't include a trailing slash in self-closing elements&mdash;the HTML5 spec says they're optional.
- Don't omit optional closing tags (e.g. `</li>` or `</body>`).

```html
<!DOCTYPE html>
<html>
  <head>
    <title>Page title</title>
  </head>
  <body>
    <img src="images/company-logo.png" alt="Company">
    <h1 class="hello-world">Hello, world!</h1>
  </body>
</html>
```

**See also**
* [W3C: HTML5 specification](http://dev.w3.org/html5/spec-author-view/syntax.html#syntax-start-tag)

# HTML 5 doctype

Enforce standards mode and more consistent rendering in every browser possible with this simple doctype at the beginning of every HTML page.

```html
<!DOCTYPE html>
<html>
  <head>
  </head>
</html>
```

# Language attribute

From the HTML5 spec: 

> Authors are encouraged to specify a lang attribute on the root html element, giving the document's language. This aids speech synthesis tools to determine what pronunciations to use, translation tools to determine what rules to use, and so forth.

```html
<html lang="en-us">
  <!-- ... -->
</html>
```

**See also**
* [W3C: The 'html' element](http://www.w3.org/html/wg/drafts/html/master/semantics.html#the-html-element)
* [SO 2 Letter Language Codes](http://reference.sitepoint.com/html/lang-codes)

# IE compatibility mode

Internet Explorer supports the use of a document compatibility ``<meta>`` tag to specify what version of IE the page should be rendered as. Unless circumstances require otherwise, it's most useful to instruct IE to use the latest supported mode with edge mode.

```html
<meta http-equiv="X-UA-Compatible" content="IE=Edge">
```

**See also**
* [What's the difference if `<meta http-equiv='X-UA-Compatible' content='IE=edge'>` exists or not?](http://stackoverflow.com/questions/6771258/whats-the-difference-if-meta-http-equiv-x-ua-compatible-content-ie-edge-e)

# Character encoding

Quickly and easily ensure proper rendering of your content by declaring an explicit character encoding. When doing so, you may avoid using character entities in your HTML, provided their encoding matches that of the document (generally UTF-8).

```html
<head>
  <meta charset="UTF-8">
</head>
```

# CSS and JavaScript includes

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

**See also**
* [Using link](http://www.w3.org/TR/2011/WD-html5-20110525/semantics.html#the-link-element)
* [Using style](http://www.w3.org/TR/2011/WD-html5-20110525/semantics.html#the-style-element)
* [Using script](http://www.w3.org/TR/2011/WD-html5-20110525/semantics.html#the-script-element)

# Practicality over purity

Strive to maintain HTML standards and semantics, but not at the expense of practicality. Use the least amount of markup with the fewest intricacies whenever possible.

# Attribute order

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

# Boolean attributes

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

**See also**
* [WhatWG section on boolean attributes](http://www.whatwg.org/specs/web-apps/current-work/multipage/common-microsyntaxes.html#boolean-attributes)

# Reducing markup

Whenever possible, avoid superfluous parent elements when writing HTML. Many times this requires iteration and refactoring, but produces less HTML. Take the following example:

```html
<!-- Not so great -->
<span class="avatar">
  <img src="...">
</span>
 
<!-- Better -->
<img class="avatar" src="...">
```

# JavaScript generated markup

Writing markup in a JavaScript file makes the content harder to find, harder to edit, and less performant. Avoid it whenever possible.