package equation;

import java.util.Scanner;

public class ConsoleInput implements UserInput {
    private Scanner scanner = new Scanner(System.in);
    @Override
    public double nextDouble() {
        return scanner.nextDouble();
    }
}
