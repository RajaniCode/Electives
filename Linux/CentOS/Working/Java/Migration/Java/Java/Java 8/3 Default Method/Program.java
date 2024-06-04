import static java.lang.System.out;

interface DefaultService {
    int getNumber();

    // Default Method
    default String getString() {
	return "This is the return from Default Method";
    }
}

class DefaultImplementation implements DefaultService {
    public int getNumber() {
        return 100;
    }   
}

class Program {
    public static void main(String... args) {
	DefaultImplementation defimp = new DefaultImplementation();
	out.println(defimp.getNumber());
	out.println(defimp.getString());
    }
}