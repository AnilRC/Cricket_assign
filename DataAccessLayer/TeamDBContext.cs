using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using Model;
using System.Data.Entity.Infrastructure;

namespace DataAccessLayer
{

   
    public class TeamDBContext:DbContext
    {
        public TeamDBContext()
        {
            Database.SetInitializer<TeamDBContext>(new DropCreateDatabaseIfModelChanges<TeamDBContext>());

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        //}
        public DbSet<TeamMembers> TeamMembersAll { get; set; }

        
    }
}
