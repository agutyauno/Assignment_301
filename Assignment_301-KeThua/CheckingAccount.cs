public class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountNumber) : base(accountNumber)
    {
        AccountNumber = accountNumber;
    }
}