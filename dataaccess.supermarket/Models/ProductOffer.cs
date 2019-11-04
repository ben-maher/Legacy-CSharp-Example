using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataaccess.supermarket
{
    public class ProductOffer
    {
        [Key]
        public int OfferId { get; set; }
        public int ProductId { get; set; }
    }
}
