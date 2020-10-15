namespace Emailer
{
    public class EmailRecipient : Model
    {
        public string? Name { get; set; }
        
        public string? Email { get; set; }
        
        public Customer? Customer { get; set; }
    }
}