#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using DreamParadise.Models;
namespace DreamParadise.Models;

public class RatingViewModel
{
    [Required(ErrorMessage = "Rating is Required.")]
    public int RatingService { get; set; }

    [Required(ErrorMessage = "Suggestion is Required.")]
    public string Suggestion { get; set; }

    [Required(ErrorMessage = "First name is Required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is Required.")]
    public string LastName { get; set; }
    
    
}
