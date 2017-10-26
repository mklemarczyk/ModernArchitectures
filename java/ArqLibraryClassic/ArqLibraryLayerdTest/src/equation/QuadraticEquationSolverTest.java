package equation;

import org.junit.Test;

public class QuadraticEquationSolverTest {

    @Test
    public void shouldSolveQuadraticEquation()
    {
        TestUserInput input = new TestUserInput(
                new double[] { 1.0, 2.0, 3.0 }
        );
        TestUserOutput output = new TestUserOutput();

        QuadraticEquationSolver quadraticEquationSolver
                = new QuadraticEquationSolver(input, output);
        quadraticEquationSolver.execute();

        output.assertContains("Brak rozwiązań");

    }
}