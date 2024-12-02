
namespace WebApplication1.Models.DomainModels
{
    public class Memebershiptype
    {
        public Guid Id { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonth { get; set; }
        public float DiscountRate { get; set; }
        public ICollection<Customer>? customers { get; set; }
    }
}
