package equation;

import java.util.Scanner;


public class QuadraticEquationSolver {
    private UserInput input;
    private UserOutput output;

    public QuadraticEquationSolver(UserInput input, UserOutput output) {

        this.input = input;
        this.output = output;
    }

    public static void main(String[] args) {
        UserInput input = new ConsoleInput();
        UserOutput output = new ConsoleOutput();

        new QuadraticEquationSolver(input, output).execute();
    }

    public void execute() {
        output.print("Podaj a: ");
        double a = input.nextDouble();

        output.print("Podaj b: ");
        double b = input.nextDouble();
        output.print("Podaj c: ");
        double c = input.nextDouble();

        double delta = b * b - 4 * a * c;

        if (delta < 0) {
            output.println("Brak rozwiązań");
        } else if (delta == 0) {
            double x = - b / (2 * a);
            output.println(String.format("Jedno rozwiązanie x = %1.2f", x));
        } else {
            double x1 = (-b - Math.sqrt(delta)) / (2 * a);
            double x2 = (-b + Math.sqrt(delta)) / (2 * a);
            output.println(String.format("Dwa rozwiązania: x1 = %1.2f x2 = %1.2f", x1, x2));
        }

    }
}
