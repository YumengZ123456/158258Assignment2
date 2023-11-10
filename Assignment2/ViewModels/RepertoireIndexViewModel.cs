using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Assignment2.ViewModels
{
    public class RepertoireIndexViewModel
    {
        public IPagedList<Repertoire> Repertoires { get; set; }
        public string Search { get; set; }
        public IEnumerable<SeasonWithCount> SeasWithCount { get; set; }
        public string Season { get; set; }
        public IEnumerable<SelectListItem> SeaFilterItems
        {
            get
            {
                var allCats = SeasWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.SeasonName,
                    Text = cc.SeaNameWithCount
                });
                return allCats;
            }
        }
        public class SeasonWithCount
        {
            public int RepertoireCount { get; set; }
            public string SeasonName { get; set; }
            public string SeaNameWithCount
            {
                get
                {
                    return SeasonName + " (" +
                    RepertoireCount.ToString() + ")";
                }
            }


        }
    }
}