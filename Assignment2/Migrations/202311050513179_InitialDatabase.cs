namespace Assignment2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Name = c.String(),
                        Medal = c.String(),
                        SeasonID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.SeasonID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Repertoires",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShortProgram = c.String(),
                        LongProgram = c.String(),
                        Gala = c.String(),
                        SeasonID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.SeasonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repertoires", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Matches", "SeasonID", "dbo.Seasons");
            DropIndex("dbo.Repertoires", new[] { "SeasonID" });
            DropIndex("dbo.Matches", new[] { "SeasonID" });
            DropTable("dbo.Repertoires");
            DropTable("dbo.Seasons");
            DropTable("dbo.Matches");
        }
    }
}
