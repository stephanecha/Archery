namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtournamentpictures3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TournamentPictureTournaments", "TournamentPicture_ID", "dbo.TournamentPictures");
            DropForeignKey("dbo.TournamentPictureTournaments", "Tournament_ID", "dbo.Tournaments");
            DropIndex("dbo.TournamentPictureTournaments", new[] { "TournamentPicture_ID" });
            DropIndex("dbo.TournamentPictureTournaments", new[] { "Tournament_ID" });
            CreateIndex("dbo.TournamentPictures", "TournamentID");
            AddForeignKey("dbo.TournamentPictures", "TournamentID", "dbo.Tournaments", "ID", cascadeDelete: true);
            DropTable("dbo.TournamentPictureTournaments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TournamentPictureTournaments",
                c => new
                    {
                        TournamentPicture_ID = c.Int(nullable: false),
                        Tournament_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TournamentPicture_ID, t.Tournament_ID });
            
            DropForeignKey("dbo.TournamentPictures", "TournamentID", "dbo.Tournaments");
            DropIndex("dbo.TournamentPictures", new[] { "TournamentID" });
            CreateIndex("dbo.TournamentPictureTournaments", "Tournament_ID");
            CreateIndex("dbo.TournamentPictureTournaments", "TournamentPicture_ID");
            AddForeignKey("dbo.TournamentPictureTournaments", "Tournament_ID", "dbo.Tournaments", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TournamentPictureTournaments", "TournamentPicture_ID", "dbo.TournamentPictures", "ID", cascadeDelete: true);
        }
    }
}
