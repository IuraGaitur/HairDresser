namespace GetHairDresser.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MYDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HairdresInfoDTOes", "photo", c => c.String());
            DropColumn("dbo.HairdresInfoDTOes", "photos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HairdresInfoDTOes", "photos", c => c.String());
            DropColumn("dbo.HairdresInfoDTOes", "photo");
        }
    }
}
