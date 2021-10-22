// Developed with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace TemplateUtil
{
    internal static class CodeGen
    {
        private const string UTIL_CLASS = @"// {0}
// Generated on {1}
// Generated with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace TemplateUtil
{{
    public static class TemplateUtilMenus
    {{
        private const string ASSETS_PATH = ""Assets/Plugins/TemplateUtil"";
        private const string PACKAGES_PATH = ""Packages/com.ifelse.templateutil"";
        
        private static void CreateAtPath(string path, string newName, bool autoNamespace)
        {{
            string filePath;
            try
            {{
                filePath = Path.Combine(ASSETS_PATH, path);
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(filePath, newName);
            }}
            catch {{
                try
                {{
                    filePath = Path.Combine(PACKAGES_PATH, path);
                    ProjectWindowUtil.CreateScriptAssetFromTemplateFile(filePath, newName);
                }}
                catch  {{
                    filePath = null;
                    Debug.LogWarning($""Template file at path {{path}} could not be found.  Please ensure that the template file is in the correct directory."");
                }}
            }}

            if (autoNamespace && filePath != null) {{
                TryApplyNamespace(filePath);
            }}
        }}

        private static void TryApplyNamespace(string filePath) {{
            string[] lines = File.ReadAllLines(filePath);
            int lineIndex = -1;
            string[] namespaceParts = null;
            
            for (int i = 0; i < lines.Length; i++) {{
                if (lines[i].StartsWith(""namespace"")) {{
                    lineIndex = i;
                    namespaceParts = lines[i].Split(' ');
                }}
            }}

            if (lineIndex == -1) {{
                Debug.Log($""No namespace could be found in the new script.\n{{File.ReadAllText(filePath)}}"");
                return;
            }}

            Debug.Log($""Found namespace {{namespaceParts[1]}} at {{lineIndex}}"");

            string[] components = filePath.Split('/');
            string newNamespace = namespaceParts[1];

            for (int i = 0; i < components.Length - 1; i++) {{
                if (components[i] == newNamespace) {{
                    for (int j = i; j < components.Length - 1; j++) {{
                        newNamespace += $"".{{components[j]}}"";
                    }}
                    break;
                }}
            }}

            namespaceParts[1] = newNamespace;

            lines[lineIndex] = string.Join("" "", namespaceParts);
        }}

        {2}
    }}
}}
#endif";
        // 0 = file name
        // 1 = date and time generated
        // 2 = util methods

        private const string UTIL_METHOD = @"
        [MenuItem(itemName: ""Assets/Create/{0}"", isValidateFunction: false, priority: {2})]
        public static void Create{3}FromTemplate() => CreateAtPath(""Templates/{3}.{1}.txt"", ""New{3}.{1}"", {4});
        ";
        // 0 = menu path
        // 1 = file extension
        // 2 = priority (less than -50 is best!)
        // 3 = template file name with no extension
        // 4 = auto namespace

        private const string PREPROCESSOR_START = "#if";
        private const string PREPROCESSOR_END = "#endif";

        private const string REGION_START = "#region";
        private const string REGION_END = "#endregion";

        public static string GenerateFileText(TemplateDatabase database, out string dateTime)
        {
            string[] folderText = new string[database.folders.Length];

            for (int i = 0; i < folderText.Length; i++)
            {
                folderText[i] = GenerateFolderText(database.folders[i]);
            }

            string allMethods = string.Join("\n", folderText);
            dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return string.Format(UTIL_CLASS, TemplateUtilWindow.UTIL_FILE, dateTime, allMethods);
        }

        private static string GenerateFolderText(TemplateDatabase.TemplateFolder folder)
        {
            string menuPath = folder.menuPath;
            string preprocessor = folder.preprocessor;
            string autoNamespace = folder.autoNamespace.ToString().ToLower();
            int priority = folder.priority;
            TextAsset[] templateFiles = folder.templateFiles;

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
                    methodArray[j] = string.Format(UTIL_METHOD, $"{menuPath}/{filePrefix}", realExtension, priority, filePrefix, autoNamespace);
                }
            }
            string methods = string.Join(string.Empty, methodArray);

            string folderText = string.Join(string.Empty, methods);
            if (preprocessor != string.Empty)
            {
                folderText = $"{PREPROCESSOR_START} {preprocessor}\n{folderText}\n{PREPROCESSOR_END}";
            }
            folderText = $"{REGION_START} {menuPath}\n{folderText}\n{REGION_END}";
            return folderText;
        }
    }
}
#endif