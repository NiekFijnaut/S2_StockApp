using Business;
using Interface;
using System.Text.RegularExpressions;
using Unit_Tests.STUB;

namespace Unit_Tests.Tests
{
    [TestClass]
    public class AccountRegisterTest
    {
        [TestMethod]
        public void AddAccount()
        {
            // Arrange
            AccountSTUB accountSTUB = new AccountSTUB();
            AccountContainer accountContainer = new AccountContainer(accountSTUB);
            AccountDTO expected = new AccountDTO(
                1,
                "piet",
                "87654321",
                "rik@fontys.nl",
                "Europe (Northern Europe, Southern Europe, Eastern Europe, Western Europe)",
                "Real Estate",
                new DateTime(1998, 10, 12)
            );
            Account account = new Account(expected.AccountID, expected.Username, expected.PasswordHash, expected.Email, expected.Region, expected.Interest, expected.Age);
           
            // Act
            accountContainer.CreateAccount(account);

            // Assert
            Assert.AreEqual(expected.AccountID, accountSTUB.CreateFakeAccountDTO.AccountID);
            Assert.AreEqual(expected.Username, accountSTUB.CreateFakeAccountDTO.Username);
            Assert.AreEqual(expected.PasswordHash, accountSTUB.CreateFakeAccountDTO.PasswordHash);
            Assert.AreEqual(expected.Email, accountSTUB.CreateFakeAccountDTO.Email);
            Assert.AreEqual(expected.Region, accountSTUB.CreateFakeAccountDTO.Region);
            Assert.AreEqual(expected.Interest, accountSTUB.CreateFakeAccountDTO.Interest);
            Assert.AreEqual(expected.Age, accountSTUB.CreateFakeAccountDTO.Age);
        }

        public void AddAccount1()
        {
            // Arrange
            AccountSTUB accountSTUB = new AccountSTUB();
            AccountContainer accountContainer = new AccountContainer(accountSTUB);
            AccountDTO expected = new AccountDTO(
                1,
                "rik",
                "7654321",
                "rik@fontys.nl",
                "Europe (Northern Europe, Southern Europe, Eastern Europe, Western Europe)",
                "Real Estate",
                new DateTime(1998, 10, 12)
            );
            Account account = new Account(expected.AccountID, expected.Username, expected.PasswordHash, expected.Email, expected.Region, expected.Interest, expected.Age);

            // Act
            accountContainer.CreateAccount(account);

            // Assert
            Assert.AreEqual(expected.AccountID, accountSTUB.CreateFakeAccountDTO.AccountID);
            Assert.AreEqual(expected.Username, accountSTUB.CreateFakeAccountDTO.Username);
            Assert.IsTrue(account.PasswordHash.Length >= 8, "Password must be at least 8 characters");
            Assert.AreEqual(expected.Email, accountSTUB.CreateFakeAccountDTO.Email);
            Assert.AreEqual(expected.Region, accountSTUB.CreateFakeAccountDTO.Region);
            Assert.AreEqual(expected.Interest, accountSTUB.CreateFakeAccountDTO.Interest);
            Assert.AreEqual(expected.Age, accountSTUB.CreateFakeAccountDTO.Age);
        }

        public void AddAccount2()
        {
            // Arrange
            AccountSTUB accountSTUB = new AccountSTUB();
            AccountContainer accountContainer = new AccountContainer(accountSTUB);
            AccountDTO expected = new AccountDTO(
                1,
                "rik",
                "87654321",
                "rikfontys.nl",
                "Europe (Northern Europe, Southern Europe, Eastern Europe, Western Europe)",
                "Real Estate",
                new DateTime(1998, 10, 12)
            );
            Account account = new Account(expected.AccountID, expected.Username, expected.PasswordHash, expected.Email, expected.Region, expected.Interest, expected.Age);

            // Act
            accountContainer.CreateAccount(account);

            // Assert
            Assert.AreEqual(expected.AccountID, accountSTUB.CreateFakeAccountDTO.AccountID);
            Assert.AreEqual(expected.Username, accountSTUB.CreateFakeAccountDTO.Username);
            Assert.AreEqual(expected.PasswordHash, accountSTUB.CreateFakeAccountDTO.PasswordHash);
            Assert.IsTrue(expected.Email.Contains('@'), "Email must contain @");
            Assert.AreEqual(expected.Region, accountSTUB.CreateFakeAccountDTO.Region);
            Assert.AreEqual(expected.Interest, accountSTUB.CreateFakeAccountDTO.Interest);
            Assert.AreEqual(expected.Age, accountSTUB.CreateFakeAccountDTO.Age);
        }

