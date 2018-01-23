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
        if (DropDownList1.Items.Count == 0)
        {
            DropDownList1.Items.Add("-");
            for (int i = 14; i <= 25; i++)
            {
                DropDownList1.Items.Add(i.ToString());
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}