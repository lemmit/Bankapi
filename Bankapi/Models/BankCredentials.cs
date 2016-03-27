namespace Bankapi.Models
{
    public class BankCredentials
    {
        public string Login { get; }
        public string Password { get; }
        public string AccountNumber { get; }
        public BankCredentials(string login, string password, string bankAccountNumber)
        {
            Login = login;
            Password = password;
            AccountNumber = bankAccountNumber;
        }
    }
}