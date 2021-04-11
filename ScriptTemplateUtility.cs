#if UNITY_EDITOR
using UnityEditor;
using System.IO;

namespace TemplateUtil
{
    public static class ScriptTemplateUtility
    {
        private const string ASSETS_PATH = "Assets/Plugins/TemplateUtil";
        private const string PACKAGES_PATH = "Packages/com.ifelse.templateutil";

        private const string CS_PATH = "{0}/C# Script";
        private const string UNITY_PATH = "{0}/Unity Script";
        private const string DOTS_PATH = "{0}/DOTS Script";

        private static void CreateAtPath(string path, string newName) {
            try
            {
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(string.Format(path, ASSETS_PATH), newName);
            }
            catch {}

            try
            {
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(string.Format(path, PACKAGES_PATH), newName);
            }
            catch {}
        }

#region C# Script
        [MenuItem(itemName: "Assets/Create/C# Script/Struct", isValidateFunction: false, priority: -100)]
        public static void CreateStructFromTemplate()
        {
            CreateAtPath($"{CS_PATH}/Struct.cs.txt", "NewStruct.cs");
        }

        [MenuItem(itemName: "Assets/Create/C# Script/Class", isValidateFunction: false, priority: -100)]
        public static void CreateClassFromTemplate()
        {
            CreateAtPath($"{CS_PATH}/Class.cs.txt", "NewClass.cs");
        }

        [MenuItem(itemName: "Assets/Create/C# Script/Interface", isValidateFunction: false, priority: -100)]
        public static void CreateInterfaceFromTemplate()
        {
            CreateAtPath($"{CS_PATH}/Interface.cs.txt", "NewInterface.cs");
        }

        [MenuItem(itemName: "Assets/Create/C# Script/Extension Class", isValidateFunction: false, priority: -100)]
        public static void CreateExtensionClassFromTemplate()
        {
            CreateAtPath($"{CS_PATH}/ExtensionClass.cs.txt", "NewExtensionClass.cs");
        }
#endregion

#region Unity Script
        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourFromTemplate()
        {
            CreateAtPath($"{UNITY_PATH}/MonoBehaviour.cs.txt", "NewMonoBehaviour.cs");
        }

        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviour Instance", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourInstanceFromTemplate()
        {
            CreateAtPath($"{UNITY_PATH}/MonoBehaviourInstance.cs.txt", "NewMonoBehaviourInstance.cs");
        }

        [MenuItem(itemName: "Assets/Create/Unity Script/ScriptableObject", isValidateFunction: false, priority: -99)]
        public static void CreateScriptableObjectFromTemplate()
        {
            CreateAtPath($"{UNITY_PATH}/ScriptableObject.cs.txt", "NewScriptableObject.cs");
        }

        [MenuItem(itemName: "Assets/Create/Unity Script/Editor", isValidateFunction: false, priority: -99)]
        public static void CreateEditorFromTemplate()
        {
            CreateAtPath($"{UNITY_PATH}/Editor.cs.txt", "NewEditor.cs");
        }
#endregion

#region DOTS Script
#if UNITY_ENTITIES
        [MenuItem(itemName: "Assets/Create/DOTS Script/SystemBase", isValidateFunction: false, priority: -98)]
        public static void CreateSystemBaseFromTemplate()
        {
            CreateAtPath($"{DOTS_PATH}/SystemBase.cs.txt", "NewSystemBase.cs");
        }

        [MenuItem(itemName: "Assets/Create/DOTS Script/IComponentData", isValidateFunction: false, priority: -98)]
        public static void CreateIComponentDataFromTemplate()
        {
            CreateAtPath($"{DOTS_PATH}/IComponentData.cs.txt", "NewIComponentData.cs");
        }

        [MenuItem(itemName: "Assets/Create/DOTS Script/MaterialPropertyOverride", isValidateFunction: false, priority: -98)]
        public static void CreateMaterialPropertyOverrideComponentFromTemplate()
        {
            CreateAtPath($"{DOTS_PATH}/MaterialPropertyOverrideComponent.cs.txt", "NewMaterialPropertyOverrideComponent.cs");
        }

        [MenuItem(itemName: "Assets/Create/DOTS Script/IConvertGameObjectToEntity", isValidateFunction: false, priority: -98)]
        public static void CreateIConvertGameObjectToEntityFromTemplate()
        {
            CreateAtPath($"{DOTS_PATH}/IConvertGameObjectToEntity.cs.txt", "NewIConvertGameObjectToEntity.cs");
        }
#endif
#endregion
    }
}
#endif
