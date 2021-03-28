#if UNITY_EDITOR
using UnityEditor;

namespace TemplateUtil
{
    public static class ScriptTemplateUtility
    {
        private static readonly string TEMPLATE_PATH = "Assets/Plugins/TemplateUtil";

        [MenuItem(itemName: "Assets/Create/Classic Script/MonoBehaviour", isValidateFunction: false, priority: -100)]
        public static void CreateMonoBehaviourFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/MonoBehaviour.cs.txt", "NewMonoBehaviour.cs");
        }

        [MenuItem(itemName: "Assets/Create/Classic Script/MonoBehaviour Instance", isValidateFunction: false, priority: -100)]
        public static void CreateMonoBehaviourInstanceFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/MonoBehaviourInstance.cs.txt", "NewMonoBehaviourInstance.cs");
        }

        [MenuItem(itemName: "Assets/Create/Classic Script/Struct", isValidateFunction: false, priority: -100)]
        public static void CreateStructFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/Struct.cs.txt", "Struct.cs");
        }

        [MenuItem(itemName: "Assets/Create/Classic Script/Class", isValidateFunction: false, priority: -100)]
        public static void CreateClassFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/Class.cs.txt", "Class.cs");
        }

        [MenuItem(itemName: "Assets/Create/Classic Script/ScriptableObject", isValidateFunction: false, priority: -100)]
        public static void CreateScriptableObjectFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/ScriptableObject.cs.txt", "NewScriptableObject.cs");
        }

        [MenuItem(itemName: "Assets/Create/Classic Script/Editor", isValidateFunction: false, priority: -100)]
        public static void CreateEditorFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/Editor.cs.txt", "NewEditor.cs");
        }

        [MenuItem(itemName: "Assets/Create/DOTS Script/SystemBase", isValidateFunction: false, priority: -100)]
        public static void CreateSystemBaseFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/SystemBase.cs.txt", "NewSystemBase.cs");
        }

        [MenuItem(itemName: "Assets/Create/DOTS Script/IComponentData", isValidateFunction: false, priority: -100)]
        public static void CreateIComponentDataFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/IComponentData.cs.txt", "NewIComponentData.cs");
        }

        [MenuItem(itemName: "Assets/Create/DOTS Script/IConvertGameObjectToEntity", isValidateFunction: false, priority: -100)]
        public static void CreateIConvertGameObjectToEntityFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile($"{TEMPLATE_PATH}/IConvertGameObjectToEntity.cs.txt", "NewIConvertGameObjectToEntity.cs");
        }
    }
}
#endif