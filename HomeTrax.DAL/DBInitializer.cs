using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using HomeTrax.BLL;

namespace HomeTrax.DAL
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            context.PropertyTypes.AddOrUpdate(
                t => t.PropertyTypeName,
                new PropertyType { PropertyTypeName = "Condo", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new PropertyType { PropertyTypeName = "Townhome", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new PropertyType { PropertyTypeName = "Single Family", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new PropertyType { PropertyTypeName = "Boathouse", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new PropertyType { PropertyTypeName = "Land", CreatedDate = DateTime.UtcNow, CreatedBy = "system" }
                );

            context.Roles.AddOrUpdate(
                t => t.RoleName,
                new Role { RoleName = "Buyer", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new Role { RoleName = "Seller", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new Role { RoleName = "Agent", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new Role { RoleName = "Administrator", CreatedDate = DateTime.UtcNow, CreatedBy = "system" }
                );

            context.Menus.AddOrUpdate(
                t => t.MenuName,
                new Menu { MenuName = "Properties", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new Menu { MenuName = "Agents", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new Menu { MenuName = "Wishlist", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new Menu { MenuName = "Offers", CreatedDate = DateTime.UtcNow, CreatedBy = "system" },
                new Menu { MenuName = "Settings", CreatedDate = DateTime.UtcNow, CreatedBy = "system" }
                );

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
