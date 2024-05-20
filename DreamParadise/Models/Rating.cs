#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace DreamParadise.Models;
public class RatingService
{

    //* ===========  rating validation ===============
        [Required]    
        public int Rating { get; set; }  


    //* ===========  Navigation property ===============
    public User? UserWhoRate {get;set;}



}
