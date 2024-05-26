#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Add this using statement to access NotMapped
using System.ComponentModel.DataAnnotations.Schema;
namespace DreamParadise.Models;
public class LoginUser
{


    //* ===========  Email validation ===============
    [Required(ErrorMessage ="Please enter your Email")]    
    public string LoginEmail { get; set; }  


    //* ======= Login Pssword validation ============
    [Required (ErrorMessage ="Please enter your password")]
    [DataType(DataType.Password)]
    public string LoginPassword { get; set; } 
}


