// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

using System;
using UnityEngine;

namespace TemplateUtil {
    [Serializable]
    internal struct TemplateFolder {
        public string menuPath;
        public string preprocessor;
        public TextAsset[] templateFiles;
    }
}