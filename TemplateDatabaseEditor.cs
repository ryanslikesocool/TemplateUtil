// Developed with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace TemplateUtil
{
    [CustomEditor(typeof(TemplateDatabase))]
    internal class TemplateUtilWindow : Editor
    {
        private const string ASSETS_PATH = "Assets/Plugins/TemplateUtil";
        private const string PACKAGES_PATH = "Packages/com.ifelse.templateutil";

        public const string UTIL_FILE = "TemplateUtilMenus.cs";

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();

            if (GUILayout.Button($"Generate {UTIL_FILE}", GUILayout.Height(48)))
            {
                RegenerateTemplateUtilFile();
            }
        }

        private void RegenerateTemplateUtilFile()
        {
            string fileText = CodeGen.GenerateFileText((TemplateDatabase)target, out string dateTime);

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

            Debug.Log($"Generated {UTIL_FILE} at {dateTime}.  Reloading the generated script...");
        }
    }
}
#endif