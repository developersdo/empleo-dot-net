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
            var context = new EmpleadoContext();

            var users = context.Set<UserProfile>().ToList();
            foreach (var user in users)
            {
                Sql("Insert into UserRolesJoin(UserId,RoleId) values ('"+user.UserId+"', 1)");
            }
        }
        
        public override void Down()
        {
        }
    }
}


