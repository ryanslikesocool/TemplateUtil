// Made with love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using System;
using UnityEngine;

namespace TemplateUtil
{
    public class TemplateUtilDatabase : ScriptableObject
    {
        [Serializable]
        public struct TemplateFolder
        {
            public string menuPath;
            public string preprocessor;
            public int priority;
            public TextAsset[] templateFiles;
        }
        public TemplateFolder[] folders = new TemplateFolder[0];
    }
}
#endif