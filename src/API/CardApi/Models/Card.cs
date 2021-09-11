using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CardNo { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
        public string HolderName { get; set; }
        public int CVV2 { get; set; }
    }
}
