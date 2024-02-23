namespace CustomValidationWebApplication.Model
{
    public class Customer
    {
        public string FullName { get; init; } = default!;
        public string Email { get; init; } = default!;
        public int Age { get; set; }
    }
}
