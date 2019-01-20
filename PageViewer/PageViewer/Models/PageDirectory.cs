using PageViewer.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PageViewer.Models
{
    public class PageDirectory
    {
        public static int pageidcounter = 0;

        public static PageDirectory BuildRootPageDirectory(DirectoryInfo rdi)
        {
            pageidcounter = 0;
            PageDirectory rpd = new PageDirectory(rdi);
            return rpd;
        }

        public DirectoryInfo _di;

        public PageDirectory(DirectoryInfo di)
        {
            Count = 0;

            PageViews = new List<PageView>();
            PageDirectories = new List<PageDirectory>();

            _di = di;

            Name = _di.Name;

            foreach (DirectoryInfo sdi in _di.GetDirectories())
            {
                PageDirectory spd = new PageDirectory(sdi);
                if (spd.PageViews.Count > 0 ||
                    spd.PageDirectories.Count > 0)
                {
                    PageDirectories.Add(spd);
                    Count += spd.Count;
                }
            }

            foreach (FileInfo fi in _di.GetFiles("*.page"))
            {
                Page page = new Page();
                page.LoadFileAsync(fi, "IPS");
                PageViews.Add(page.GetPageView(pageidcounter++));
                Count++;
            }
        }
        public PageDirectory()
        {
            PageViews = new List<PageView>();
            PageDirectories = new List<PageDirectory>();
        }

        public PageDirectory ApplyFilter(string filter)
        {
            PageDirectory fpd = new PageDirectory();
            fpd._di = _di;
            fpd.Name = _di.Name;

            foreach (PageDirectory spd in PageDirectories)
            {
                PageDirectory sfpd = spd.ApplyFilter(filter);
                if (sfpd.PageViews.Count > 0 ||
                    sfpd.PageDirectories.Count > 0)
                {
                    fpd.PageDirectories.Add(sfpd);
                    fpd.Count += sfpd.Count;
                }
            }

            foreach (PageView spv in PageViews)
            {
                if (spv.Name.ToUpper().Contains(filter.ToUpper()))
                {
                    fpd.PageViews.Add(spv);
                    fpd.Count++;
                }
            }

            return fpd;
        }

        public PageView FindPageView(int id)
        {
            foreach (PageView pv in PageViews)
            {
                if (pv.ID == id)
                {
                    return pv;
                }
            }

            foreach (PageDirectory pd in PageDirectories)
            {
                PageView pv = pd.FindPageView(id);
                if (pv != null)
                {
                    return pv;
                }
            }

            return null;
        }

        public int Count { get; set; }
        public string Name { get; set; }
        public List<PageView> PageViews { get; set; }
        public List<PageDirectory> PageDirectories { get; set; }
    }
}
