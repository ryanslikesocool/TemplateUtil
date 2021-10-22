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

namespace TemplateUtil
{
    internal static class Extensions
    {
        internal static void CreateScriptAssetFromTemplateFile(string templatePath, string defaultNewFileName, Action onEndEditing)
        {
            if (templatePath == null)
                throw new ArgumentNullException(nameof(templatePath));
            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"The template file \"{templatePath}\" could not be found.", templatePath);

            if (string.IsNullOrEmpty(defaultNewFileName))
                defaultNewFileName = Path.GetFileName(templatePath);

            Texture2D icon = null;
            switch (Path.GetExtension(defaultNewFileName))
            {
                case ".cs":
                    icon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
                    break;
                case ".shader":
                    icon = IconContent<Shader>().image as Texture2D;
                    break;
                case ".asmdef":
                    icon = IconContent<AssemblyDefinitionAsset>().image as Texture2D;
                    break;
                case ".asmref":
                    icon = IconContent<AssemblyDefinitionReferenceAsset>().image as Texture2D;
                    break;
                default:
                    icon = IconContent<TextAsset>().image as Texture2D;
                    break;
            }
            DoCreateScriptAsset createScriptAsset = ScriptableObject.CreateInstance<DoCreateScriptAsset>();
            createScriptAsset.onEndEditing = onEndEditing;
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, createScriptAsset, defaultNewFileName, icon, templatePath);
        }

        internal static void TryApplyNamespace(bool autoNamespace, string filePath)
        {
            if (!autoNamespace || filePath == null) { return; }

            string[] lines = File.ReadAllLines(filePath);
            int lineIndex = -1;
            string[] namespaceParts = null;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("namespace"))
                {
                    lineIndex = i;
                    namespaceParts = lines[i].Split(' ');
                }
                //break;
                Debug.Log(lines[i]);
            }

            if (lineIndex == -1)
            {
                return;
            }

            string[] components = filePath.Split('/');
            string newNamespace = namespaceParts[1];

            for (int i = 0; i < components.Length - 1; i++)
            {
                if (components[i] == newNamespace)
                {
                    for (int j = i; j < components.Length - 1; j++)
                    {
                        newNamespace += $".{components[j]}";
                    }
                    break;
                }
            }

            namespaceParts[1] = newNamespace;

            lines[lineIndex] = string.Join(" ", namespaceParts);

            File.WriteAllLines(filePath, lines);
        }

        internal static GUIContent IconContent<T>(string text = null) where T : UnityEngine.Object
        {
            Texture2D texture = typeof(EditorGUIUtility).GetMethod("FindTexture").Invoke(null, new object[] { typeof(T) }) as Texture2D;
            return typeof(EditorGUIUtility).GetMethod("IconContent").Invoke(null, new object[] { texture, text }) as GUIContent;
        }
    }

    internal class DoCreateScriptAsset : EndNameEditAction
    {
        public Action onEndEditing;

        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            UnityEngine.Object o = typeof(ProjectWindowUtil).GetMethod("CreateScriptAssetFromTemplate", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, new object[] { pathName, resourceFile }) as UnityEngine.Object;
            ProjectWindowUtil.ShowCreatedAsset(o);

            Task.Run(async delegate
            {
                await Task.Delay(10000);
                onEndEditing();
            });
        }
    }
}
#endif