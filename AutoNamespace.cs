// Developed with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

namespace TemplateUtil {
    internal sealed class AutoNamespace : UnityEditor.AssetModificationProcessor {
        internal static void OnWillCreateAsset(string path) {
            path = path.Replace(".meta", string.Empty);
            if (!path.EndsWith(".cs")) { return; }

            string systemPath = path.Insert(0, Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("Assets")));

            ReplaceScriptKeywords(systemPath, path);

            AssetDatabase.Refresh();
        }


        private static void ReplaceScriptKeywords(string systemPath, string projectPath) {
            projectPath = projectPath.Substring(projectPath.IndexOf("/Assets/") + "/Assets/".Length);
            projectPath = projectPath.Substring(0, projectPath.LastIndexOf("/"));
            projectPath = projectPath.Replace("/Scripts/", "/").Replace('/', '.');

            string rootNamespace = string.IsNullOrWhiteSpace(EditorSettings.projectGenerationRootNamespace) ? string.Empty : $"{EditorSettings.projectGenerationRootNamespace}.";
            string fullNamespace = $"{rootNamespace}{projectPath}";
            string fileData = File.ReadAllText(systemPath);

            fileData = fileData.Replace("#NAMESPACE#", fullNamespace);

            File.WriteAllText(systemPath, fileData);
        }
    }
}
#endif