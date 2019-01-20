using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PageViewer.Models;

namespace PageViewer.Data
{
    public class Page : XMLPersistedObject
    {
        public Page()
        {
            Libraries = new LibraryDictionary();
        }

        // Attributes
        //[AttributeIsXMLAttribute()]
        //public int id;

        // Properties
        //[AttributeIsXMLSubProperty()]
        //public String encrypted;

        // Sub Elements
        public LibraryDictionary Libraries;
        public IPS_Plugin_DrawingPageImpl DrawingPageImpl;

        public override bool IsSubElement(String p_sName)
        {
            switch (p_sName)
            {
                case "Library":
                case "IPS.Plugin.DrawingPageImpl":
                    return true;
                default:
                    return false;
            }
        }

        public override XMLPersistedObject GetSubElementObject(String p_sName)
        {
            switch (p_sName)
            {
                case "Library":
                    return new Library();
                case "IPS.Plugin.DrawingPageImpl":
                    return new IPS_Plugin_DrawingPageImpl();
                default:
                    return null;
            }
        }

        public override void AddSubElementObject(XMLPersistedObject p_SubElementObject)
        {
            Library l_Library = p_SubElementObject as Library;
            if (l_Library != null)
            {
                if (!Libraries.ContainsKey(l_Library.Name))
                {
                    Libraries.Add(l_Library.Name, l_Library);
                }
                else
                {
                    ReportXMLReadError("Multiple library definitions with the same name are present : " + l_Library.Name);
                }
            }

            IPS_Plugin_DrawingPageImpl l_IPS_Plugin_DrawingPageImpl = p_SubElementObject as IPS_Plugin_DrawingPageImpl;
            if (l_Library != null)
            {
                DrawingPageImpl = l_IPS_Plugin_DrawingPageImpl;
            }
        }

        private PageView _pageview;

        public PageView GetPageView(int id)
        {
            if (_pageview == null)
            {
                _pageview = new PageView();
                _pageview.Name = GetRootXMLFileInfo().Name;
                _pageview.ID = id;
            }
            return _pageview;
        }

    }
}
