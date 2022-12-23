using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShippingMark.Models
{
    public class CartonLabel
    {
        public int ID { get; set; }

        [Display(Name = "Carton Number")]
        [Required]
        public int CartonNumber { get; set; }

        [Display(Name = "Buyer Carton Number")]
        [Required]
        public int BuyerCartonNumber { get; set; }

        [Display(Name = "Style PPJ")]
        [Required]
        public int StylePPJ { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Fab")]
        public string Fab { get; set; }

        [Display(Name = "Color Name")]
        public string ColorName { get; set; }

        [Required]
        public int Col00 { get; set; }

        [Required]
        public int Col0 { get; set; }

        [Required]
        public int Col1 { get; set; }

        [Required]
        public int Col2 { get; set; }

        [Required]
        public int Col3 { get; set; }

        [Required]
        public int Col4 { get; set; }

        [Required]
        public int Col5 { get; set; }

        [Required]
        public int Col6 { get; set; }

        [Required]
        public int Col8 { get; set; }

        [Required]
        public int Col10 { get; set; }

        [Required]
        public int Col12 { get; set; }

        [Required]
        public int Col14 { get; set; }

        [Required]
        public int Col16 { get; set; }

        [Required]
        public int Col18 { get; set; }

        [Required]
        public int Col20 { get; set; }

        [Required]
        public int Col22 { get; set; }

        [Required]
        public int Col24 { get; set; }

        [Required]
        public int Col26 { get; set; }

        [Required]
        public int Col28 { get; set; }

        [Required]
        public int Col30 { get; set; }

        [Display(Name = "Total Quantity")]
        [Required]
        public int TotalQuantity { get; set; }

        [Display(Name = "Carton Quantity")]
        [Required]
        public int CartonQuantity { get; set; }

        [Display(Name = "Total Pieces")]
        [Required]
        public int TotalPieces { get; set; }

        [Display(Name = "Total Net Weight")]
        [Required]
        public double TotalNetWeight { get; set; }

        [Display(Name = "Total Gross Weight")]
        [Required]
        public double TotalGrossWeight { get; set; }

        [Display(Name = "Dimension")]
        [Required]
        public string Dimension { get; set; }
    }
}
