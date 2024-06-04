using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class _Default : System.Web.UI.MobileControls.MobilePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Command1_Click(object sender, EventArgs e)
    {
        int Credit_Hr_1 = Convert.ToInt32(TextBox1.Text);
        int Credit_Hr_2 = Convert.ToInt32(TextBox2.Text);
        int Credit_Hr_3 = Convert.ToInt32(TextBox3.Text);
        int Credit_Hr_4 = Convert.ToInt32(TextBox4.Text);
        int Total_Crdt_Hr = Credit_Hr_1 + Credit_Hr_2 + Credit_Hr_3 + Credit_Hr_4;

        string Grade1 = Convert.ToString(TextBox5.Text);
        string Grade2 = Convert.ToString(TextBox6.Text);
        string Grade3 = Convert.ToString(TextBox6.Text);
        string Grade4 = Convert.ToString(TextBox7.Text);

        int Grade_Value = 0;
        int Temp_Grade_Value = 0;
        if (Grade1 == "A")
            Temp_Grade_Value = Credit_Hr_1 * 4;

        if (Grade1 == "B")
            Temp_Grade_Value = Credit_Hr_1 * 3;

        if (Grade1 == "C")
            Temp_Grade_Value = Credit_Hr_1 * 2;

        if (Grade1 == "D")
            Temp_Grade_Value = Credit_Hr_1 * 1;

        if (Grade1 == "F")
            Temp_Grade_Value = Credit_Hr_1 * 0;

        Grade_Value = Grade_Value + Temp_Grade_Value;

        if (Grade2 == "A")
            Temp_Grade_Value = Credit_Hr_2 * 4;

        if (Grade2 == "B")
            Temp_Grade_Value = Credit_Hr_2 * 3;

        if (Grade2 == "C")
            Temp_Grade_Value = Credit_Hr_2 * 2;

        if (Grade2 == "D")
            Temp_Grade_Value = Credit_Hr_2 * 1;

        if (Grade2 == "F")
            Temp_Grade_Value = Credit_Hr_2 * 0;

        Grade_Value = Grade_Value + Temp_Grade_Value;

        if (Grade3 == "A")
            Temp_Grade_Value = Credit_Hr_3 * 4;

        if (Grade3 == "B")
            Temp_Grade_Value = Credit_Hr_3 * 3;

        if (Grade3 == "C")
            Temp_Grade_Value = Credit_Hr_3 * 2;

        if (Grade3 == "D")
            Temp_Grade_Value = Credit_Hr_3 * 1;

        if (Grade3 == "F")
            Temp_Grade_Value = Credit_Hr_3 * 0;

        Grade_Value = Grade_Value + Temp_Grade_Value;

        if (Grade4 == "A")
            Temp_Grade_Value = Credit_Hr_4 * 4;

        if (Grade4 == "B")
            Temp_Grade_Value = Credit_Hr_4 * 3;

        if (Grade4 == "C")
            Temp_Grade_Value = Credit_Hr_4 * 2;

        if (Grade4 == "D")
            Temp_Grade_Value = Credit_Hr_4 * 1;
        if (Grade4 == "F")
            Temp_Grade_Value = Credit_Hr_4 * 0;

        Grade_Value = Grade_Value + Temp_Grade_Value;

        float GPA = Grade_Value / Total_Crdt_Hr;
        this.ActiveForm = this.Form2;

        Label1.Text = Grade_Value.ToString();
    }
    protected void Command2_Click(object sender, EventArgs e)
    {
        this.ActiveForm = this.Form1;
    }

}