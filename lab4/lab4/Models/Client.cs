using System;
using System.Collections.Generic;

namespace lab4
{
    public partial class Client
    {
        public Client()
        {
            Voucher = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string PassportData { get; set; }

        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
