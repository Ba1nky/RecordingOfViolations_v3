using RecordingOfViolations.Models;
using System.ComponentModel.DataAnnotations;

namespace RecordingOfViolations.Annotations
{
    public class NotAllowedAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Violation violation = value as Violation;

            if (violation.Policeman == violation.Offender && 
                violation.Date < DateTime.Now.AddDays(-30))
            {
                return false;
            }
            return true;
        }
    }

}

