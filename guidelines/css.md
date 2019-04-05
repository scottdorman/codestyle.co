---
layout: guideline
title: CSS
icon: "icon-css3-01"
attribution:
   url: "http://codeguide.co/#css"
   title: "Adapted from codeguide.co"
---

# Contents
{:.no_toc}
* TOC
{:toc}

# Syntax

- Use soft tabs with two spaces&mdash;they're the only way to guarantee code renders the same in any environment.
- When grouping selectors, keep individual selectors to a single line.
- Include one space before the opening brace of declaration blocks for legibility.
- Place closing braces of declaration blocks on a new line.
- Include one space after `:` for each declaration.
- Each declaration should appear on its own line for more accurate error reporting.
- End all declarations with a semi-colon. The last declaration's is optional, but your code is more error prone without it.
- Comma-separated property values should include a space after each comma (e.g., `box-shadow`).
- Don't include spaces after commas *within* `rgb()`, `rgba()`, `hsl()`, `hsla()`, or `rect()` values. This helps differentiate multiple color values (comma, no space) from multiple property values (comma with space).
- Don't prefix property values or color parameters with a leading zero (e.g., `.5` instead of `0.5` and `-.5px` instead of `-0.5px`).
- Lowercase all hex values, e.g., `#fff`. Lowercase letters are much easier to discern when scanning a document as they tend to have more unique shapes.
- Use shorthand hex values where available, e.g., `#fff` instead of `#ffffff`.
- Quote attribute values in selectors, e.g., `input[type="text"]`. They're only optional in some cases, and it's a good practice for consistency.
- Avoid specifying units for zero values, e.g., `margin: 0;` instead of `margin: 0px;`.

```css
/* Bad CSS */
.selector, .selector-secondary, .selector[type=text] {
  padding:15px;
  margin:0px 0px 15px;
  background-color:rgba(0, 0, 0, 0.5);
  box-shadow:0px 1px 2px #CCC,inset 0 1px 0 #FFFFFF
}
 
/* Good CSS */
.selector,
.selector-secondary,
.selector[type="text"] {
  padding: 15px;
  margin-bottom: 15px;
  background-color: rgba(0,0,0,.5);
  box-shadow: 0 1px 2px #ccc, inset 0 1px 0 #fff;
}
```

