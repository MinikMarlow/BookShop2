using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace BookApp.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(100, ErrorMessage = "{0} должно быть не менее {2} и не более {1} символов.", MinimumLength = 6)]
    public string? Surname { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "{0} должно быть не менее {2} и не более {1} символов.", MinimumLength = 2)]
    public string? Ima {  get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "{0} должно быть не менее {2} и не более {1} символов.", MinimumLength = 2)]
    public string? SecSurname { get; set; }
    [Required]
    public int? CityId { get; set; }
    public virtual City? City { get; set; }
}

