using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008EventBubblingControlSample
{
    public class EventBubbler : Control, INamingContainer
    {
        private int number = 100;
        private Label label;
        private TextBox box1;
        private TextBox box2;

        public event EventHandler Click;
        public event EventHandler Reset;
        public event EventHandler Submit;

        public string Label
        {
            get
            {
                EnsureChildControls();
                return label.Text;
            }
            set
            {
                EnsureChildControls();
                label.Text = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string Text1
        {
            get
            {
                EnsureChildControls();
                return box1.Text;
            }
            set
            {
                EnsureChildControls();
                box1.Text = value;
            }
        }

        public string Text2
        {
            get
            {
                EnsureChildControls();
                return box2.Text;
            }
            set
            {
                EnsureChildControls();
                box2.Text = value;
            }
        }


        protected override void CreateChildControls()
        {

            Controls.Add(new LiteralControl("<h3>Enter a number : "));

            box1 = new TextBox();
            box1.Text = "0";
            Controls.Add(box1);

            Controls.Add(new LiteralControl("</h3>"));

            Controls.Add(new LiteralControl("<h3>Enter another number : "));

            box2 = new TextBox();
            box2.Text = "0";
            Controls.Add(box2);

            Controls.Add(new LiteralControl("</h3>"));

            Button button1 = new Button();
            button1.Text = "Click";
            button1.CommandName = "Click";
            Controls.Add(button1);

            Button button2 = new Button();
            button2.Text = "Reset";
            button2.CommandName = "Reset";
            Controls.Add(button2);

            Button button3 = new Button();
            button3.Text = "Submit";
            button3.CommandName = "Submit";
            Controls.Add(button3);

            Controls.Add(new LiteralControl("<br><br>"));
            label = new Label();
            label.Height = 50;
            label.Width = 500;
            label.Text = "Click a button.";
            Controls.Add(label);

        }

        protected override bool OnBubbleEvent(object source, EventArgs e)
        {
            bool handled = false;
            if (e is CommandEventArgs)
            {
                CommandEventArgs ce = (CommandEventArgs)e;
                if (ce.CommandName == "Click")
                {
                    OnClick(ce);
                    handled = true;
                }
                else if (ce.CommandName == "Reset")
                {
                    OnReset(ce);
                    handled = true;
                }
                else if (ce.CommandName == "Submit")
                {
                    OnSubmit(ce);
                    handled = true;
                }

            }
            return handled;
        }

        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

        protected virtual void OnReset(EventArgs e)
        {
            if (Reset != null)
            {
                Reset(this, e);
            }
        }

        protected virtual void OnSubmit(EventArgs e)
        {
            if (Submit != null)
            {
                Submit(this, e);
            }
        }
    }
}
