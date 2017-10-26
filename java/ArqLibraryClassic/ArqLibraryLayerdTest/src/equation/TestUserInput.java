package equation;

public class TestUserInput implements UserInput {

    private double[] nextDoubles;
    int current = 0;

    public TestUserInput(double[] nextDoubles) {

        this.nextDoubles = nextDoubles;
    }

    @Override
    public double nextDouble() {
        return nextDoubles[current++];
    }
}
