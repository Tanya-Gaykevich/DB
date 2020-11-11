using System.Collections.Generic;

namespace lab2.Model
{
    public partial class Service
    {
        public Service()
        {
            ServiceVoucher = new HashSet<ServiceVoucher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<ServiceVoucher> ServiceVoucher { get; set; }
    }
}
