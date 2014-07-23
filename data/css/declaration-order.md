Related property declarations should be grouped together following the order:

1. Positioning
2. Box model
3. Typographic
4. Visual

Positioning comes first because it can remove an element from the normal flow of the document and override box model related styles. The box model comes next as it dictates a component's dimensions and placement.

Everything else takes place *inside* the component or without impacting the previous two sections, and thus they come last.