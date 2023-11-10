using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Match
    {
        public int ID { get; set; }

        public string Date { get; set; }
        public string Name { get; set; }
        public string Medal { get; set; }
        public int? SeasonID { get; set; }
        public virtual Season Season { get; set; }

    }
}