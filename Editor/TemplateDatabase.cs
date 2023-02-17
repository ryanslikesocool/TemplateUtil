// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using System;
using UnityEngine;

namespace TemplateUtil {
    [CreateAssetMenu(menuName = "Developed With Love/TemplateUtil/Template Database")]
    internal sealed class TemplateDatabase : ScriptableObject {
        public TemplateFolder[] folders = new TemplateFolder[0];
    }
}
#endif