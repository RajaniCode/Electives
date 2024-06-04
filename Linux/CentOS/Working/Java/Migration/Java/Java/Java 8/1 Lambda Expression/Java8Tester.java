import java.util.Collections;
import java.util.List;
import java.util.ArrayList;
import java.util.Comparator;

public class Java8Tester {
   public static void main(String args[]){
   
      List<String> names1 = new ArrayList<String>();
      names1.add("Delta ");
      names1.add("Alpha ");
      names1.add("Epsilon ");
      names1.add("Beta ");
      names1.add("Gamma ");
		
      List<String> names2 = new ArrayList<String>();
      names2.add("Delta ");
      names2.add("Alpha ");
      names2.add("Epsilon ");
      names2.add("Beta ");
      names2.add("Gamma ");
		
      Java8Tester tester = new Java8Tester();
      System.out.println("Sort using Java 7 syntax: ");
		
      tester.sortUsingJava7(names1);
      System.out.println(names1);
      System.out.println("Sort using Java 8 syntax: ");
		
      tester.sortUsingJava8(names2);
      System.out.println(names2);
   }
   
   //sort using java 7
   private void sortUsingJava7(List<String> names){   
      Collections.sort(names, new Comparator<String>() {
         @Override
         public int compare(String s1, String s2) {
            return s1.compareTo(s2);
         }
      });
   }
   
   //sort using java 8
   private void sortUsingJava8(List<String> names){
      Collections.sort(names, (s1, s2) -> s1.compareTo(s2));
   }
}