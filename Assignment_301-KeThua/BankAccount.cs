public class BankAccount
{
    private string accountNumber;
    private decimal currentBalance;

    public decimal CurrentBalance { get => currentBalance; set => currentBalance = value; }
    public string AccountNumber { get => accountNumber; set => accountNumber = value; }

    public BankAccount(string accountNumber)
    {
        this.accountNumber = accountNumber;
    }


    public void Withdraw(decimal  amount)
    {
        currentBalance -= amount;
    }
}