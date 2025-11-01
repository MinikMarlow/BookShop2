using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data;

public class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

		if (context == null || context.Cities == null)
		{
			throw new NullReferenceException("");
		}
		if (context.Cities.Any())
		{
			return;
		}
		context.Cities.AddRange(
			new City
			{
				CityName = "Чебоксары"
			},
			new City
			{
				CityName = "Казань"
			},
			new City
			{
				CityName = "Нижний Новгород"
			}
			);
		context.SaveChanges();

		var user1 = new ApplicationUser
		{
			UserName = "minikon2017@yandex.ru",
			Email = "minikon2017@yandex.ru",
			Surname = "Чапурина",
			Ima = "Татьяна",
			SecSurname = "Алексеевна",
			CityId = 1,
			NormalizedEmail = "MINIKON2017@YANDEX.RU",
			NormalizedUserName = "MINIKON2017@YANDEX.RU",
			LockoutEnabled = true,
		};

		var user2 = new ApplicationUser
		{
			UserName = "minikon2017@gmail.com",
			Email = "minikon2017@gmail.com",
			Surname = "Сидоров",
			Ima = "Иван",
			SecSurname = "Петрович",
			CityId = 1,
			NormalizedEmail = "MINIKON2017@GMAIL.COM",
			NormalizedUserName = "MINIKON2017@GMAIL.COM",
			LockoutEnabled = true,
		};

		var passwordHash = new PasswordHasher<ApplicationUser>();

		user1.PasswordHash = passwordHash.HashPassword(user1, ".9nR7Y$TE8qXe8.");
		user2.PasswordHash = passwordHash.HashPassword(user2, ".9nR7Y$TE8qXe8.");

		var role1 = new IdentityRole("Administrator");

		var role2 = new IdentityRole("User");


		context.Roles.Add(role1);
		context.Roles.Add(role2);
		context.Users.Add(user1);
		context.Users.Add(user2);
		context.SaveChanges();


		context.UserRoles.Add(
			new IdentityUserRole<string>
			{
				RoleId = role1.Id,
				UserId = user1.Id,
			}
			);
		context.UserRoles.Add(
		   new IdentityUserRole<string>
		   {
			   RoleId = role2.Id,
			   UserId = user2.Id,
		   }
		   );

		context.SaveChanges();
	}
}
