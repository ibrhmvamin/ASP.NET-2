using System.ComponentModel.DataAnnotations;

namespace ASP.NET_2.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required,MinLength(1)]
        public string Description {  get; set; }

        [Required,Range(0.01,double.MaxValue,ErrorMessage ="Price can not be less or equal to 0")]
        public double Price { get; set; }

        [Required,Range(0, double.MaxValue, ErrorMessage = "Discount can not be less than 0")]
        public double Discount { get; set; }
    }
}
