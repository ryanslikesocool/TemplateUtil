// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

//#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TemplateUtil {
    internal static class FileUtilities {
        internal const string UTIL_FILE_NAME = "TemplateMenus.cs";
        internal const string UTIL_FILE_PATH = PLUGINS_PATH + "/" + UTIL_FILE_NAME;
        internal const string PLUGINS_PATH = "Assets/Plugins/TemplateUtil/Editor";
        internal const string PACKAGES_PATH = "Packages/com.developedwithlove.templateutil";

        private const string ASMDEF_PATH = PLUGINS_PATH + "/" + "TemplateUtil.Menus.asmdef";

        private const string ASMDEF_CONTENT = @"{{
    ""name"": ""TemplateUtil.Menus"",
    ""rootNamespace"": ""TemplateUtil"",
    ""references"": [
        ""GUID:0dc901d9e6cf745f79acfd63c10efcca""
    ],
    ""includePlatforms"": [
        ""Editor""
    ],
    ""excludePlatforms"": [],
    ""allowUnsafeCode"": false,
    ""overrideReferences"": false,
    ""precompiledReferences"": [],
    ""autoReferenced"": false,
    ""defineConstraints"": [],
    ""versionDefines"": [
        {0}
    ],
    ""noEngineReferences"": false
}}";

        private const string VERSION_DEFINE_FORMAT = @"
        {{
            ""name"": ""{0}"",
            ""expression"": ""{1}"",
            ""define"": ""{2}""
        }}";

        internal static void CreatePluginsFolder() {
            if (File.Exists(PLUGINS_PATH)) {
                return;
            }

            Directory.CreateDirectory(PLUGINS_PATH);
        }

        internal static void CreateAssemblyDefinition(VersionDefine[] defines) {
            if (File.Exists(ASMDEF_PATH)) {
                return;
            }

            string definesString = string.Join(",\n", defines.Select(d => String.Format(VERSION_DEFINE_FORMAT, d.name, d.expression, d.define)));
            string asmdefContent = String.Format(ASMDEF_CONTENT, definesString);

            File.WriteAllText(ASMDEF_PATH, asmdefContent);
            AssetDatabase.ImportAsset(ASMDEF_PATH, ImportAssetOptions.ForceUpdate);
        }
    }
}
//#endif