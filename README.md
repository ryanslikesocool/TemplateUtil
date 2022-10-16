# TemplateUtil
Easily customizable Unity script templates\
![Sample Image](images~/sample.jpg)

**Recommended Installation** (Unity Package Manager)
- "Add package from git URL..."
- `https://github.com/ryanslikesocool/TemplateUtil.git`

**Alternate Installation**
- Get the latest [release](https://github.com/ryanslikesocool/TemplateUtil/releases)
- Open with the desired Unity project
- Import into Plugins

## Preinstalled Templates
- C# Script/
    - Class
    - PartialClass
    - AbstractClass
    - ExtensionClass
    - PartialExtensionClass
    - SingletonClass
    - Struct
    - Interface
    - Enum
    - Attribute
- Unity Script/
    - MonoBehaviour
    - PartialMonoBehaviour
    - AbstractMonoBehaviour
    - MonoBehaviourInstance
    - ScriptableObject
    - Editor/
        - Editor
        - EditorWindow
    - Jobs/
        - Job (IJob)
        - ForJob (IJobFor)
        - ParallelForJob (IJobParallelFor)
    - Universal Render Pipeline/
        - RenderFeatureSettings
        - ScriptableRenderFeature
        - ScriptableRenderPass
- DOTS Script/
    - AuthoringComponent (IConvertGameObjectToEntity)
    - Component/
        - Component (IComponentData)
        - BufferElementComponent (IBufferElementData)
        - MaterialPropertyOverride
    - System/
        - System (SystemBase)
        - SystemGroup (ComponentSystemGroup)
        - ConversionSystem (GameObjectConversionSystem)
- Shader File/
    - HLSLExtension
    - URP/
        - URPUnlit
- Miscellaneous/
    - PlainText
    - JSON
    - Markdown

## Usage
When in the Project view in Unity, right click into the `Create` menu.\
Select one of the script templates at the top of the list to create a new script from the desired template.

## Modifying/Adding Templates
Templates are stored in `Assets/Plugins/TemplateUtil/Templates` as `.{type}.txt` files.\
`{type}` can be replaced with the desired result file extension.

**Modifying Templates**\
To modify a preinstalled template, modify the `.{type}.txt` file located in the template folder.  This should look about the same as a normal C# file.\
If TemplateUtil is installed via the Package Manager, duplicate the `.{type}.txt` file in the package cache and place it in `Assets/Plugins/TemplateUtil/Templates`.  The Package Manager verifies the integrity of packages every reload, so any changes will be overwritten if you edit the file in the package cache.  TemplateUtil will prioritize templates in the Plugins folder.

**Adding Templates**\
To add a template, create a new file with the extension `.{type}.txt` in the template folder.\
If TemplateUtil is installed via the Package Manager, create the file inside `Assets/Plugins/TemplateUtil/Templates`, which should be empty otherwise.\
Add the C# code you'd like for the template.  Refer to **Dynamic Text** for information on automatically filling certain text.\
In the package directory, locate the `Template Util Database` ScriptableObject to add template files.
- Folder: Groups to categorize templates.  Purely for organization in the editor
    - Menu Path: The path that the templates should be under in the right-click>Create menu
    - Preprocessor: Optional preprocessor to use for the templates (for example, `UNITY_URP` will only show the menu if the URP package is installed).  This string is inserted directly into the C# script, so using `&&` or `||` to combine preprocessors will work as expected.
    - Priority: The menu priority of the object.  -50 or lower will put the menu at the top of the Create menu.
    - Templates: All of the template files to include under the menu path.
- Generate: Generates the C# file to enable the menus.  This will overwrite the old file.

**Dynamic Text**\
- `#SCRIPTNAME#`: The name of the file when created
- `#ROOTNAMESPACEBEGIN#` and `#ROOTNAMESPACEEND#`: Wrapped around an object to automatically fill with the current assembly's namespace, if there is one.
- `#NOTRIM#`: Disables automatically trimming whitespace
