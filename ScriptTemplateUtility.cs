#if UNITY_EDITOR
using UnityEditor;

namespace TemplateUtil
{
    public static class ScriptTemplateUtility
    {
        private const string CS_PATH = "Assets/Plugins/TemplateUtil/C# Script";
        private const string UNITY_PATH = "Assets/Plugins/TemplateUtil/Unity Script";
        private const string DOTS_PATH = "Assets/Plugins/TemplateUtil/DOTS Script";

        #region C# Script
        [MenuItem(itemName: "Assets/Create/C# Script/Struct", isValidateFunction: false, priority: -100)]
        public static void CreateStructFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{CS_PATH}/Struct.cs.txt", "NewStruct.cs");
        }

        [MenuItem(itemName: "Assets/Create/C# Script/Class", isValidateFunction: false, priority: -100)]
        public static void CreateClassFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{CS_PATH}/Class.cs.txt", "NewClass.cs");
        }

        [MenuItem(itemName: "Assets/Create/C# Script/Interface", isValidateFunction: false, priority: -100)]
        public static void CreateInterfaceFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{CS_PATH}/Interface.cs.txt", "NewInterface.cs");
        }

        [MenuItem(itemName: "Assets/Create/C# Script/Extension Class", isValidateFunction: false, priority: -100)]
        public static void CreateExtensionClassFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{CS_PATH}/ExtensionClass.cs.txt", "NewExtensionClass.cs");
        }
        #endregion

        #region Unity Script
        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{UNITY_PATH}/MonoBehaviour.cs.txt", "NewMonoBehaviour.cs");
        }

        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviour Instance", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourInstanceFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{UNITY_PATH}/MonoBehaviourInstance.cs.txt", "NewMonoBehaviourInstance.cs");
        }

        [MenuItem(itemName: "Assets/Create/Unity Script/ScriptableObject", isValidateFunction: false, priority: -99)]
        public static void CreateScriptableObjectFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{UNITY_PATH}/ScriptableObject.cs.txt", "NewScriptableObject.cs");
        }

        [MenuItem(itemName: "Assets/Create/Unity Script/Editor", isValidateFunction: false, priority: -99)]
        public static void CreateEditorFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{UNITY_PATH}/Editor.cs.txt", "NewEditor.cs");
        }
        #endregion

        #region DOTS Script
        [MenuItem(itemName: "Assets/Create/DOTS Script/SystemBase", isValidateFunction: false, priority: -98)]
        public static void CreateSystemBaseFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{DOTS_PATH}/SystemBase.cs.txt", "NewSystemBase.cs");
        }

        [MenuItem(itemName: "Assets/Create/DOTS Script/IComponentData", isValidateFunction: false, priority: -98)]
        public static void CreateIComponentDataFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{DOTS_PATH}/IComponentData.cs.txt", "NewIComponentData.cs");
        }

        [MenuItem(itemName: "Assets/Create/DOTS Script/IConvertGameObjectToEntity", isValidateFunction: false, priority: -98)]
        public static void CreateIConvertGameObjectToEntityFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{DOTS_PATH}/IConvertGameObjectToEntity.cs.txt", "NewIConvertGameObjectToEntity.cs");
        }
        #endregion
    }
}
#endif