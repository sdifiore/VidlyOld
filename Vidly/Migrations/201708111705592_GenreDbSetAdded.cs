namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreDbSetAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            Sql("insert into Genres (Id, Name) values (1, 'ScyFy');");
            Sql("insert into Genres (Id, Name) values (2, 'Fantasy');");
            Sql("insert into Genres (Id, Name) values (3, 'Romance');");
            Sql("insert into Genres (Id, Name) values (4, 'Horror');");
            Sql("insert into Genres (Id, Name) values (5, 'War');");

        }
        
        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
