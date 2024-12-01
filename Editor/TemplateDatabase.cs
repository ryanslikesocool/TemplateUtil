// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using UnityEngine;

namespace TemplateUtil {
	[CreateAssetMenu(menuName = "Developed With Love/TemplateUtil/Template Database")]
	internal sealed class TemplateDatabase : ScriptableObject {
		public int basePriority
#if UNITY_2023_1_OR_NEWER
			= -200;
#else
			= -100;
#endif
		public VersionDefine[] defines = default;
		public TemplateFolder[] folders = default;
	}
}
#endif