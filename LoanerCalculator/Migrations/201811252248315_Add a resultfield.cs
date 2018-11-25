namespace LoanerCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addaresultfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalculateModels", "Results", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalculateModels", "Results");
        }
    }
}
