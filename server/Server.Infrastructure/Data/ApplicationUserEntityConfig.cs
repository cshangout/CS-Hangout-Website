using Common.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Infrastructure.Data;

public class ApplicationUserEntityConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Ignore(x => x.SecurityStamp);
        builder.Ignore(x => x.ConcurrencyStamp);
        builder.Ignore(x => x.PhoneNumber);
        builder.Ignore(x => x.PhoneNumberConfirmed);
        builder.Ignore(x => x.TwoFactorEnabled);
        builder.Ignore(x => x.LockoutEnd);
        builder.Ignore(x => x.LockoutEnabled);
        builder.Ignore(x => x.AccessFailedCount);

    }
}