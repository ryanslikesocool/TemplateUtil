// Developed with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace TemplateUtil
{
    public class TemplateUtilWindow : EditorWindow
    {
        private const string ASSETS_PATH = "Assets/Plugins/TemplateUtil";
        private const string PACKAGES_PATH = "Packages/com.ifelse.templateutil";

        private const string UTIL_FILE = "TemplateUtilMenus.cs";

        private const string UTIL_CLASS = @"// {0}
// Generated on {1}
// Generated with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace TemplateUtil
{{
    public static class TemplateUtilMenus
    {{
        private const string ASSETS_PATH = ""Assets/Plugins/TemplateUtil"";
        private const string PACKAGES_PATH = ""Packages/com.ifelse.templateutil"";
        
        private static void CreateAtPath(string path, string newName)
        {{
            try
            {{
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(Path.Combine(ASSETS_PATH, path), newName);
                return;
            }}
            catch {{}}

            try
            {{
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(Path.Combine(PACKAGES_PATH, path), newName);
                return;
            }}
            catch  {{}}

            Debug.LogWarning(""Template file could not be found.  Please ensure that the template file is in the correct directory."");
        }}

        {2}
    }}
}}
#endif
        ";
        // 0 = file name
        // 1 = date and time generated
        // 2 = util methods

        private const string UTIL_METHOD = @"
        [MenuItem(itemName: ""Assets/Create/{0}"", isValidateFunction: false, priority: {2})]
        public static void Create{3}FromTemplate()
        {{
            CreateAtPath(""Templates/{3}.{1}.txt"", ""New{3}.{1}"");
        }}
        ";
        // 0 = menu path
        // 1 = priority (less than -50 is best!)
        // 2 = template file name with no extension

        private const string PREPROCESSOR_START = "#if";
        private const string PREPROCESSOR_END = "#endif";

        private const string REGION_START = "#region";
        private const string REGION_END = "#endregion";

        private Vector2 scrollPos = Vector2.zero;

        private TemplateUtilDatabase database = null;
        private SerializedObject scriptableObject = null;
        private SerializedProperty folderProp = null;

        public TemplateUtilDatabase.TemplateFolder[] folders
        {
            get => database.folders;
            set
            {
                if (database != null)
                {
                    database.folders = value;
                }
            }
        }

        [MenuItem("Tools/ifelse/TemplateUtil Manager")]
        private static void Init()
        {
            TemplateUtilWindow window = (TemplateUtilWindow)EditorWindow.GetWindow(typeof(TemplateUtilWindow));
            window.Show();
            window.titleContent = new GUIContent("Template Util");
        }

        private void OnGUI()
        {
            if (database == null)
            {
                database = (TemplateUtilDatabase)EditorGUILayout.ObjectField(database, typeof(TemplateUtilDatabase), false);
            }
            else
            {
                if (scriptableObject == null || folderProp == null)
                {
                    scriptableObject = new SerializedObject(database);
                    folderProp = scriptableObject.FindProperty("folders");
                }

                scriptableObject.Update();

                scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
                EditorGUILayout.PropertyField(folderProp, true);
                EditorGUILayout.EndScrollView();

                if (GUILayout.Button($"Generate {UTIL_FILE}"))
                {
                    RegenerateTemplateUtilFile();
                }

                scriptableObject.ApplyModifiedProperties();
            }
        }

        private void RegenerateTemplateUtilFile()
        {
            string[] folderText = new string[folders.Length];

            for (int i = 0; i < folders.Length; i++)
            {
                string menuPath = folders[i].menuPath;
                string preprocessor = folders[i].preprocessor;
                int priority = folders[i].priority;
                TextAsset[] templateFiles = folders[i].templateFiles;

                string[] methodArray = new string[templateFiles.Length];
                for (int j = 0; j < methodArray.Length; j++)
                {
                    string filePath = AssetDatabase.GetAssetPath(templateFiles[j]);
                    string[] components = filePath.Split('/');
                    string[] finalComponents = components[components.Length - 1].Split('.');

                    if (finalComponents.Length == 3 && finalComponents[finalComponents.Length - 1] == "txt")
                    {
                        string realExtension = finalComponents[1];
                        string filePrefix = finalComponents[0];
                        methodArray[j] = string.Format(UTIL_METHOD, $"{menuPath}/{filePrefix}", realExtension, priority, filePrefix);
                    }
                }
                string methods = string.Join(string.Empty, methodArray);

                folderText[i] = string.Join(string.Empty, methods);
                if (preprocessor != string.Empty)
                {
                    folderText[i] = $"{PREPROCESSOR_START} {preprocessor}\n{folderText[i]}\n{PREPROCESSOR_END}";
                }
                folderText[i] = $"{REGION_START} {menuPath}\n{folderText[i]}\n{REGION_END}";
            }

            string allMethods = string.Join("\n", folderText);

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string fileText = string.Format(UTIL_CLASS, UTIL_FILE, dateTime, allMethods);

            string dataPath = Application.dataPath.Replace("Assets", string.Empty);
            bool isPackage = File.Exists(Path.Combine(dataPath, PACKAGES_PATH));
            dataPath = Path.Combine(dataPath, isPackage ? PACKAGES_PATH : ASSETS_PATH);

            if (!File.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }

            string path = Path.Combine(dataPath, UTIL_FILE);
            File.WriteAllText(path, fileText);

            string importPath = Path.Combine(isPackage ? PACKAGES_PATH : ASSETS_PATH, UTIL_FILE);
            AssetDatabase.ImportAsset(importPath, ImportAssetOptions.ForceUpdate);

            Debug.Log($"Generated {UTIL_FILE} at {dateTime}.  Reloading asset database...");
        }
    }
}
#endif