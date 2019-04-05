---
layout: guideline
title: General
icon: "far fa-file-code"
---

# Contents
{:.no_toc}
* TOC
{:toc}

# Editor preferences
Set your editor to the following settings to avoid common code inconsistencies and dirty diffs:

- Use soft-tabs set to two spaces.
- Trim trailing white space on save.
- Set encoding to UTF-8.
- Add new line at end of files.

Consider documenting and applying these preferences to your project's `.editorconfig` file or your editor options.

**See also**
* [An example EditorConfig file in Bootstrap](https://github.com/twbs/bootstrap/blob/master/.editorconfig)
* [Learn more about EditorConfig](http://editorconfig.org/)

# Comments

Code is written and maintained by people. Ensure your code is descriptive, well commented, and approachable by others. Great code comments convey context or purpose.

Be sure to write in complete sentences for larger comments and succinct phrases for general notes.

# Naming conventions

## Word Choice

- Choose easily readable identifier names. For example, `HorizonalAlignment` is more readable than `AlignmentHorizontal`.
- Favor readability over brevity. For example, `CanScrollHorizontally` is better than `ScrollableX`.
- Avoid underscores, hyphens, or any other non-alphanumeric characters.
- Avoid using Hungarian notation.
- Avoid using identifiers that conflict with keywords of widely used programming languages.

## Abbreviations and Acronyms

- Don't use abbreviations or contractions as part of identifier names.
- Don't use acronyms that aren't widely accepted, and even if they are, only when necessary.

## Case Sensitivity

- Don't assume that all programming languages are case sensitive. Names should not differ by case alone.
