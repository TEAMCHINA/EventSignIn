namespace EventSignIn.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int GraduationYear { get; set; }
        public bool EmailOptIn { get; set; }
        public string Notes { get; set; }
    }
}