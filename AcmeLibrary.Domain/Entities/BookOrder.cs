using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Domain.Entities
{
    public class BookOrder
    {
        public string Isbn { get; set; } = null!;
        public Guid ClientId { get; set; }
        public int Quantity { get; set; }
    }
}
