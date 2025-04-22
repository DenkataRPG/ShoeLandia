namespace ShoeLandia.Data.Configurations
{
	using ShoeLandia.Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> appUser)
		{

            appUser
				.HasMany(e => e.Claims)
				.WithOne()
				.HasForeignKey(e => e.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);

			appUser
				.HasMany(e => e.Logins)
				.WithOne()
				.HasForeignKey(e => e.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Restrict);


			appUser
				.HasMany(x => x.Items)
				.WithOne(x => x.Owner)
				.HasForeignKey(x => x.OwnerId)
				.OnDelete(DeleteBehavior.Cascade);
			appUser
				.HasMany(x => x.Reviews)
				.WithOne(x => x.Author)
				.HasForeignKey(x => x.AuthorId)
				.OnDelete(DeleteBehavior.Cascade);

		}
    }
}
