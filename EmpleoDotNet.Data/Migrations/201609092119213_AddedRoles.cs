using System.Linq;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoles : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Roles(Id, Name) values (1, 'Client') ");
            Sql("Insert into Roles(Id, Name) values (2, 'Moderator') ");
            Sql("Insert into UserRolesJoin(UserId,RoleId) Select Id, 1 from Users");
        }
        
        public override void Down()
        {
        }
    }
}


