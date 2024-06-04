import static java.lang.System.*;

class Program
{
    int Method(int i)
    {
	i = i * i;
	int j = i + 1;
	return j;
    }

    // public static void main(String args[])
    public static void main(String[] args)
    {
	int n = 5;
	Program p = new Program();
	p.Method(n);
	out.println("Number = " + n);
	out.println("Fine");
    }
}