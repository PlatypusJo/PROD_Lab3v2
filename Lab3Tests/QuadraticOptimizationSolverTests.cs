using QuadraticOptimizationSolver.DataModels;
using QuadraticOptimizationSolver.Interfaces;
using QuadraticOptimizationSolver.Solvers;

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
            IQuadraticOptimizationSolver<FunctionMinimizationDataModel> solver = new FunctionMinimizationSolver();
            FunctionMinimizationDataModel dataEntity = new("-0.0001*x^2-0.0001*y^2+7*x+4*y", 3, 3, 200, 7, 1, 380);

            // Act
            var actualResult = solver.Solve(dataEntity);

            // Assert
            for (int i = 0; i < actualResult.Length; i++)
                Assert.True(Math.Abs(expectedResult[i] - actualResult[i]) < accuracy);
        }
    }
}