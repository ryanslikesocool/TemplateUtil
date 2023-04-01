# TemplateUtil
Easily customizable Unity script templates.\
![Sample Image](images~/sample.jpg)

## Installation

**Recommended Installation** (Unity Package Manager)
- "Add package from git URL..."
- `https://github.com/ryanslikesocool/TemplateUtil.git`

**Alternate Installation** (Not recommended)
- Get the latest [release](https://github.com/ryanslikesocool/TemplateUtil/releases)
- Open with the desired Unity project
- Import into Plugins

## Setup
- Once installed into a project, locate the package folder.  If TemplateUtil was installed via the Package Manager, this will be in `Packages/TemplateUtil/`.
- **If installed via the Package Manager**: Copy and paste one of the Template Database scriptable objects into the `Assets` folder.  This will allow you to prepare and generate the template menu.
- Once settings are configured to your liking, click the `Generate` button at the bottom of the scriptable object to generate the menu script.
- 🎉 Your templates are now ready to use! 🎉

## About Template Files
Templates are stored in `Assets/Plugins/TemplateUtil/Templates` as `<name>.<type>.txt` files.\
`<type>` should be replaced with the desired file extension.

## Modifying Pre-installed Templates
To modify a preinstalled template, modify the `.<type>.txt` file located in the template folder.  This should look about the same as a normal C# file.\
If TemplateUtil is installed via the Package Manager, duplicate the `.<type>.txt` file in the package cache and place it in `Assets/Plugins/TemplateUtil/Templates`.  The Package Manager verifies the integrity of packages every reload, so any changes will be overwritten if you edit the file in the package cache.  TemplateUtil will prioritize templates in the project's Plugins folder over ones from the package.

## Adding Custom Templates
To add a template, create a new file with the extension `.<type>.txt` in the template folder.\
If TemplateUtil is installed via the Package Manager, create the file inside `Assets/Plugins/TemplateUtil/Templates`.\
Add the text you'd like for the template.  Refer to [Dynamic Text](#dynamic-text) for information on automatically filling certain text.\
In the package directory, locate the `Template Util Database` asset to add template files and adjust settings.

## Template Database Settings
| Setting | Description |
| --- | --- |
| Base Priority | The base priority of the list.  The entire template list is offset within the larger Create menu by this amount.  `-50` or lower will put the template list at the top of the Create menu. |
||
| Defines ✨ | Preprocessors to filter templates.  The properties are the same as the ones in an assembly definition file. |
| ✨ / Name | The name of the package to filter, expressed in reverse DNS lookup form. (e.g. `com.unity.render-pipelines.universal`) |
| ✨ / Expression | A version expression.  (e.g. `10.2` would include anything greater than or equal to version `10.2` of a package) |
| ✨ / Define | The scripting define to use as a preprocessor.  (e.g. `UNITY_URP`) |
||
| Folders 📁 | Groups to categorize templates.  Items are kept in the order of the list. |
| 📁 / Path | The path that the templates should be under in the `Create` menu.  You can use forward slashes to create subfolders. |
| 📁 / Define | An optional preprocessor to use for the templates in the group.  For example, if you created a define for the Universal Render Pipeline with the define `UNITY_URP`, the menu would only be displayed if the URP package is installed. |
| 📁 / Templates | All of the template files to include under the menu path. |
||
| Generate | Generates the C# and assembly definition files to enable the menus.  These are placed in your project's `Assets/Plugins/` folder. |

## Dynamic Text
- `#SCRIPTNAME#`: The name of the file when created
- `#ROOTNAMESPACEBEGIN#` and `#ROOTNAMESPACEEND#`: Wrap around an object to fill with the current assembly's namespace, if there is one.
- `#NOTRIM#`: Disables automatically trimming whitespace