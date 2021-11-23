// TemplateUtilMenus.cs
// Generated on 2021-11-22 23:37:59
// Generated with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace TemplateUtil {
    internal static class TemplateUtilMenus {
		#region C# Script

        [MenuItem(itemName: "Assets/Create/C# Script/Class", isValidateFunction: false, priority: -100)]
        internal static void CreateClassFromTemplate() => Extensions.CreateAtPath("Templates/Class.cs.txt", "NewClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/PartialClass", isValidateFunction: false, priority: -100)]
        internal static void CreatePartialClassFromTemplate() => Extensions.CreateAtPath("Templates/PartialClass.cs.txt", "NewPartialClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/AbstractClass", isValidateFunction: false, priority: -100)]
        internal static void CreateAbstractClassFromTemplate() => Extensions.CreateAtPath("Templates/AbstractClass.cs.txt", "NewAbstractClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/ExtensionClass", isValidateFunction: false, priority: -100)]
        internal static void CreateExtensionClassFromTemplate() => Extensions.CreateAtPath("Templates/ExtensionClass.cs.txt", "NewExtensionClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/PartialExtensionClass", isValidateFunction: false, priority: -100)]
        internal static void CreatePartialExtensionClassFromTemplate() => Extensions.CreateAtPath("Templates/PartialExtensionClass.cs.txt", "NewPartialExtensionClass.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/Struct", isValidateFunction: false, priority: -100)]
        internal static void CreateStructFromTemplate() => Extensions.CreateAtPath("Templates/Struct.cs.txt", "NewStruct.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/Interface", isValidateFunction: false, priority: -100)]
        internal static void CreateInterfaceFromTemplate() => Extensions.CreateAtPath("Templates/Interface.cs.txt", "NewInterface.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/Enum", isValidateFunction: false, priority: -100)]
        internal static void CreateEnumFromTemplate() => Extensions.CreateAtPath("Templates/Enum.cs.txt", "NewEnum.cs", true);
        
        [MenuItem(itemName: "Assets/Create/C# Script/Attribute", isValidateFunction: false, priority: -100)]
        internal static void CreateAttributeFromTemplate() => Extensions.CreateAtPath("Templates/Attribute.cs.txt", "NewAttribute.cs", true);
        
		#endregion

		#region Unity Script

        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviour", isValidateFunction: false, priority: -99)]
        internal static void CreateMonoBehaviourFromTemplate() => Extensions.CreateAtPath("Templates/MonoBehaviour.cs.txt", "NewMonoBehaviour.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/PartialMonoBehaviour", isValidateFunction: false, priority: -99)]
        internal static void CreatePartialMonoBehaviourFromTemplate() => Extensions.CreateAtPath("Templates/PartialMonoBehaviour.cs.txt", "NewPartialMonoBehaviour.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/AbstractMonoBehaviour", isValidateFunction: false, priority: -99)]
        internal static void CreateAbstractMonoBehaviourFromTemplate() => Extensions.CreateAtPath("Templates/AbstractMonoBehaviour.cs.txt", "NewAbstractMonoBehaviour.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviourInstance", isValidateFunction: false, priority: -99)]
        internal static void CreateMonoBehaviourInstanceFromTemplate() => Extensions.CreateAtPath("Templates/MonoBehaviourInstance.cs.txt", "NewMonoBehaviourInstance.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/ScriptableObject", isValidateFunction: false, priority: -99)]
        internal static void CreateScriptableObjectFromTemplate() => Extensions.CreateAtPath("Templates/ScriptableObject.cs.txt", "NewScriptableObject.cs", true);
        
		#endregion

		#region Unity Script/Jobs
#if UNITY_JOBS

        [MenuItem(itemName: "Assets/Create/Unity Script/Jobs/Job", isValidateFunction: false, priority: -98)]
        internal static void CreateJobFromTemplate() => Extensions.CreateAtPath("Templates/Job.cs.txt", "NewJob.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/Jobs/ForJob", isValidateFunction: false, priority: -98)]
        internal static void CreateForJobFromTemplate() => Extensions.CreateAtPath("Templates/ForJob.cs.txt", "NewForJob.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/Jobs/ParallelForJob", isValidateFunction: false, priority: -98)]
        internal static void CreateParallelForJobFromTemplate() => Extensions.CreateAtPath("Templates/ParallelForJob.cs.txt", "NewParallelForJob.cs", true);
        
