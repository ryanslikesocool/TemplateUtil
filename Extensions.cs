// Developed with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
using UnityEditor.ProjectWindowCallback;
using System.Reflection;
using System.Threading.Tasks;

namespace TemplateUtil {
    internal static class Extensions {
        private const string ASSETS_PATH = "Assets/Plugins/TemplateUtil";
        private const string PACKAGES_PATH = "Packages/com.developedwithlove.templateutil";

        internal static void CreateAtPath(string path, string newName, bool autoNamespace) {
            string filePath;
            try {
                filePath = Path.Combine(ASSETS_PATH, path);
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(filePath, newName);
                return;
            } catch (System.Exception error) {
                filePath = null;
                Debug.LogWarning($"Template file at path {path} could not be found.  Please ensure that the template file is in the correct directory.\n{error}");
            }

            try {
                filePath = Path.Combine(PACKAGES_PATH, path);
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(filePath, newName);
                return;
            } catch (System.Exception error) {
                filePath = null;
                Debug.LogWarning($"Template file at path {path} could not be found.  Please ensure that the template file is in the correct directory.\n{error}");
            }
        }
    }
}
#endif