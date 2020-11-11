namespace lab2.Model
{
    public partial class ServiceVoucher
    {
        public int Id { get; set; }
        public string ReservationMark { get; set; }
        public string PaymentMark { get; set; }
        public int VoucherId { get; set; }
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
        public virtual Voucher Voucher { get; set; }
      
    }
}
