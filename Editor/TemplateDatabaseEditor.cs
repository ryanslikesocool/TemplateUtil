// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TemplateUtil {
	[CustomEditor(typeof(TemplateDatabase))]
	internal sealed class TemplateDatabaseEditor : Editor {
		private TemplateDatabase database = null;

		public void OnEnable() {
			database = (TemplateDatabase)target;
		}

		public override void OnInspectorGUI() {
			DrawDefaultInspector();

			if (GUILayout.Button($"Generate {FileUtilities.UTIL_FILE_NAME}", GUILayout.Height(50))) {
				RegenerateTemplateFile();
			}
		}

		private void RegenerateTemplateFile() {
			MenuBuilder.RebuildScript(database);
		}
	}
}
#endif