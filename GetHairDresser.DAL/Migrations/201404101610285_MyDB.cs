namespace GetHairDresser.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HairdresInfoDTOes",
                c => new
                    {
                        HairdressInfoID = c.Int(nullable: false),
                        map_data = c.String(),
                        rating = c.Double(nullable: false),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.HairdressInfoID)
                .ForeignKey("dbo.UserDTOes", t => t.HairdressInfoID)
                .Index(t => t.HairdressInfoID);
            
            CreateTable(
                "dbo.UserDTOes",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        age = c.Int(nullable: false),
                        gender = c.String(),
                        location = c.String(),
                        typeClient = c.String(),
                        UserFacebook = c.String(),
                        UserGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.JobAppointmentDTOes",
                c => new
                    {
                        JobAppID = c.Int(nullable: false, identity: true),
                        DateJob = c.DateTime(nullable: false),
                        HourJob = c.Time(nullable: false, precision: 7),
                        Status = c.Int(nullable: false),
                        Hairdresser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.JobAppID)
                .ForeignKey("dbo.UserDTOes", t => t.Hairdresser_UserId)
                .Index(t => t.Hairdresser_UserId);
            
            CreateTable(
                "dbo.MessageDTOes",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        receiverID_UserId = c.Int(),
                        senderID_UserId = c.Int(),
                        UserDTO_UserId = c.Int(),
                        UserDTO_UserId1 = c.Int(),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.UserDTOes", t => t.receiverID_UserId)
                .ForeignKey("dbo.UserDTOes", t => t.senderID_UserId)
                .ForeignKey("dbo.UserDTOes", t => t.UserDTO_UserId)
                .ForeignKey("dbo.UserDTOes", t => t.UserDTO_UserId1)
                .Index(t => t.receiverID_UserId)
                .Index(t => t.senderID_UserId)
                .Index(t => t.UserDTO_UserId)
                .Index(t => t.UserDTO_UserId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HairdresInfoDTOes", "HairdressInfoID", "dbo.UserDTOes");
            DropForeignKey("dbo.MessageDTOes", "UserDTO_UserId1", "dbo.UserDTOes");
            DropForeignKey("dbo.MessageDTOes", "UserDTO_UserId", "dbo.UserDTOes");
            DropForeignKey("dbo.MessageDTOes", "senderID_UserId", "dbo.UserDTOes");
            DropForeignKey("dbo.MessageDTOes", "receiverID_UserId", "dbo.UserDTOes");
            DropForeignKey("dbo.JobAppointmentDTOes", "Hairdresser_UserId", "dbo.UserDTOes");
            DropIndex("dbo.HairdresInfoDTOes", new[] { "HairdressInfoID" });
            DropIndex("dbo.MessageDTOes", new[] { "UserDTO_UserId1" });
            DropIndex("dbo.MessageDTOes", new[] { "UserDTO_UserId" });
            DropIndex("dbo.MessageDTOes", new[] { "senderID_UserId" });
            DropIndex("dbo.MessageDTOes", new[] { "receiverID_UserId" });
            DropIndex("dbo.JobAppointmentDTOes", new[] { "Hairdresser_UserId" });
            DropTable("dbo.MessageDTOes");
            DropTable("dbo.JobAppointmentDTOes");
            DropTable("dbo.UserDTOes");
            DropTable("dbo.HairdresInfoDTOes");
        }
    }
}
