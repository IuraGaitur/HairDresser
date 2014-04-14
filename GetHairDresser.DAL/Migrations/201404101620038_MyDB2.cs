namespace GetHairDresser.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HairdresInfoDTOes", "photos", c => c.String());
            DropColumn("dbo.HairdresInfoDTOes", "photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HairdresInfoDTOes", "photo", c => c.String());
            DropColumn("dbo.HairdresInfoDTOes", "photos");
        }
    }
}
