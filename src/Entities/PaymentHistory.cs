namespace web_back.Entities
{
    public class PaymentHistory
    {
        public PaymentHistory() { }
        public long Id { get; set; }
        public User User { get; set; }
        public TypePayment PaymentType { get; set; }
        public DateTime? PaymentAt { get; set; }
        public double Amount { get; set; }
        public Boolean IsPayment {  get; set; }


    }
}
