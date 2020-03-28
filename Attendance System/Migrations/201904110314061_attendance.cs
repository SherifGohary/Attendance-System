namespace Attendance_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Late", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Late");
        }
    }
}
