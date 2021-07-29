using System;

namespace E_Commerce_Shop.WebUI.Helpers
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public string CurrentCategory { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((double)TotalItems / ItemsPerPage);
        }
    }
}