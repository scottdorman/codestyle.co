## Capitalization

- Use PascalCasing for all public member, type, and namespace names consisting of multiple words.
- Use camelCasing for parameter names.

<table class="table">
                <tbody><tr>
                  <th>
                    <p>Identifier</p>
                  </th>
                  <th>
                    <p>Casing</p>
                  </th>
                  <th>
                    <p>Example</p>
                  </th>
                </tr>
                <tr>
                  <td>
                    <p>Namespace</p>
                  </td>
                  <td>
                    <p>Pascal</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">namespace System.Security&nbsp;{ ... }</span>
                    </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>Type</p>
                  </td>
                  <td>
                    <p>Pascal</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">public class StreamReader { ... }</span>
                    </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>Interface</p>
                  </td>
                  <td>
                    <p>Pascal</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">public interface IEnumerable { ... }</span>
                    </p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>Method</p>
                  </td>
                  <td>
                    <p>Pascal</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">public class Object {</span>
                      <br> <span class="code">   public virtual string ToString();</span><br> <span class="code">}</span></p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>Property</p>
                  </td>
                  <td>
                    <p>Pascal</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">public class String {</span>
                      <br> <span class="code">   public int Length { get; }</span><br> <span class="code">}</span></p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>Event</p>
                  </td>
                  <td>
                    <p>Pascal</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">public class Process {</span>
                      <br> <span class="code">   public event EventHandler Exited;</span><br> <span class="code">}</span></p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>Field</p>
                  </td>
                  <td>
                    <p>Pascal</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">public class MessageQueue {</span>
                      <br> <span class="code">   public static readonly TimeSpan</span><br> <span class="code">InfiniteTimeout;</span><br> <span class="code">}</span><br> <span class="code">public struct UInt32 {</span><br> <span class="code">   public const Min = 0;</span><br> <span class="code">}</span></p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>Enum value</p>
                  </td>
                  <td>
                    <p>Pascal</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">public enum FileMode {</span>
                      <br> <span class="code">   Append,</span><br> <span class="code">   ...</span><br> <span class="code">}</span></p>
                  </td>
                </tr>
                <tr>
                  <td>
                    <p>Parameter</p>
                  </td>
                  <td>
                    <p>Camel</p>
                  </td>
                  <td>
                    <p>
                      <span class="code">public class Convert {</span>
                      <br> <span class="code">   public static int ToInt32(string value);</span><br> <span class="code">}</span></p>
                  </td>
                </tr>
              </tbody></table>

- Don't capitalize each word in closed-form compound words. These are compound words written as a single word, such as endpoint. Treat a closed-form word as a single word. Use a current dictionary to determine if a compound word is written in closed form.

## Avoid Language-Specific Names

- Use semantically interesting names rather than language-specific keywords for type names. For example, `GetLength` is a better name than `GetInt`.
- In cases when an identifier has no semantic meaning beyond its type, use a generic CLR type name, rather than a language-specific name.
- Use a common name, such as *value* or *item*, rather than repeating the tpe name when an identifier has no semantic meaning and the type of the parameter is not important.

## Naming New Versions of Existing APIs

- Use a name similar to the old API when creating new versions of an existing API. This helps to highlight the relationship between the APIs.
- Prefer adding a suffix rather than a prefix to indicate a new version of an existing API. This will assist discovery when browsing documentation, or using Intellisense. The old version of the API will be organized close to the new APIs, because most browsers and Intellisense show identifiers in alphabetical order.
- Consider using a brand new, but meaningful identifier, instead of adding a suffix or a prefix.
- Use a numeric suffix to indicate a new version of an existing API, particularly if the existing name of the API is the only name that makes sense (i.e., if it is an industry standard) and if adding any meaningful suffix (or changing the name) is not an appropriate option.
- Don't use the "Ex" (or a similar) suffix for an identifier to distinguish it from an earlier version of the same API.
- Use the "64" suffix when introducing versions of APIs that operate on a 64-bit integer (a long integer) instead of a 32-bit integer. You only need to take this approach when the existing 32-bit API exists; don’t do it for brand new APIs with only a 64-bit version.
