using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Helper
{
    public class Paging
    {
        private int _totalPages;
        public int TotalPages
        {
            get => _totalPages; set
            {
                _totalPages = value;
                Pages = new List<PageInfo>();
                for (int i = 1; i <= _totalPages; i++)
                {
                    Pages.Add(new PageInfo
                    {
                        Page = i,
                        TotalPage = _totalPages
                    });

                }
            }
        }
        public int CurrentPage { get; set; }
        public int CakePerPage { get; set; }

        List<PageInfo> Pages { get; set; }
    }
}
