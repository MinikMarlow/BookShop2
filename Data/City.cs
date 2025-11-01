namespace BookApp.Data;

public class City
{
	public int CityId { get; set; }

	public string? CityName { get; set; }

	public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
}
