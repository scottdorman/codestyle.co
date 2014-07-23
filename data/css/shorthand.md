Strive to limit use of shorthand declarations to instances where you must explicitly set all the available values. Common overused shorthand properties include:


- ``padding``
- ``margin``
- ``font``
- ``background``
- ``border``
- ``border-radius``

Often times we don't need to set all the values a shorthand property represents. For example, HTML headings only set top and bottom margin, so when necessary, only override those two values. Excessive use of shorthand properties often leads to sloppier code with unnecessary overrides and unintended side effects.