<% @ Control Language="C#" ClassName="Spinner" %>

<script runat="server">
private int m_minValue;
private int m_maxValue = 100;
private int m_currentNumber = 0;
public int MinValue
{
    get
    {
        return m_minValue;
    }
    set
    {
        if(value >= this.MaxValue)
        {    
            throw new Exception("MinValue must be less than MaxValue.");
        }
        else
        {
            m_minValue = value;
        }
    }
}

public int MaxValue
{
    get
    {
        return m_maxValue;
    }
    set
    {
        if(value <= this.MinValue)
        {
            throw new 
                Exception("MaxValue must be greater than MinValue.");
        }
        else
        {
            m_maxValue = value;
        }
    }
}

public int CurrentNumber
{
    get
    {
        return m_currentNumber;
    }
}

protected void Page_Load(Object sender, EventArgs e)
{
    if(IsPostBack)
    {
        m_currentNumber =
            Int16.Parse(ViewState["currentNumber"].ToString());
    }
    else
    {
        m_currentNumber = this.MinValue;
    }
    DisplayNumber();
}

protected void DisplayNumber()
{
    textNumber.Text = this.CurrentNumber.ToString();
    ViewState["currentNumber"] = this.CurrentNumber.ToString();
}

protected void buttonUp_Click(Object sender, EventArgs e)
{
    if(m_currentNumber == this.MaxValue)
    {
        m_currentNumber = this.MinValue;
    }
    else
    {
        m_currentNumber += 1;
    }
    DisplayNumber();
}

protected void buttonDown_Click(Object sender, EventArgs e)
{
    if(m_currentNumber == this.MinValue)
    {
        m_currentNumber = this.MaxValue;
    }
    else
    {
        m_currentNumber -= 1;
    }
    DisplayNumber();
}
</script>
<asp:TextBox ID="textNumber" runat="server" 
    ReadOnly="True" Width="32px" Enabled="False" />
<asp:Button Font-Bold="True" ID="buttonUp" runat="server"  
    Text="^" OnClick="buttonUp_Click" />
<asp:Button Font-Bold="True" ID="buttonDown" runat="server" 
    Text="v" OnClick="buttonDown_Click" />