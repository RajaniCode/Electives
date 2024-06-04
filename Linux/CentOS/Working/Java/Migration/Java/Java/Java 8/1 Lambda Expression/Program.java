import static java.lang.System.out;

class Program {

    interface Mathematics {
        int maths(int x, int y);
    }

    interface Greetings {
        void greeting(String message);
    } 

    int calculation(int x, int y, Mathematics m) {
        return m.maths(x, y);
    }

    public static void main(String... args)
    {
    	Program prgm = new Program();
        
        // Lambda Expression
    	Mathematics addition = (int x, int y) -> x + y;
     	Mathematics subtraction = (x, y) -> x - y;
    	Mathematics multiplication = (x, y) -> { return x * y; };
    	Mathematics division = (x, y) -> x / y;

        out.println("10 + 5 = " + prgm.calculation(10, 5, addition));
        out.println("10 - 5 = " + prgm.calculation(10, 5, subtraction));
        out.println("10 * 5 = " + prgm.calculation(10, 5, multiplication));
        out.println("10 / 5 = " + prgm.calculation(10, 5, division));
        
 	// Lambda Expression
    	Greetings greet1 = (message) -> out.println("Hello " + message);
	Greetings greet2 = message -> out.println("What's " + message);

        greet1.greeting("World!");
        greet2.greeting("up?");
    }
}