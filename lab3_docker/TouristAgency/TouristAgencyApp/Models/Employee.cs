using System;
using System.Collections.Generic;

namespace TouristAgencyApp
{
    public partial class Employee
    {
        public Employee()
        {
            Voucher = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public int PositionId { get; set; }

        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
