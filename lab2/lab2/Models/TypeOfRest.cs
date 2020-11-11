using System;
using System.Collections.Generic;

namespace lab2.Model
{
    public partial class TypeOfRest
    {
        public TypeOfRest()
        {
            Voucher = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Limitation { get; set; }

        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
