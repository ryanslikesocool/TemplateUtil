// Developed with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using System;
using UnityEngine;

namespace TemplateUtil
{
    public class TemplateDatabase : ScriptableObject
    {
        [Serializable]
        public struct TemplateFolder
        {
            public string menuPath;
            public string preprocessor;
            public bool autoNamespace;
            public int priority;
            public TextAsset[] templateFiles;
        }
        public TemplateFolder[] folders = new TemplateFolder[0];
    }
}
#endif