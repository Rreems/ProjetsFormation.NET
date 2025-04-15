using Exercice.Core;

namespace Exercices.MSTest;

[TestClass]
public class GradingCalculatorTests
{
    private GradingCalculator? _gradingCalculator;

    private void SetUp(int score, int attendancePercentage)
    {
        _gradingCalculator = new GradingCalculator()
        {
            Score = score,
            AttendancePercentage = attendancePercentage
        };
    }

    //Score : 95%, Présence : 90 ⇒ Note: A
    [TestMethod]
    public void WhenGetGrade_95_90_Then_A()
    {
        // Arrange
        //GradingCalculator _gradingCalculator = new GradingCalculator()
        //{
        //    Score = 95,
        //    AttendancePercentage = 90
        //};

        // équivalent avec une méthode SetUp
        SetUp(95, 90);

        // Act
        char c = _gradingCalculator.GetGrade();

        // Assert
        Assert.AreEqual('A', c);
    }

    //Score : 85%, Présence : 90 ⇒ Note: B
    [TestMethod]
    public void WhenGetGrade_85_90_Then_B()
    {
        SetUp(85, 90);
        char c = _gradingCalculator.GetGrade();
        Assert.AreEqual('B', c);
    }

    // Score : 65%, Présence : 90 => Note: C
    [TestMethod]
    public void WhenGetGrade_65_90_Then_C()
    {
        SetUp(65, 90);
        char c = _gradingCalculator.GetGrade();
        Assert.AreEqual('C', c);
    }

    // Score : 95%, Présence : 65 => Note: B
    [TestMethod]
    public void WhenGetGrade_95_65_Then_B()
    {
        SetUp(95, 65);
        char c = _gradingCalculator.GetGrade();
        Assert.AreEqual('B', c);
    }

    // Score : 95%, Présence : 55 => Note: F
    [TestMethod]
    public void WhenGetGrade_95_55_Then_F()
    {
        SetUp(95, 55);
        char c = _gradingCalculator.GetGrade();
        Assert.AreEqual('F', c);
    }

    // Score : 65%, Présence : 55 => Note: F
    [TestMethod]
    public void WhenGetGrade_65_55_Then_F()
    {
        SetUp(65, 55);
        char c = _gradingCalculator.GetGrade();
        Assert.AreEqual('F', c);
    }

    // Score : 50%, Présence : 90 => Note: F
    [TestMethod]
    public void WhenGetGrade_50_90_Then_F()
    {
        SetUp(50, 90);
        char c = _gradingCalculator.GetGrade();
        Assert.AreEqual('F', c);
    }

    [DataTestMethod]
    [DataRow(95, 90, 'A')]
    [DataRow(85, 90, 'B')]
    [DataRow(65, 90, 'C')]
    [DataRow(95, 65, 'B')]
    [DataRow(95, 55, 'F')]
    [DataRow(65, 55, 'F')]
    [DataRow(50, 90, 'F')]
    public void WhenGetGrade(int score, int attendancePct, char note)
    {
        SetUp(score, attendancePct);
        char c = _gradingCalculator.GetGrade();
        Assert.AreEqual(note, c);
    }
}
