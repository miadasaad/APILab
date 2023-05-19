
using System.ComponentModel.DataAnnotations;

namespace LabOne.validators
{
    public class MustBeInPastAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is DateTime prodDate && prodDate < DateTime.Now;
        }
    }
}
