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
        internal static void CreateScriptAssetFromTemplateFile(string templatePath, string defaultNewFileName, bool autoNamespace)
        {
            if (templatePath == null)
            {
                throw new ArgumentNullException(nameof(templatePath));
            }
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"The template file \"{templatePath}\" could not be found.", templatePath);
            }

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

            if (autoNamespace)
            {
                string[] originalLines = File.ReadAllLines(templatePath);
                TryApplyNamespace(templatePath, originalLines);
                ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<DoCreateScriptAsset>(), defaultNewFileName, icon, templatePath);
                File.WriteAllLines(templatePath, originalLines);
            }
            else
            {
                ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<DoCreateScriptAsset>(), defaultNewFileName, icon, templatePath);
            }
        }

        internal static void TryApplyNamespace(string filePath, string[] lines)
        {
            if (filePath == null || lines == null) { return; }

            int lineIndex = -1;
            string namespaceLine = null;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("    #ROOTNAMESPACEBEGIN#"))
                {
                    lineIndex = i;
                    namespaceLine = lines[i];
                }
            }

            if (lineIndex == -1) { return; }

            string[] components = filePath.Split('/');
            string localPath = filePath.TrimSuffix(components[components.Length - 1]);
            int asmdefStartIndex = -1;
            for (int i = components.Length - 2; i >= 0; i--)
            {
                Debug.Log($"{localPath} && {components[i]}");

                //FIXME: im thinking that GetFiles uses global location, and not relative to the project
                if (Directory.GetFiles(localPath, "*.asmdef", SearchOption.TopDirectoryOnly).Length > 0)
                {
                    asmdefStartIndex = i + 1;
                    break;
                }
                localPath = localPath.TrimSuffix(components[i]);
            }

            if (asmdefStartIndex == -1) { return; }

            string asmdefStartPath = string.Empty;
            for (int i = asmdefStartIndex; i < components.Length - 1; i++)
            {
                asmdefStartPath += $".{components[i]}";
            }

            lines[lineIndex] = namespaceLine + asmdefStartPath;

            Debug.Log(lines[lineIndex]);

            File.WriteAllLines(filePath, lines);
        }

        internal static GUIContent IconContent<T>(string text = null) where T : UnityEngine.Object
        {
            Texture2D texture = typeof(EditorGUIUtility).GetMethod("FindTexture").Invoke(null, new object[] { typeof(T) }) as Texture2D;
            return typeof(EditorGUIUtility).GetMethod("IconContent").Invoke(null, new object[] { texture, text }) as GUIContent;
        }

        internal static string TrimSuffix(this string s, string suffix)
        {
            if (s.EndsWith(suffix))
            {
                return s.Substring(0, s.Length - suffix.Length);
            }
            else
            {
                return s;
            }
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