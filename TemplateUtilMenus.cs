// TemplateUtilMenus.cs
// Generated on 2021-07-26 02:29:29

#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace TemplateUtil
{
    public static class TemplateUtilMenus
    {
        private const string ASSETS_PATH = "Assets/Plugins/TemplateUtil";
        private const string PACKAGES_PATH = "Packages/com.ifelse.templateutil";
        
        private static void CreateAtPath(string path, string newName)
        {
            try
            {
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(Path.Combine(ASSETS_PATH, path), newName);
                return;
            }
            catch {}

            try
            {
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(Path.Combine(PACKAGES_PATH, path), newName);
                return;
            }
            catch  {}

            Debug.LogWarning("Template file could not be found.  Please ensure that the template file is in the correct directory.");
        }

        #region C# Script

        [MenuItem(itemName: "Assets/Create/C# Script/Class", isValidateFunction: false, priority: -100)]
        public static void CreateClassFromTemplate()
        {
            CreateAtPath($"Templates/Class.cs.txt", "NewClass.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/AbstractClass", isValidateFunction: false, priority: -100)]
        public static void CreateAbstractClassFromTemplate()
        {
            CreateAtPath($"Templates/AbstractClass.cs.txt", "NewAbstractClass.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/ExtensionClass", isValidateFunction: false, priority: -100)]
        public static void CreateExtensionClassFromTemplate()
        {
            CreateAtPath($"Templates/ExtensionClass.cs.txt", "NewExtensionClass.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/PartialExtensionClass", isValidateFunction: false, priority: -100)]
        public static void CreatePartialExtensionClassFromTemplate()
        {
            CreateAtPath($"Templates/PartialExtensionClass.cs.txt", "NewPartialExtensionClass.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/Struct", isValidateFunction: false, priority: -100)]
        public static void CreateStructFromTemplate()
        {
            CreateAtPath($"Templates/Struct.cs.txt", "NewStruct.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/Interface", isValidateFunction: false, priority: -100)]
        public static void CreateInterfaceFromTemplate()
        {
            CreateAtPath($"Templates/Interface.cs.txt", "NewInterface.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/Enum", isValidateFunction: false, priority: -100)]
        public static void CreateEnumFromTemplate()
        {
            CreateAtPath($"Templates/Enum.cs.txt", "NewEnum.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/Attribute", isValidateFunction: false, priority: -100)]
        public static void CreateAttributeFromTemplate()
        {
            CreateAtPath($"Templates/Attribute.cs.txt", "NewAttribute.cs");
        }
        
#endregion
#region Unity Script

        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourFromTemplate()
        {
            CreateAtPath($"Templates/MonoBehaviour.cs.txt", "NewMonoBehaviour.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/Unity Script/AbstractMonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreateAbstractMonoBehaviourFromTemplate()
        {
            CreateAtPath($"Templates/AbstractMonoBehaviour.cs.txt", "NewAbstractMonoBehaviour.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviourInstance", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourInstanceFromTemplate()
        {
            CreateAtPath($"Templates/MonoBehaviourInstance.cs.txt", "NewMonoBehaviourInstance.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/Unity Script/ScriptableObject", isValidateFunction: false, priority: -99)]
        public static void CreateScriptableObjectFromTemplate()
        {
            CreateAtPath($"Templates/ScriptableObject.cs.txt", "NewScriptableObject.cs");
        }
        
#endregion
#region Unity Script/Editor

        [MenuItem(itemName: "Assets/Create/Unity Script/Editor/Editor", isValidateFunction: false, priority: -98)]
        public static void CreateEditorFromTemplate()
        {
            CreateAtPath($"Templates/Editor.cs.txt", "NewEditor.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/Unity Script/Editor/EditorWindow", isValidateFunction: false, priority: -98)]
        public static void CreateEditorWindowFromTemplate()
        {
            CreateAtPath($"Templates/EditorWindow.cs.txt", "NewEditorWindow.cs");
        }
        
#endregion
#region DOTS Script
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/AuthoringComponent", isValidateFunction: false, priority: -98)]
        public static void CreateAuthoringComponentFromTemplate()
        {
            CreateAtPath($"Templates/AuthoringComponent.cs.txt", "NewAuthoringComponent.cs");
        }
        
#endif
#endregion
#region DOTS Script/Component
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/Component", isValidateFunction: false, priority: -98)]
        public static void CreateComponentFromTemplate()
        {
            CreateAtPath($"Templates/Component.cs.txt", "NewComponent.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/BufferElementComponent", isValidateFunction: false, priority: -98)]
        public static void CreateBufferElementComponentFromTemplate()
        {
            CreateAtPath($"Templates/BufferElementComponent.cs.txt", "NewBufferElementComponent.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/MaterialPropertyOverride", isValidateFunction: false, priority: -98)]
        public static void CreateMaterialPropertyOverrideFromTemplate()
        {
            CreateAtPath($"Templates/MaterialPropertyOverride.cs.txt", "NewMaterialPropertyOverride.cs");
        }
        
#endif
#endregion
#region DOTS Script/System
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/System/System", isValidateFunction: false, priority: -98)]
        public static void CreateSystemFromTemplate()
        {
            CreateAtPath($"Templates/System.cs.txt", "NewSystem.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/System/SystemGroup", isValidateFunction: false, priority: -98)]
        public static void CreateSystemGroupFromTemplate()
        {
            CreateAtPath($"Templates/SystemGroup.cs.txt", "NewSystemGroup.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/System/ConversionSystem", isValidateFunction: false, priority: -98)]
        public static void CreateConversionSystemFromTemplate()
        {
            CreateAtPath($"Templates/ConversionSystem.cs.txt", "NewConversionSystem.cs");
        }
        
#endif
#endregion
#region URP Script
#if UNITY_URP

        [MenuItem(itemName: "Assets/Create/URP Script/RenderFeatureSettings", isValidateFunction: false, priority: -97)]
        public static void CreateRenderFeatureSettingsFromTemplate()
        {
            CreateAtPath($"Templates/RenderFeatureSettings.cs.txt", "NewRenderFeatureSettings.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/URP Script/ScriptableRendererFeature", isValidateFunction: false, priority: -97)]
        public static void CreateScriptableRendererFeatureFromTemplate()
        {
            CreateAtPath($"Templates/ScriptableRendererFeature.cs.txt", "NewScriptableRendererFeature.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/URP Script/ScriptableRenderPass", isValidateFunction: false, priority: -97)]
        public static void CreateScriptableRenderPassFromTemplate()
        {
            CreateAtPath($"Templates/ScriptableRenderPass.cs.txt", "NewScriptableRenderPass.cs");
        }
        
#endif
#endregion
#region Shader File/URP
#if UNITY_URP

        [MenuItem(itemName: "Assets/Create/Shader File/URP/URPUnlit", isValidateFunction: false, priority: -96)]
        public static void CreateURPUnlitFromTemplate()
        {
            CreateAtPath($"Templates/URPUnlit.shader.txt", "NewURPUnlit.shader");
        }
        
        [MenuItem(itemName: "Assets/Create/Shader File/URP/HLSLExtension", isValidateFunction: false, priority: -96)]
        public static void CreateHLSLExtensionFromTemplate()
        {
            CreateAtPath($"Templates/HLSLExtension.hlsl.txt", "NewHLSLExtension.hlsl");
        }
        
#endif
#endregion
    }
}
#endif
        