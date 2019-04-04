using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using adgtechAssesment.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace adgtechAssesment.DAL
{
    public class dataaccesslayer
    {
        incident_model_lsit reglist = new incident_model_lsit();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public DataSet get_record()
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT Incident_ID, Incident_Desc, Incident_Priority FROM [Incidents]", con);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool update_record(incident_model inc)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("UPDATE [Incidents] SET Incident_Desc = '" + inc.Incident_Desc + "', Incident_Priority = '" + inc.Incident_Priority + "' WHERE Incident_ID = '" + inc.Incident_No + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool delete_record(string id)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM [Incidents] WHERE Incident_ID = '" + id + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}