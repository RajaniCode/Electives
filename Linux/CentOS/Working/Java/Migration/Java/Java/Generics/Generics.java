import static java.lang.System.out;
import static java.lang.System.err;

class G<T>
{
    T obj;

    public G(T obj)
    {
        this.obj = obj;
    }

    public T getObject()
    {
        return obj;
    }

    public void showType()
    {
        out.println("Type: " + obj.getClass());
        // out.println("Type: " + obj.getClass().getName());
    }
}

class Generics
{
    public static void main(String... args)
    {
        G<String> gs = new G<String>("Hello World!");
        String s = gs.getObject();
        out.println("Object: " + s);
        gs.showType();

        G<Integer> gi = new G<Integer>(100);
        int i = gi.getObject();
        out.println("Object: " + i);
        gi.showType();
    }
}

