namespace Assignment2.Migrations
{
    using Assignment2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2.Data.Assignment2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment2.Data.Assignment2Context context)
        {
            var seasons = new List<Season>
            {
                new Season{Name="2010-2011 Season"},
                new Season{Name="2011-2012 Season"},
                new Season{Name="2012-2013 Season"},
                new Season{Name="2013-2014 Season"},
                new Season{Name="2014-2015 Season"},
                new Season{Name="2015-2016 Season"},
                new Season{Name="2016-2017 Season"},
                new Season{Name="2017-2018 Season"},
                new Season{Name="2018-2019 Season"},
                new Season{Name="2019-2020 Season"},
                new Season{Name="2020-2021 Season"},
                new Season{Name="2021-2022 Season"},
            };
            seasons.ForEach(c => context.Seasons.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var matches = new List<Match>
            {
                new Match{Date="2010-10-22",Name="NHK",Medal="No medal",SeasonID=seasons.Single(c=>c.Name=="2010-2011 Season").ID},
                new Match{Date="2010-11-19",Name="COR",Medal="No medal",SeasonID=seasons.Single(c=>c.Name=="2010-2011 Season").ID},
                new Match{Date="2010-12-23",Name="JN",Medal="No medal",SeasonID=seasons.Single(c=>c.Name=="2010-2011 Season").ID},
                new Match{Date="2011-2-15",Name="4CC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2010-2011 Season").ID},
                new Match{Date="2011-11-3",Name="COC",Medal="No medal",SeasonID=seasons.Single(c=>c.Name=="2011-2012 Season").ID},
                new Match{Date="2011-11-25",Name="COR",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2011-2012 Season").ID},
                new Match{Date="2011-12-22",Name="JN",Medal="Bronze medal",SeasonID=seasons.Single(c=>c.Name=="2011-2012 Season").ID},
                new Match{Date="2011-12-10",Name="GPF",Medal="No medal",SeasonID=seasons.Single(c=>c.Name=="2011-2012 Season").ID},
                new Match{Date="2012-3-26",Name="WC",Medal="Bronze medal",SeasonID=seasons.Single(c=>c.Name=="2011-2012 Season").ID},
                new Match{Date="2012-10-20",Name="SA",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2012-2013 Season").ID},
                new Match{Date="2012-11-21",Name="NHK",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2012-2013 Season").ID},
                new Match{Date="2012-12-7",Name="GPF",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2012-2013 Season").ID},
                new Match{Date="2012-12-20",Name="JN",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2012-2013 Season").ID},
                new Match{Date="2013-2-8",Name="4CC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2012-2013 Season").ID},
                new Match{Date="2013-3-10",Name="WC",Medal="No medal",SeasonID=seasons.Single(c=>c.Name=="2012-2013 Season").ID},
                new Match{Date="2013-10-25",Name="SC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2013-2014 Season").ID},
                new Match{Date="2013-11-15",Name="TEB",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2013-2014 Season").ID},
                new Match{Date="2013-12-21",Name="JN",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2013-2014 Season").ID},
                new Match{Date="2014-2-13",Name="OWG",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2013-2014 Season").ID},
                new Match{Date="2014-3-26",Name="WC",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2013-2014 Season").ID},
                new Match{Date="2014-11-7",Name="COC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2014-2015 Season").ID},
                new Match{Date="2014-11-28",Name="NHK",Medal="No medal",SeasonID=seasons.Single(c=>c.Name=="2014-2015 Season").ID},
                new Match{Date="2014-12-12",Name="GPF",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2014-2015 Season").ID},
                new Match{Date="2014-12-26",Name="JN",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2014-2015 Season").ID},
                new Match{Date="2015-3-25",Name="WC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2014-2015 Season").ID},
                new Match{Date="2015-4-16",Name="WTT",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2014-2015 Season").ID},
                new Match{Date="2015-10-30",Name="SC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2015-2016 Season").ID},
                new Match{Date="2015-11-27",Name="NHK",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2015-2016 Season").ID},
                new Match{Date="2015-12-10",Name="GPF",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2015-2016 Season").ID},
                new Match{Date="2015-12-24",Name="JN",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2015-2016 Season").ID},
                new Match{Date="2016-3-28",Name="WC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2015-2016 Season").ID},
                new Match{Date="2016-10-28",Name="SC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2016-2017 Season").ID},
                new Match{Date="2016-11-25",Name="NHK",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2016-2017 Season").ID},
                new Match{Date="2016-12-7",Name="GPF",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2016-2017 Season").ID},
                new Match{Date="2017-2-14",Name="4CC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2016-2017 Season").ID},
                new Match{Date="2017-3-29",Name="WC",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2016-2017 Season").ID},
                new Match{Date="2017-4-20",Name="WTT",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2016-2017 Season").ID},
                new Match{Date="2017-10-20",Name="COR",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2017-2018 Season").ID},
                new Match{Date="2018-2-16",Name="OWG",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2017-2018 Season").ID},
                new Match{Date="2018-11-16",Name="COR",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2018-2019 Season").ID},
                new Match{Date="2019-3-18",Name="WC",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2018-2019 Season").ID},
                new Match{Date="2019-10-25",Name="SC",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2019-2020 Season").ID},
                new Match{Date="2019-11-22",Name="NHK",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2019-2020 Season").ID},
                new Match{Date="2019-12-4",Name="GPF",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2019-2020 Season").ID},
                new Match{Date="2019-12-18",Name="JN",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2019-2020 Season").ID},
                new Match{Date="2020-2-4",Name="4CC",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2019-2020 Season").ID},
                new Match{Date="2020-12-24",Name="JN",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2020-2021 Season").ID},
                new Match{Date="2021-3-22",Name="WC",Medal="Bronze medal",SeasonID=seasons.Single(c=>c.Name=="2020-2021 Season").ID},
                new Match{Date="2021-4-15",Name="WTT",Medal="Silver medal",SeasonID=seasons.Single(c=>c.Name=="2020-2021 Season").ID},
                new Match{Date="2021-12-24",Name="JN",Medal="Gold medal",SeasonID=seasons.Single(c=>c.Name=="2021-2022 Season").ID},
                new Match{Date="2022-2-8",Name="OWG",Medal="No medal",SeasonID=seasons.Single(c=>c.Name=="2021-2022 Season").ID},
            };
            matches.ForEach(c => context.Matches.AddOrUpdate(p => p.Date, c));
            context.SaveChanges();

            var repertoires = new List<Repertoire>
            {
                new Repertoire{ShortProgram="White Legend",LongProgram="Song of the homeless",Gala="Vertigo",SeasonID=seasons.Single(c=>c.Name=="2010-2011 Season").ID},
                new Repertoire{ShortProgram="Étude in D sharp minor, op. 8 no. 12",LongProgram="Kissing You",Gala="Somebody to Love",SeasonID=seasons.Single(c=>c.Name=="2011-2012 Season").ID},
                new Repertoire{ShortProgram="Étude in D sharp minor, op. 8 no. 12",LongProgram="Escape",Gala="Somebody to Love",SeasonID=seasons.Single(c=>c.Name=="2011-2012 Season").ID},
                new Repertoire{ShortProgram="Parisienne Walkways",LongProgram="Notre-Dame de Paris",Gala="Hello, I Love You",SeasonID=seasons.Single(c=>c.Name=="2012-2013 Season").ID},
                new Repertoire{ShortProgram="Parisienne Walkways",LongProgram="Notre-Dame de Paris",Gala="Turn into flowers",SeasonID=seasons.Single(c=>c.Name=="2012-2013 Season").ID},
                new Repertoire{ShortProgram="Parisienne Walkways",LongProgram="Romeo and Juliet",Gala="Story",SeasonID=seasons.Single(c=>c.Name=="2013-2014 Season").ID},
                new Repertoire{ShortProgram="Chopin Ballade no.1",LongProgram="The Phantom of the Opera",Gala="The Final Time Traveler",SeasonID=seasons.Single(c=>c.Name=="2014-2015 Season").ID},
                new Repertoire{ShortProgram="Chopin Ballade no.1",LongProgram="The Phantom of the Opera",Gala="Flowers bloom",SeasonID=seasons.Single(c=>c.Name=="2014-2015 Season").ID},
                new Repertoire{ShortProgram="Chopin Ballade no.1",LongProgram="SEIMEI",Gala="Requiem of Heaven &Earth",SeasonID=seasons.Single(c=>c.Name=="2015-2016 Season").ID},
                new Repertoire{ShortProgram="Let's go Crazy",LongProgram="Hope & Legacy",Gala="Notte Stellata",SeasonID=seasons.Single(c=>c.Name=="2016-2017 Season").ID},
                new Repertoire{ShortProgram="Chopin Ballade no.1",LongProgram="SEIMEI",Gala="Notte Stellata",SeasonID=seasons.Single(c=>c.Name=="2017-2018 Season").ID},
                new Repertoire{ShortProgram="Otonal",LongProgram="Origin",Gala="Spring,come on",SeasonID=seasons.Single(c=>c.Name=="2018-2019 Season").ID},
                new Repertoire{ShortProgram="Otonal",LongProgram="Origin",Gala="no song",SeasonID=seasons.Single(c=>c.Name=="2019-2020 Season").ID},
                new Repertoire{ShortProgram="Let me entertain you",LongProgram="Heaven and Earth",Gala="no song",SeasonID=seasons.Single(c=>c.Name=="2020-2021 Season").ID},
                new Repertoire{ShortProgram="Introduction and Rondo Capriccioso",LongProgram="Heaven and Earth",Gala="Spring,come on",SeasonID=seasons.Single(c=>c.Name=="2021-2022 Season").ID},
            };
            repertoires.ForEach(c => context.Repertoires.AddOrUpdate(p => p.ID, c));
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
