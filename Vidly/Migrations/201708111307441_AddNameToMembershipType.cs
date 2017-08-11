namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 31));
            Sql("update MembershipTypes set Name = 'Pay As You Go' where id = 1");
            Sql("update MembershipTypes set Name = 'Montly' where id = 2");
            Sql("update MembershipTypes set Name = 'Quartelly' where id = 3");
            Sql("update MembershipTypes set Name = 'Annualy' where id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
