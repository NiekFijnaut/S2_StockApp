namespace Interface
{
    public record AccountDTO(
        int? AccountID, 
        string Username, 
        string PasswordHash,
        string Email, 
        string Region, 
        string Interest, 
        DateTime Age);
}