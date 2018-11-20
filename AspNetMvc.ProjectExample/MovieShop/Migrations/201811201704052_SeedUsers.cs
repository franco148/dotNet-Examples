namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'56c44674-bde1-4649-9cac-c99540d9e4b5', N'guest@extreme.com', 0, N'ALKV726kUmFDEibdu1ZvksZpILWMRE5IpHx+UMAQZfSmCgvDXmaqCDPjConxg7xSLg==', N'9ccf1544-581b-4650-ad75-e15027bf1ab5', NULL, 0, 0, NULL, 1, 0, N'guest@extreme.com')            
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cc67b733-755b-4c2e-80b7-7ceb43d28da7', N'admin@extreme.com', 0, N'AC9Oi5YZJpUVftrS4iROk/oGjyAcKy4allvLOp0Yc0ggflxLcxsVAyNlYQlToZblbA==', N'35259264-4f3b-4f24-b997-ae3b792b51c4', NULL, 0, 0, NULL, 1, 0, N'admin@extreme.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ee034348-f758-422d-99ef-ebbbd1f21a60', N'CanMaanageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cc67b733-755b-4c2e-80b7-7ceb43d28da7', N'ee034348-f758-422d-99ef-ebbbd1f21a60')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
