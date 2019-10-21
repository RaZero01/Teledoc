namespace TestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    INN = c.Int(nullable: false),
                    clientType = c.String(nullable: false),
                    DateOfRegister = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Enrollment",
                c => new
                {
                    EnrollmentID = c.Int(nullable: false, identity: true),
                    OrganizationID = c.Int(nullable: false),
                    ClientID = c.Int(nullable: false),
                    Payed = c.Int(),
                })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Organization", t => t.OrganizationID, cascadeDelete: true)
                .Index(t => t.OrganizationID)
                .Index(t => t.ClientID);

            CreateTable(
                "dbo.Organization",
                c => new
                {
                    OrganizationID = c.Int(nullable: false),
                    Name = c.String(maxLength: 50),
                    DepartmentID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.OrganizationID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);

            CreateTable(
                "dbo.Department",
                c => new
                {
                    DepartmentID = c.Int(nullable: false, identity: true),
                    Title = c.String(maxLength: 50),
                    Budget = c.Decimal(nullable: false, storeType: "money"),
                    StartDate = c.DateTime(nullable: false),
                    WorkerID = c.Int(),
                })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Worker", t => t.WorkerID)
                .Index(t => t.WorkerID);

            CreateTable(
                "dbo.Worker",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    LastName = c.String(nullable: false, maxLength: 50),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    HireDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Office",
                c => new
                {
                    WorkerID = c.Int(nullable: false),
                    Location = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.WorkerID)
                .ForeignKey("dbo.Worker", t => t.WorkerID)
                .Index(t => t.WorkerID);

            CreateTable(
                "dbo.OrganizationWorker",
                c => new
                {
                    OrganizationID = c.Int(nullable: false),
                    wORKERID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.OrganizationID, t.wORKERID })
                .ForeignKey("dbo.Organization", t => t.OrganizationID, cascadeDelete: true)
                .ForeignKey("dbo.Worker", t => t.wORKERID, cascadeDelete: true)
                .Index(t => t.OrganizationID)
                .Index(t => t.wORKERID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.OrganizationWorker", "wORKERID", "dbo.Worker");
            DropForeignKey("dbo.OrganizationWorker", "OrganizationID", "dbo.Organization");
            DropForeignKey("dbo.Enrollment", "OrganizationID", "dbo.Organization");
            DropForeignKey("dbo.Organization", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "WorkerID", "dbo.Worker");
            DropForeignKey("dbo.Office", "WorkerID", "dbo.Worker");
            DropForeignKey("dbo.Enrollment", "ClientID", "dbo.Client");
            DropIndex("dbo.OrganizationWorker", new[] { "wORKERID" });
            DropIndex("dbo.OrganizationWorker", new[] { "OrganizationID" });
            DropIndex("dbo.Office", new[] { "WorkerID" });
            DropIndex("dbo.Department", new[] { "WorkerID" });
            DropIndex("dbo.Organization", new[] { "DepartmentID" });
            DropIndex("dbo.Enrollment", new[] { "ClientID" });
            DropIndex("dbo.Enrollment", new[] { "OrganizationID" });
            DropTable("dbo.OrganizationWorker");
            DropTable("dbo.Office");
            DropTable("dbo.Worker");
            DropTable("dbo.Department");
            DropTable("dbo.Organization");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Client");
        }
    }
}
