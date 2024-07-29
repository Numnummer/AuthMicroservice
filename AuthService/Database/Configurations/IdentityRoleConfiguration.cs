using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthMicroservice.Database.Configurations
{
    public class IdentityRoleConfiguration
        : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var developerRole = new IdentityRole()
            {
                Id="developer",
                Name = "developer",
                NormalizedName = "DEVELOPER"
            };
            var adminRole = new IdentityRole()
            {
                Id="admin",
                Name = "admin",
                NormalizedName = "ADMIN"
            };
            var userRole = new IdentityRole()
            {
                Id="user",
                Name = "user",
                NormalizedName = "USER"
            };
            builder.HasData(
            [
                developerRole,
                adminRole,
                userRole
            ]);
        }
    }
}
