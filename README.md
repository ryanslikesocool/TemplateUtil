# TemplateUtil
Easily customizable Unity script templates\
![Sample Image](images~/sample.jpg)

**RECOMMENDED INSTALLATION**
- Add via the Unity Package Manager
- "Add package from git URL..."
- `https://github.com/ryanslikesocool/TemplateUtil.git`
- Add

**Not-so Recommended Installation**
- Get the latest [release](https://github.com/ryanslikesocool/TemplateUtil/releases)
- Open with the desired Unity project
- Import into Plugins

## Prebuilt Templates
- C# Script
    - Class
    - AbstractClass
    - ExtensionClass
    - PartialExtensionClass
    - Struct
    - Interface
    - Enum
    - Attribute
- Unity Script
    - MonoBehaviour
    - MonoBehaviourInstance
    - AbstractMonoBehaviour
    - ScriptableObject
    - Editor
        - Editor
        - EditorWindow
    - Jobs
        - Job (IJob)
        - ForJob (IJobFor)
        - ParallelForJob (IJobParallelFor)
- DOTS Script
    - AuthoringComponent (IConvertGameObjectToEntity)
    - Component
        - Component (IComponentData)
        - BufferElementComponent (IBufferElementData)
        - MaterialPropertyOverride
    - System
        - System (SystemBase)
        - SystemGroup (ComponentSystemGroup)
        - ConversionSystem (GameObjectConversionSystem)
- URP Script
    - RenderFeatureSettings
    - ScriptableRenderFeature
    - ScriptableRenderPass
- Shader File
    - URP
        - URPUnlit
        - HLSLExtension

## Usage
When in the Project view in Unity, right click into the `Create` menu.\
Select one of the script templates at the top of the list to create a new script from the desired template.

## Modifying/Adding Templates
Templates are stored in `Assets/Plugins/TemplateUtil/Templates` as `.cs.txt` files.

**Modifying Templates**\
To modify a prebuilt template, modify the `.cs.txt` file located in the template folder.  This should look about the same as a normal C# file.\
If TemplateUtil is installed via the Package Manager, duplicate the `.cs.txt` file in the package cache and place it in `Assets/Plugins/TemplateUtil/Templates`.  The Package Manager verifies the integrity of packages every reload, so any changes will be overwritten if you edit the file in the package cache.  TemplateUtil will prioritize templates in the Plugins folder.

**Adding Templates**\
To add a template, create a new file with the extension `.cs.txt` in the template folder.\
If TemplateUtil is installed via the Package Manager, create the file inside `Assets/Plugins/TemplateUtil/Templates`, which should be empty otherwise.\
Add the C# code you'd like for the template.  Refer to **Dynamic Text** for information on automatically filling certain text.\
Open Window/TemplateUtil Manager.
- Folder: Groups to categorize templates.  Purely for organization in the editor
    - Menu Path: The path that the templates should be under in the right-click>Create menu
    - Preprocessor: Optional preprocessor to use for the templates (for example, `#if UNITY_EDITOR`)
    - Priority: The menu priority of the object.  -50 or lower will put the menu at the top of the list
    - Templates: All of the template text files to include under the menu path
- Generate: Generates the C# file to enable the menus.  This will overwrite the old file.

**Dynamic Text**\
- `#SCRIPTNAME#`: The name of the file when created
- `#ROOTNAMESPACEBEGIN#` and `#ROOTNAMESPACEEND#`: Wrapped around an object to automatically fill with the current scope's namespace.
