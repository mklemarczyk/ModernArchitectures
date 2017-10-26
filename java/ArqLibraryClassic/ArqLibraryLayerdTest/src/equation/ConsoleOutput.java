package equation;

public class ConsoleOutput implements UserOutput {
    @Override
    public void print(String text) {
        System.out.print(text);
    }

    @Override
    public void println(String text) {
        System.out.print(text);
    }
}
