## Capitalization

There are two ways to capitalize identifiers:

- **PascalCasing** capitalizes the first character of each word, including acronyms. A special case is made for two-letter acronyms, in which both letters are capitalized.
- **camelCasing** capitalizes the first character of each word except the first word. Two-letter acronyms that begin a camel-cased identifier are both lowercase.

In general, PascalCasing should be used for all identifiers exept parameter names, which should use camelCasing. The following table shows the capitalization rules for different types of identifiers.

<table class="table table-condensed">
	<thead>
		<tr>
			<th>Identifier</th>
			<th>Casing</th>
		</tr>
	</thead>
	<tbody>
	    <tr>
	      <td>
	        Namespace
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Type
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Interface
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Method
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Property
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Event
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Field
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Enum
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Enum value
	      </td>
	      <td>
	        Pascal
	      </td>
	    </tr>
	    <tr>
	      <td>
	        Parameter
	      </td>
	      <td>
	        Camel
	      </td>
	    </tr>
	  </tbody>
</table>

- When a compound word is written as a single word (known as closed form), such as endpoint, don't capitalize each word. Instead, you should treat them as a single word. You can use a current dictionary to help decide if a compound word is written in closed form.

## Avoid Language-Specific Names

- Using semantically interesting and meaningful names rather than language-specific keywords. If an identifier has no semantic meaning beyond its type, use a generic CLR type name rather than a language-specific one. This not only helps convey meaning, but is usually easier to read as well. For example, `GetLength` is a better name than `GetInt`.
- When an identifier has no semantic meaning and the type is not important, use a common name, such as *value* or *item* rather than repeating the type name.

## Naming New Versions of Existing APIs

- To help highlight the relationship between the APIs, use a name that is similar to the old API when creating a new version. You should consider using a brand new, but meaningful, name instead of adding a suffix or a prefix. If there isn't a meaningful new name that can be used, adding a suffix is better than adding a prefix to make the new API more discoverable. Since Intellisense and most documentation show identifiers in alphabetical order, this will show the new API near the old one. Add a numeric suffix only if a meaningful suffix (or changing the name) isn't appropriate, such as when the name is an industry standard name). However, don't use an "Ex" (or a similar) suffix to distinguish it from an existing API.
- Use the "64" suffix when introducing versions of APIs that operate on a 64-bit integer (a long integer) instead of a 32-bit integer. You only need to take this approach when the existing 32-bit API exists; don’t do it for brand new APIs with only a 64-bit version.

## Namespaces

- Namespaces should follow the general pattern of `<Company>.(<Product>|<Technology>)[.<Feature>][.<Subnamespace>]`. They should always start with a company name to help prevent name collisions. The second level of the namespace should be a stable version-independent product or technology name. The remaining two levels are optional.
- Namespaces should be organized around groups of related technology and not company organizational hierarchies.
- Don't use the same name for a namespace and a type in that namespace. Doing so creates problems both for the compiler and the developer and requires that the type always be fully qualified.

## Class, Struct, Enumeration, and Interface Names

- To distinguish classes and structs from methods, use nouns or noun phrases with PascalCasing. Intefaces should use adjective phrases. If a noun or noun phrase seems like the better name for an interface, it's likely that the interface should really be an abstract class instead.
- While interfaces start with an "I" prefix, classes should not start with a "C" prefix. When defining a class-interface pair, where the class is a standard implementation of the interface, make sure that the names differ only by the "I" prefix of the interface.
- When creating a derived class, using the name of the base class as an ending suffix can help with readability and helps to clearly explain the class relationship. However, use reasonable judgement as it isn't always better.
- Enumerations (also called enums) should follow all of the same naming rules as classes and structs, but should always be singular unless the values are bit fields (also called a flags enum), in which case the name should be pluaral.
- Don't end an enumeration name with an "Enum", "Flag", or "Flags" suffix and don't use a prefix on the value names.
- Generic type parameters should be descriptive and always start with a "T" prefix. If there is only a single type parameter, unless a single-letter name is completely self-explanatory and a descriptive name would not add value. However, if there is only a single type parameter, you can use "T" as the name.

## Common Names for Derived Types

- When deriving from certain .NET Framework types or implementing certain .NET Framework interfaces, follow these guidelines:

    - `System.Attribute` - Add the suffix "Attribute."
    - `System.Delegate` - Add the suffix "EventHandler" to names of delegates that are used in events and the suffix "Callback" to any other delegates. Don't add the suffix "Delegate."
    - `System.EventArgs` - Add the suffix "EventArgs."
    - `System.Enum` - Don't derive directly from this class; instead use the language keyword. Don't add an "Enum" or "Flag" suffix.
    - `System.Exception` - Add the suffix "Exception."
    - `IDictionary`, `IDictionary<TKey, TValue>` - Add the suffix "Dictionary."
    - `IEnumerable`, `ICollection`, `IList`, `IEnumerable<T>`, `ICollection<T>`, `IList<T>` - Add the suffix "Collection."
    - `System.IO.Stream` - Add the suffix "Stream."
    - `CodeAccessPermission`, `IPermission` - Add the suffix "Permission."

## Method, Property and Field Names

- Methods represent taking an action, so method names should be verbs or verb phrases. Properties and fields refer to data, so property names should be nouns, noun phrases, or adjectives.
- Properties which represent collections should be a plural phrase describing the items in the collection.
- Properties which represent Boolean data should use an affirmative phrase. You can also prefix these properties with "Is", "Can", or "Has" if doing so adds value.
- Properties shouldn't match the name of "Get" methods.
- Fields should not use a prefix, like "g\_", "s\_", or "\_".

## Event Names

- Events refer to some action that is happening or has happened, so event names should be a verb or verb phrase. Use verb tense to indicate the time when the event is raised. This also means that you shouldn't use "Before" or "After" prefixes or postfixes to indicate pre- and post-events.
- For consistency, event handlers should always end with the "EventHandler" suffix and should always use two parameters named `sender` and `e`.

## Parameter Names

- Parameter names should always be descriptive and whenever possible be based on the parameter's meaning instead of it's type.
- For operator overload parameters, follow these additional guidelines:

    - Use `left` and `right` for binary operator overload parameters and `value` for unary operator overload parameters unless more meaningful names would add significant value.
    - Don't use abbreviations or numeric indices.

## Resource Names

Localized resources can be referenced as if they were properties, so their naming should be similar to those of actual properties. These additional guidelines should also be followed:

- Use descriptive rather than short identifiers and use only alphanumeric characters and underscores.
- Exception message resources should be prefixed with the exception type name.

## Assembly and DLL names

Using a name that represents the large chunks of functionality, such as `System.Data`, helps in discoverability.