// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TemplateUtil {
    public static class MenuUtilities {
        public static void CreateAtPath(string path, string newName) {
            try {
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(Path.Combine(FileUtilities.PLUGINS_PATH, path), newName);
                return;
            } catch { }

            try {
                ProjectWindowUtil.CreateScriptAssetFromTemplateFile(Path.Combine(FileUtilities.PACKAGES_PATH, path), newName);
                return;
            } catch { }

            Debug.LogWarning("Template file could not be found.  Please ensure that the template file is in the correct directory.");
        }
    }
}
#endif