using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

public class Well
{
    private string WHid;
    private string Gid;

    public string WellheadID
    {
        get
        {
            if (!string.IsNullOrEmpty(WHid))
                return WHid;
            else
                return null;
        }
        set
        {
            WHid = value;
        }
    }

    public string GroupID
    {
        get
        {
            if (!string.IsNullOrEmpty(Gid))
                return Gid;
            else
                return null;
        }
        set
        {
            Gid = value;
        }
    }

    public Well() { }

    public Well(string idWH, string idG)
    {
        WHid = idWH;
        Gid = idG;
    }
 
    public List<Well> GetWell(string idWellhead)
    {
        try
        {
            Well WellObject;
            List<Well> WellList = new List<Well>();

            //string SQLiteQuery = "SELECT PowerTime, PowerValue FROM BatteryPower";

            string SQLiteQuery = "SELECT wh.WellheadID AS WellheadID, wg.GroupID AS GroupID, ";
            SQLiteQuery += "wg.GroupName AS GroupName, om.OperationModeName AS OperationModeName ";
            SQLiteQuery += "FROM WellHead wh, WellheadGroup wg, OperationMode om ";
            SQLiteQuery += "WHERE wh.GroupID = wg.GroupID ";
            SQLiteQuery += "AND wh.OperationModeID = om.OperationModeID ";
            SQLiteQuery += "ORDER BY wg.GroupID; ";

            DatabaseConnection ConnectionDatabase = new DatabaseConnection();
            DataSet DatSet = ConnectionDatabase.GetDataSet(SQLiteQuery);

            for (int intR = 0; intR < DatSet.Tables[0].Rows.Count; intR++)
            {
                string IDWellhead = DatSet.Tables[0].Rows[intR]["WellheadID"].ToString();
                string IDGroup = DatSet.Tables[0].Rows[intR]["GroupID"].ToString();
                WellObject = new Well(IDWellhead, IDGroup);
                WellList.Add(WellObject);
            }

            if (WellList != null && WellList.Count > 0)
                return WellList;
            else
                return null;

        }
        catch (Exception exp)
        {
            string s = exp.ToString();
            return null;
        }
    }

   

}

