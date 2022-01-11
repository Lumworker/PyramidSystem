using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Web.UI;
using System.Configuration;
using System.IO;
using Workflow_Application;

namespace MobileTask.AppCode
{
    public class ClassBrowseNew
    {
        public static String Proj_Num, Customer, prLine, startLine;
        public static String StatusLine = "";

        string PK = System.Configuration.ConfigurationManager.AppSettings["PK"];
        string Site = System.Configuration.ConfigurationManager.AppSettings["Site"];
        string PKM = System.Configuration.ConfigurationManager.AppSettings["PKM"];
        string PKT = System.Configuration.ConfigurationManager.AppSettings["PKT"];
        string SPN = System.Configuration.ConfigurationManager.AppSettings["SPN"];
        string PH = System.Configuration.ConfigurationManager.AppSettings["PH"];
        string IND = System.Configuration.ConfigurationManager.AppSettings["IND"];
        string MY = System.Configuration.ConfigurationManager.AppSettings["MY"];
        string TG = System.Configuration.ConfigurationManager.AppSettings["TG"];
        string CTG = System.Configuration.ConfigurationManager.AppSettings["CTG"];
        string HA = System.Configuration.ConfigurationManager.AppSettings["HA"];
        string CHA = System.Configuration.ConfigurationManager.AppSettings["CHA"];

        //public static String con = "Data Source=K2DB1\\K2DBC1;Initial Catalog=K2;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=50000";
        public static String con = "Data Source=K2DB1\\K2DBC1;Initial Catalog=K2;Persist Security Info=True;User ID=dv;Password=@Wanlapa; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conIT_Portal = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=IT_Portal;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=50000";
        public static String conPatkol = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=PATKOL_K2APP_DATA;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=50000";
        public static String conHRPortal = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=HRPortal;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=50000";
        public static String conPK = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_PK"].ConnectionString;

