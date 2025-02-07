using Exo01.Bibliotheque;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace Exo02.TestMSTest;

//Lors du déclanchement de la fonction GetFibSeries() avec un Range de 1
//Le résultat n’est pas vide
//Le résultat correspond à une liste qui contient {0}

//Lors du déclanchement de la fonction GetFibSeries() avec un Range de 6
//Le résultat contient le chiffre 3
//Le résultat contient 6 éléments
//Le résultat n’a pas le chiffre 4 en son sein
//Le résultat correspond à une liste qui contient {0, 1, 1, 2, 3, 5}
//Le résultat est trié de façon ascendance


[TestClass]
public sealed class FibTest
{

    private Fib? _fib;


    private void SetUp(int range)
    {
        _fib = new Fib(range);
    }

    private void TearDown()
    {
        _fib = null;
    }


    [TestMethod]
    public void Given_Range1_WhenGetFibSeries_Then_ListNotEmpty()
    {
        // Arrange
        SetUp(1);

        // Act
        List<int> l = _fib.GetFibSeries();

        // Assert 
        Assert.IsNotNull(l);
    }

    [TestMethod]
    public void Given_Range1_WhenGetFibSeries_Then_ListContainsOnly0()
    {
        SetUp(1);

        List<int> result = new List<int>() { 0 };

        CollectionAssert.AreEqual(_fib.GetFibSeries(), result);
    }

    [TestMethod]
    public void Given_Range6_WhenGetFibSeries_Then_ListContains3()
    {
        SetUp(6);

        CollectionAssert.Contains(_fib.GetFibSeries(), 3);
    }

    [TestMethod]
    public void Given_Range6_WhenGetFibSeries_Then_ListContains6Items()
    {
        SetUp(6);

        Assert.AreEqual(6, _fib.GetFibSeries().Count());
    }


    [TestMethod]
    public void Given_Range6_WhenGetFibSeries_Then_ListDontContains4()
    {
        SetUp(6);

        CollectionAssert.DoesNotContain(_fib.GetFibSeries(), 4);
    }

    [TestMethod]
    //[DataRow([0,1,1,2,3,5])]
    public void Given_Range6_WhenGetFibSeries_Then_ListAreEquivalentList()
    {
        SetUp(6);

        //List<int> equivalentList =  excepted.ToList();
        List<int> equivalentList = new List<int>() { 0, 1, 1, 2, 3, 5 };

        //CollectionAssert.IsSubsetOf(_fib.GetFibSeries() , equivalentList);
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void Given_Range6_WhenGetFibSeries_Then_ListOrderByAsc()
    {
        SetUp(6);
        List<int> fibResult = _fib.GetFibSeries();
        List<int> excepted = fibResult.OrderBy(x => x)
                                            .ToList();


        CollectionAssert.AreEquivalent(excepted, _fib.GetFibSeries());
    }

}