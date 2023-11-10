using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Repertoire
    {
        public int ID { get; set; }
        public string ShortProgram { get; set; }
        public string LongProgram { get; set; }
        public string Gala { get; set; }
        public int? SeasonID { get; set; }
        public virtual Season Season { get; set; }
    }
}