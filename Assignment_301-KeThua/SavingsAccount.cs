public class SavingsAccount : BankAccount
{
    public SavingsAccount(string accountNumber) : base(accountNumber)
    {
        AccountNumber = accountNumber;
    }
}