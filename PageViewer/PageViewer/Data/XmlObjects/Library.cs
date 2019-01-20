using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageViewer.Data
{
    public class Library : XMLPersistedObject
    {
        public Library()
        {
            Name = string.Empty;
            Version = string.Empty;
        }

        // Attributes
        [AttributeIsXMLAttribute()]
        public string Name;
        [AttributeIsXMLAttribute()]
        public string Version;

        // Properties

        // Sub Elements

        public override bool IsSubElement(String p_sName)
        {
            switch (p_sName)
            {
                default:
                    return false;
            }
        }

        public override XMLPersistedObject GetSubElementObject(String p_sName)
        {
            switch (p_sName)
            {
                default:
                    return null;
            }
        }

        public override void AddSubElementObject(XMLPersistedObject p_SubElementObject)
        {
        }
    }

    public class LibraryDictionary : Dictionary<string, Library>
    {
    }
}
