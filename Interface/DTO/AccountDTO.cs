namespace Interface
{
    public record AccountDTO(
        long AccountID, 
        string Username, 
        string PasswordHash,
        string Email, 
        string Region, 
        string Interest, 
        DateTime Age, 
        long StockID);
}