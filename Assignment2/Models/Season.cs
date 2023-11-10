using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Assignment2.Models
{
    public class Season
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Repertoire> Repertoires { get; set; }
    }
}