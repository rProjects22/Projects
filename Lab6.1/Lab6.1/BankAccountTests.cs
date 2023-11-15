using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests;

[TestClass]
public class BankAccountTests
{
    [TestMethod]
    public void Credit_WithValidAmount_UpdatesBalance()
    {
        // Arrange
        double creditAmount = 4.55;
        double expected = 7.44;
        BankAccount account = new("John Smith", 100);

        // Act
        account.Credit(creditAmount);

        // Assert
        double actual = account.Balance;
        Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
    }


    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double creditAmount = -100.00;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

        // Act and assert
        Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));

        // Assert is handled by ExpectedException
    }
}
