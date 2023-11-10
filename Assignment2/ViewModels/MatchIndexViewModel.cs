using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using PagedList;

namespace Assignment2.ViewModels
{ 
public class MatchIndexViewModel
{
        public IPagedList<Match> Matches { get; set; }
        public string Search { get; set; }
    public string Season { get; set; }
        public string SortBy { get; internal set; }
        public Dictionary<string, string> Sorts { get; set; }
        public IEnumerable<SeasonWithCount> SeasWithCount { get; set; }
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
        public int MatchCount { get; set; }
        public string SeasonName { get; set; }
        public string SeaNameWithCount
        {
            get
            {
                return SeasonName + " (" +
                MatchCount.ToString() + ")";
            }
        }

    }
}
}