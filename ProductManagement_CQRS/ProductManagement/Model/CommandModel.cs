using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Model
{
    public class CommandModel
    {
        // COMMANDS:- CREATE , UPDATE , DELETE .
        // COMMAND MODEL WITH ALL THE VALIDATIONS:-

        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Product name must contain only letters, digits, and spaces.")]
        public string ProductName { get; set; }



        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int Qty { get; set; }



        [Range(0.0, float.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public float Price { get; set; }



        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Added by must contain only letters and spaces.")]
        public string AddedBy { get; set; }



        public DateTime AddedOn { get; set; }

    }
}
