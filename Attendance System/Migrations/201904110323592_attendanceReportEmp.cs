namespace Attendance_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attendanceReportEmp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Attend = c.DateTime(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.EmpReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttendId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendances", t => t.AttendId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.AttendId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpReports", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EmpReports", "AttendId", "dbo.Attendances");
            DropForeignKey("dbo.Attendances", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.EmpReports", new[] { "UserId" });
            DropIndex("dbo.EmpReports", new[] { "AttendId" });
            DropIndex("dbo.Attendances", new[] { "UserID" });
            DropTable("dbo.EmpReports");
            DropTable("dbo.Attendances");
        }
    }
}