        public void AddAccount3()
        {
            // Arrange
            AccountSTUB accountSTUB = new AccountSTUB();
            AccountContainer accountContainer = new AccountContainer(accountSTUB);
            AccountDTO expected = new AccountDTO(
                1,
                "rik",
                "87654321",
                "rik@fontys.nl",
                "Europe (Northern Europe, Southern Europe, Eastern Europe, Western Europe)",
                "Real Estate",
                new DateTime(2010, 10, 12)
            );
            Account account = new Account(expected.AccountID, expected.Username, expected.PasswordHash, expected.Email, expected.Region, expected.Interest, expected.Age);

            // Act
            accountContainer.CreateAccount(account);

            // Assert
            Assert.AreEqual(expected.AccountID, accountSTUB.CreateFakeAccountDTO.AccountID);
            Assert.AreEqual(expected.Username, accountSTUB.CreateFakeAccountDTO.Username);
            Assert.AreEqual(expected.PasswordHash, accountSTUB.CreateFakeAccountDTO.PasswordHash);
            Assert.AreEqual(expected.Email, accountSTUB.CreateFakeAccountDTO.Email);
            Assert.AreEqual(expected.Region, accountSTUB.CreateFakeAccountDTO.Region);
            Assert.AreEqual(expected.Interest, accountSTUB.CreateFakeAccountDTO.Interest);
            int age = DateTime.Today.Year - expected.Age.Year;
            Assert.IsTrue(age >= 18, "Minimum age requirement is 18 years.");
        }

        public void AddAccount4()
        {
            // Arrange
            AccountSTUB accountSTUB = new AccountSTUB();
            AccountContainer accountContainer = new AccountContainer(accountSTUB);
            AccountDTO expected = new AccountDTO(
                1,
                "piet",
                "87654321",
                "rik@fontys.nl",
                "Europe (Northern Europe, Southern Europe, Eastern Europe, Western Europe)",
                "Real Estate",
                new DateTime(1998, 10, 12)
            );
            Account account = new Account(expected.AccountID, expected.Username, expected.PasswordHash, expected.Email, expected.Region, expected.Interest, expected.Age);

            // Act
            accountContainer.CreateAccount(account);

            // Assert
            Assert.AreEqual(expected.AccountID, accountSTUB.CreateFakeAccountDTO.AccountID);
            Assert.AreEqual(expected.Username, accountSTUB.CreateFakeAccountDTO.Username);
            Assert.AreEqual(expected.PasswordHash, accountSTUB.CreateFakeAccountDTO.PasswordHash);
            Assert.AreEqual(expected.Email, accountSTUB.CreateFakeAccountDTO.Email);
            Assert.AreEqual(expected.Region, accountSTUB.CreateFakeAccountDTO.Region);
            Assert.AreEqual(expected.Interest, accountSTUB.CreateFakeAccountDTO.Interest);
            Assert.AreEqual(expected.Age, accountSTUB.CreateFakeAccountDTO.Age);
        }

        [TestMethod]
        public Account Login()
        {
            // Arrange
            string validUsername = "rik";
            string validPassword = "87654321";
            AccountSTUB accountSTUB = new AccountSTUB();
            AccountContainer accountContainer = new AccountContainer(accountSTUB);
            Account expected = accountContainer.GetAccount(validPassword, validUsername);

            // Act
            AccountDTO result = accountSTUB.Login(validPassword, validUsername);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.AccountID, result.AccountID);
            Assert.AreEqual(expected.Username, result.Username);
            Assert.AreEqual(expected.PasswordHash, result.PasswordHash);
            Assert.AreEqual(expected.Email, result.Email);
            Assert.AreEqual(expected.Region, result.Region);
            Assert.AreEqual(expected.Interest, result.Interest);
            Assert.AreEqual(expected.Age, result.Age);
            return expected;
        }
    }
}