// Developed With Love by Ryan Boyer http://ryanjboyer.com <3

#if UNITY_EDITOR
using System;

namespace TemplateUtil {
    [Serializable]
    internal struct VersionDefine {
        public string name;
        public string expression;
        public string define;
    }
}
#endif