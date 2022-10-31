using RecordingOfViolations.Models;
using System.ComponentModel.DataAnnotations;

namespace RecordingOfViolations.Annotations
{
    public class MyPriceAttribute : ValidationAttribute
    {

        public override bool IsValid(object objectPrice)
        {
            decimal price;

            if (objectPrice != null)
            {
                try
                {
                    bool result = decimal.TryParse(objectPrice.ToString(), out price);
                }
                catch
                {
                    return false;
                }

                return price > 0;
            }
            return false;
        }
    }
}
