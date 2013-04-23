using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using HomeTrax.BLL;

namespace HomeTrax.DAL
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("DefaultConnection")
        { }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentProperty> AgentProperties { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAgent> ClientAgents { get; set; }
        public DbSet<ClientProperty> ClientProperties { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().HasKey(t => t.AgentId).Property(t => t.AgentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Agent>().Ignore(t => t.Page);

            modelBuilder.Entity<Client>().HasKey(t => t.ClientId).Property(t => t.ClientId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Client>().Ignore(t => t.Page);

            modelBuilder.Entity<AgentProperty>().HasKey(t => t.AgentPropertyId).Property(t => t.AgentPropertyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ClientAgent>().HasKey(t => t.ClientAgentId).Property(t => t.ClientAgentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<RoleMenu>().HasKey(t => t.RoleMenuId).Property(t => t.RoleMenuId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ClientProperty>().HasKey(t => t.ClientPropertyId).Property(t => t.ClientPropertyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<UserRole>().HasKey(t => t.UserRoleId).Property(t => t.UserRoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Criteria>().HasKey(t => t.CriteriaId).Property(t => t.CriteriaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Menu>().HasKey(t => t.MenuId).Property(t => t.MenuId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Property>().HasKey(t => t.PropertyId).Property(t => t.PropertyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PropertyType>().HasKey(t => t.PropertyTypeId).Property(t => t.PropertyTypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Role>().HasKey(t => t.RoleId).Property(t => t.RoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().HasKey(t => t.UserId).Property(t => t.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
