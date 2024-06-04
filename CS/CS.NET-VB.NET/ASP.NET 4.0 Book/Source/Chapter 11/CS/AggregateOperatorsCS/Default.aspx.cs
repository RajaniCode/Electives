using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int[] numbers = { 5, 4, 1, 3, 9, 10, 35, 29, 20, 87, 100, 26, 42, 78, 91 };
        int OddNumbers = numbers.Count(n => n % 2 == 1);
        ListBox1.Items.Add("The Count of odd Numbers are: " + OddNumbers);

        double numSum = numbers.Sum();
        ListBox1.Items.Add("The sum of numbers is :" + numSum);
        int minNum = numbers.Min();
        ListBox1.Items.Add("Minimum number is:" + minNum);

        int maxNum = numbers.Max();
        ListBox1.Items.Add("Maximum number is :" + maxNum);

        double avgNum = numbers.Average();
        ListBox1.Items.Add("Average of numbers is : " + avgNum);

    }
}