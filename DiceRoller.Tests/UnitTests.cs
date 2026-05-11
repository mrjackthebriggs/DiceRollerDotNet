using Xunit;
using DiceRollerLib;

namespace DiceRoller.Tests;

public class StaticTests{
    // theories allow test re-use with multiple inputs
    [Theory]
    [InlineData("2d6")]
    [InlineData("5d6")]
    [InlineData("2d12")]
    [InlineData("3d20")]
    [InlineData("3d20x")]
    [InlineData("2d6x")]
    public void TestDiceRollValidationReturnTrue(string val)
    {
    Assert.True(DiceRollerLib.DiceRoller.ValidityCheck(val),$"\'{val}\' Failed");
    }

    [Theory]
    [InlineData("2d6d5")]
    [InlineData("dick")]
    [InlineData("2dick5")]
    [InlineData("2dd5")]
    [InlineData("2dd5x")]
    [InlineData("2dick5x")]
    public void TestDiceRollValidationReturnFalse(string val)
    {
    Assert.False(DiceRollerLib.DiceRoller.ValidityCheck(val),$"\'{val}\' Failed");
    }
}

public class InstanceTests{

}
