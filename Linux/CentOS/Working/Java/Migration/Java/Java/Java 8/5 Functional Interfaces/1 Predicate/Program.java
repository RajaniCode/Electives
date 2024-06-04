import static java.lang.System.out;
import java.util.Arrays;
import java.util.List;
import java.util.function.Predicate;


class Program {
    public static void main(String... args) {
    	List<Integer> lst = Arrays.asList(1, 2, 3, 4, 5);
	
	out.println("Integers");
	evaluate(lst, n -> true);	
 	
	out.println("Odd Integers");
	evaluate(lst, n -> n % 2 != 0 );

	out.println("Even Integers");
	evaluate(lst, n -> n % 2 == 0);
    }

    static void evaluate(List<Integer> lst, Predicate<Integer> pred)
    {
	for(int i: lst) {
	    if(pred.test(i)) {
	        out.println(i);
	    }
    	}
    }  
}