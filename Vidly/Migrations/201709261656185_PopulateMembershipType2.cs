namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType2 : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT membershiptypes ON");
            Sql("insert into membershiptypes (Id, SignUpFee, DurationInMonths, DiscountRate) values (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");
            Sql("SET IDENTITY_INSERT membershiptypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
