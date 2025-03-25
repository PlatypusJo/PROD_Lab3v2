using Optimization.Interfaces;
using Optimization.QuadraticOptimization;

namespace Lab3Tests
{
    public class QuadraticOptimizationSolverTests
    {
        private const double accuracy = 0.09;

        [Fact]
        public void OptimizeTestOwnVariant()
        {
            // Arrange
            double[] expectedResult = { 52.2, 14.4 };

            // Act
            IQuadraticOptimizationSolver solver = new QuadraticOptimizationSolver();
            var realResult = solver.Optimize("-0.0001*x^2-0.0001*y^2+7*x+4*y", 3, 3, 200, 7, 1, 380);

            // Assert
            for (int i = 0; i < realResult.Length; i++)
                Assert.True(Math.Abs(expectedResult[i] - realResult[i]) < accuracy);
        }
    }
}