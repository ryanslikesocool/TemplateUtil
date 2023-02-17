// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

using System.IO;
using UnityEditor;
using UnityEngine;

namespace TemplateUtil {
    internal static class MenuUtilities {
        public const string UTIL_FILE_NAME = "TemplateMenus.cs";
        public const string PLUGINS_PATH = "Assets/Plugins/TemplateUtil/Editor";
        public const string PACKAGES_PATH = "Packages/com.developedwithlove.templateutil";
        public const string UTIL_FILE_PATH = PLUGINS_PATH + "/" + UTIL_FILE_NAME;

        private const string ASMREF_PATH = PLUGINS_PATH + "/" + "TemplateUtil.asmref";

        public static void CreateAtPath(string path, string newName) {
            try {
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(Path.Combine(PLUGINS_PATH, path), newName);
                return;
            } catch { }

            try {
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(Path.Combine(PACKAGES_PATH, path), newName);
                return;
            } catch { }

            Debug.LogWarning("Template file could not be found.  Please ensure that the template file is in the correct directory.");
        }

        public static void CreatePluginsFolder() {
            if (File.Exists(PLUGINS_PATH)) {
                return;
            }

            Directory.CreateDirectory(PLUGINS_PATH);
        }

        public static void CreateAssemblyDefinitionReference() {
            if (File.Exists(ASMREF_PATH)) {
                return;
            }

            File.WriteAllText(ASMREF_PATH,
@"{
    ""reference"": ""GUID:0dc901d9e6cf745f79acfd63c10efcca""
}"
            );
            AssetDatabase.ImportAsset(ASMREF_PATH, ImportAssetOptions.ForceUpdate);
        }
    }
}