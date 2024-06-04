import java.util.List;
import java.util.ArrayList;

public class Java8Tester {
   public static void main(String args[]){
      List names = new ArrayList();

      names.add("Delta ");
      names.add("Alpha ");
      names.add("Epsilon ");
      names.add("Beta ");
      names.add("Gamma ");

      names.forEach(System.out::println);
   }
}