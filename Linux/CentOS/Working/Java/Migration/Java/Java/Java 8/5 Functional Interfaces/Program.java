import static java.lang.System.out;
import java.util.List;
import java.util.ArrayList;
import java.util.Arrays;

interface FunctionalNumber {
    double getNumber();
}

class Program {
    static int sum = 0;
    public static void main(String... args) {
        FunctionalNumber number;

        number = () -> 123.45D;
        out.println("Number: " + number.getNumber());
        
	number = () -> Math.random() * 100;
        out.println("Random Number: " + number.getNumber());

 	//int sum = 100;
	List<Integer> listp = new ArrayList<Integer>();
        listp.add(555);
	listp.add(77);
        listp.add(3);
	out.println("List");
	listp.forEach(out::println);
	out.println("Sum");
	//listp.forEach(n -> out.printf("%d ", (sum += n)));	
	listp.forEach(n -> out.printf("%d%n", (sum += n)));
	out.println();

        List<Integer> lst = Arrays.asList(555, 77, 3); 	
	out.println("forEach printf:");       
        lst.forEach(i -> out.printf("%d ", i));  // lst.forEach(i -> System.out.printf("%d, ", i));
	out.println();
	out.println("forEach format:");
        lst.forEach(i -> out.format("%d ", i));  // lst.forEach(i -> System.out.format("%d, ", i));	
	
	out.println();
        out.println("format:");
	int i = 123;
 	int j = 456;
	out.format("i = %d, j = %d",  i, j); 
	out.println();
	out.println("printf:");
        out.printf("i = %d, j = %d",  i, j);
    }
}