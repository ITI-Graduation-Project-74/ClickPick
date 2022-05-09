namespace ClickPick.Models
{
    public class UsersWithorder
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime OrderDateTime { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }

        public string? Note { get; set; }

        public string? BillingAddress { get; set; }
        public string Method { get; set; }
        public string CouponName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int Percentage { get; set; }

    }
}
