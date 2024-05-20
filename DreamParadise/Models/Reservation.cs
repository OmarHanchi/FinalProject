#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DreamParadise.Models;
public class Reservation
{


    //* =========== CheckIn Date validation ===============
    [Required(ErrorMessage ="please enter the CheckIn date")]
    [FutureDate]
    public DateTime CheckIn { get; set; }
    

    //* =========== CheckOut Date validation ===============

    [Required(ErrorMessage ="please enter the CheckOut date")]
    [FutureDate]
    public DateTime CheckOut { get; set; }  

    //* =========== chosen room validation ===============
    [Required]
    public string Room {get;set;}

    //* ===========  Price validation ===============
    [Required]
    public int  Price {get;set;}



    //* ===========   Navigation ===============
    public User? UserWhoReserved {get;set;}




}


    //! =========== Future date attribute creation   ===============

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value ==null )
        {
            return ValidationResult.Success;
        }
        DateTime SubmittedDate = (DateTime) value;
        if (SubmittedDate < DateTime.Now)
        {
            return new ValidationResult ("Please enter a date in the future ! ");

        }
        return ValidationResult.Success;
    }
  
}



    //! =========== Checkout  date range  attribute creation   ===============
     public class DateRangeAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public DateRangeAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var endDate = (DateTime?)value;
            var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);

            if (startDateProperty == null)
            {
                return new ValidationResult($"Unknown property: {_startDatePropertyName}");
            }

            var startDate = (DateTime?)startDateProperty.GetValue(validationContext.ObjectInstance);

            if (endDate.HasValue && startDate.HasValue && endDate <= startDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
