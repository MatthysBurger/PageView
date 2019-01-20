using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageViewer.Data
{
    public class IPS_Plugin_DrawingPageImpl : XMLPersistedObject
    {
        public IPS_Plugin_DrawingPageImpl()
        {
            Properties = string.Empty;
            Values = string.Empty;
        }

        // Attributes

        // Properties
        [AttributeIsXMLSubProperty()]
        public string Properties;
        [AttributeIsXMLSubProperty()]
        public string Values;

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
}
