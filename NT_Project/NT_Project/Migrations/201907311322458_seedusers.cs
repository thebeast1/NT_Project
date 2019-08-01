namespace NT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Bio], [Photo_Url], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5569e555-ff48-4269-81f5-a1c6e517690b', NULL, NULL, NULL, N'Admin@gmail.com', 0, N'AEa2VYBKnbC6/6SY8i922Jx/uun0Q55hzD5qtxo/rTZ1deThP4ML3swsNl3uEb0YHw==', N'c183ab14-c0f8-4eab-9ff6-0602b3514855', NULL, 0, 0, NULL, 1, 0, N'Admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Bio], [Photo_Url], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9dfa2801-3fb3-4545-b25f-8ad392f31e2a', N'karim', NULL, NULL, N'karim_ehabb@gmail.com', 0, N'ADnTl2jzmuPNZsTt8AHwIiGa+V86dMML8CzQGlfBajC/Q2TWqxIU48OgsHM36UpNXA==', N'846343b9-c655-415e-ade6-4f2f8af15b92', NULL, 0, 0, NULL, 1, 0, N'karim_ehabb@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Bio], [Photo_Url], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd8700c8e-bd7d-4411-bbc2-4fe03386548e', NULL, NULL, NULL, N'lala@gmail.com', 0, N'AJOPDfL077MT72hbtr5MA0ydg224Y+z5iic9XmxQcQPYRRDUEX8w/m7CmQfZY2k41w==', N'aef1a67b-f753-4fc9-8964-51216f33f4f9', NULL, 0, 0, NULL, 1, 0, N'lala@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9dd5b0d2-53eb-4b26-8c71-f2a4361690b1', N'CanShowUsers')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5569e555-ff48-4269-81f5-a1c6e517690b', N'9dd5b0d2-53eb-4b26-8c71-f2a4361690b1')

");
        }
        
        public override void Down()
        {
        }
    }
}
