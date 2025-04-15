using Demo02TDD.Core;

namespace Demo02TDD.Tests;

[TestClass]
public class LeapTesterTests
{
    //RED 1
    [DataTestMethod]
    [DataRow(1200)]
    [DataRow(400)]
    public void TestLeap_400_ShouldBe_True(int year)
    {
        LeapTester lt = new();

        bool res = lt.IsLeap(year);

        Assert.IsTrue(res);
    }

    //RED 2
    [DataTestMethod]
    [DataRow(12)]
    [DataRow(404)]
    public void TestLeap_4_Not_100_ShouldBe_True(int year)
    {
        LeapTester lt = new();

        bool res = lt.IsLeap(year);

        Assert.IsTrue(res);
    }

    //RED 3
    [DataTestMethod]
    [DataRow(8000)]
    [DataRow(12000)]
    public void TestLeap_4000_ShouldBe_False(int year)
    {
        LeapTester lt = new();

        bool res = lt.IsLeap(year);

        Assert.IsFalse(res);
    }

    // RED 4
    [TestMethod]
    public void TestLeap_Others_ShouldBe_False()
    {
        LeapTester lt = new LeapTester();

        bool res = lt.IsLeap(1999);

        Assert.IsFalse(res);
    }
}
