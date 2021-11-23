// TemplateUtilMenus.cs
// Generated on 2021-10-22 07:46:32
// Generated with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace TemplateUtil
{
    public static class TemplateUtilMenus
    {
        private const string ASSETS_PATH = "Assets/Plugins/TemplateUtil";
        private const string PACKAGES_PATH = "Packages/com.ifelse.templateutil";
        
        private static void CreateAtPath(string path, string newName, bool autoNamespace)
        {
            string filePath;
            try
            {
                filePath = Path.Combine(ASSETS_PATH, path);
                Extensions.CreateScriptAssetFromTemplateFile(filePath, newName, autoNamespace);
                return;
            }
            catch (System.Exception error)
            {
                filePath = null;
                Debug.LogWarning($"Template file at path {path} could not be found.  Please ensure that the template file is in the correct directory.\n{error}");
            }

            try
            {
                filePath = Path.Combine(PACKAGES_PATH, path);
                Extensions.CreateScriptAssetFromTemplateFile(filePath, newName, autoNamespace);
                return;
            }
            catch (System.Exception error)
            {
                filePath = null;
                Debug.LogWarning($"Template file at path {path} could not be found.  Please ensure that the template file is in the correct directory.\n{error}");
            }
        }

        #region C# Script

        [MenuItem(itemName: "Assets/Create/C# Script/Class", isValidateFunction: false, priority: -100)]
        public static void CreateClassFromTemplate() => CreateAtPath("Templates/Class.cs.txt", "NewClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/PartialClass", isValidateFunction: false, priority: -100)]
        public static void CreatePartialClassFromTemplate() => CreateAtPath("Templates/PartialClass.cs.txt", "NewPartialClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/AbstractClass", isValidateFunction: false, priority: -100)]
        public static void CreateAbstractClassFromTemplate() => CreateAtPath("Templates/AbstractClass.cs.txt", "NewAbstractClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/ExtensionClass", isValidateFunction: false, priority: -100)]
        public static void CreateExtensionClassFromTemplate() => CreateAtPath("Templates/ExtensionClass.cs.txt", "NewExtensionClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/PartialExtensionClass", isValidateFunction: false, priority: -100)]
        public static void CreatePartialExtensionClassFromTemplate() => CreateAtPath("Templates/PartialExtensionClass.cs.txt", "NewPartialExtensionClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/Struct", isValidateFunction: false, priority: -100)]
        public static void CreateStructFromTemplate() => CreateAtPath("Templates/Struct.cs.txt", "NewStruct.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/Interface", isValidateFunction: false, priority: -100)]
        public static void CreateInterfaceFromTemplate() => CreateAtPath("Templates/Interface.cs.txt", "NewInterface.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/Enum", isValidateFunction: false, priority: -100)]
        public static void CreateEnumFromTemplate() => CreateAtPath("Templates/Enum.cs.txt", "NewEnum.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/Attribute", isValidateFunction: false, priority: -100)]
        public static void CreateAttributeFromTemplate() => CreateAtPath("Templates/Attribute.cs.txt", "NewAttribute.cs", true);
        
#endregion
#region Unity Script

        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourFromTemplate() => CreateAtPath("Templates/MonoBehaviour.cs.txt", "NewMonoBehaviour.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/PartialMonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreatePartialMonoBehaviourFromTemplate() => CreateAtPath("Templates/PartialMonoBehaviour.cs.txt", "NewPartialMonoBehaviour.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/AbstractMonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreateAbstractMonoBehaviourFromTemplate() => CreateAtPath("Templates/AbstractMonoBehaviour.cs.txt", "NewAbstractMonoBehaviour.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviourInstance", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourInstanceFromTemplate() => CreateAtPath("Templates/MonoBehaviourInstance.cs.txt", "NewMonoBehaviourInstance.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/ScriptableObject", isValidateFunction: false, priority: -99)]
        public static void CreateScriptableObjectFromTemplate() => CreateAtPath("Templates/ScriptableObject.cs.txt", "NewScriptableObject.cs", true);
        
#endregion
#region Unity Script/Jobs
#if UNITY_JOBS

        [MenuItem(itemName: "Assets/Create/Unity Script/Jobs/Job", isValidateFunction: false, priority: -98)]
        public static void CreateJobFromTemplate() => CreateAtPath("Templates/Job.cs.txt", "NewJob.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/Jobs/ForJob", isValidateFunction: false, priority: -98)]
        public static void CreateForJobFromTemplate() => CreateAtPath("Templates/ForJob.cs.txt", "NewForJob.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/Jobs/ParallelForJob", isValidateFunction: false, priority: -98)]
        public static void CreateParallelForJobFromTemplate() => CreateAtPath("Templates/ParallelForJob.cs.txt", "NewParallelForJob.cs", true);
        
