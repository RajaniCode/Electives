import static java.lang.System.out;
import static java.lang.System.err;

class NG
{
    Object obj;

    public NG(Object obj)
    {
        this.obj = obj;
    }

    public Object getObject()
    {
        return obj;
    }

    public void showType()
    {
        out.println("Type: " + obj.getClass());
	// out.println("Type: " + obj.getClass().getName());
    }
}

class NonGenerics
{
    public static void main(String... args)
    {
        NG n = new NG("Hello World!");
        String s = (String)n.getObject();
        out.println("Object: " + s);
        n.showType();

        n = new NG(100);
        int i = (int)n.getObject();
        out.println("Object: " + i);
        n.showType();
    }
}

