// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace TemplateUtil {
    internal static class MenuBuilder {
        private const string UTIL_CLASS =
@"// {0}
// Generated on {1}
// Generated With Love by Ryan Boyer http://ryanjboyer.com <3

using UnityEditor;

namespace TemplateUtil {{
    internal static class TemplateMenus {{
        {2}
    }}
}}";
        // 0 = file name
        // 1 = date and time generated
        // 2 = util methods

        private const string UTIL_METHOD =
@"
        [MenuItem(itemName: ""Assets/Create/{0}"", isValidateFunction: false, priority: {2})]
        public static void Create{3}FromTemplate() => MenuUtilities.CreateAtPath(""Templates/{3}.{1}.txt"", ""New{3}.{1}"");
";
        // 0 = menu path
        // 1 = priority (less than -50 is best!)
        // 2 = template file name with no extension

        private const string PREPROCESSOR_START = "#if";
        private const string PREPROCESSOR_END = "#endif";

        private const string REGION_START = "#region";
        private const string REGION_END = "#endregion";

        public static void RebuildScript(in TemplateDatabase database) {
            (string fileText, string dateTime) = CreateText(database);
            WriteText(database.defines, fileText, dateTime);
            Debug.Log($"Generated {FileUtilities.UTIL_FILE_NAME} at {dateTime}.  Reloading scripts...");
        }

        private static (string, string) CreateText(in TemplateDatabase database) {
            TemplateFolder[] folders = database.folders;

            string[] folderText = new string[folders.Length];

            for (int i = 0; i < folders.Length; i++) {
                string menuPath = folders[i].menuPath;
                string preprocessor = folders[i].preprocessor;
                int priority = database.basePriority - (folders.Length - i);
                TextAsset[] templateFiles = folders[i].templateFiles;

                string[] methodArray = new string[templateFiles.Length];
                for (int j = 0; j < methodArray.Length; j++) {
                    string filePath = AssetDatabase.GetAssetPath(templateFiles[j]);
                    string[] components = filePath.Split('/');
                    string[] finalComponents = components[components.Length - 1].Split('.');

                    if (finalComponents.Length == 3 && finalComponents[finalComponents.Length - 1] == "txt") {
                        string realExtension = finalComponents[1];
                        string filePrefix = finalComponents[0];
                        methodArray[j] = string.Format(UTIL_METHOD, $"{menuPath}/{filePrefix}", realExtension, priority, filePrefix);
                    }
                }
                string methods = string.Join(string.Empty, methodArray);

                folderText[i] = string.Join(string.Empty, methods);
                if (preprocessor != string.Empty) {
                    folderText[i] = $"{PREPROCESSOR_START} {preprocessor}\n{folderText[i]}\n{PREPROCESSOR_END}";
                }
                folderText[i] = $"{REGION_START} {menuPath}\n{folderText[i]}\n{REGION_END}";
            }

            string allMethods = string.Join("\n", folderText);
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string fileText = string.Format(UTIL_CLASS, FileUtilities.UTIL_FILE_NAME, dateTime, allMethods);

            return (fileText, dateTime);
        }

        private static void WriteText(VersionDefine[] defines, string fileText, string dateTime) {
            FileUtilities.CreatePluginsFolder();
            FileUtilities.CreateAssemblyDefinition(defines);

            string path = Path.Combine(Application.dataPath.Replace("Assets", string.Empty), FileUtilities.UTIL_FILE_PATH);
            File.WriteAllText(path, fileText);
            AssetDatabase.Refresh();
        }
    }
}
#endif