using AspCoreApplication2023.Models;

namespace WebApplication1.Models
{
    public class Memebershiptype
    {
        public int Id { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonth { get; set; }
        public float DiscountRate { get; set; }
        public ICollection<Customer>? customers { get; set; }
    }
}
