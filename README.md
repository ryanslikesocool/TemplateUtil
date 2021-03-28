# TemplateUtil
Easily customizable Unity script templates

## Prebuilt Templates
- Classic Script
    - MonoBehaviour
    - MonoBehaviour Instance
    - Struct
    - Class
    - Scriptable Object
    - Editor
- DOTS Script
    - SystemBase
    - IComponentData
    - IConvertGameObjectToEntity

## Installation
- Get the latest [release](https://github.com/ryanslikesocool/TemplateUtil/releases)
- Open with the desired Unity project
- Import into Plugins

## Usage
When in the Project view in Unity, right click into the `Create` menu.\
Select one of the script templates at the top of the list to create a new script from the desired template.

## Modifying/Adding Templates
Templates are stored in `Assets/Plugins/TemplateUtil` as `.cs.txt` files.

**Modifying Templates**\
To modify a prebuilt template, modify the text file located in the template folder.\
They should look about the same as a normal C# file

**Adding Templates**\
To add a template, create a new file with the extension `.cs.txt` in the template folder.\
Add the C# code you'd like for the template.  Refer to **Dynamic Text** for information on automatically filling certain text.\
In `ScriptTemplateUtility.cs`, add a new method like the one below, replacing `MyCustomScript` with the template file name.
```cs
[MenuItem(itemName: "Assets/Create/Folder/MyCustomScript", isValidateFunction: false, priority: -100)]
public static void CreateMyCustomScriptFromTemplate()
{
    ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/MyCustomScript.cs.txt", "NewMyCustomScript.cs");
}
```

**Dynamic Text**\
`#SCRIPTNAME#` - The name of the file when created\
`#ROOTNAMESPACEBEGIN#` and `#ROOTNAMESPACEEND#` - Wrapped around an object to automatically fill with the current scope's namespace.

## Credtis
[This wonderful post](https://forum.unity.com/threads/how-to-create-your-own-c-script-template.459977/#post-5365599) on the Unity forums
