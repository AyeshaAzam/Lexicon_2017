namespace PersonalRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonalstoPersonal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Salary = c.Int(nullable: false),
                        Position = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personals");
        }
    }
}
