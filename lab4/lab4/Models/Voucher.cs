using System;
using System.Collections.Generic;

namespace lab4
{
    public partial class Voucher
    {
        public Voucher()
        {
            ServiceVoucher = new HashSet<ServiceVoucher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HotelId { get; set; }
        public int TypeOfRestId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual TypeOfRest TypeOfRest { get; set; }
        public virtual ICollection<ServiceVoucher> ServiceVoucher { get; set; }
    }
}
