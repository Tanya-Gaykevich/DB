using System;
using System.Collections.Generic;

namespace TouristAgencyApp
{
    public partial class Hotel
    {
        public Hotel()
        {
            Voucher = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public int NumberOfStars { get; set; }
        public string ContactPerson { get; set; }
        public string HotelPhoto { get; set; }
        public string RoomFoto { get; set; }

        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
