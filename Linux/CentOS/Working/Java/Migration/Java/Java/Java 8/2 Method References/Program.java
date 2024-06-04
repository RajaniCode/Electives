import static java.lang.System.out;

interface ReverseFunc {
    String func(String str);
}

class StringReverse {
    // static String reverse(String str) {
    String reverse(String str) {
    	String result = "";
	for(int i = str.length() - 1; i >= 0; i--) {
	    result += str.charAt(i);            
   	}
        return result;
    }   
}

class Program {

    String stringFunc(ReverseFunc revFunc, String str) {
        return revFunc.func(str);
    }

    public static void main(String... args) {
        String str = "Hello World!";
    	String rstr = "";

        Program prgm = new Program();
        StringReverse srev = new StringReverse(); //

        // Method References
 	// rstr = prgm.stringFunc(StringRevers::reverse, str);
	
	// Method References
	rstr = prgm.stringFunc(srev::reverse, str);
	
       	out.println(rstr);
   }
}