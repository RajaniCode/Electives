using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


/// <summary>
///  Author: Antonio Suarez
///   Email: Antonio.Suarez@GrupoKino.com
///Web Page: http://www.grupoKino.com
/// </summary>

public partial class _Default : System.Web.UI.Page
{
    #region Global Variables

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
            FreezeGridviewHeader(GridView1, _tb, PanelContainer);
    }






    #region GridView1 Functions

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType ==  DataControlRowType.DataRow)
            if (e.Row.RowIndex == 1)
                FreezeGridviewHeader(GridView1,_tb,PanelContainer);
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            AddSortDirectionImage(GridView1, e.Row);
    }

    #endregion


    #region GridView1 Functions
      protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            if (e.Row.RowIndex == 1)
                FreezeGridviewHeader(GridView2, _tb2, PanelContainer2);
    }  

    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            AddSortDirectionImage(GridView2, e.Row);
    }    

    #endregion

    /// <summary>
    ///  Author: Antonio Suarez
    ///   Email: Antonio.Suarez@GrupoKino.com
    ///Web Page: http://www.grupoKino.com    
    /// [Español]Funcion que copia el header de un gridview a un control tipo Table 
    /// [English]Function that copy a gridview header to a table control.
    /// </summary>
    /// <param name="_gv1">
    /// [Español]Gridview del cual se copiara el encabezado.
    /// [English]GridView from where the header row will be copied
    /// </param>
    /// <param name="_tb1">
    /// [Español]Renglon del gridview al cual se le agrega la imagen 
    /// [English]Row of gridview to add sort image
    /// </param>
    /// <param name="_pc1">
    /// [Español]Panel que contendra tanto al gridview como al control table
    /// [English]Panel container of the gridview and table control.   
    /// </param>     
    protected void FreezeGridviewHeader(GridView _gv1, Table _tb1,Panel _pc1)
    {
        Page.EnableViewState = false;

        //[Español]Copiando las propiedades del renglon de encabezado
        //[English]Coping a header row data and properties    
        _tb1.Rows.Add(_gv1.HeaderRow);
        _tb1.Rows[0].ControlStyle.CopyFrom(_gv1.HeaderStyle);
        _tb1.CellPadding = _gv1.CellPadding;
        _tb1.CellSpacing = _gv1.CellSpacing;
        _tb1.BorderWidth = _gv1.BorderWidth;

        //if (!_gv1.Width.IsEmpty)
        //_gv1.Width = Unit.Pixel(Convert.ToInt32(_gv1.Width.Value) + Convert.ToInt32(_tb1.Width.Value) + 13);

        //[Español]Copiando las propiedades de cada celda del nuevo encabezado.
        //[English]Coping  each cells properties to the new header cells properties
        int Count = 0;
        _pc1.Width = Unit.Pixel(100);
        for (Count = 0; Count < _gv1.HeaderRow.Cells.Count - 1; Count++)
        {
            _tb1.Rows[0].Cells[Count].Width = _gv1.Columns[Count].ItemStyle.Width;
            _tb1.Rows[0].Cells[Count].BorderWidth = _gv1.Columns[Count].HeaderStyle.BorderWidth;
            _tb1.Rows[0].Cells[Count].BorderStyle = _gv1.Columns[Count].HeaderStyle.BorderStyle;
            _pc1.Width = Unit.Pixel(Convert.ToInt32(_tb1.Rows[0].Cells[Count].Width.Value) + Convert.ToInt32(_pc1.Width.Value) + 14);
        }
        //Panel1.Width = Unit.Pixel(Convert.ToInt32(_tb1.Rows[0].Cells[Count-1].Width.Value) + 12);
    }


    /// <summary>
    ///  Author: Antonio Suarez
    ///   Email: Antonio.Suarez@GrupoKino.com
    ///Web Page: http://www.grupoKino.com    
    /// [Español]Funcion que agrega una imagen a la columna ordenada de un gridView 
    /// [English]Function that adds a image to the sorted column.
    /// </summary>
    /// <param name="gridviewID">
    /// [Español]Gridview al cual se le agregara la imagen 
    /// [English]GridView to add sort image
    /// </param>
    /// <param name="itemRow">
    /// [Español]Renglon del gridview al cual se le agrega la imagen 
    /// [English]Row of gridview to add sort image
    /// </param>
    public void AddSortDirectionImage(GridView gridviewID, GridViewRow itemRow)
    {
        if (gridviewID.AllowSorting == false)
            return;

        Image sortImage = new Image();
        Label space = new Label();

        sortImage.ImageUrl = (gridviewID.SortDirection == SortDirection.Ascending ? @"~/sort_asc.gif" : @"~/sort_desc.gif");
        sortImage.Visible = true;
        space.Text = " ";


        for (int i = 0; i < gridviewID.Columns.Count; i++)
        {
            string colExpr = gridviewID.Columns[i].SortExpression;
            if (colExpr != "" && colExpr == gridviewID.SortExpression)
            {
                itemRow.Cells[i].Controls.Add(space);
                itemRow.Cells[i].Controls.Add(sortImage);
            }
        }
    }
}
