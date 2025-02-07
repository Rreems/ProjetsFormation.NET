using Xunit;

namespace Exo01.Tests;


public sealed class TestGradingXUnit : IDisposable
{
    private GradingCalculator? _gradinCalculator;


    // SetUp
    private TestGradingXUnit()
    {
        _gradinCalculator = new GradingCalculator();
    }

    // TearDown
    void IDisposable.Dispose()
    {
        _gradinCalculator = null;
    }


    [Theory]
    [InlineData(95, 90, 'A')]
    [InlineData(85, 90, 'B')]
    [InlineData(65, 90, 'C')]
    [InlineData(95, 65, 'B')]
    [InlineData(95, 55, 'F')]
    [InlineData(65, 55, 'F')]
    [InlineData(50, 90, 'F')]
    public void WhenGetGrade_Score_AttendancePercentage_Then_Grading(int score, int attendancePercentage, char grading)
    {
        // Arrange
        _gradinCalculator.Score = score;
        _gradinCalculator.AttendancePercentage = attendancePercentage;

        // Act
        var result = _gradinCalculator.GetGrade();

        // Assert
        Assert.Equal(grading, result);
    }


}
