import java.text.*;

 
class Alpha{
    public static void main(String[] args){
        System.out.println("Alpha");
		double d = Math.pow(236D, 1.0/3.0);
		DecimalFormat df = new DecimalFormat("#.#");
		df.setRoundingMode(java.math.RoundingMode.FLOOR);
		System.out.println(df.format(d));
    }
}