**See also**
* [Unquoted attribute values](http://mathiasbynens.be/notes/unquoted-attribute-values#css)
* [Syntax section of the Cascading Style Sheets article on Wikipedia](http://en.wikipedia.org/wiki/Cascading_Style_Sheets#Syntax)

# HTML 5 doctype

Enforce standards mode and more consistent rendering in every browser possible with this simple doctype at the beginning of every HTML page.

```html
<!DOCTYPE html>
<html>
  <head>
  </head>
</html>
```

# Declaration order

Related property declarations should be grouped together following the order:

1. Positioning
2. Box model
3. Typographic
4. Visual

Positioning comes first because it can remove an element from the normal flow of the document and override box model related styles. The box model comes next as it dictates a component's dimensions and placement.

Everything else takes place *inside* the component or without impacting the previous two sections, and thus they come last.

```css
.declaration-order {
  /* Positioning */
  position: absolute;
  top: 0;
  right: 0;
  bottom: 0;
  left: 0;
  z-index: 100;
 
  /* Box-model */
  display: block;
  float: right;
  width: 100px;
  height: 100px;
 
  /* Typography */
  font: normal 13px "Helvetica Neue", sans-serif;
  line-height: 1.5;
  color: #333;
  text-align: center;
 
  /* Visual */
  background-color: #f5f5f5;
  border: 1px solid #e5e5e5;
  border-radius: 3px;
 
  /* Misc */
  opacity: 1;
}
```

**See also**
* [A complete list of properties and their order](http://twitter.github.com/recess)

# Don't use `@import`

Compared to `<link>`s, `@import` is slower, adds extra page requests, and can cause other unforeseen problems. Avoid them and instead opt for an alternate approach:

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

**See also**
* [Don't use import (by Steve Souders)](http://www.stevesouders.com/blog/2009/04/09/dont-use-import/)

# Media query placement

Place media queries as close to their relevant rule sets whenever possible. Don't bundle them all in a separate stylesheet or at the end of the document. Doing so only makes it easier for folks to miss them in the future. Here's a typical setup.

```css
.element { ... }
.element-avatar { ... }
.element-selected { ... }
 
@media (min-width: 480px) {
  .element { ...}
  .element-avatar { ... }
  .element-selected { ... }
}
```

# Prefixed properties

When using vendor prefixed properties, indent each property such that the declaration's value lines up vertically for easy multi-line editing.

In Textmate, use **Text &rarr; Edit Each Line in Selection** (&#8963;&#8984;A). In Sublime Text 2, use **Selection &rarr; Add Previous Line** (&#8963;&#8679;&uarr;) and **Selection &rarr;  Add Next Line** (&#8963;&#8679;&darr;).

```css
/* Prefixed properties */
.selector {
  -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.15);
          box-shadow: 0 1px 2px rgba(0,0,0,.15);
}
```

# Rules with single declarations

In instances where a rule set includes **only one declaration**, consider removing line breaks for readability and faster editing. Any rule set with multiple declarations should be split to separate lines.

The key factor here is error detection&mdash;e.g., a CSS validator stating you have a syntax error on Line 183. With a single declaration, there's no missing it. With multiple declarations, separate lines is a must for your sanity.

```css
/* Single declarations on one line */
.span1 { width: 60px; }
.span2 { width: 140px; }
.span3 { width: 220px; }
 
/* Multiple declarations, one per line */
.sprite {
  display: inline-block;
  width: 16px;
  height: 15px;
  background-image: url(../img/sprite.png);
}
.icon           { background-position: 0 0; }
.icon-home      { background-position: 0 -20px; }
.icon-account   { background-position: 0 -40px; }
```

# Shorthand notation

Strive to limit use of shorthand declarations to instances where you must explicitly set all the available values. Common overused shorthand properties include:


- ``padding``
- ``margin``
- ``font``
- ``background``
- ``border``
- ``border-radius``

Often times we don't need to set all the values a shorthand property represents. For example, HTML headings only set top and bottom margin, so when necessary, only override those two values. Excessive use of shorthand properties often leads to sloppier code with unnecessary overrides and unintended side effects.

```css
/* Bad example */
.element {
  margin: 0 0 10px;
  background: red;
  background: url("image.jpg");
  border-radius: 3px 3px 0 0;
}
 
/* Good example */
.element {
  margin-bottom: 10px;
  background-color: red;
  background-image: url("image.jpg");
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
}
```

**See also**
* [Shorthand properties (Mozilla Developer Network)](https://developer.mozilla.org/en-US/docs/Web/CSS/Shorthand_properties)

# Nesting in LESS and SASS

Avoid unnecessary nesting. Just because you can nest, doesn't mean you always should. Consider nesting only if you must scope styles to a parent and if there are multiple elements to be nested.

```css
// Without nesting
.table > thead > tr > th { ... }
.table > thead > tr > td { ... }
 
// With nesting
.table > thead > tr {
  > th { ... }
  > td { ... }
}
```

# Classes

- Keep classes lowercase and use dashes (not underscores or camelCase). Dashes serve as natural breaks in related class (e.g., `.btn` and `.btn-danger`).
- Avoid excessive and arbitrary shorthand notation. `.btn` is useful for *button*, but `.s` doesn't mean anything.
- Keep classes as short and succinct as possible.
- Use meaningful names; use structural or purposeful names over presentational.
- Prefix classes based on the closest parent or base class.
- Use `.js-*` classes to denote behavior (as opposed to style), but keep these classes out of your CSS.

It's also useful to apply many of these same rules when creating Sass and Less variable names.

```css
/* Bad example */
.t { ... }
.red { ... }
.header { ... }
 
/* Good example */
.tweet { ... }
.important { ... }
.tweet-header { ... }
```

# Selectors

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

**See also**
* [Scope CSS classes with prefixes](http://markdotto.com/2012/02/16/scope-css-classes-with-prefixes/)
* [Stop the cascade](http://markdotto.com/2012/03/02/stop-the-cascade/)

# Organization
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