        public string SeletSite_ref(string site_ref)
        {
            string connn = "";
            if (site_ref == PK)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_PK"].ConnectionString;
            }
            else if (site_ref == PKM)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_PKM"].ConnectionString;
            }
            else if (site_ref == PKT)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_PKT"].ConnectionString;
            }
            else if (site_ref == SPN)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_SPN"].ConnectionString;
            }
            else if (site_ref == PH)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLOverseaPH"].ConnectionString;
            }
            else if (site_ref == IND)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLOverseaID"].ConnectionString;
            }
            else if (site_ref == MY)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLOverseaMY"].ConnectionString;
            }
            else if (site_ref == TG)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_TG"].ConnectionString;
            }
            else if (site_ref == HA)
            {
                connn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_HA"].ConnectionString;
            }

            return connn;
        }
        public String GetUser()
        {
            var UserDomain = HttpContext.Current.Request.LogonUserIdentity.Name;
            UserDomain = UserDomain.Replace("PATKOL\\", "");
            return UserDomain;
        }

        public List<string[]> GetLoginByLocation()
        {
            List<String[]> GetLoginByLocation = new List<String[]>();
            using (SqlConnection connection = new SqlConnection(conIT_Portal))
            {
                string sql = "Select [site_ref],[Username] from [dbo].[TB_Ctr_DFSite] WHERE [Username] = '" + GetUser() + "'";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String[] getData = new String[2];
                            getData[0] = reader[0].ToString().Trim();
                            getData[1] = reader[1].ToString().Trim();
                            GetLoginByLocation.Add(getData);
                        }
                    }
                }
            }
            return GetLoginByLocation;
        }

        public List<String[]> GetNameEmployee(string search, string site_ref)
        {
            List<String[]> getNameEmployee = new List<String[]>();
            using (SqlConnection connection = new SqlConnection(SeletSite_ref(site_ref)))
            {
                string sql = "SELECT [emp_num],[name],[Uf_UserLogin] FROM [dbo].[employee_mst] WHERE ISNULL([Uf_EmpStatus],1) = 1 AND [emp_num] LIKE '%" + search + "%'";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String[] getData = new String[3];
                            getData[0] = reader[0].ToString().Trim();
                            getData[1] = reader[1].ToString().Trim();
                            getData[2] = reader[2].ToString().Trim();
                            getNameEmployee.Add(getData);
                        }
                    }
                }
            }
            return getNameEmployee;
        }


        public List<String[]> LoadPosition(String Site_ref, String Dept, string Level)
        {
            List<String[]> Data = new List<String[]>();
            using (SqlConnection connection = new SqlConnection(conHRPortal))
            {
                string SQL = "SELECT JobTitle ,Position from [HRPortal].[dbo].[TB_HR_Employee_Position]";
                SQL += " where  Status = 'Active' ";
                //SQL += " where  stat = 'A' and class = '" + Dept + "' and Uf_hrlevel = '" + Level + "'";

                using (SqlCommand cmd = new SqlCommand(SQL, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String[] getData = new String[2];
                            getData[0] = reader[0].ToString().Trim();
                            getData[1] = reader[1].ToString().Trim();
                            Data.Add(getData);
                        }
                    }
                }
            }
            return Data;
        }


        public String checkK2TableName(String WFType)
        {
            String TableName = "";
            string sqlCmd = "SELECT TB_Name FROM TB_K2TableName WHERE WFType = '" + WFType + "' AND Type <> 'L'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read()) { TableName = rs["TB_Name"].ToString(); }
            conn.Close();
            return TableName;
        }

        public String checkK2ViewName(string WFType)
        {
            String TableName = "";
            string sqlCmd = "SELECT VW_Name FROM TB_K2TableName WHERE WFType = '" + WFType + "' AND Type <> 'L'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read()) { TableName = rs["VW_Name"].ToString(); }
            conn.Close();
            return TableName;
        }

        public void SP_Proj_Loging()
        {
            SqlConnection con = new SqlConnection(conPK);
            SqlCommand cmd = new SqlCommand("SP_Proj_Loging", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Page", "My Space");
            cmd.Parameters.AddWithValue("ProjNum", "");
            cmd.Parameters.AddWithValue("User", GetUser());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///Select Data

        public List<String[]> Get_K2_Task(string checkFilter, int K2ID, string UserTask, string WFtype, string WorkflowType, string Subject, string Requester, string dateStart, string dateEnd, string site_ref, string Activity, string TypeSearch)
        {
            List<String[]> get_K2Task = new List<String[]>();
            string sql = "";
            if (TypeSearch == "MyTask")
            {
                sql = "EXEC SP_Worklist_MyTask_ReVersion '" + GetUser() + "', '" + site_ref + "'," + K2ID + ",'" + WFtype + "'" +
                ",'" + WorkflowType + "','" + Subject + "' ,'" + Requester + "' ,'" + Activity + "' " +
                ",'" + dateStart + "' ,'" + dateEnd + "'";
            }
            else if (TypeSearch == "SearchAll")
            {
                sql = "EXEC SP_Worklist_WFSearch_ReVersion '" + UserTask + "', '" + site_ref + "'," + K2ID + ",'" + WFtype + "'" +
                ",'" + WorkflowType + "','" + Subject + "' ,'" + Requester + "' ,'" + Activity + "' " +
                ",'" + dateStart + "' ,'" + dateEnd + "'";
            }


            using (SqlConnection connection = new SqlConnection(con))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    cmd.CommandTimeout = 2000;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String[] detail = new String[12];
                            detail[0] = reader["K2ID"].ToString().Trim();
                            detail[1] = reader["WFtype"].ToString().Trim();
                            detail[2] = reader["WorkflowType"].ToString().Trim();
                            detail[3] = reader["Subject"].ToString().Trim();
                            detail[4] = reader["Requester"].ToString().Trim();
                            detail[5] = reader["CreateDate"].ToString().Trim();
                            detail[6] = reader["Activity"].ToString().Trim();
                            detail[7] = reader["Site_ref"].ToString().Trim();
                            detail[8] = reader["linkNew"].ToString().Trim();
                            detail[9] = reader["TB_Name"].ToString().Trim();
                            detail[10] = reader["Type"].ToString().Trim();
                            detail[11] = reader["IDMain"].ToString().Trim();

                            get_K2Task.Add(detail);
                        }
                    }
                }
            }
            return get_K2Task;
        }

        public List<ArrayList> GetDataDictionary(string DataType, string word, string site_ref)
        {
            List<ArrayList> GetDataDictionary = new List<ArrayList>();

            using (SqlConnection conn = new SqlConnection(SeletSite_ref(site_ref)))
            {
                string sql = "SELECT TOP(10) * FROM [dbo].[TB_DataDictionary] ";
                sql += "WHERE ( [DataKey] LIKE ('%" + word + "%') OR [DataSearch] LIKE ('%" + word + "%') )";
                if (DataType != "")
                {
                    sql += "AND [DataType] = '" + DataType + "'";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            GetDataDictionary.Add(detail);
                        }
                    }
                }
            }
            return GetDataDictionary;
        }

        public List<ArrayList> GetSite_ref()
        {
            List<ArrayList> GetData = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(conPatkol))
            {
                string sql = "SELECT [SiteRef],Corp_NameEN FROM [dbo].[SiteDatabase] sb LEFT JOIN TB_company cp ON sb.SiteRef = cp.Corp_Name WHERE [ShowEntries] = 1";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            GetData.Add(detail);
                        }
                    }
                }
            }
            return GetData;
        }

        public List<ArrayList> GetModuleWorkFlow(string site_ref)
        {
            List<ArrayList> GetData = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(con))
            {
                //string sql = "SELECT [MainTypeID],[Description] FROM [dbo].[TB_WorkflowMainType]";

                string sql = " select distinct wmt.MainTypeID as code,wmt.MainTypeID + ' /' + wmt.Description as name ";
                sql += " from [dbo].[TB_WorkflowMainType] wmt inner join [dbo].[TB_WorkflowType] ft on wmt.MainTypeID = ft.MainType";
                sql += " where 1 =1 ";
                if (site_ref == "ERP_PK") { sql += " and ft.PK_SiteRef = 1 "; }
                else if (site_ref == "ERP_PKM") { sql += " and ft.PKM_Siteref = 1 "; }
                else if (site_ref == "ERP_PKT") { sql += " and ft.PKT_SiteRef = 1 "; }
                else if (site_ref == "ERP_SPN") { sql += " and ft.PN_SiteRef = 1 "; }
                else if (site_ref == "ERP_PH") { sql += " and ft.PH_SiteRef = 1 "; }
                else if (site_ref == "ERP_ID") { sql += " and ft.ID_SiteRef = 1 "; }
                else if (site_ref == "ERP_TG") { sql += " and ft.TG_SiteRef = 1 "; }
                else if (site_ref == "ERP_HA") { sql += " and ft.HA_SiteRef = 1 "; }
                else if (site_ref == "ERP_MY") { sql += " and ft.MY_SiteRef = 1 "; }

                sql += " order by wmt.MainTypeID asc ";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            GetData.Add(detail);
                        }
                    }
                }
            }
            return GetData;
        }

        public List<ArrayList> GetWorkflow(string WorkflowType, string site_ref)
        {
            List<ArrayList> GetData = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(con))
            {
                //string sql = "SELECT [WorkflowType],[Description],SUBSTRING([linkNew],3,LEN([linkNew])) AS [linkNew]  FROM [dbo].[TB_WorkflowType] ";
                string sql = "select distinct substring(WorkflowType,0,5) as code,substring(WorkflowType,0,5) + ' / ' + Description as name from [dbo].[TB_WorkflowType] ft ";
                sql += " where StatusType = 1 AND WorkflowType is not null and Description is not null ";

                if (site_ref == PK) { sql += " AND ft.[PK_SiteRef] = 1 "; }
                else if (site_ref == PKM) { sql += " AND ft.[PKM_Siteref] = 1 "; }
                else if (site_ref == PKT) { sql += " AND ft.[PKT_SiteRef] = 1 "; }
                else if (site_ref == SPN) { sql += " AND ft.[PN_SiteRef] = 1 "; }
                else if (site_ref == HA) { sql += " AND ft.[HA_SiteRef] = 1 "; }
                else if (site_ref == PH) { sql += " AND ft.[PH_SiteRef] = 1 "; }
                else if (site_ref == IND) { sql += " AND ft.[ID_SiteRef] = 1 "; }
                else if (site_ref == TG) { sql += " AND ft.[TG_SiteRef] = 1 "; }
                else if (site_ref == MY) { sql += " AND ft.[MY_SiteRef] = 1 "; }

                if (WorkflowType != "")
                {
                    sql += " AND [MainType] = '" + WorkflowType + "' ";
                }

                sql += " Order by substring(WorkflowType,0,5) asc ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            GetData.Add(detail);
                        }
                    }
                }
            }
            return GetData;
        }

        public List<ArrayList> GetNewWorkflow(string WorkflowType, string site_ref)
        {
            List<ArrayList> GetData = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(con))
            {
                //string sql = "SELECT [WorkflowType],[Description],SUBSTRING([linkNew],3,LEN([linkNew])) AS [linkNew]  FROM [dbo].[TB_WorkflowType] ";
                string sql = "select distinct substring(WorkflowType,0,5) as code,substring(WorkflowType,0,5) + ' / ' + Description as name,SUBSTRING([linkNew],3,LEN([linkNew])) AS [linkNew] from [dbo].[TB_WorkflowType] ft ";
                sql += " where StatusType = 1 AND link is not null AND link not like '%SyteLine%' AND type = 'K2' AND WorkflowType is not null and Description is not null ";

                if (site_ref == PK) { sql += " AND ft.[PK_SiteRef] = 1 "; }
                else if (site_ref == PKM) { sql += " AND ft.[PKM_Siteref] = 1 "; }
                else if (site_ref == PKT) { sql += " AND ft.[PKT_SiteRef] = 1 "; }
                else if (site_ref == SPN) { sql += " AND ft.[PN_SiteRef] = 1 "; }
                else if (site_ref == HA) { sql += " AND ft.[HA_SiteRef] = 1 "; }
                else if (site_ref == PH) { sql += " AND ft.[PH_SiteRef] = 1 "; }
                else if (site_ref == IND) { sql += " AND ft.[ID_SiteRef] = 1 "; }
                else if (site_ref == TG) { sql += " AND ft.[TG_SiteRef] = 1 "; }
                else if (site_ref == MY) { sql += " AND ft.[MY_SiteRef] = 1 "; }

                if (WorkflowType != "")
                {
                    sql += " AND [MainType] = '" + WorkflowType + "' ";
                }

                sql += " Order by substring(WorkflowType,0,5) asc ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            GetData.Add(detail);
                        }
                    }
                }
            }
            return GetData;
        }
        public string GetWorkflowURL(string WorkflowType)
        {
            string url = "";
            using (SqlConnection conn = new SqlConnection(con))
            {
                string sql = "SELECT SUBSTRING([linkNew],3,LEN([linkNew])) AS [linkNew]  FROM [dbo].[TB_WorkflowType] WHERE ([PK_SiteRef] = 1 OR [PKM_Siteref] = 1 OR [PKT_SiteRef] = 1 OR [PN_SiteRef] = 1 OR [HA_SiteRef] = 1 OR [PH_SiteRef] = 1 OR [ID_SiteRef] = 1 OR [TG_SiteRef] = 1 OR [MY_SiteRef] = 1) ";
                sql += " AND [WorkflowType] = '" + WorkflowType + "' ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            url = reader[0].ToString();
                        }
                    }
                }
            }
            return url;
        }

        public string K2SingleSelectID(string table, string K2_ID, string TypeDB, string site_ref)
        {
            string id = "";
            List<ArrayList> GetDataK2SingleSelect = new List<ArrayList>();
            var ConnectionDB = "";
            if (TypeDB == "K2") { ConnectionDB = con; }
            else { ConnectionDB = SeletSite_ref(site_ref); }

            using (SqlConnection conn = new SqlConnection(ConnectionDB))
            {
                string sql = "SELECT TOP(1) [ID] FROM " + table + " WHERE [ProcessInstanceID] = '" + K2_ID + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader[0].ToString();
                        }
                    }
                }
            }
            return id;
        }


        public List<ArrayList> GetHistoryApproveWorkFlow(string text, string date)
        {
            List<ArrayList> GetData = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(con))
            {
                string sql = " SELECT [K2ID],[Subject],[Step Name],[ActionDate],[Action] ";
                sql += " FROM [dbo].[VW_Workflow_History_User]";
                sql += " WHERE [Username] = '" + GetUser() + "' ";
                //sql += " WHERE [Username] = 'CHANACHON.PR' ";
                sql += " AND ( [K2ID] LIKE '%" + text + "%' ";
                sql += " OR [Subject] LIKE '%" + text + "%' ";
                sql += " OR [Step Name] LIKE '%" + text + "%' )";
                if (date != "") { sql += " AND CONVERT(DATE, '" + date + "') = CONVERT(DATE, [ActionDate]) "; }
                else { sql += " AND CONVERT(DATE, GETDATE()) = CONVERT(DATE, [ActionDate]) "; }
                sql += " ORDER BY [ActionDate] ";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            GetData.Add(detail);
                        }
                    }
                }
            }
            return GetData;
        }

        public List<ArrayList> GetActivityExportK2(String WFType)
        {
            ClassDBConnK2 DBConn = new ClassDBConnK2();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadDataActivity(checkK2TableName(WFType));
            List<ArrayList> ListData = new List<ArrayList>();
            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    ArrayList detail = new ArrayList();
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        detail.Add(row[i].ToString());
                    }
                    ListData.Add(detail);
                }
            }
            return ListData;
        }

        public List<List<ArrayList>> GetExportK2(String WFType, String sDate, String eDate, String Activity, String Costcenter, String Site_Ref)
        {
            ClassDBConnK2 DBConn = new ClassDBConnK2();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadDataExportByVW(checkK2ViewName(WFType), sDate, eDate, Activity, Costcenter, Site_Ref);

            List<List<ArrayList>> ListTotal = new List<List<ArrayList>>();

            List<ArrayList> ListColumn = new List<ArrayList>();
            List<ArrayList> ListData = new List<ArrayList>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataColumn row in DTData.Columns)
                {
                    ArrayList detail = new ArrayList();
                    detail.Add(row.ColumnName.ToString());
                    ListColumn.Add(detail);
                }

                foreach (DataRow row in DTData.Rows)
                {
                    ArrayList detail = new ArrayList();
                    for (int i = 0; i < row.ItemArray.Length; i++) { detail.Add(row[i].ToString()); }
                    ListData.Add(detail);
                }

                ListTotal.Add(ListColumn);
                ListTotal.Add(ListData);
            }
            return ListTotal;
        }
        public List<ArrayList> TB_Pyramid_SpecialGroup()
        {
            List<ArrayList> data = new List<ArrayList>();
            using (SqlConnection connection = new SqlConnection(conHRPortal))
            {
                string sql = " SELECT TOP (1000) [Spc_Code],[PicName] FROM [HRPortal].[dbo].[TB_Pyramid_SpecialGroup]";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            data.Add(detail);
                        }
                    }
                    connection.Close();
                }
            }
            return data;
        }
        public List<ArrayList> TB_Pyramid_Employee()
        {
            List<ArrayList> data = new List<ArrayList>();
            using (SqlConnection connection = new SqlConnection(conHRPortal))
            {
                string sql = "SELECT TOP (1000) [Emp_Num],[Emp_Name] FROM [HRPortal].[dbo].[TB_Pyramid_Employee]";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            data.Add(detail);
                        }
                    }
                    connection.Close();
                }
            }
            return data;
        }
        public List<ArrayList> TB_Pyramid_Company(string search)
        {
            List<ArrayList> data = new List<ArrayList>();
            using (SqlConnection connection = new SqlConnection(conHRPortal))
            {
                string sql = "SELECT TOP (1000) [Comp_Code],[Comp_Name],[site_ref] FROM [HRPortal].[dbo].[TB_Pyramid_Company] ";
                if (search != "")
                {
                    sql += " WHERE [Comp_Code] like '%" + search + "%' or [Comp_Name] like'%" + search + "%'";
                }
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            data.Add(detail);
                        }
                    }
                    connection.Close();
                }
            }
            return data;
        }
        public List<ArrayList> TB_Pyramid_Dept(string site_ref, string CompCode, string GroupID, string search)
        {
            List<ArrayList> data = new List<ArrayList>();
            using (SqlConnection connection = new SqlConnection(conHRPortal))
            {
                string sql = "SELECT TOP (1000) [DeptID],[DeptCode],[DeptName],[site_ref],[CompCode],[GroupID] FROM [HRPortal].[dbo].[TB_Pyramid_Dept] " +
                    " WHERE [site_ref] = '" + site_ref + "' AND [CompCode] = '" + CompCode + "' AND [GroupID] ='" + GroupID + "' ";
                if (search != "")
                {
                    sql += " AND ([DeptCode] like '%" + search + "%' or [DeptName] like'%" + search + "%' )";
                }
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            data.Add(detail);
                        }
                    }
                    connection.Close();
                }
            }
            return data;
        }
        public List<ArrayList> TB_Pyramid_Group(string site_ref, string Comp_Code, string search)
        {
            List<ArrayList> data = new List<ArrayList>();
            using (SqlConnection connection = new SqlConnection(conHRPortal))
            {
                string sql = "SELECT TOP (1000) [site_ref],[Comp_Code],[Group_ID],[GroupName]  FROM [HRPortal].[dbo].[TB_Pyramid_Group] WHERE [site_ref] = '" + site_ref + "' AND [Comp_Code] = '" + Comp_Code + "' ";
                if (search != "")
                {
                    sql += " AND [Group_ID] like '%" + search + "%' or [GroupName] like'%" + search + "%'";
                }
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ArrayList detail = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                detail.Add(reader[i].ToString());
                            }
                            data.Add(detail);
                        }
                    }
                    connection.Close();
                }
            }
            return data;
        }
        public string SP_Pyramid_SpecialGroup(string Spc_Code, string PicName, string Action)
        {
            SqlConnection con = new SqlConnection(conHRPortal);
            SqlCommand cmd = new SqlCommand("SP_Pyramid_SpecialGroup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Spc_Code", Spc_Code);
            cmd.Parameters.AddWithValue("PicName", PicName);
            cmd.Parameters.AddWithValue("UpdateBy", GetUser());
            cmd.Parameters.AddWithValue("Action", Action);
            con.Open();
            //cmd.ExecuteNonQuery();
            SqlDataReader rs = cmd.ExecuteReader();
            string returnData = "";
            if (rs.Read())
            {
                returnData = rs["Msg"].ToString();
            }
            con.Close();
            return returnData;
        }
        public string SP_Pyramid_Employee(string Emp_Num, string Emp_Name, string Action)
        {
            SqlConnection con = new SqlConnection(conHRPortal);
            SqlCommand cmd = new SqlCommand("SP_Pyramid_Employee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Emp_Num ", Emp_Num);
            cmd.Parameters.AddWithValue("Emp_Name", Emp_Name);
            cmd.Parameters.AddWithValue("UpdateBy", GetUser());
            cmd.Parameters.AddWithValue("Action", Action);
            con.Open();
            //cmd.ExecuteNonQuery();
            SqlDataReader rs = cmd.ExecuteReader();
            string returnData = "";
            if (rs.Read())
            {
                returnData = rs["Msg"].ToString();
            }
            con.Close();
            return returnData;
        }
        public string SP_Pyramid_Company(string Comp_Code, string Comp_Name, string site_ref, string Action)
        {
            SqlConnection con = new SqlConnection(conHRPortal);
            SqlCommand cmd = new SqlCommand("SP_Pyramid_Company", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Comp_Code ", Comp_Code);
            cmd.Parameters.AddWithValue("Comp_Name", Comp_Name);
            cmd.Parameters.AddWithValue("site_ref", site_ref);
            cmd.Parameters.AddWithValue("UpdateBy", GetUser());
            cmd.Parameters.AddWithValue("Action", Action);
            con.Open();
            //cmd.ExecuteNonQuery();
            SqlDataReader rs = cmd.ExecuteReader();
            string returnData = "";
            if (rs.Read())
            {
                returnData = rs["Msg"].ToString();
            }
            con.Close();
            return returnData;
        }
        public string SP_Pyramid_Group(string Group_ID, string GroupName, string Comp_Code, string site_ref, string Action)
        {
            SqlConnection con = new SqlConnection(conHRPortal);
            SqlCommand cmd = new SqlCommand("SP_Pyramid_Group", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Group_ID ", Group_ID);
            cmd.Parameters.AddWithValue("GroupName ", GroupName);
            cmd.Parameters.AddWithValue("Comp_Code", Comp_Code);
            cmd.Parameters.AddWithValue("site_ref", site_ref);
            cmd.Parameters.AddWithValue("UpdateBy", GetUser());
            cmd.Parameters.AddWithValue("Action", Action);
            con.Open();
            //cmd.ExecuteNonQuery();
            SqlDataReader rs = cmd.ExecuteReader();
            string returnData = "";
            if (rs.Read())
            {
                returnData = rs["Msg"].ToString();
            }
            con.Close();
            return returnData;
        }
        public string SP_Pyramid_Dept(int DeptID, string DeptCode, string DeptName, string site_ref, string CompCode, string GroupID, string Action)
        {
            SqlConnection con = new SqlConnection(conHRPortal);
            SqlCommand cmd = new SqlCommand("SP_Pyramid_Dept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DeptID ", DeptID);
            cmd.Parameters.AddWithValue("DeptCode ", DeptCode);
            cmd.Parameters.AddWithValue("DeptName", DeptName);
            cmd.Parameters.AddWithValue("site_ref", site_ref);
            cmd.Parameters.AddWithValue("CompCode", CompCode);
            cmd.Parameters.AddWithValue("GroupID", GroupID);
            cmd.Parameters.AddWithValue("UpdateBy", GetUser());
            cmd.Parameters.AddWithValue("Action", Action);
            con.Open();
            //cmd.ExecuteNonQuery();
            SqlDataReader rs = cmd.ExecuteReader();
            string returnData = "";
            if (rs.Read())
            {
                returnData = rs["Msg"].ToString();
            }
            con.Close();
            return returnData;
        }


    }
}