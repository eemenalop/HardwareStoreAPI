using System.ComponentModel.DataAnnotations;

namespace billingSystem.Dtos.CustomersDtos
{
    public class UpdateCustomerDto
    {
        public string name { get; set; }

        public string email { get; set; }
    }
}
