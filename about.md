---
layout: guideline
title: About
description: Thoughts on code standards and style guides
nav-include: true
---

# Contents
{:.no_toc}
* TOC
{:toc}

# What is a code standard?
A code standard is a consistent, yet flexible, set of "best practices" designed to improve quality and readability while making code changes and maintenance easier. It
* encompasses all aspects of code construction
* is designed to improve adaptation & maintenance
* does not form an inflexible set of standards
* is consistent
* is not “one size fits all” 
* defines “best practices” for writing code
* must adapt to changes

# What's in a code standard or style guide?
Although a code standard can cover anything you want, it typically focuses on these broad areas.

## Source code presentation (formatting)
The physical layout of source text on the page or screen has a strong effect on its readability.

## Readability
There are many myths about comments and readability. The responsibility for true readability rests more with naming and code structure than with comments. Having as many comment lines as code lines does not imply readability; it more likely indicates the writer does not understand what is important to communicate. 

However, comments can be important as well, when used properly. The idea of code that is "self documenting" can only go so far. Comments should offer explanations as to why the code behaves (or is written) the way it is, reasons why a particular algorithm or design was chosen over another, warnings about changes to the code (A good example here is changing the order of enum values. If that enum doesn't have explicit numeric values and whose numeric value is stored in a database, changing the order of the values will break existing code.), and other information that may be helpful in the future to understand the intent of the code.

## Program Structure
Proper structure improves program clarity. This is analogous to readability on lower levels and facilitates the use of the readability guidelines.

## Programming Practices
Software is always subject to change, commonly known as “maintenance”. Errors need to be corrected or system functionality may need to be enhanced in planned or unplanned ways. Requirements often change over time, and modifications are done long after the software was originally written, usually by someone other than the original author.

Easy and successful modifications require the software be readable, understandable, and structured according to accepted practices. If it can't be easily understood by a programmer familiar with the intended function, it's not maintainable. Making code readable and comprehensible enhance its maintainability. 

## Correctness
Correctness is one aspect of reliability. While style guides can't enforce using correct algorithms, they can suggest techniques and language features which are known to minimize the chances of failures.

## Portability/Interoperability
The common definition of portability for software is

> portability (software). The ease with which software can be transferred from one computer system or environment to another 
> {:. blockqoute-footer} (IEEE Dictionary 1984).

Many portability concerns aren't pure language issues; they involve hardware (byte order, device I/O) and software (utility libraries, operating systems, run-time libraries). 

## Reusability
Reusability is how much, and how easily, code can be used in different applications with minimal to no change. If the code being reused is maintainable, then the application reusing it is more maintainable. 

## Performance
Performance is sometimes at odds with maintainability and portability. Sometimes, to improv speed or memory usage, the best approach leads to confusing code.

## Globalization/Localization
Globalization and localization concerns can have a significant impact on how code is written. It's always easier to plan for globalization/localization early on than to try and add it afterwards.

# Adopting a code standard
Adopting a code standard shouldn't be difficult, but sometimes corporate culture works against it. 
* Without management buy-in, adopting a code standard is almost guaranteed to fail.
* Get support from the "entrenched developer" by getting them involved in the decisions and learn to compromise when needed.
* Make your standard a simple "list" of the guidelines; otherwise it's unlikely anyone will actually read it. Create a more deailed document if you want to provide support, rationale, and code samples, but it's not necessary.

# Enforcing a code standard
There are a variety of ways to enforce a code standard, but if you have a standard defined you do want some way to enforce it.
* Visual Studio Options
   * Define it once, then export them to a .settings file
* `.editorconfig` files
* Add-ins (R#, MZ-Tools, etc.)
* External tools (FxCop, StyleCop, NDepend, etc.)
* Build automation (can run external tools, analysis, etc.)
* Code reviews

# Legacy code
My definition of legacy code is
> Any code that's been written more than 10 minutes ago.
* Don’t change legacy code en-masse
* If the code already has a consistent style, keep following it (for that file only), even if it doesn't follow your current code standard

# Resources
## Blogs & Articles
* [https://scottdorman.blog/tags/#code-standards](https://scottdorman.blog/tags/#code-standards)
* [http://blogs.msdn.com/brada/archive/tags/Framework+Design+Guidelines/default.aspx](http://blogs.msdn.com/brada/archive/tags/Framework+Design+Guidelines/default.aspx)
* [http://blogs.msdn.com/kcwalina/archive/tags/Design+Guidelines/default.aspx](http://blogs.msdn.com/kcwalina/archive/tags/Design+Guidelines/default.aspx)

## Books
* [Framework Design Guidelines (2nd Edition)](https://amzn.to/2FS6Dzl)
* [Ada 95 Quality and Style: Guidelines for Professional Programmers.](https://amzn.to/2CUBvi0)
* [Ada 95, Quality and Style: Guidelines for Professional Programmers (Lecture Notes in Computer Science)](https://amzn.to/2G0GOOL)
* [Clean Code: A Handbook of Agile Software Craftsmanship](https://amzn.to/2CUBPgI)
* [Code Complete: A Practical Handbook of Software Construction (2nd Edition)](https://amzn.to/2G0H00r)