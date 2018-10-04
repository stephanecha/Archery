namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtournamentpictures2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TournamentPictures", "TournamentID", "dbo.Tournaments");
            DropIndex("dbo.TournamentPictures", new[] { "TournamentID" });
            CreateTable(
                "dbo.TournamentPictureTournaments",
                c => new
                    {
                        TournamentPicture_ID = c.Int(nullable: false),
                        Tournament_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TournamentPicture_ID, t.Tournament_ID })
                .ForeignKey("dbo.TournamentPictures", t => t.TournamentPicture_ID, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_ID, cascadeDelete: true)
                .Index(t => t.TournamentPicture_ID)
                .Index(t => t.Tournament_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentPictureTournaments", "Tournament_ID", "dbo.Tournaments");
            DropForeignKey("dbo.TournamentPictureTournaments", "TournamentPicture_ID", "dbo.TournamentPictures");
            DropIndex("dbo.TournamentPictureTournaments", new[] { "Tournament_ID" });
            DropIndex("dbo.TournamentPictureTournaments", new[] { "TournamentPicture_ID" });
            DropTable("dbo.TournamentPictureTournaments");
            CreateIndex("dbo.TournamentPictures", "TournamentID");
            AddForeignKey("dbo.TournamentPictures", "TournamentID", "dbo.Tournaments", "ID", cascadeDelete: true);
        }
    }
}