#endif
#endregion
#region Unity Script/Editor

        [MenuItem(itemName: "Assets/Create/Unity Script/Editor/Editor", isValidateFunction: false, priority: -97)]
        public static void CreateEditorFromTemplate() => CreateAtPath("Templates/Editor.cs.txt", "NewEditor.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/Editor/EditorWindow", isValidateFunction: false, priority: -97)]
        public static void CreateEditorWindowFromTemplate() => CreateAtPath("Templates/EditorWindow.cs.txt", "NewEditorWindow.cs", true);
        
#endregion
#region DOTS Script
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/AuthoringComponent", isValidateFunction: false, priority: -98)]
        public static void CreateAuthoringComponentFromTemplate() => CreateAtPath("Templates/AuthoringComponent.cs.txt", "NewAuthoringComponent.cs", true);
        
#endif
#endregion
#region DOTS Script/Component
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/Component", isValidateFunction: false, priority: -98)]
        public static void CreateComponentFromTemplate() => CreateAtPath("Templates/Component.cs.txt", "NewComponent.cs", true);
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/BufferElementComponent", isValidateFunction: false, priority: -98)]
        public static void CreateBufferElementComponentFromTemplate() => CreateAtPath("Templates/BufferElementComponent.cs.txt", "NewBufferElementComponent.cs", true);
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/MaterialPropertyOverride", isValidateFunction: false, priority: -98)]
        public static void CreateMaterialPropertyOverrideFromTemplate() => CreateAtPath("Templates/MaterialPropertyOverride.cs.txt", "NewMaterialPropertyOverride.cs", true);
        
#endif
#endregion
#region DOTS Script/System
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/System/System", isValidateFunction: false, priority: -98)]
        public static void CreateSystemFromTemplate() => CreateAtPath("Templates/System.cs.txt", "NewSystem.cs", true);
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/System/SystemGroup", isValidateFunction: false, priority: -98)]
        public static void CreateSystemGroupFromTemplate() => CreateAtPath("Templates/SystemGroup.cs.txt", "NewSystemGroup.cs", true);
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/System/ConversionSystem", isValidateFunction: false, priority: -98)]
        public static void CreateConversionSystemFromTemplate() => CreateAtPath("Templates/ConversionSystem.cs.txt", "NewConversionSystem.cs", true);
        
#endif
#endregion
#region URP Script
#if UNITY_URP

        [MenuItem(itemName: "Assets/Create/URP Script/RenderFeatureSettings", isValidateFunction: false, priority: -97)]
        public static void CreateRenderFeatureSettingsFromTemplate() => CreateAtPath("Templates/RenderFeatureSettings.cs.txt", "NewRenderFeatureSettings.cs", true);
        
        [MenuItem(itemName: "Assets/Create/URP Script/ScriptableRendererFeature", isValidateFunction: false, priority: -97)]
        public static void CreateScriptableRendererFeatureFromTemplate() => CreateAtPath("Templates/ScriptableRendererFeature.cs.txt", "NewScriptableRendererFeature.cs", true);
        
        [MenuItem(itemName: "Assets/Create/URP Script/ScriptableRenderPass", isValidateFunction: false, priority: -97)]
        public static void CreateScriptableRenderPassFromTemplate() => CreateAtPath("Templates/ScriptableRenderPass.cs.txt", "NewScriptableRenderPass.cs", true);
        
#endif
#endregion
#region Shader File/URP
#if UNITY_URP

        [MenuItem(itemName: "Assets/Create/Shader File/URP/URPUnlit", isValidateFunction: false, priority: -96)]
        public static void CreateURPUnlitFromTemplate() => CreateAtPath("Templates/URPUnlit.shader.txt", "NewURPUnlit.shader", false);
        
        [MenuItem(itemName: "Assets/Create/Shader File/URP/HLSLExtension", isValidateFunction: false, priority: -96)]
        public static void CreateHLSLExtensionFromTemplate() => CreateAtPath("Templates/HLSLExtension.hlsl.txt", "NewHLSLExtension.hlsl", false);
        
#endif
#endregion
    }
}
#endif