#endif
		#endregion

		#region Unity Script/Editor

        [MenuItem(itemName: "Assets/Create/Unity Script/Editor/Editor", isValidateFunction: false, priority: -97)]
        internal static void CreateEditorFromTemplate() => Extensions.CreateAtPath("Templates/Editor.cs.txt", "NewEditor.cs", true);
        
        [MenuItem(itemName: "Assets/Create/Unity Script/Editor/EditorWindow", isValidateFunction: false, priority: -97)]
        internal static void CreateEditorWindowFromTemplate() => Extensions.CreateAtPath("Templates/EditorWindow.cs.txt", "NewEditorWindow.cs", true);
        
		#endregion

		#region DOTS Script
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/AuthoringComponent", isValidateFunction: false, priority: -98)]
        internal static void CreateAuthoringComponentFromTemplate() => Extensions.CreateAtPath("Templates/AuthoringComponent.cs.txt", "NewAuthoringComponent.cs", true);
        
#endif
		#endregion

		#region DOTS Script/Component
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/Component", isValidateFunction: false, priority: -98)]
        internal static void CreateComponentFromTemplate() => Extensions.CreateAtPath("Templates/Component.cs.txt", "NewComponent.cs", true);
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/BufferElementComponent", isValidateFunction: false, priority: -98)]
        internal static void CreateBufferElementComponentFromTemplate() => Extensions.CreateAtPath("Templates/BufferElementComponent.cs.txt", "NewBufferElementComponent.cs", true);
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/Component/MaterialPropertyOverride", isValidateFunction: false, priority: -98)]
        internal static void CreateMaterialPropertyOverrideFromTemplate() => Extensions.CreateAtPath("Templates/MaterialPropertyOverride.cs.txt", "NewMaterialPropertyOverride.cs", true);
        
#endif
		#endregion

		#region DOTS Script/System
#if UNITY_DOTS

        [MenuItem(itemName: "Assets/Create/DOTS Script/System/System", isValidateFunction: false, priority: -98)]
        internal static void CreateSystemFromTemplate() => Extensions.CreateAtPath("Templates/System.cs.txt", "NewSystem.cs", true);
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/System/SystemGroup", isValidateFunction: false, priority: -98)]
        internal static void CreateSystemGroupFromTemplate() => Extensions.CreateAtPath("Templates/SystemGroup.cs.txt", "NewSystemGroup.cs", true);
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/System/ConversionSystem", isValidateFunction: false, priority: -98)]
        internal static void CreateConversionSystemFromTemplate() => Extensions.CreateAtPath("Templates/ConversionSystem.cs.txt", "NewConversionSystem.cs", true);
        
#endif
		#endregion

		#region URP Script
#if UNITY_URP

        [MenuItem(itemName: "Assets/Create/URP Script/RenderFeatureSettings", isValidateFunction: false, priority: -97)]
        internal static void CreateRenderFeatureSettingsFromTemplate() => Extensions.CreateAtPath("Templates/RenderFeatureSettings.cs.txt", "NewRenderFeatureSettings.cs", true);
        
        [MenuItem(itemName: "Assets/Create/URP Script/ScriptableRendererFeature", isValidateFunction: false, priority: -97)]
        internal static void CreateScriptableRendererFeatureFromTemplate() => Extensions.CreateAtPath("Templates/ScriptableRendererFeature.cs.txt", "NewScriptableRendererFeature.cs", true);
        
        [MenuItem(itemName: "Assets/Create/URP Script/ScriptableRenderPass", isValidateFunction: false, priority: -97)]
        internal static void CreateScriptableRenderPassFromTemplate() => Extensions.CreateAtPath("Templates/ScriptableRenderPass.cs.txt", "NewScriptableRenderPass.cs", true);
        
#endif
		#endregion

		#region Shader File/URP
#if UNITY_URP

        [MenuItem(itemName: "Assets/Create/Shader File/URP/URPUnlit", isValidateFunction: false, priority: -96)]
        internal static void CreateURPUnlitFromTemplate() => Extensions.CreateAtPath("Templates/URPUnlit.shader.txt", "NewURPUnlit.shader", false);
        
        [MenuItem(itemName: "Assets/Create/Shader File/URP/HLSLExtension", isValidateFunction: false, priority: -96)]
        internal static void CreateHLSLExtensionFromTemplate() => Extensions.CreateAtPath("Templates/HLSLExtension.hlsl.txt", "NewHLSLExtension.hlsl", false);
        
#endif
		#endregion

    }
}
#endif