
// TemplateUtilMenus.cs
// Generated on 2021-04-12 05:23:41

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

        #region Unity Script

        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourFromTemplate()
        {
            CreateAtPath($"Templates/MonoBehaviour.cs.txt", "NewMonoBehaviour.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/Unity Script/MonoBehaviourInstance", isValidateFunction: false, priority: -99)]
        public static void CreateMonoBehaviourInstanceFromTemplate()
        {
            CreateAtPath($"Templates/MonoBehaviourInstance.cs.txt", "NewMonoBehaviourInstance.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/Unity Script/AbstractMonoBehaviour", isValidateFunction: false, priority: -99)]
        public static void CreateAbstractMonoBehaviourFromTemplate()
        {
            CreateAtPath($"Templates/AbstractMonoBehaviour.cs.txt", "NewAbstractMonoBehaviour.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/Unity Script/ScriptableObject", isValidateFunction: false, priority: -99)]
        public static void CreateScriptableObjectFromTemplate()
        {
            CreateAtPath($"Templates/ScriptableObject.cs.txt", "NewScriptableObject.cs");
        }
        
#endregion
#region Unity Script/Editors

        [MenuItem(itemName: "Assets/Create/Unity Script/Editors/Editor", isValidateFunction: false, priority: -99)]
        public static void CreateEditorFromTemplate()
        {
            CreateAtPath($"Templates/Editor.cs.txt", "NewEditor.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/Unity Script/Editors/EditorWindow", isValidateFunction: false, priority: -99)]
        public static void CreateEditorWindowFromTemplate()
        {
            CreateAtPath($"Templates/EditorWindow.cs.txt", "NewEditorWindow.cs");
        }
        
#endregion
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
        
        [MenuItem(itemName: "Assets/Create/C# Script/Struct", isValidateFunction: false, priority: -100)]
        public static void CreateStructFromTemplate()
        {
            CreateAtPath($"Templates/Struct.cs.txt", "NewStruct.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/Enum", isValidateFunction: false, priority: -100)]
        public static void CreateEnumFromTemplate()
        {
            CreateAtPath($"Templates/Enum.cs.txt", "NewEnum.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/C# Script/Interface", isValidateFunction: false, priority: -100)]
        public static void CreateInterfaceFromTemplate()
        {
            CreateAtPath($"Templates/Interface.cs.txt", "NewInterface.cs");
        }
        
#endregion
#region DOTS Script
#if UNITY_ENTITIES

        [MenuItem(itemName: "Assets/Create/DOTS Script/IComponentData", isValidateFunction: false, priority: -98)]
        public static void CreateIComponentDataFromTemplate()
        {
            CreateAtPath($"Templates/IComponentData.cs.txt", "NewIComponentData.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/MaterialPropertyOverrideComponent", isValidateFunction: false, priority: -98)]
        public static void CreateMaterialPropertyOverrideComponentFromTemplate()
        {
            CreateAtPath($"Templates/MaterialPropertyOverrideComponent.cs.txt", "NewMaterialPropertyOverrideComponent.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/IConvertGameObjectToEntity", isValidateFunction: false, priority: -98)]
        public static void CreateIConvertGameObjectToEntityFromTemplate()
        {
            CreateAtPath($"Templates/IConvertGameObjectToEntity.cs.txt", "NewIConvertGameObjectToEntity.cs");
        }
        
        [MenuItem(itemName: "Assets/Create/DOTS Script/SystemBase", isValidateFunction: false, priority: -98)]
        public static void CreateSystemBaseFromTemplate()
        {
            CreateAtPath($"Templates/SystemBase.cs.txt", "NewSystemBase.cs");
        }
        
#endif
#endregion
    }
}
#endif
        