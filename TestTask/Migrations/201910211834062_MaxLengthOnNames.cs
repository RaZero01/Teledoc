namespace TestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Client", "FirstName", c => c.String(maxLength: 50));
        }

        public override void Down()
        {
            AlterColumn("dbo.Client", "FirstName", c => c.String());
            AlterColumn("dbo.Client", "LastName", c => c.String());
        }
    }
}
