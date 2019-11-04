
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataaccess.supermarket
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public string OfferDescription { get; set; }
        public string ShortDescription { get; set; }
        public bool Bogof { get; set; }
        public bool Tftpot { get; set; }
        public int? TftpotGroup { get; set; }
        public bool Discount { get; set; }
        public int? DiscountPercentage { get; set; }
    }
}
