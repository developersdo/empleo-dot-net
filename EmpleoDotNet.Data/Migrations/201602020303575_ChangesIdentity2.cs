namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesIdentity2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRolesJoin", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRolesJoin", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserRolesJoin", new[] { "UserId" });
            DropIndex("dbo.UserRolesJoin", new[] { "RoleId" });
            RenameColumn(table: "dbo.Claims", name: "User_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.Logins", name: "User_Id", newName: "IdentityUser_Id");
            RenameIndex(table: "dbo.Logins", name: "IX_User_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.Claims", name: "IX_User_Id", newName: "IX_IdentityUser_Id");
            AddColumn("dbo.UserRolesJoin", "IdentityRole_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserRolesJoin", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Users", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Claims", "UserId", c => c.String());
            AlterColumn("dbo.Tags", "Name", c => c.String());
            CreateIndex("dbo.UserRolesJoin", "IdentityRole_Id");
            CreateIndex("dbo.UserRolesJoin", "IdentityUser_Id");
            AddForeignKey("dbo.UserRolesJoin", "IdentityUser_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserRolesJoin", "IdentityRole_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRolesJoin", "IdentityRole_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRolesJoin", "IdentityUser_Id", "dbo.Users");
            DropIndex("dbo.UserRolesJoin", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserRolesJoin", new[] { "IdentityRole_Id" });
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Claims", "UserId");
            DropColumn("dbo.Users", "AccessFailedCount");
            DropColumn("dbo.Users", "LockoutEnabled");
            DropColumn("dbo.Users", "LockoutEndDateUtc");
            DropColumn("dbo.Users", "TwoFactorEnabled");
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.UserRolesJoin", "IdentityUser_Id");
            DropColumn("dbo.UserRolesJoin", "IdentityRole_Id");
            RenameIndex(table: "dbo.Claims", name: "IX_IdentityUser_Id", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Logins", name: "IX_IdentityUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Logins", name: "IdentityUser_Id", newName: "User_Id");
            RenameColumn(table: "dbo.Claims", name: "IdentityUser_Id", newName: "User_Id");
            CreateIndex("dbo.UserRolesJoin", "RoleId");
            CreateIndex("dbo.UserRolesJoin", "UserId");
            AddForeignKey("dbo.UserRolesJoin", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRolesJoin", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
