import static java.lang.System.out;

interface StaticService {
    int getNumber();

    // Static Method In Interface
    static String getString() {
	return "This is the return from Static Method In Interface";
    }
}

class DefaultImplementation implements StaticService {
    public int getNumber() {
        return 100;
    }   
}

class Program {
    public static void main(String... args) {
	DefaultImplementation defimp = new DefaultImplementation();
	out.println(defimp.getNumber());
	out.println(StaticService.getString());
    }
}