//Xây dựng một lớp cơ sở "BankAccount" (Tài khoản ngân hàng) với thuộc tính "accountNumber" (số tài khoản) và phương thức "Withdraw" (rút tiền). Tạo các lớp con "CheckingAccount" (Tài khoản thanh toán) và "SavingsAccount" (Tài khoản tiết kiệm) kế thừa từ lớp "BankAccount" và triển khai phương thức "Withdraw" cho từng lớp con, trong đó tài khoản thanh toán cho phép rút tiền mà không cần kiểm tra số dư, tài khoản tiết kiệm yêu cầu kiểm tra số dư trước khi rút tiền.

using System.Linq;

internal class Program
{
    static List<BankAccount> accounts = [];
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("quan ly tai khoan ngan hang");
            Console.WriteLine("1. tao tai khoan thanh toan");
            Console.WriteLine("2. tao tai khoan tiet kiem");
            Console.WriteLine("3. gui tien");
            Console.WriteLine("4. rut tien");
            Console.WriteLine("5. xem thong tin tai khoan");
            Console.WriteLine("0. thoat");
            int choice = InputCheck.Int("moi chon chuc nang: ");
            switch (choice)
            {
                case 1:
                    Console.WriteLine("tao tai khoan thanh toan");
                    string input = InputCheck.String("nhap so tai khoan: ");
                    CheckingAccount checkingAccount = new(input);
                    var account = accounts.FirstOrDefault(x => x.AccountNumber == input);
                    if (account != null)
                    {
                        Console.WriteLine("tai khoan da ton tai");
                        break;        
                    }
                    accounts.Add(checkingAccount);
                    break;
                case 2:
                    Console.WriteLine("tao tai khoan tiet kiem");
                    input = InputCheck.String("nhap so tai khoan: ");
                    SavingsAccount savingsAccount = new(input);
                    account = accounts.FirstOrDefault(x => x.AccountNumber == input);
                    if (account != null)
                    {
                        Console.WriteLine("tai khoan da ton tai");
                        break;        
                    }
                    accounts.Add(savingsAccount);
                    break;
                case 3:
                    Console.WriteLine("gui tien");
                    PrintAccount();
                    input = InputCheck.String("chon tai khoan de gui tien");
                    account = accounts.FirstOrDefault(x => x.AccountNumber == input);
                    if (account != null)
                    {
                        account.CurrentBalance += InputCheck.Decimal("nhap so tien gui: ");
                    }
                    else
                    {
                        Console.WriteLine("tai khoan khong ton tai");
                    }
                    break;
                case 4:
                    Console.WriteLine("rut tien");
                    PrintAccount();
                    input = InputCheck.String("chon tai khoan de rut tien");
                    account = accounts.FirstOrDefault(x => x.AccountNumber == input);
                    if (account == null)
                    {
                        Console.WriteLine("tai khoan khong ton tai");
                        break;
                    }
                    
                    decimal amount = InputCheck.Decimal("nhap so tien rut: ");
                    if (account is SavingsAccount && account.CurrentBalance < amount)
                    {
                        Console.WriteLine("so du khong du");
                        break;
                    }
                    account.Withdraw(amount);
                    Console.WriteLine("rut tien thanh cong");
                    break;
                case 5:
                    Console.WriteLine("xem thong tin tai khoan");
                    PrintAccount();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("chuc nang khong ton tai");
                    break;
            }
        }
    }

    static void PrintAccount()
    {
        Console.WriteLine("{0,-20}|{1,-50}|{2,-20}", "so tai khoan", "so du", "loai tai khoan");
        foreach (var item in accounts)
        {
            Console.WriteLine($"{item.AccountNumber,-20}|{item.CurrentBalance,-50}|{item.GetType().Name,-20}");
        }
    }
}