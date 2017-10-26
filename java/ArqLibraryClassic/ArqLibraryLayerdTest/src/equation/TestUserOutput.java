package equation;

import org.junit.Assert;

import java.util.ArrayList;
import java.util.List;

public class TestUserOutput implements UserOutput {
    private List<String> history = new ArrayList<>();

    @Override
    public void print(String text) {
        history.add(text);
    }

    @Override
    public void println(String text) {
        history.add(text);
    }

    public void assertContains(String text) {
        for (String element : history) {
            if (element.equals(text)) {
                Assert.assertTrue(true);
                return;
            }
        }

        Assert.fail("History doesn't contain: " + text);
    }
}
