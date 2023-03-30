namespace Interface
{
    public record AccountDTO(
        long AccountID, 
        string Username, 
        string Email, 
        string Region, 
        string Interest, 
        DateTime Age, 
        long StockID);
}