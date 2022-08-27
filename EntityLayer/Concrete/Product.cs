using EntityLayer.Concrete.CustomAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]

        [Required,MinLength(3,ErrorMessage = "{0} must be at least 3 characters"),
            MaxLength(20,ErrorMessage = "{0} must be a maximum of 20 characters")]
        public string? Name { get; set; }
        [StringLength(50)]
        [Required, MinLength(2, ErrorMessage = "{0} must be at least 2 characters"),
            MaxLength(10, ErrorMessage = "{0} must be a maximum of 10 characters")]
        public string? Code { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d{0,10}$",ErrorMessage = "{0} must be greater than 0.")]
        public int Price { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d{0,2}$", ErrorMessage = "{0}Must be greater than 0.")]
        public int TaxRate { get; set; }

        [Required]
        public bool Availability { get; set; }
        [Date(ErrorMessage = "Date entered can be in the range of + / - 10 years from today")]
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; } = DateTime.Now.Date;
        [Date(ErrorMessage = "Date entered can be in the range of + / - 10 years from today")]
        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; } = DateTime.Now.Date;
    }
}
