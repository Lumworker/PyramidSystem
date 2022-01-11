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

namespace Workflow_Application.AppCode
{
    public class ClassBrowse
    {
        public static String Proj_Num, Customer, prLine, startLine;
        public static String StatusLine = "";

        public String site_ref, ref_num, AttID;
        public int ParamB;
      
        public static int row;
        public static int StepFO;
        public String code = "", name = "";

        public Boolean paramb1, paramb2, paramb3, paramb4, paramb5, paramb6, paramb7, paramb8, paramb9; 
        public String ProjNum, PO, revenue, projDesc, itemgroup, conSL, SiteRef;
        public String Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8, Param9, Param10, Param11, Param12, Param13, Param14, Param15, Param16, Param17, Param18, Param19, Param20;
        public String Param21, Param22, Param23, Param24, Param25, Param26, Param27, Param28, Param29, Param30, Param31, Param32, Param33, Param34, Param35, Param36, Param37, Param38, Param39, Param40;
        public String Param41, Param42, Param43, Param44, Param45, Param46, Param47, Param48, Param49, Param50, Param51, Param52, Param53, Param54, Param55, Param56, Param57, Param58, Param59, Param60;
      
        public String rParam1, rParam2, rParam3, rParam4, rParam5, rParam6, rParam7, rParam8, rParam9, rParam10;
        public String rParam11, rParam12, rParam13, rParam14, rParam15, rParam16, rParam17, rParam18, rParam19, rParam20;
        public String rParam21, rParam22, rParam23, rParam24, rParam25, rParam26, rParam27, rParam28, rParam29, rParam30;
        public String rParam31, rParam32, rParam33, rParam34, rParam35, rParam36, rParam37, rParam38, rParam39, rParam40;
        public String rParam41, rParam42, rParam43, rParam44, rParam45, rParam46, rParam47, rParam48, rParam49, rParam50;
        public String rParam51, rParam52, rParam53, rParam54, rParam55, rParam56, rParam57, rParam58, rParam59, rParam60;

        public static String con = "Data Source=K2DB1\\K2DBC1;Initial Catalog=K2;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLPK = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_PKS_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLPKT = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_PKTS_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLPKM = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_PKMS_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLSPN = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_SPanel_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLCRPPK = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=CRP2_PKS_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLCRPPKM = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=CRP2_PKMS_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLCRPPKT = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=CRP2_PKTS_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLCRPSPN = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=CRP2_SPanel_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        //public static String conSLOversea = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_Oversea_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLOverseaPH = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_Oversea_PH_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLOverseaID = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_Oversea_ID_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLOverseaMY = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_Oversea_MY_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conPATag = "Data Source=DBL2\\DBC2;Initial Catalog=PATag;Persist Security Info=True;User ID=sa;Password=edpedp; Connect Timeout=900; pooling=true; Max Pool Size=5000";
        public static String conPKFlow = "Data Source=DBL2\\DBC2;Initial Catalog=PKFLOW;Persist Security Info=True;User ID=sa;Password=edpedp; Connect Timeout=900; pooling=true; Max Pool Size=5000";
        public static String conSLHR = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=HRPortal;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conSLPKAPP = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=PATKOL_K2APP_DATA;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";

        public static String conCTG = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=CRP2_TG_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conTG = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_TG_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";
        public static String conCHA = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=CRP2_HA_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";

        public static String conHA = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_HA_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";


        //ConnectionStringSLERP_TG
       

        public String CheckConSiteRef()
        {
            if (SiteRef == "ERP_PKT")
            {
                conSL = conSLPKT;
            }
            else if (SiteRef == "ERP_PKM")
            {
                conSL = conSLPKM;
            }
            else if (SiteRef == "ERP_PK")
            {
                conSL = conSLPK;
            }
            else if (SiteRef == "ERP_SPN")
            {
                conSL = conSLSPN;
            }
            else if (SiteRef == "CRP2_PKS")
            {
                conSL = conSLCRPPK;
            }
            else if (SiteRef == "CRP2_PKT")
            {
                conSL = conSLCRPPKT;
            }
            else if (SiteRef == "CRP2_PKM")
            {
                conSL = conSLCRPPKM;
            }
            else if (SiteRef == "CRP2_SPN")
            {
                conSL = conSLCRPSPN;
            }
            else if (SiteRef == "PATag")
            {
                conSL = conPATag;
            }
            else if (SiteRef == "PKFLOW")
            {
                conSL = conPKFlow;
            }
            else if (SiteRef == "HRPortal")
            {
                conSL = conSLHR;
            }
            else if (SiteRef == "ERP_PH")
            {
                conSL = conSLOverseaPH;
            }
            else if (SiteRef == "ERP_ID")
            {
                conSL = conSLOverseaID;
            }
            else if (SiteRef == "CRP2_TG")
            {
                conSL = conCTG;
            }
            else if (SiteRef == "ERP_TG")
            {
                conSL = conTG;
            }
            else if (SiteRef == "CRP2_HA")
            {
                conSL = conCHA;
            }
            else if (SiteRef == "ERP_HA")
            {
                conSL = conHA;
            }
            else if (SiteRef == "ERP_HA")
            {
                conSL = conHA;
            }
            else if (SiteRef == "ERP_MY")
            {
                conSL = conSLOverseaMY;
            }
            else
            {
                conSL = conSLPK;
            }
            return conSL;

        }

        public DataSet K2BoundPOSL()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT [po_num] as 'code' , '' as 'name' FROM [dbo].[VW_WF_PO] WHERE [po_num] like '%" + code + "%' OR [po_num] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }


        public DataSet K2BoundPOLineSL()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT [po_line] as 'code' , '' as 'name' FROM [dbo].[VW_WF_PO_Line] WHERE [po_num] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public void LoadPOLineSL()
        {
            string sqlCmd = "select [Buyer],[item],[qty_ordered_conv],[item_cost_conv],[whse],[po_vend_num] from [dbo].[VW_WF_PO_Line] where [po_num] = '" + Param1 + "' and [po_line] = '" + Param2 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["item"].ToString();
                rParam2 = rs["qty_ordered_conv"].ToString();
                rParam3 = rs["item_cost_conv"].ToString();
                rParam4 = rs["whse"].ToString();
                rParam5 = rs["po_vend_num"].ToString();
                rParam6 = rs["Buyer"].ToString();
            }
            conn.Close();
        }

        public DataSet K2BoundPRSL()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT [req_num] as 'code' , '' as 'name' FROM [dbo].[preq_mst] WHERE [req_num] like '%" + code + "%' OR [req_num] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundPRLineSL()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT [req_line] as 'code' , '' as 'name' FROM [dbo].[preqitem_mst] WHERE [req_num] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public void LoadPRLineSL()
        {
            string sqlCmd = "select [Buyer],[item],[qty_ordered_conv],[plan_cost_conv],[whse],[vend_num] from [dbo].[preqitem_mst] where [req_num] = '" + Param1 + "' and [req_line] = '" + Param2 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["item"].ToString();
                rParam2 = rs["qty_ordered_conv"].ToString();
                rParam3 = rs["plan_cost_conv"].ToString();
                rParam4 = rs["whse"].ToString();
                rParam5 = rs["vend_num"].ToString();
                rParam6 = rs["Buyer"].ToString();
            }
            conn.Close();
        }

       

        public DataSet K2BoundWHSL()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT whse as 'code' , name as 'name' FROM dbo.whse_mst WHERE [whse] like '%" + code + "%' OR [whse] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        //public DataSet K2BoundItemSL()
        //{
        //    //CheckConSiteRef();
        //    string sqlcmd = "select item as code,Description as name from [dbo].[item_mst]  where item like '%" + code + "%' OR [item] like '%" + name + "%'";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        public DataSet K2BoundItemSL()
        {

            string sqlcmd = "select item as code,Description as name from [dbo].[item_mst]  where item like '%" + code + "%' OR [Description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundItemJobMatl()
        {
            //CheckConSiteRef();
            string sqlcmd = "select jb.item as code,it.Uf_LongDesc as name from [job_mst] jb left join item_mst it";
            sqlcmd += " on jb.item=it.item  where (jb.item like '%" + code + "%' OR it.[Uf_LongDesc] like '%" + name + "%') and jb.job='" + Param1 + "' and jb.suffix=0";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundFamilyCode()
        {
            string sqlcmd = "SELECT [family_code] as 'code',[description] as 'name' FROM [dbo].[famcode_mst] WHERE [family_code] like '%" + code + "%' OR [description] like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }



        //public void K2BoundExportinvoiceSelectData()
        //{
        //    string sqlCmd = "select [ProcessInstanceID] as code,[InvoiceNumber] as name,[site_ref],[Project],[ExportNO],[ModeShipment],[ProjectDescription],[Customer] from [dbo].[VW_WF_ExportInvoice] where [ProcessInstanceID] like '%" + Param1 + "%'";

        //    SqlConnection conn = new SqlConnection(conSLPK);
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {

        //        rParam1 = rs["code"].ToString();
        //        rParam2 = rs["name"].ToString();
        //        rParam3 = rs["site_ref"].ToString();
        //        rParam4 = rs["Project"].ToString();
        //        rParam5 = rs["ExportNO"].ToString();
        //        rParam6 = rs["ModeShipment"].ToString();
        //        rParam7 = rs["ProjectDescription"].ToString();
        //        rParam8 = rs["Customer"].ToString();

        //    }
        //    conn.Close();
        //}
        public void K2BoundExportinvoiceSelectData()
        {
            string sqlCmd = "select [ProcessInstanceID] as code,[InvoiceNumber] as name,[site_ref],[Project],[ExportNO],[ModeShipment],[ProjectDescription],[Customer] from [dbo].[VW_WF_ExportInvoice] where [ProcessInstanceID] like '%" + Param1 + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["code"].ToString();
                rParam2 = rs["name"].ToString();
                rParam3 = rs["site_ref"].ToString();
                rParam4 = rs["Project"].ToString();
                rParam5 = rs["ExportNO"].ToString();
                rParam6 = rs["ModeShipment"].ToString();
                rParam7 = rs["ProjectDescription"].ToString();
                rParam8 = rs["Customer"].ToString();

            }
            conn.Close();
        }

        public void LoadCurrentRate()
        {
            string sqlcmd = "select isnull((SELECT [buy_rate] ";
            sqlcmd += "from [dbo].[currate_mst] where [from_curr_code] = '" + Param1 + "'";
            sqlcmd += " And eff_date = (SELECT MAX(eff_date) from [dbo].[currate_mst] where eff_date > CONVERT(DATETIME,'" + Param2 + "',103)";
            sqlcmd += " And eff_date < CONVERT(DATETIME,'" + Param3 + "',103) and [from_curr_code] = '" + Param1 + "')),'1')  as buy_rate";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {

                rParam1 = rs["buy_rate"].ToString();


            }
            else
            {
                rParam1 = "";

            }

            conn.Close();


        }

        public DataSet K2BoundRequester3()
        {

            string sqlcmd = " select Ltrim(emp_num) as code,name,dept,site_ref from [dbo].[VW_employee_mst] ";
            sqlcmd += " where emp_type <> 'N' and name is not null  and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

            //string sqlcmd = " select distinct Ltrim(emp_num) as code,name,dept from [dbo].[VW_Employee_All] ";
            //sqlcmd += " where name is not null  and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

            //SqlConnection conn = new SqlConnection(con);
            //conn.Open();
            //SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //conn.Close();
            //return ds;


        }
        public void LoadCurrFromVend()
        {
            string sqlcmd = "SELECT Currency ";
            sqlcmd += "from [dbo].[VW_WF_Vendors] where [vend_num] like '%" + Param1 + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {

                rParam1 = rs["Currency"].ToString();


            }
            else
            {
                rParam1 = "";

            }

            conn.Close();


        }
        public DataSet K2BoundMia()
        {
            string sqlcmd = "select Top(200)   [mia_num] as code,[item] as name from ppcl_mia_item_mst WHERE [mia_num] like '%" + code + "%' OR [item] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundTask()
        {
            string sqlcmd = "select task_num as code,task_desc as name from [dbo].projtask_mst where (proj_num Like '%" + code + "%' or '%" + code + "%' = '%%' or  task_desc Like '%" + name + "%' or '%" + name + "%' = '%%') ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BrowseProvince()
        {
            string sqlcmd = " select [state] as code,[description] as name from [dbo].state_mst Where (state Like '%" + code + "%' or '%" + code + "%' = '%%' or  description Like '%" + name + "%' or '%" + name + "%' = '%%')";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundProsro2()
        {
            string sqlcmd = "select Top(50) [ProjectNum] as code,[ProjectDesc] as name from VW_WF_Project  WHERE [ProjectNum] like '%" + code + "%' OR [ProjectDesc] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public void K2BrowseProjectsor()
        {
            string sqlCmd = "select [ProjectDesc]from VW_WF_Project WHERE [ProjectNum] ='" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                //,SUBSTRING(job_title,3,100) As 'Jobtitle'
                rParam1 = rs["ProjectDesc"].ToString();
                //rParam1 = rs["job_title"].ToString();


            }
            conn.Close();
        }
        public DataSet WFModelCar()
        {
            string sqlCmd = "SELECT [DDLName] FROM  [TB_DropDownListDetail] WHERE [GroupID] ='" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            DataSet ds = new DataSet();
            DataTable DT = new DataTable();
            DT.Load(cmd.ExecuteReader());

            ds.Tables.Add(DT);
            conn.Close();
            return ds;
        }
        //public DataSet paygroup()
        //{
        //    string sqlCmd = "select  pay_type_num as code,pay_type_name as name From [dbo].[ppcc_esy_vch_pay_type] Where pay_group ='" + Param1 + "'";

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandTimeout = 0;
        //    DataSet ds = new DataSet();
        //    DataTable DT = new DataTable();
        //    DT.Load(cmd.ExecuteReader());

        //    ds.Tables.Add(DT);
        //    conn.Close();
        //    return ds;
        //}
        public DataSet paygroup()
        {
            string sqlCmd = "select  pay_type_name_th as code,pay_type_name as name From [dbo].[ppcc_esy_vch_pay_type] Where pay_group ='" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            DataSet ds = new DataSet();
            DataTable DT = new DataTable();
            DT.Load(cmd.ExecuteReader());

            ds.Tables.Add(DT);
            conn.Close();
            return ds;
        }

        

        public DataSet LoadTerms()
        {
            string sqlCmd = "SELECT [terms_code],[description] FROM VW_WF_Terms ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //public DataSet K2BoundCurrency()
        //{
        //    string sqlcmd = "SELECT [Code] as 'code' , [Name] as 'name' FROM [dbo].[VW_Currency] WHERE [Code] like '%" + code + "%' OR [Name] like '%" + name + "%'";
        //    SqlConnection conn = new SqlConnection(con);
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        //02/09/2018 WS
        //public DataSet K2BoundCurrency()
        //{
        //    string sqlcmd = "SELECT [Code] as 'code' , [Name] as 'name' FROM [dbo].[VW_Currency] WHERE [Code] like '%" + code + "%' OR [Name] like '%" + name + "%'";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        //public DataSet K2BoundCurrency()
        //{
        //    string sqlcmd = "SELECT [curr_code] as 'code' , [description] as 'name' FROM [dbo].[VW_Currency] WHERE [Code] like '%" + code + "%' OR [Name] like '%" + name + "%'";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        public DataSet K2BoundCurrency()
        {
            string sqlcmd = "SELECT [curr_code] as 'code' , [description] as 'name' FROM [dbo].[VW_WF_Currency] WHERE [curr_code] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundPO()
        {
            string sqlcmd = "SELECT [po_num] as 'code' , '' as 'name' FROM [dbo].[VW_WF_PO] WHERE [po_num] like '%" + code + "%' OR [po_num] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BrowseCO()
        {
            string sqlcmd = "select [co_num] as code,name as name from [dbo].[VW_WF_CO] where [co_num] like '%" + code + "%' OR name like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;


        }
        public DataSet K2BrowseCO2()
        {
            string sqlcmd = "select [co_num] as code,'' as name from [dbo].[co_mst] where [co_num] like '%" + code + "%' OR [co_num] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;


        }
        public DataSet K2BrowseCOHA()
        {
            string sqlcmd = "select distinct [QuotationNo] as code,'' as name from [dbo].[VW_WF_SA_Estimate_HA] where ([CoNum] is not null) and (QuotationNo like '%" + code + "%' OR QuotationNo like '%" + name + "%') ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;


        }
      
        public void K2BrowseCODetile()
        {
            string sqlcmd = "select [cust_num],[slsman],NameSale,[Uf_SaleSupervisor],NameSaleSup,MgrId ,MgrName ,EstCost,Price,[Uf_StandardFactor],[order_date],[terms_code],[description],name ";
            sqlcmd += "from [dbo].[VW_WF_CO] where [co_num] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {

                rParam1 = rs["cust_num"].ToString();
                rParam2 = rs["slsman"].ToString();
                rParam3 = rs["NameSale"].ToString();
                rParam4 = rs["Uf_SaleSupervisor"].ToString();
                rParam5 = rs["NameSaleSup"].ToString();
                rParam6 = rs["EstCost"].ToString();
                rParam7 = rs["Price"].ToString();
                rParam8 = rs["Uf_StandardFactor"].ToString();
                rParam9 = rs["order_date"].ToString();
                rParam10 = rs["terms_code"].ToString();
                rParam11 = rs["description"].ToString();
                rParam12 = rs["name"].ToString();
                rParam13 = rs["MgrId"].ToString();
                rParam14 = rs["MgrName"].ToString();


            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
                rParam6 = "";
                rParam7 = "";
                rParam8 = "";
                rParam9 = "";
                rParam10 = "";
                rParam11 = "";
            }

            conn.Close();


        }

        public DataSet K2BoundGRN()
        {
            string sqlcmd = "SELECT [grn_num] as 'code' , '' as 'name' FROM [dbo].[grn_hdr_mst] WHERE [grn_num] like '%" + code + "%' OR [grn_num] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        //public DataSet K2BoundExportinvoice()
        //{
        //    string sqlcmd = "select [ProcessInstanceID] as code,[InvoiceNumber] as name,[site_ref],[Project],[ExportNO],[ModeShipment],[ProjectDescription],[Customer] from [dbo].[VW_WF_ExportInvoice] where [ProcessInstanceID] like '%" + code + "%' OR [InvoiceNumber] like '%" + name + "%'";
        //    //ต้องเปลี่ยนการ Query ข้อมูล
        //    SqlConnection conn = new SqlConnection(conSLPK);//ต้องเปลี่ยน conn ถ้าเป็น K2
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;

        //}
        public DataSet K2BoundExportinvoice()
        {
            string sqlcmd = "select [ProcessInstanceID] as code,[InvoiceNumber] as name,[site_ref],[Project],[ExportNO],[ModeShipment],[ProjectDescription],[Customer] from [dbo].[VW_WF_ExportInvoice] where [ProcessInstanceID] like '%" + code + "%' OR [InvoiceNumber] like '%" + name + "%'";
            //ต้องเปลี่ยนการ Query ข้อมูล
            //SqlConnection conn = new SqlConnection(conSLPK);//ต้องเปลี่ยน conn ถ้าเป็น K2
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BoundReason()
        {
            string sqlcmd = "select [reason_code] as code,[description] as name from [dbo].[reason_mst] where [reason_code] like '%" + code + "%' OR [description] like '%" + name + "%'";
            //ต้องเปลี่ยนการ Query ข้อมูล
            SqlConnection conn = new SqlConnection(CheckConSiteRef());//ต้องเปลี่ยน conn ถ้าเป็น K2
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }



        public DataSet K2BoundWarehouse()
        {
            string sqlcmd = "SELECT [whse] as 'code',[name] as 'name' FROM [dbo].[whse_mst] WHERE [whse] like '%" + code + "%' OR [name] like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }


        public DataSet K2BoundProductCode()
        {
            string sqlcmd = "SELECT [product_code] as 'code' ,[description] as 'name' FROM [dbo].[prodcode_mst] WHERE [product_code] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }


        public DataSet K2BoundUOM()
        {
            string sqlcmd = "SELECT  [u_m] as 'code',description as 'name'  FROM [dbo].[u_m_mst] WHERE [u_m] like '%" + name + "%' OR  [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BoundCustomer()
        {
            string sqlcmd = "SELECT [cust_num] as 'code' , [LongName] as 'name' FROM [dbo].[VW_WF_Customers] WHERE [cust_num] like '%" + code + "%' OR [LongName] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundSRO()
        {
            string sqlcmd = "SELECT distinct [SRONum] as 'code',[SRODesc] as 'name' FROM [dbo].[VW_WF_SRO] WHERE [SRONum] like '%" + code + "%' OR [SRODesc] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundSupplier()
        {
            string sqlcmd = "SELECT Distinct [vend_num] as 'code',[Name] as 'name' FROM [dbo].[VW_WF_Vendors]WHERE [vend_num] like '%" + code + "%' OR [Name] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundCurrencySL()
        {
            string sqlcmd = "SELECT [curr_code] as 'code' , [description] as 'name' FROM [dbo].[VW_Currency] WHERE [curr_code] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundItemCodePk()
        {
            string sqlcmd = "SELECT [item] as 'code', [LongDescription] as 'name' FROM [dbo].[VW_WF_ItemSearch] WHERE [item] like '%" + code + "%' OR [LongDescription] like '%" + name + "%' OR [StructureID] LIKE '" + code + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public void selectItemDescription()
        {
            string sqlCmd = "SELECT [LongDescription] FROM [dbo].[VW_WF_ItemSearch] WHERE [item] = '" + code + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                itemgroup = rs["LongDescription"].ToString();

            }
            conn.Close();
        }


        public void selectProjData()
        {

            string sqlCmd = "SELECT [proj_rev],[proj_desc] FROM [dbo].[VW_Proj] WHERE [proj_num] = '" + Proj_Num + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                revenue = rs["proj_rev"].ToString();
                projDesc = rs["proj_desc"].ToString();

            }
            conn.Close();

        }

        public void selectItemGroup()
        {

            string sqlCmd = "SELECT [group_desc] FROM [dbo].[VW_ItemGroup] WHERE [group_name] = '" + code + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                itemgroup = rs["group_desc"].ToString();

            }
            conn.Close();

        }
        public DataSet K2BoundWare()
        {

            string sqlcmd = "select [whse] as code , [name] as name , loc , cost , u_m from [dbo].[VW_Warehouse] where ([item] = '" + code + "')";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;



        }
        public void K2BoundWareSelectData()
        {
            string sqlCmd = "select [whse] as code , [name] as name , loc , cost , u_m from [dbo].[VW_Warehouse] where [item] = '" + rParam1 + "' and ([whse] like '%" + code + "%' AND [name]  like '%" + name + "%')";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["item"].ToString();

            }
            conn.Close();
        }

        public void K2BoundCheckLinkK2()
        {
            string sqlCmd = "SELECT TOP 1 Data FROM Server.WorklistHeader WHERE ProcInstID = " + Param1 + " ORDER BY ID DESC";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Data"].ToString();

            }
            conn.Close();
        }

        public DataSet K2BoundItem()
        {
            string sqlcmd = "select item as code,ProductDescription as name from [dbo].[VW_Item] where (item = '" + code + "' or '" + code + "' = '')";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundProj()
        {

            string sqlcmd = "select al1.ProjectNum as code,al1.ProjectDesc as name  from (select pro.Proj_num as ProjectNum,pro.proj_desc as ProjectDesc from proj_mst pro where pro.Type = 'P') al1 where ProjectNum Like '%" + code + "%' or ProjectDesc like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }


       


        public void selectProductCode()
        {
            string sqlCmd = "SELECT [description] FROM [dbo].[prodcode_mst] WHERE [product_code] = '" + code + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                itemgroup = rs["description"].ToString();

            }
        }

        public void selectWarehouse()
        {
            string sqlCmd = "SELECT [name] FROM [dbo].[whse_mst] WHERE [whse] = '" + code + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                itemgroup = rs["name"].ToString();

            }
        }

        public void selectUOM()
        {
            string sqlCmd = "SELECT [description] FROM [dbo].[u_m_mst] WHERE [u_m] = '" + code + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                itemgroup = rs["description"].ToString();

            }
        }

        public void selectSupplier()
        {
            string sqlCmd = "SELECT [Name] FROM  [dbo].[VW_WF_Vendors] WHERE [vend_num] = '" + code + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                itemgroup = rs["Name"].ToString();

            }
        }


        public DataSet K2Worklist()
        {
            string sqlcmd = "Exec [SP_Rpt_WorkList] '" + Param1 + "','" + Param2 + "','" + Param3 + "','" + Param4 + "','" + Param5 + "','" + Param6 + "','" + Param7 + "','" + Param8 + "','" + Param9 + "','" + Param10 + "','" + Param11 + "','" + Param12 + "','" + Param13 + "','" + Param14 + "','" + Param15 + "'";
            //ต้องเปลี่ยนการ Query ข้อมูล
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2WorklistSearch()
        {
            //string sqlcmd = "Select top 200 WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,max(WL.CreateDate)as CreateDate,max(WL.Activity) as Activity,WL.Site_ref,max(WL.Status) as [Status],max(WL.[User]) as [User]";
            //sqlcmd += " from(select  WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.CreateDate,WL.Activity,WL.Site_ref,WL.Status,WL.[User]";
            //sqlcmd += " from VW_Rpt_WorkList WL with(nolock) where  1=1 " + Param1;
            //sqlcmd += " )WL group by WL.K2ID	,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.Site_ref";


            ////ต้องเปลี่ยนการ Query ข้อมูล
            //SqlConnection conn = new SqlConnection(con);

            //conn.Open();
            //SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            //da.Fill(ds);
            //conn.Close();
            ds.Tables.Add(K2WorklistSearchTable());
            return ds;

        }
        public DataTable K2WorklistSearchTable()
        {
            string sqlcmd = "Select WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,max(WL.CreateDate)as CreateDate,max(WL.Activity) as Activity,WL.Site_ref,max(WL.Status) as [Status],max(WL.[User]) as [User]";
            sqlcmd += " from(select  WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.CreateDate,WL.Activity,WL.Site_ref,WL.Status,WL.[User]";
            sqlcmd += " from VW_Rpt_WorkList WL with(nolock) where  1=1 " + Param1;
            sqlcmd += " )WL group by WL.K2ID	,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.Site_ref Order by WL.K2ID DESC ";

            ClassDBConnK2 K2Conn = new ClassDBConnK2();
            return K2Conn.ExecuteReader(sqlcmd);
        }

        public DataSet K2BoundRequester()
        {

            string sqlcmd = " select Uf_UserAD as code,name from [dbo].[VW_employee_mst] ";
            sqlcmd += " where emp_type <> 'N'and name is not null  and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //public DataSet K2BoundRequester2()
        //{

        //    string sqlcmd = " select Ltrim(emp_num) as code,name,dept from [dbo].[employee_mst] ";
        //    sqlcmd += " where name is not null  and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;

        //}



        public DataSet K2BoundRequesterUserAd()
        {

            string sqlcmd = " select Uf_UserAD as code,name from [dbo].[VW_employee_mst] ";
            sqlcmd += " where name is not null  and Uf_UserAD Like '%" + code + "%' or name Like '%" + name + "%'  ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public void K2BoundWorkflowTypeandTableName()
        {
            string sqlCmd = "SELECT  CASE WHEN WT.linkNew is NULL Then wt.link Else linkNew End AS linknew,[TB_Name],tn.[Type] FROM [dbo].[TB_WorkflowType] wt LEFT JOIN [dbo].[TB_K2TableName] tn ON wt.WorkflowType = tn.WFType WHERE WorkflowType = '" + Param1 + "' AND tn.[Type] <> 'L'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["linkNew"].ToString();
                rParam2 = rs["TB_Name"].ToString();
                rParam4 = rs["Type"].ToString();
            }
            conn.Close();
        }

        public void K2BoundWorkflowIDTable()
        {
            // string sqlCmd = "SELECT ID FROM  " + rParam2 + " WHERE [ProcessInstanceID] =" + Param1;
            string sqlCmd = "SELECT  MAX(Value) as ID FROM  VW_ServerLog_ProcInstData WHERE [ProcInstID] =" + Param1 + "  and (Name='ID' or Name='RequestID' or Name='Ref_ID')";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam3 = rs["ID"].ToString();


            }
            conn.Close();
        }

        public void K2BoundWorkflowIDFactoryTable()
        {
            //string sqlCmd = "SELECT ID FROM  " + rParam2 + " WHERE [ProcessInstanceID] =" + Param1;
            string sqlCmd = "SELECT  MAX(Value) as ID FROM  VW_ServerLog_ProcInstData WHERE [ProcInstID] =" + Param1 + "  and (Name='ID')";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam3 = rs["ID"].ToString();


            }
            conn.Close();
        }

        public void K2BoundPFromPR()
        {
            string sqlCmd = "SELECT ref_num,proj_desc FROM [VW_Purchade_Requisition] WHERE req_num = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(conSLPK);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["ref_num"].ToString();
                rParam2 = rs["proj_desc"].ToString();


            }
            conn.Close();
        }


        //public void K2BoundEmpInfo()
        //{
        //    string sqlCmd = "SELECT y.*,[name],SUBSTRING(dept,1,3) As 'Department',SUBSTRING(dept,1,1) As 'SubDepartment',SUBSTRING(job_title,3,100) As 'Jobtitle',(CASE WHEN  y.LongMonth < 0 THEN y.LongYear-1 ELSE y.LongYear END) as 'LiveYear' ";
        //    sqlCmd += ",(CASE WHEN  y.LongMonth < 0 THEN 12+y.LongMonth ELSE y.LongMonth END) as 'LiveMonth' FROM ";
        //    sqlCmd += "( SELECT *,YEAR(GETDATE()) - YEAR(hire_date) as 'LongYear',MONTH(GETDATE()) - MONTH(hire_date) as 'LongMonth' ";
        //    sqlCmd += " ,dept as 'Deptt'  FROM [dbo].[VW_WF_Employees] WHERE emp_num = '" + Param1 + "')y";

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {
        //        //,SUBSTRING(job_title,3,100) As 'Jobtitle'
        //        rParam1 = rs["Jobtitle"].ToString();
        //        //rParam1 = rs["job_title"].ToString();
        //        rParam2 = rs["Uf_Level"].ToString();
        //        rParam3 = rs["Uf_Location"].ToString();
        //        rParam4 = rs["LiveYear"].ToString();
        //        rParam5 = rs["LiveMonth"].ToString();
        //        rParam6 = rs["Department"].ToString();
        //        rParam10 = rs["SubDepartment"].ToString();
        //        rParam11 = rs["dept"].ToString();
        //        rParam12 = rs["name"].ToString();

        //    }
        //    conn.Close();
        //}

        public void K2BoundEmpInfo()
        {
            string sqlCmd = "SELECT y.*,[name],SUBSTRING(dept,1,3) As 'Department',SUBSTRING(dept,1,1) As 'SubDepartment',job_title As 'Jobtitle',(CASE WHEN  y.LongMonth < 0 THEN y.LongYear-1 ELSE y.LongYear END) as 'LiveYear' ";
            sqlCmd += ",(CASE WHEN  y.LongMonth < 0 THEN 12+y.LongMonth ELSE y.LongMonth END) as 'LiveMonth' FROM ";
            sqlCmd += "( SELECT *,YEAR(GETDATE()) - YEAR(hire_date) as 'LongYear',MONTH(GETDATE()) - MONTH(hire_date) as 'LongMonth' ";
            sqlCmd += " ,dept as 'Deptt'  FROM [dbo].[VW_WF_Employees] WHERE emp_num = '" + Param1 + "')y";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                //,SUBSTRING(job_title,3,100) As 'Jobtitle'
                rParam1 = rs["Jobtitle"].ToString();
                //rParam1 = rs["job_title"].ToString();
                rParam2 = rs["Uf_Level"].ToString();
                rParam3 = rs["Uf_Location"].ToString();
                rParam4 = rs["LiveYear"].ToString();
                rParam5 = rs["LiveMonth"].ToString();
                rParam6 = rs["Department"].ToString();
                rParam10 = rs["SubDepartment"].ToString();
                rParam11 = rs["dept"].ToString();
                rParam12 = rs["name"].ToString();

            }
            conn.Close();
        }


        public void K2BoundIDTable()
        {
            string sqlCmd = Param1;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["ID"].ToString();



            }
            conn.Close();
        }
        public DataSet K2TableName_insert()
        {

            string sqlcmd = "EXEC SP_TBK2TableName_insert '" + Param11 + "','" + Param12 + "','" + Param13 + "','" + Param14 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2NewWFType_select()
        {

            string sqlcmd = "SELECT [WorkflowType],[WorkflowType] + ' - ' + [Description] as 'Name' ";
            sqlcmd += " FROM [dbo].[TB_WorkflowType] WHERE [WorkflowType] NOT IN (SELECT [WFType] FROM  [dbo].[TB_K2TableName]  )";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void K2CheckWFName()
        {
            string sqlCmd = "SELECT TOP 1 [Description] FROM [dbo].[TB_WorkflowType] WHERE [WorkflowType] = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Description"].ToString();



            }
            conn.Close();
        }


        public DataSet K2Column_select()
        {

            string sqlcmd = "EXEC SP_ColumnName_select '" + Param2 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void K2CountGVLine()
        {
            string sqlCmd = "SELECT COUNT([ID]) as 'ID' FROM [dbo].[TB_TBNameLine] WHERE [WFType] = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["ID"].ToString();



            }
            conn.Close();
        }
        public void K2CheckTBGVLine()
        {
            string sqlCmd = "SELECT [TB_Name],[Type]  FROM [dbo].[TB_TBNameLine] WHERE [WFType] = '" + Param1 + "' AND [GV_Num] = " + Param2;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["TB_Name"].ToString();
                rParam2 = rs["Type"].ToString();


            }
            conn.Close();
        }
        public DataSet K2UpdateAndClearGVLine()
        {

            string sqlcmd = Param3;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public void K2BrowseEmpAll()
        {
            string sqlCmd = "select [Emp_num],[name],[dept],[username] from [dbo].[VW_Employee_All] where username = REPLACE('" + Param1 + "','PATKOL\\','') AND [Site_ref] = '" + Param2 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Emp_num"].ToString();
                rParam2 = rs["name"].ToString();
                rParam3 = rs["dept"].ToString();
                rParam4 = rs["username"].ToString();


            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
            }
            conn.Close();
        }


        //CP Add 27/10/2016-----------------------------------------------------------------------------------------------------------------------

        public DataSet SP_Enquiry_Line_Insert()
        {

            string sqlcmd = "EXEC SP_Enquiry_Line_Insert '" + Param1 + "','" + Param2 + "','" + SiteRef + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void K2BrowseEmpInfor()
        {
            if (Param1 != "")
            {
                string sqlCmd = "select emp.[name],emp.[dept],emp.[username],emp.[Uf_FullNameEN],emp.[Uf_Level],posi.Uf_jobtitle as JobTitle from [dbo].[employee_mst] emp";
                sqlCmd += " left join emp_pos_mst pos";
                sqlCmd += " ON emp.emp_num = pos.emp_num";
                sqlCmd += " left join position_mst posi";
                sqlCmd += " ON posi.job_id = pos.job_id where emp.Emp_num Like '%" + Param1 + "%'";

                SqlConnection conn = new SqlConnection(CheckConSiteRef());
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlCmd, conn);
                cmd.CommandType = CommandType.Text;
                // cmd.CommandTimeout = 300;
                SqlDataReader rs = cmd.ExecuteReader();

                if (rs.Read())
                {

                    rParam1 = rs["name"].ToString();
                    rParam2 = rs["dept"].ToString();
                    rParam3 = rs["username"].ToString();
                    rParam4 = rs["Uf_FullNameEN"].ToString();
                    rParam5 = rs["Uf_Level"].ToString();

                    rParam6 = rs["JobTitle"].ToString();

                }
                else
                {
                    rParam1 = "";
                    rParam2 = "";
                    rParam3 = "";

                }
                conn.Close();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";

            }
        }


        public void K2BrowseCustInfor()
        {
            string sqlCmd = "select [name] from [dbo].[custaddr_mst] where [cust_num] = '" + Param1 + "' AND [cust_seq] = 0";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["name"].ToString();



            }
            else
            {
                rParam1 = "";


            }
            conn.Close();
        }

        public void K2BrowseProjSroDesc()
        {
            string sqlCmd = "SELECT y.* FROM ( ";
            sqlCmd += "SELECT [sro_num] as 'Code',Description,[cust_num],[total_price] as Rev FROM [dbo].[fs_sro_mst] ";
            sqlCmd += "UNION ALL ( SELECT [proj_num] as 'Code',[proj_desc] as 'Description',[cust_num],[proj_rev] as Rev FROM [dbo].[proj_mst] WHERE [type] = 'P') ";
            sqlCmd += ")y WHERE y.Code = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Description"].ToString();
                rParam2 = rs["cust_num"].ToString();
                rParam3 = rs["Rev"].ToString();

            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
            }
            conn.Close();
        }

        public DataSet K2BrowseProjSro()
        {

            string sqlCmd = "SELECT y.* FROM ( ";
            sqlCmd += "SELECT [sro_num] as 'Code',Description as 'Name',[cust_num] FROM [dbo].[fs_sro_mst] ";
            sqlCmd += "UNION ALL ( SELECT [proj_num] as 'Code',[proj_desc] as 'Description',[cust_num] FROM [dbo].[proj_mst] WHERE [type] = 'P') ";
            sqlCmd += ")y WHERE y.Code like '%" + code + "%' OR y.Name LIKE '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BrowsePR()
        {

            string sqlCmd = "SELECT [req_num] as 'Code',[Uf_PurchaseType] as 'Name' FROM [dbo].[preq_mst] WHERE req_num like '%" + code + "%' OR  Uf_PurchaseType = '%" + name + "%'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BrowseEst()
        {

            string sqlCmd = "SELECT [co_num] as 'Code', '' as 'Name' FROM [dbo].[co_mst] WHERE [type] = 'E' AND co_num like '%" + code + "%'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        //public DataSet K2BrowseEst()
        //{

        //    string sqlCmd = "SELECT [co_num] as 'Code', '' as 'Name' FROM [dbo].[co_mst] WHERE [type] = 'E' AND co_num like '%" + code + "%'";


        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;

        //}
        public DataSet K2BrowseCOLine()
        {

            string sqlCmd = "SELECT y.Code,y.Name FROM (SELECT [co_line] as 'Code', [item]+ ' '+[Uf_ItemLongDesc] as 'Name',[co_num] FROM [dbo].[coitem_mst])y WHERE  y.[co_num] = '" + Param1 + "' AND (y.Code like '%" + code + "%' OR y.Name like '%" + name + "%')";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BrowseEmp()
        {

            string sqlCmd = "SELECT [emp_num] as 'Code' ,[name] as 'Name' FROM [dbo].[employee_mst] WHERE (emp_num like '%" + code + "%' OR name like '%" + name + "%')";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BrowseEmpTG()
        {

            string sqlCmd = "SELECT [emp_num] as 'Code' ,[name] as 'Name' FROM [dbo].[employee_mst] WHERE emp_type <> 'N' and (emp_num like '%" + code + "%' OR name like '%" + name + "%')";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
       
        public void K2BrowseCOLineDesc()
        {
            string sqlCmd = "SELECT [item],[Uf_ItemLongDesc],[qty_ordered] FROM [dbo].[coitem_mst] WHERE [co_num] = '" + Param1 + "' AND [co_line] = '" + Param2 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["item"].ToString();
                rParam2 = rs["Uf_ItemLongDesc"].ToString();
                rParam3 = rs["qty_ordered"].ToString();

            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";

            }
            conn.Close();
        }


        public void K2GetEnquiryNo()
        {
            string sqlCmd = "EXEC SP_PD_CalEnqNum '" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["PrefixEnq"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }

        public DataSet K2UpdateEnquiryLine_PO_CO()
        {

            string sqlCmd = "EXEC SP_PD_UpdatePOCO '" + Param1 + "','" + Param2 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void K2CheckCOSourceTOJob()
        {
            //string sqlCmd = "SELECT COUNT([co_num]) as 'Count' FROM [dbo].[coitem_mst] WHERE [co_num] = '" + Param1 + "' AND ISNULL([ref_num],'') = ''";
            string sqlCmd = "SELECT COUNT([co_num]) as 'Count' FROM [dbo].[coitem_mst] WHERE [co_num] = '" + Param1 + "' AND ISNULL([ref_num],'') = '' AND Uf_InternalStatus <> 'Reject' ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Count"].ToString();

            }
            else
            {
                rParam1 = "1";

            }
            conn.Close();
        }

        public DataSet K2BrowseInv()
        {

            string sqlCmd = "SELECT [emp_num] as 'Code' ,[name] as 'Name' FROM [dbo].[employee_mst] WHERE emp_type <> 'N' and (emp_num like '%" + code + "%' OR name like '%" + name + "%')";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2AttManul_Select()
        {

            string sqlCmd = "SELECT [WFType],[NameHeader] FROM [dbo].[TB_K2AttachManual] WHERE  WFType LIKE '%" + Param1 + "%' ORDER BY WFType ASC";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataTable GetDataManul()
        {
            DataTable dt = new DataTable();
            //String strConnString = System.Configuration.ConfigurationManager
            //.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(con);
            SqlDataAdapter sda = new SqlDataAdapter();
            string sqlCmd = "SELECT [DataHeader] as Data,[ContentTypeHeader] as ContentType,[NameHeader] as Name FROM [dbo].[TB_K2AttachManual] WHERE [WFType] =  '" + Param1 + "' AND  DataHeader IS NOT NULL AND DataHeader <> '' ";
            SqlCommand cmd = new SqlCommand(sqlCmd);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            try
            {
                conn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
                sda.Dispose();
                conn.Dispose();
            }
        }

        public DataSet BoundProjSL()
        {


            string sqlcmd = "SELECT [proj_num] as 'code' , proj_desc as 'name' FROM [dbo].[proj_mst] WHERE [proj_num] like '%" + code + "%' OR [proj_desc] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet BoundItem()
        {


            string sqlcmd = "SELECT distinct [item] as 'code' , [Uf_LongDesc] as 'name' FROM [dbo].[item_mst] WHERE [item] like '%" + code + "%' OR [Description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet BoundPurchase()
        {


            string sqlcmd = "SELECT [po_num] as 'code' , [vend_num] as 'name' FROM [dbo].[po_mst] WHERE [po_num] like '%" + code + "%' OR [vend_num] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //Edit by WO 23/08/2017 เพิ่ม SRO
        public void LoadDataProj()
        {
            string sqlCmd = "select y.* from (select p.proj_num,ca.cust_num,ca.name,p.Uf_MngID,pji.ProjEngineer,isnull(ca.addr##1,'') + ' ' + isnull(ca.addr##2,'') + ' ' + isnull(ca.addr##3,'') + ' ' + isnull(ca.addr##4,'') as shipto ";
            sqlCmd += " from [dbo].[proj_mst]  as p left join [dbo].[TB_ProjInfo] pji on pji.ProjNum = p.proj_num";
            sqlCmd += " left join [dbo].[custaddr_mst] as ca on ca.[cust_num] = p.[cust_num] and ca.cust_seq = p.cust_seq ";
            sqlCmd += " Union all ";
            sqlCmd += " SELECT s.sro_num as proj_num,s.cust_num,ca.name,s.bill_mgr as Uf_MngID,s.partner_id as ProjEngineer,isnull(ca.addr##1,'') + ' ' + isnull(ca.addr##2,'') + ' ' + isnull(ca.addr##3,'') + ' ' + isnull(ca.addr##4,'') as shipto ";
            sqlCmd += " FROM [dbo].[fs_sro_mst] s ";
            sqlCmd += " left join [dbo].[custaddr_mst] as ca on ca.[cust_num] = s.[cust_num] and ca.cust_seq = s.cust_seq) y ";
            sqlCmd += " where [proj_num] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["cust_num"].ToString();
                rParam2 = rs["name"].ToString();
                rParam3 = rs["Uf_MngID"].ToString();
                rParam4 = rs["ProjEngineer"].ToString();
                rParam5 = rs["shipto"].ToString();


            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
            }
            conn.Close();
        }

        public void LoadDataEmp()
        {
            string sqlCmd = "select * from [dbo].[employee_mst] where [emp_num] like '%" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Uf_UserAD"].ToString();

            }
            else
            {
                rParam1 = "";
            }
            conn.Close();
        }

        public DataSet BoundSafetyOff()
        {

            string sqlcmd = " select Ltrim(emp_num) as code,name,dept,site_ref,Uf_EmpStatus from [dbo].[employee_mst] ";
            sqlcmd += " where name is not null and dept = '1MG511' and Uf_EmpStatus = '1' and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }


        public DataSet K2BrowseCarType()
        {

            string sqlCmd = "SELECT [MainGroup] as 'Code' ,'' as 'Name' FROM [dbo].[TB_CarType] WHERE MainGroup like '%" + code + "%' OR MainGroup like '%" + name + "%'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BrowseTypeOfCar()
        {

            string sqlCmd = "SELECT [MainGroup] as 'Code' ,'' as 'Name' FROM [dbo].[TB_TypeOfCar] WHERE MainGroup like '%" + code + "%' OR MainGroup like '%" + name + "%'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BrowseModelOfCar()
        {

            string sqlCmd = "SELECT [Name] as 'Code' ,'' as 'Name' FROM [dbo].[VW_ModelOfCar] WHERE (Name like '%" + code + "%' OR Name like '%" + name + "%') AND  [MainGroup] ='" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2DeleteCarLine()
        {

            string sqlCmd = "DELETE [dbo].[TB_DeliveryGoods_CarLine] WHERE [ID] = " + Param1;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2DeleteCarLineTG()
        {

            string sqlCmd = "DELETE [dbo].[TB_PD_DeliveryGoodsTG_CarLine] WHERE [ID] = " + Param1;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BrowseLineOfCar()
        {

            string sqlCmd = "SELECT [Line] as 'Code' ,[TypeOfCar] + ' ' +[ModelOfCar]+ ' ('+CONVERT(NVARCHAR(10),[Qty])+')' as 'Name' FROM [dbo].[TB_DeliveryGoods_CarLine] WHERE   [Ref_ID] ='" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BrowseLineOfCarTG()
        {

            string sqlCmd = "SELECT [Line] as 'Code' ,[TypeOfCar] + ' ' +[ModelOfCar]+ ' ('+CONVERT(NVARCHAR(10),[Qty])+')' as 'Name' FROM [dbo].[TB_PD_DeliveryGoodsTG_CarLine] WHERE   [Ref_ID] ='" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //public DataSet BoundPosition()
        //{


        //    string sqlcmd = "SELECT DISTINCT '' as 'code' , [job_title] as 'name' FROM [dbo].[position_mst] WHERE [job_title] like '%" + code + "%'";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;

        //}
        //Ws 02/09/2018
        public DataSet BoundPosition()
        {


            string sqlcmd = "SELECT DISTINCT '' as 'code' , [Uf_Jobtitle] as 'name' FROM [dbo].[position_mst] WHERE [Uf_Jobtitle] like '%" + code + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet BoundCostCenter()
        {


            string sqlcmd = "SELECT [dept] as 'code' , [description] as 'name' FROM [dbo].[dept_mst] WHERE [dept] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();





            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet BoundDivision()
        {


            string sqlcmd = "SELECT SUBSTRING(dept,1,3)  as 'code' , SUBSTRING(dept,2,2) As 'name' FROM [dbo].[dept_mst] WHERE [dept] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet BoundLocation()
        {


            string sqlcmd = "SELECT [Location] as 'code' , [Description] as 'name' FROM [dbo].[TB_Location] WHERE [Location] like '%" + code + "%' OR [Description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //public DataSet BoundTDOper()
        //{

        //    string sqlcmd = " select Ltrim(emp_num) as code,name,dept,site_ref,Uf_EmpStatus from [dbo].[employee_mst] ";
        //    sqlcmd += " where name is not null and dept Like '%TD%' and Uf_EmpStatus = '1' and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;

        //}
        public DataSet BoundTDOper()
        {

            string sqlcmd = " select Ltrim(emp_num) as code,name,dept,site_ref,Uf_EmpStatus from [dbo].[employee_mst] ";
            sqlcmd += " where name is not null and (dept Like '%EN%' or dept Like '%TD%' OR dept Like '%QA%') and Uf_EmpStatus = '1' and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet BoundTypeIn()
        {

            string sqlcmd = " select Distinct Type_ing as code,'' as name from [dbo].[TB_EN_Charge] ";
            sqlcmd += " where  Type_ing Like '%" + code + "%' or Type_ing Like '%" + name + "%'  ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet BoundTypeEq()
        {

            string sqlcmd = " select Distinct '' as code,Type_equ as name from [dbo].[TB_EN_Charge] ";
            sqlcmd += " where [Status] = 'A' and Type_ing = '" + Param1 + "' and Type_equ Like '%" + code + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void LoadDataENChang()
        {
            string sqlCmd = "select [Cost],[UM],[EmpAD_Step3],[EmpAD_Step4] from [dbo].[TB_EN_Charge] where [Type_ing] = '" + Param1 + "' and [Type_equ] = '" + Param2 + "' and [Status] = 'A'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Cost"].ToString();
                rParam2 = rs["UM"].ToString();
                rParam3 = rs["EmpAD_Step3"].ToString();
                rParam4 = rs["EmpAD_Step4"].ToString();

            }
            else
            {
                rParam1 = "";
            }
            conn.Close();
        }



        //CP Add 23/11/2016-----------------------------------------------------------------------------------------------------------------------

        public DataSet K2BrowseCarTypePKFlow()
        {

            string sqlCmd = "SELECT [CarCode] as code,[CarType] as name FROM [dbo].[TB_CarType] WHERE  CarCode like '%" + code + "%' OR CarType like '%" + name + "%'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        // WS 15/08/2017
        public void K2SelectCarTypePKFlow()
        {
            string sqlCmd = "SELECT [CostOfDay] ,[CostOfDaySelfServ] ,[CostOfDaywithDriv] FROM [dbo].[TB_CarType] WHERE [CarCode] = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["CostOfDaySelfServ"].ToString();
                rParam2 = rs["CostOfDaywithDriv"].ToString();//50
                rParam3 = rs["CostOfDay"].ToString();
                //rParam2 = rs["Driver"].ToString();


            }
            else
            {
                rParam1 = "0";
                rParam2 = "0";
                rParam3 = "0";
            }
            conn.Close();
        }

        public DataSet K2BrowseCarLicPKFlow()
        {

            string sqlCmd = "SELECT [Lisence]+'('+[CarLocation]+')' AS code,[Detail] AS name FROM [dbo].[TB_CarLisence] WHERE Status = 'A' AND [CarType] = '" + Param1 + "' AND (Lisence like '%" + code + "%' OR Detail like '%" + name + "%')";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public void K2SelectCarLicPKFlow()
        {
            string sqlCmd = "SELECT   ItemNumbers.Description AS name From ItemNumbers WHERE ItemNumbers.Number = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["name"].ToString();


            }
            else
            {
                rParam1 = "0";

            }
            conn.Close();
        }

        public DataSet K2BrowseCompanyInfo()
        {

            string sqlCmd = "SELECT y.code,y.name FROM ( SELECT '' as code , [Uf_Parms_THAcompany] + ' ' + ISNULL([Uf_Parms_THAaddr_1],'') + ' ' + ISNULL([Uf_Parms_THAaddr_2],'') + ' ' + ISNULL([Uf_Parms_THAaddr_3],'') + ' ' + ISNULL([Uf_Parms_THAaddr_4],'') as name FROM [dbo].[parms_mst_all] WHERE [Uf_Parms_THAcompany] IS NOT NULL)y WHERE y.name like '%" + name + "%'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }


        public DataSet K2BrowseServiceCenterofRepairing()
        {

            string sqlCmd = "SELECT   '' as code, NameStatus as name FROM  TB_ServiceCenterofRepairing  where  NameStatus like '%" + code + "%'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public void K2BrowseIDEnquiry()
        {
            string sqlCmd = "SELECT [ID] FROM [dbo].[TB_Enquiry03] WHERE [EnquiryNo] = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["ID"].ToString();



            }
            else
            {
                rParam1 = "";


            }
            conn.Close();
        }
        public void K2SelectItemCodeInfo()
        {
            string sqlCmd = "SELECT [StructureID],[ItemCharacteristic],[ItemCodeDescription],[ItemCodeGenerate],[ItemGroup],[ProductCode],Buyer FROM [dbo].[TB_CreateNewItemCode] WHERE ID =  " + Param1;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["StructureID"].ToString();
                rParam2 = rs["ItemCharacteristic"].ToString();
                rParam3 = rs["ItemCodeDescription"].ToString();
                rParam4 = rs["ItemCodeGenerate"].ToString();
                rParam5 = rs["ItemGroup"].ToString();
                rParam6 = rs["ProductCode"].ToString();
                rParam7 = rs["Buyer"].ToString();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
                rParam6 = "";
                rParam7 = "";

            }
            conn.Close();
        }

        public void LoadPOforPU12()
        {
            string sqlCmd = "select po.po_num,poi.req_num as 'pr',po.po_cost as 'AmtPo',po.Vend_num,v.name as 'Contract',poi.ref_num as 'RefNum',proj.cust_num,cust.name as 'RefName' from po_mst po ";
            sqlCmd += " left join poitem_mst poi on poi.po_num = po.po_num";
            sqlCmd += " left join vendaddr_mst v on v.vend_num = po.vend_num";
            sqlCmd += " left join proj_mst proj on proj.proj_num = poi.ref_num";
            sqlCmd += " left join custaddr_mst cust on cust.cust_num = proj.cust_num";
            sqlCmd += " where po.po_num = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["pr"].ToString();
                rParam2 = rs["AmtPo"].ToString();
                rParam3 = rs["Contract"].ToString();
                rParam4 = rs["RefNum"].ToString();
                rParam5 = rs["Refname"].ToString();
            }
            conn.Close();
        }

        public DataSet K2BrowseProjSroTask()
        {

            string sqlCmd = "SELECT [task_num]  as 'Code',[task_desc]  as 'Name'   FROM VW_ProjSroTask WHERE [proj_num] = '" + Param1 + "' AND (task_num like '%" + code + "%' OR  task_desc = '%" + name + "%')";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BoundRequester2()
        {
            string sqlcmd = " select distinct Ltrim(emp_num) as code,name,dept,site_ref from [dbo].[VW_employee_mst] ";
            sqlcmd += " where emp_type <> 'N' and name is not null  and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;



            //string sqlcmd = " select distinct Ltrim(emp_num) as code,name,dept from [dbo].[VW_Employee_All] ";
            //sqlcmd += " where name is not null  and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

            //SqlConnection conn = new SqlConnection(con);
            //conn.Open();
            //SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //conn.Close();
            //return ds;
         

        }

        //CP Add 23/11/2016-----------------------------------------------------------------------------------------------------------------------

        public DataSet K2BrowseCarLicPATag()
        {

            string sqlCmd = "select pa_tag_carid as code,PA_TAG_DETAIL as name from PA_TAG_Master WHERE PA_TAG_BTY in ( 'ซื้อขาด','ส่วนตัว') AND PA_TAG_STATUS = 'Active' AND (pa_tag_carid like '%" + code + "%' OR PA_TAG_DETAIL like '%" + name + "%')";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void K2BrowseAttendent()
        {
            string sqlCmd = "SELECT TOP 1 SUBSTRING(pat.[PA_PE_CODE],3,2) + SUBSTRING(pat.[PA_PE_CODE],6,8) as 'EmpNum',PA_PE_NAME,YEAR(GETDATE()) - YEAR(pam.[PA_TAG_DATE]) as carAge from [dbo].[PA_TAG_MASTER] pam LEFT JOIN  PA_TAG_PE  pat ON pam.[PA_TAG_CODE] = pat.[PA_TAG_CODE] WHERE  pa_tag_carid = '" + Param1 + "' order by pa_tag_carid,[PA_PE_ID] DESC";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["PA_PE_NAME"].ToString();
                rParam2 = rs["EmpNum"].ToString();
                rParam3 = rs["carAge"].ToString();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
            }
            conn.Close();
        }

        public void K2BrowsePATotalCost()
        {
            string sqlCmd = "SELECT pam.[PA_TAG_CODE], SUM(ISNULL(pat.[PA_MA_PRICE],0)) as 'TotalPrice' FROM  [dbo].[PA_TAG_MASTER] pam LEFT JOIN[dbo].[PA_TAG_MA] pat ON pam.[PA_TAG_CODE] = pat.[PA_TAG_CODE] WHERE  pa_tag_carid = '" + Param1 + "'  GROUP BY pam.[PA_TAG_CODE]";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["TotalPrice"].ToString();
                //rParam2 = rs["EmpNum"].ToString();
            }
            else
            {
                rParam1 = "";
                //rParam2 = "";
            }
            conn.Close();
        }

        public void K2BrowsePAMileCost()
        {
            string sqlCmd = "SELECT TOP 1 [PA_MA_PRICE],[PA_MA_MILE],[PA_MA_DATE] FROM  [dbo].[PA_TAG_MASTER] pam LEFT JOIN[dbo].[PA_TAG_MA] pat ON pam.[PA_TAG_CODE] = pat.[PA_TAG_CODE] WHERE  pa_tag_carid = '" + Param1 + "'  ORDER BY [PA_MA_DATE] DESC";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["PA_MA_PRICE"].ToString();
                rParam2 = rs["PA_MA_MILE"].ToString();
                rParam3 = rs["PA_MA_DATE"].ToString();
            }
            else
            {
                rParam1 = "0";
                rParam2 = "0";
                rParam3 = "0";
            }
            conn.Close();
        }
        //SB Add 18/01/2017--------------------------------------------------------------------------------
        public DataSet K2BrowseProvince2()
        {
            string sqlcmd = " select [state] as code,[Uf_DescriptionTH] as name from [dbo].state_mst Where (state Like '%" + code + "%' or '%" + code + "%' = '%%' or  [Uf_DescriptionTH] Like '%" + name + "%' or '%" + name + "%' = '%%')";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundProsro3()
        {
            string sqlcmd = "select  code,name from [VW_Projec_Job_Co]  WHERE code like '%" + code + "%' OR name like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BoundProshopdrawing()
        {
            string sqlcmd = "select distinct Project as code,'' as name from [TB_PJ_ShopDrawingApprove]  WHERE Project like '%" + code + "%' OR Project like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BrowseTark()
        {

            string sqlcmd = "SELECT code,name,Protark FROM [dbo].[VW_Tark_Projec_Job_Co] WHERE Protark = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundMia2()
        {

            //string sqlcmd = "SELECT DISTINCT [uf_mia] as code,'' as name FROM Vw_MiaAllForJob WHERE JobNum = '" + Param1 + "' AND task_num = '" + Param2 + "'";
            string sqlcmd = "SELECT DISTINCT [uf_mia] as code,'' as name FROM Vw_MiaAllForJob WHERE JobNum = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //SB Add 19/01/2017-----------WS Revise 19/02/2018---------------------------------------------------------------------
        public DataSet K2BoundCostcenter()
        {

            string sqlcmd = "select distinct  Dept as code,[Description] as name from [dbo].[dept_mst]";
            sqlcmd += "WHERE dept like '%" + code + "%' OR description like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

            //string sqlcmd = " select distinct  dept as code,[description] as name from [dbo].[VW_Employee_All] ";
            //sqlcmd += "WHERE dept like '%" + code + "%' OR description like '%" + name + "%'";

            //SqlConnection conn = new SqlConnection(con);
            //conn.Open();
            //SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //conn.Close();
            //return ds;


        }

        // WO Add 26/01/2017-------------------------------------------------------------------------------------------------------
        //public DataSet K2BoundDiv()
        //{

        //    string sqlcmd = "SELECT [div_num] as code,[dept] as name FROM [dbo].[dept_mst] WHERE [div_num] Like '%" + code + "%' or [dept] Like '%" + name + "%'  ";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;

        //}

        // WO Add 26/01/2017-------------------------------------------------------------------------------------------------------
        public DataSet K2BoundDiv()
        {

            string sqlcmd = "SELECT [dept] as code,[description] as name FROM [dbo].[dept_mst] WHERE [div_num] Like '%" + code + "%' or [dept] Like '%" + name + "%'  ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //SB Add 31/01/2017--------------------------------------------------------------------------------
        public DataSet BoundProjReturnmatNotmia()
        {


            string sqlcmd = " select DISTINCT Top 50 Project as code, ProjectDescription as name from [VW_Item_Project] ";
            sqlcmd += "where Project like '%" + code + "%' OR ProjectDescription like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;



        }


        public DataSet K2BrowseItemReturnmatNotmia()
        {
            //string sqlcmd = "select DISTINCT Top 50 itemcode as code , description as name from VW_Item_Project where project = '" + Param1 + "'";
            string sqlcmd = "select DISTINCT Top 50 item as code , ProductDescription as name from VW_Item where item Like '%" + code + "%' or ProductDescription Like '%" + name + "%'  ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BrowsePOReturnmatNotmia()
        {
            //string sqlcmd = "select DISTINCT Top 50 itemcode as code , description as name from VW_Item_Project where project = '" + Param1 + "'";
            string sqlcmd = "select DISTINCT Top 50 PO as code,'' as name from VW_Item_Project where itemcode  = '" + Param1 + "' AND (PO like '%" + code + "%' OR  PO  = '%" + name + "%') ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //public void K2BrowsePOReturnmatNotmia()
        //{

        //    string sqlCmd = "select DISTINCT Top 50 PO from VW_Item_Project where project = '" + Param1 + "'";

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {
        //        rParam1 = rs["PO"].ToString();

        //    }
        //    else
        //    {
        //        rParam1 = "";

        //    }
        //    conn.Close();

        //}
        //------Update By SB 02/02/2017 Start Version Loq
        //CP Add 26/01/2017--------------------------------------------------------------------------------

        public DataSet K2BrowseCarLineRef_select()
        {

            string sqlCmd = "EXEC [dbo].[SP_PD_DeliveryGoods_CarLineRef_select] '" + Param1 + "','" + Param2 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BrowseCarLineRefTG_select()
        {

            string sqlCmd = "EXEC [dbo].[SP_PD_DeliveryGoodsTG_CarLineRef_select] '" + Param1 + "','" + Param2 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }


        public void K2SelectDeliveryGoodsTotalCost()
        {
            string sqlCmd = "SELECT [TotalCost] FROM [dbo].[TB_DeliveryGoods02] WHERE ID = " + Param1 + "";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["TotalCost"].ToString();
                //rParam2 = rs["EmpNum"].ToString();
            }
            else
            {
                rParam1 = "";
                //rParam2 = "";
            }
            conn.Close();
        }

        public void K2SelectDeliveryGoodsTGTotalCost()
        {
            string sqlCmd = "SELECT [TotalCost] FROM [dbo].[TB_PD_DeliveryGoodsTG] WHERE ID = " + Param1 + "";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["TotalCost"].ToString();
                //rParam2 = rs["EmpNum"].ToString();
            }
            else
            {
                rParam1 = "";
                //rParam2 = "";
            }
            conn.Close();
        }

        // By SB 08/02/2017 Worklist V3
        public DataSet K2BrowseWorkFlowType()
        {
            string sqlCmd = " select distinct WorkflowType as code,WorkflowType + ' / ' + Description as name  from [dbo].[TB_WorkflowType] where MainType='" + Param1 + "' and WorkflowType is not null and Description is not null order by WorkflowType asc ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BrowseWorkFlowTypeForMyTask()
        {
            string sqlCmd = " select distinct WorkflowType as code,WorkflowType + ' / ' + Description as name  from [dbo].[TB_WorkflowType] where MainType='" + Param1 + "' and WorkflowType is not null and Description is not null AND LEN(WorkflowType) =  4 order by WorkflowType asc ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BrowseWorkFlowTypeNoMaintype()
        {
            string sqlCmd = " select distinct WorkflowType as code,WorkflowType + ' / ' + Description as name  from [dbo].[TB_WorkflowType] where  WorkflowType is not null and Description is not null order by WorkflowType asc ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //CP Add 08/02/2017--------------------------------------------------------------------------------
        public void K2CheckSireRefDef()
        {
            string sqlCmd = "SELECT TOP 1 [Site_ref],[Uf_Location] FROM [dbo].[VW_Employee_All_OverSea] WHERE [Uf_Location] is not null and RTRIM(LTRIM([Emp_num] )) = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["Site_ref"].ToString();
                rParam2 = rs["Uf_Location"].ToString();
            }
            else
            {
                rParam1 = "ERP_PK";
                rParam2 = "SL";
            }
            conn.Close();
        }
        // By SB 14/02/2017 Discard Asset
        public DataSet K2BrowseAsset()
        {

            string sqlcmd = "select   fa_num as code,fa_desc as name from [dbo].[famaster_mst]WHERE fa_num like '%" + code + "%' OR fa_desc like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //WO Start Add 15/02/2017--------------------------------------------------------------------------------

        public DataSet K2WorkflowSearch()
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(K2WorkflowSearchTable());
            return ds;

        }
        public DataTable K2WorkflowSearchTable()
        {
            string sqlcmd = "Select WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,max(WL.CreateDate)as CreateDate,max(WL.Activity) as Activity,WL.Site_ref,max(WL.Status) as [Status],max(WL.[User]) as [User]";
            sqlcmd += " from(select  WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.CreateDate,WL.Activity,WL.Site_ref,WL.Status,WL.[User]";
            sqlcmd += " from VW_Worklist_WorkflowSearch WL with(nolock) where  1=1 " + Param1;
            sqlcmd += " )WL group by WL.K2ID	,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.Site_ref Order by WL.K2ID DESC ";

            ClassDBConnK2 K2Conn = new ClassDBConnK2();
            return K2Conn.ExecuteReader(sqlcmd);
        }


        //WO End Add 15/02/2017--------------------------------------------------------------------------------
        public DataSet K2MytaskSearch()
        {
            //string sqlcmd = "Select top 200 WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,max(WL.CreateDate)as CreateDate,max(WL.Activity) as Activity,WL.Site_ref,max(WL.Status) as [Status],max(WL.[User]) as [User]";
            //sqlcmd += " from(select  WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.CreateDate,WL.Activity,WL.Site_ref,WL.Status,WL.[User]";
            //sqlcmd += " from VW_Rpt_WorkList WL with(nolock) where  1=1 " + Param1;
            //sqlcmd += " )WL group by WL.K2ID	,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.Site_ref";


            ////ต้องเปลี่ยนการ Query ข้อมูล
            //SqlConnection conn = new SqlConnection(con);

            //conn.Open();
            //SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            //da.Fill(ds);
            //conn.Close();
            ds.Tables.Add(K2MytaskSearchTable());
            return ds;

        }
        public DataTable K2MytaskSearchTable()
        {
            string sqlcmd = "Select WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,max(WL.CreateDate)as CreateDate,max(WL.Activity) as Activity,WL.Site_ref,max(WL.Status) as [Status],max(WL.[User]) as [User]";
            sqlcmd += " from(select  WL.K2ID,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.CreateDate,WL.Activity,WL.Site_ref,WL.Status,WL.[User], WL.ActDate ";
            sqlcmd += " from VW_Worklist_MyTaskV2 WL with(nolock) where  1=1 " + Param1;
            sqlcmd += " )WL group by WL.K2ID	,WL.WFtype,WL.WorkflowType,WL.[Subject],WL.Requester,WL.Site_ref,WL.ActDate Order by WL.ActDate DESC ";

            ClassDBConnK2 K2Conn = new ClassDBConnK2();
            return K2Conn.ExecuteReader(sqlcmd);
        }
        // WO Star edit 17/02/2017 611697 Chang View---------------------------------------------------------------------------------
        //CP Add 21/02/2017---------
        
        //-----------------------------------------------------------------------
        public string K2BrowseItemLasrPurchase(string ItemCode, string Site_ref)  //JT 17/04/2019
        {
            SiteRef = Site_ref;
            string sqlCmd = "SELECT TOP 1 ISNULL([cost],0) as  [cost] FROM [dbo].[matltran_mst] WHERE [item] =  '" + ItemCode + "' And [trans_type] in ('R' , 'M') And [ref_type] = 'P' Order By [trans_num] Desc ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["cost"].ToString();

            }
            else
            {
                rParam1 = "0";

            }
            conn.Close();


            return rParam1;


        }


        //CP Start Add 17/02/2017--------------------------------------------------------------------------------


        public DataSet K2DeleteITResponsLine()
        {

            string sqlCmd = "DELETE [dbo].[TB_HR_Responsibility] WHERE [ID] = " + Param1;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }


        //CP End Add 17/02/2017-----------------------

        //CP Start Add 27/02/2017--------------------------------------------------------------------------------
        public DataSet K2BoundIssueGroup()
        {
            string sqlcmd = "SELECT  IssueGroupID as 'code', IssueGroupName as 'name' FROM     TB_IssueGroup WHERE IssueGroupID like '%" + code + "%' OR IssueGroupName like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BoundIssueDetail()
        {
            string sqlcmd = "SELECT  IssueDetailID as 'code', IssueDetailName as 'name' FROM     TB_IssueDetail WHERE IssueGroupID = '" + Param1 + "' AND (IssueDetailID like '%" + code + "%' OR IssueDetailName like '%" + name + "%')";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        //CP Start Add 01/03/2017--------------------------------------------------------------------------------
        public void K2BrowseCheckSNValue()
        {

            string sqlCmd = "SELECT [ProcInstID] FROM [ServerLog].[Worklist] WHERE [ProcInstID] =   " + Param1 + " AND [Status] = 0 AND [Destination] like '%" + Param2 + "%'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["ProcInstID"].ToString();

            }
            else
            {
                rParam1 = "0";

            }
            conn.Close();

        }

        public DataSet K2BoundProceesInprocessToApprove()
        {
            string sqlcmd = " SELECT [ProcInstID],[SiteRef] FROM [PATKOL_K2APP_DATA].[dbo].[Vw_CheckMIAStatusIncoorect] WHERE [ProcessStatus] = 'Approved' AND [WFStatus] = 'I' ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2UpdateProceesInprocessToApprove()
        {
            string sqlcmd = " UPDATE [dbo].[ppcl_mia_item_mst] SET [WFStatus] = 'A' WHERE [Uf_ProcInstId] = '" + Param1 + "' ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BoundProceesReject()
        {
            string sqlcmd = " SELECT [ProcInstID],[SiteRef] FROM [PATKOL_K2APP_DATA].[dbo].[Vw_CheckMIAStatusIncoorect] WHERE [ProcessStatus] = 'Rejected'  ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2UpdateProceesReject()
        {
            string sqlcmd = " UPDATE [dbo].[ppcl_mia_item_mst] SET [WFStatus] = 'R' WHERE [Uf_ProcInstId] = '" + Param1 + "' ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BoundProceesDeleted()
        {
            string sqlcmd = " SELECT [ProcInstID],[SiteRef] FROM [PATKOL_K2APP_DATA].[dbo].[VW_CheckClearWFMIA]  ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BoundProceesIncorrect()
        {
            string sqlcmd = " SELECT [ProcInstID],[SiteRef] FROM [PATKOL_K2APP_DATA].[dbo].[Vw_CheckMIAStatusIncoorect] WHERE  [WFStatus] <> 'R' ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2BoundProceesIncorrectForReject()
        {
            string sqlcmd = " SELECT [ProcInstID],[SiteRef] FROM [PATKOL_K2APP_DATA].[dbo].[Vw_CheckMIAStatusIncoorect] WHERE  [WFStatus] = 'R' ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2ProceesForDeletedK2()
        {
            string sqlcmd = " UPDATE [Server].[ProcInst] SET Folio = Folio + ' Deleted' WHERE ID =  '" + Param1 + "' ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public DataSet K2ProceesForDeleted()
        {
            string sqlcmd = " DELETE [dbo].[ProcessApproval] WHERE [ProcInstID] =   '" + Param1 + "' ";
            SqlConnection conn = new SqlConnection(conSLPKAPP);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void K2BrowseCheckSNValueForMIA()
        {
            string sqlCmd = "";
            //string sqlCmd = "SELECT [ProcInstID] FROM [ServerLog].[Worklist] WHERE [ProcInstID] =   " + Param1 + " AND [Status] = 0 AND [Destination] like '%" + Param2 + "%'";
            sqlCmd = "SELECT TOP 1 y.* FROM (";
            sqlCmd += "SELECT CONVERT(NVARCHAR(10),[ProcInstID])+'_'+CONVERT(NVARCHAR(10),[ActInstDestID]) as 'SNValue','CHANACHON.PR' as 'UserAction' FROM [ServerLog].[Worklist] WHERE [Status] = 0 AND [Destination] = 'K2:PATKOL\\CHANACHON.PR'  AND [ProcInstID] = " + Param1 + " ";
            sqlCmd += "UNION ALL (";
            sqlCmd += "SELECT TOP 1 CONVERT(NVARCHAR(10),[ProcInstID])+'_'+CONVERT(NVARCHAR(10),[ActInstDestID]) as 'SNValue',SUBSTRING([Destination],11,LEN([Destination])) as 'UserAction' FROM [ServerLog].[Worklist] WHERE [Status] = 0 AND [ProcInstID] = " + Param1 + " ";
            sqlCmd += "))y";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["SNValue"].ToString();
                rParam2 = rs["UserAction"].ToString();


            }
            else
            {
                rParam1 = "0";

            }
            conn.Close();

        }
        //ruj  Start Add 13/03/2017--------------------------------------------------------------------------------

        public void K2BoundITsupportSlaandSTD()
        {
            string sqlCmd = "SELECT distinct [MainGroup],[Group],[SLA Type],[STD Time],[Ref_ID] FROM TB_IT_MainGroupNew where [MainGroup] ='" + Param1 + "' and [Group]='" + Param2 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                //,SUBSTRING(job_title,3,100) As 'Jobtitle'
                rParam1 = rs["SLA Type"].ToString();
                rParam2 = rs["STD Time"].ToString();
                rParam3 = rs["Ref_ID"].ToString();

            }
            conn.Close();
        }


        public DataSet K2BoundDocumentITSupport()
        {
            string sqlcmd = "SELECT Document_ID  as 'code' , Detail  as 'name' FROM [dbo].[TB_IT_DocumentSupportNew] ";
            sqlcmd += " where [Ref_ID] = '" + Param1 + "' and [Dep] = '" + Param2 + "' and [Status] = 1";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public void K2BoundITsupportSlaandSTDIP()
        {
            string sqlCmd = "SELECT distinct [Document_ID],[SLA_Type],[STD_Time],[Ref_ID] FROM TB_IT_DocumentSupportNew where [Document_ID] ='" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                //,SUBSTRING(job_title,3,100) As 'Jobtitle'
                rParam1 = rs["SLA_Type"].ToString();
                rParam2 = rs["STD_Time"].ToString();
                rParam3 = rs["Ref_ID"].ToString();

            }
            conn.Close();
        }
        public DataSet K2BoundSupporttype()
        {


            string sqlcmd = " select Dep as code, Supporttype as name from [TB_IT_ITSupporttype] ";
            sqlcmd += "where Dep like '%" + Param1 + "%' and Supporttype like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;



        }



        public DataSet K2BoundApplicationFormSyteLine()
        {
            string sqlcmd = " select 'SyteLine' as code, [Name] as name from [Vw_IT_IT_ApplicationFormSyteline] ";
            sqlcmd += "where Name like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundApplicationFormWorkFlow()
        {
            string sqlcmd = " select [WorkflowType] as code, [Description] as name from [TB_WorkflowType] ";
            sqlcmd += "where [WorkflowType] like '%" + code + "%' or [Description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundApplicationFormReport()
        {


            string sqlcmd = "select distinct [GroupReport] as code, [ReportDisplay] as name from [TB_ReportDetails]";
            sqlcmd += "where [GroupReport] Like '%" + code + "%' or [ReportDisplay] Like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataTable GetDataManulITSupport()
        {
            DataTable dt = new DataTable();
            //String strConnString = System.Configuration.ConfigurationManager
            //.ConnectionStrings["conString"].ConnectionString;
            SqlConnection conn = new SqlConnection(con);
            SqlDataAdapter sda = new SqlDataAdapter();
            string sqlCmd = "SELECT [DataHeader] as Data,[ContentTypeHeader] as ContentType,[NameHeader] as Name FROM [dbo].[TB_IT_DocumentSupportNew] WHERE [Document_ID] =  '" + Param1 + "' AND  DataHeader IS NOT NULL AND DataHeader <> ''   ";
            SqlCommand cmd = new SqlCommand(sqlCmd);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            try
            {
                conn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
                sda.Dispose();
                conn.Dispose();
            }
        }
        public DataSet K2AttManul_SelectITSupport()
        {

            string sqlCmd = "SELECT [Document_ID],[Detail],[NameHeader] FROM [dbo].[TB_IT_DocumentSupportNew] WHERE  Document_ID LIKE '%" + Param1 + "%' ORDER BY Document_ID ASC";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //SB 17/03/2017
        public DataSet K2BoundMainGroupITSupport()
        {

            string sqlcmd = "SELECT distinct  [Dep] as Code, [MainGroup] as name  FROM TB_IT_MainGroupNew where [Dep] ='" + Param1 + "' and [MainGroup] like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;


        }
        public DataSet K2BoundMainGroupITSupportIP()
        {

            string sqlcmd = "SELECT distinct  [Dep] as Code, [MainGroup] as name  FROM TB_IT_MainGroupNew where [MainModule] like '%" + Param1 + "%' and [Dep] ='" + Param2 + "' and [MainGroup] like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;


        }


        public DataSet K2BoundGroupITSupport()
        {
            string sqlcmd = "SELECT distinct  [MainGroup] as Code ,[Group] as name FROM TB_IT_MainGroupNew where [MainGroup] ='" + Param1 + "' and [Group] like '%" + name + "%' ";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BoundGroupITSupportIP()
        {
            string sqlcmd = "SELECT distinct  [MainGroup] as Code ,[Group] as name FROM TB_IT_MainGroupNew where  [MainModule] like '%" + Param2 + "%' and [MainGroup] ='" + Param1 + "' and [Group] like '%" + name + "%' ";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        //SB 07/04/2017

        public DataSet K2History(string K2ID)//JT 17/04/2019
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(K2HistorySearchTable(K2ID));
            return ds;

        }

  
        public DataTable K2HistorySearchTable(string K2ID)//JT 17/04/2019
        {
            string sqlcmd = "Select HT.[K2ID],HT.[Activity Name],HT.[Destination],HT.[StartDate],HT.[Finish Date],HT.[Status],HT.[FinalAction],HT.[Subject]";
            sqlcmd += "from [VW_Workflow_History] HT with(nolock) where  1=1 and K2ID = '" + K2ID + "'";


            ClassDBConnK2 K2Conn = new ClassDBConnK2();
            return K2Conn.ExecuteReader(sqlcmd);

        }

        public DataSet K2HistorySubject(string K2ID) //JT 17/04/2019
        {
            string sqlCmd = "Select HT.[K2ID],HT.[Activity Name],HT.[Destination],HT.[StartDate],HT.[Finish Date],HT.[Status],HT.[FinalAction],HT.[Subject] from [VW_Workflow_History] HT with(nolock) where  1=1 and HT.[K2ID]='" + K2ID + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();



            if (rs.Read())
            {
                //,SUBSTRING(job_title,3,100) As 'Jobtitle'
                rParam1 = rs["Subject"].ToString();
                rParam2 = rs["Destination"].ToString();

            }

            DataSet ds = new DataSet();
            DataTable dt = new DataTable("MyTable");
            dt.Columns.Add(new DataColumn("Subject", typeof(string)));
            dt.Columns.Add(new DataColumn("Destination", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["Subject"] = rParam1;
            dr["Destination"] = rParam2;
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            conn.Close();
            return ds;
        }

        public DataSet K2BoundCountry()
        {
            string sqlcmd = "SELECT  iso_country_code as 'code', country as 'name' FROM     [dbo].[VW_country_mst] WHERE iso_country_code like '%" + code + "%' OR country like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        // WJ Create
        public DataSet K2BrowseJob()
        {
            string sqlcmd = "SELECT  [JobNo] as 'Code',[CustNameRefer] as 'name' FROM [dbo].[TB_Rpt_JobCostSummary] WHERE [JobNo] like '%" + code + "%' OR [CustNameRefer] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        //public void K2GetPaymentTerm()
        //{
        //    string sqlCmd = "SELECT Terms_Code FROM [dbo].[VW_Vendors] WHERE vend_num = '" + Param1 + "'";


        //    SqlConnection conn = new SqlConnection(con);
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {

        //        rParam1 = rs["Terms_Code"].ToString();

        //    }
        //    else
        //    {
        //        rParam1 = "";

        //    }
        //    conn.Close();
        //}
        //public void K2GetPaymentTerm()
        //{
        //    string sqlCmd = "SELECT Terms_Code,[Add1],[Add2] ,[Add3],[Add4],[City] FROM [dbo].[VW_Vendors] WHERE vend_num = '" + Param1 + "'";
               

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {

        //        rParam1 = rs["Terms_Code"].ToString();
        //        rParam2 = rs["Add1"].ToString() + "  " + rs["Add2"].ToString() + "  " + rs["Add3"].ToString() + "  " + rs["Add4"].ToString() + "  " + rs["City"].ToString();

        //    }
        //    else
        //    {
        //        rParam1 = "";
        //        rParam2 = "";

        //    }
        //    conn.Close();
        //}

        //26/04/2017 SB

        public DataSet K2BoundK2CancelandChangeTravelRequest()
        {
            string sqlcmd = "SELECT  [ProcessInstanceID] as 'code', [Subject] as 'name' FROM  [dbo].[VW_HR_TravelingRequest] WHERE [ProcessInstanceID]  like '%" + code + "%' OR [Subject] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }



        public void K2BoundReferk2()
        {
            string sqlCmd = "SELECT [ID],[FightDetail],[TypeTraveling],[ChargeType],[Project],[Country] FROM [dbo].[TB_HR_TravelingRequest] WHERE [ProcessInstanceID] = '" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["FightDetail"].ToString();
                rParam2 = rs["TypeTraveling"].ToString();
                rParam3 = rs["ChargeType"].ToString();
                rParam4 = rs["Project"].ToString();
                rParam5 = rs["ID"].ToString();
                rParam6 = rs["Country"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }
        public DataSet K2BoundEmnameHR13()
        {
            string sqlcmd = "SELECT [Emp_ID] as code,[EmpName] as name FROM [dbo].[TB_HR_TravelingRequest_Line] WHERE [Ref_ID] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //------------- Wisa.je ----------------------
        //public void K2GetPaymentTermDis()
        //{
        //    string sqlCmd = "SELECT Terms_Description FROM [dbo].[VW_Vendors] WHERE vend_num = '" + Param2 + "'";


        //    SqlConnection conn = new SqlConnection(con);
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {

        //        rParam2 = rs["Terms_Description"].ToString();

        //    }
        //    else
        //    {
        //        rParam2 = "";

        //    }
        //    conn.Close();
        //}
        public void K2GetPaymentTermDis()
        {
            string sqlCmd = "SELECT Terms_Description FROM [dbo].[VW_Vendors] WHERE vend_num = '" + Param2 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam2 = rs["Terms_Description"].ToString();

            }
            else
            {
                rParam2 = "";

            }
            conn.Close();
        }

        public DataSet K2BoundPONum()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT [po_num] as 'code' , [vend_num] as 'name' FROM [dbo].[VW_WF_PO] WHERE [po_num] like '%" + code + "%' OR [vend_num] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //public void K2GetSupplierNamePO()
        //{
        //    string sqlCmd = "SELECT Name FROM [dbo].[VW_Vendors] WHERE vend_num = '" + Param3 + "'";


        //    SqlConnection conn = new SqlConnection(con);
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {

        //        rParam3 = rs["Name"].ToString();

        //    }
        //    else
        //    {
        //        rParam3 = "";

        //    }
        //    conn.Close();
        //}
        public void K2GetSupplierNamePO()
        {
            string sqlCmd = "SELECT Name FROM [dbo].[VW_Vendors] WHERE vend_num = '" + Param3 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam3 = rs["Name"].ToString();

            }
            else
            {
                rParam3 = "";

            }
            conn.Close();
        }
        public void K2GetPOByGRN()
        {
            string sqlCmd = "SELECT po_num FROM [dbo].[grn_line_mst] WHERE grn_num = '" + Param4 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam4 = rs["po_num"].ToString();

            }
            else
            {
                rParam4 = "";

            }
            conn.Close();
        }
        public DataSet K2BoundPONumByGRN()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT DISTINCT [po_num] as 'code' , [vend_num] as 'name' FROM [dbo].[grn_line_mst] WHERE ([po_num] like '%" + code + "%' OR [vend_num] like '%" + name + "%') AND grn_num = '" + Param4 + "' ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundGRNDate()
        {
            string sqlcmd = "SELECT [grn_num] as 'code' , convert(nvarchar(20),[grn_hdr_date],103)  as 'name' FROM [dbo].[grn_hdr_mst] WHERE [grn_num] like '%" + code + "%' OR [grn_hdr_date] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public void K2BrowseItembywh()
        {

            string sqlCmd = "select item,whse,unit_cost  FROM itemwhse_mst Where item='" + Param1 + "' and whse='" + Param2 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["unit_cost"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();

        }
        //SB------------------------------------------
        public void K2BoundReferLineHR13()
        {
            string sqlCmd = "SELECT [CostCenter],[DateDeparture],[DateArrival] FROM [dbo].[TB_HR_TravelingRequest_Line] WHERE [Ref_ID] = '" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["DateDeparture"].ToString();
                rParam2 = rs["DateArrival"].ToString();
                rParam3 = rs["CostCenter"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }
        ////------------ Wisa.je 04/05/2017 ---------------------
        //public void K2GetProjName()
        //{
        //    string sqlCmd = "SELECT proj_desc FROM [dbo].[proj_mst] WHERE proj_num = '" + Param5 + "'";


        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {

        //        rParam5 = rs["proj_desc"].ToString();

        //    }
        //    else
        //    {
        //        rParam5 = "";

        //    }
        //    conn.Close();
        //}
        //------------ SB Revise 12/03/2019 ---------------------
        public void K2GetProjName()
        {
            string sqlCmd = "SELECT proj_desc,cust_num FROM [dbo].[proj_mst] WHERE proj_num = '" + Param5 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam5 = rs["proj_desc"].ToString();
                rParam1 = rs["cust_num"].ToString();

            }
            else
            {
                rParam5 = "";
                rParam1 = "";

            }
            conn.Close();
        }
        //public void K2GetCustName()
        //{
        //    string sqlCmd = "SELECT Distinct [site_ref],[ProjectNo],[CustomerName] FROM [dbo].[VW_TB_Rpt_ProjectCostDetail]  WHERE ProjectNo = '" + Param6 + "'";

        //    SqlConnection conn = new SqlConnection(con);
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {

        //        rParam6 = rs["CustomerName"].ToString();

        //    }
        //    else
        //    {
        //        rParam6 = "";

        //    }
        //    conn.Close();
        //}

        public void K2GetCustName()
        {
            string sqlCmd = "SELECT Distinct [site_ref],[ProjectNo],[CustomerName] FROM [dbo].[VW_TB_Rpt_ProjectCostDetail]  WHERE ProjectNo = '" + Param6 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam6 = rs["CustomerName"].ToString();

            }
            else
            {
                rParam6 = "";

            }
            conn.Close();
        }
        public DataSet K2BoundWHforItem()
        {
            string sqlcmd = "SELECT [whse] as 'code', '' as 'name' FROM [dbo].[Itemwhse_mst] WHERE ([whse] like '%" + code + "%' OR [whse] like '%" + name + "%') AND item = '" + Param2 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BoundMainModule()
        {

            string sqlcmd = "SELECT distinct  [MainModule] as Code, '' as name  FROM TB_IT_MainGroupNew Where [MainModule] is not null ";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;


        }
        //26/05/2017 By SB
        public void K2BoundDocIP()
        {
            string sqlCmd = "SELECT Document_ID  FROM [dbo].[TB_IT_DocumentSupportNew] where [Ref_ID] = '" + Param1 + "'";



            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam6 = rs["Document_ID"].ToString();

            }
            else
            {
                rParam6 = "";

            }
            conn.Close();
        }
        //12/06/2017 By SB
        //public DataSet K2BoundProjectOversea()
        //{
        //    string sqlcmd = "SELECT [Project] as 'code' , [ProjectDes] as 'name' FROM [dbo].[VW_ProjectOpenOversea] WHERE [Project] like '%" + code + "%' OR [ProjectDes] like '%" + name + "%'";
        //    SqlConnection conn = new SqlConnection(con);
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        //12/06/2017 By SB (WS Revise 2018-07-23)
        public DataSet K2BoundProjectOversea()
        {
            string sqlcmd = "SELECT [Project] as 'code' , [ProjectDes] as 'name' FROM [dbo].[VW_ProjectOpenOversea] WHERE ([Project] like '%" + code + "%' OR [ProjectDes] like '%" + name + "%') AND [Site_Ref] like '%" + Param1 + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
       
        public DataSet BoundCostCenterOversea()
        {


            string sqlcmd = "SELECT [dept] as 'code' , [description] as 'name' FROM [dbo].[dept_Overseas] WHERE [dept] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void K2UpdateItemCodeFinal()
        {
            string sqlCmd = "EXEC SP_IC_UpdateItemFinal '" + Param1 + "'";



            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["ItemCodeFinal"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }
        public void LoadItemOversea()
        {
            string sqlCmd = "Select [UnitCost],[UOM] From [dbo].[VW_ItemSearch] where [item]='" + Param1 + "' and [site_ref]='" + Param2 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["UnitCost"].ToString();
                rParam2 = rs["UOM"].ToString();

            }
            conn.Close();
        }
      

        // SB PL06 26/06/2017 (WS Revise 2018-07-04)
        public DataSet K2BoundPROversa()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT [PRnumber] as 'code' , [Subject] as 'name' FROM [dbo].[TB_PL_PurchaseRequest] WHERE ([Status] <> 'Draft' and [Status] <> 'Deleted') and ([Site_Ref] like '%" + Param1 + "%') and([PRnumber] like '%" + code + "%' OR [Subject] like '%" + name + "%')";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundPRLineOversa()
        {
            //CheckConSiteRef();
            string sqlcmd = "SELECT [PR_LineNum] as 'code' , '' as 'name' FROM [dbo].[TB_PL_PurchaseRequest_Line] WHERE [Ref_ID] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public void LoadRefIDOversea()
        {
            string sqlCmd = "Select [ID] From [dbo].[TB_PL_PurchaseRequest] where [PRnumber]='" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["ID"].ToString();

            }
            conn.Close();
        }
        //public void LoadPRLineOversea()
        //{
        //    string sqlCmd = "select [location],[Jobno],[Item],[Qty],[TotalAmount] from [TB_PL_PurchaseRequest_Line] where [Ref_ID] = '" + Param1 + "' and [PR_LineNum] = '" + Param2 + "'";

        //    SqlConnection conn = new SqlConnection(con);
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand(sqlCmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();

        //    if (rs.Read())
        //    {

        //        rParam1 = rs["location"].ToString();
        //        rParam2 = rs["Jobno"].ToString();
        //        rParam3 = rs["Item"].ToString();
        //        rParam4 = rs["TotalAmount"].ToString();
        //        rParam5 = rs["Qty"].ToString();
        //    }
        //    conn.Close();
        //}
        public void LoadPRLineOversea()
        {
            string sqlCmd = "select [location],[Jobno],[Item],[Qty],[TotalAmount],[ItemDes] from [TB_PL_PurchaseRequest_Line] where [Ref_ID] = '" + Param1 + "' and [PR_LineNum] = '" + Param2 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["location"].ToString();
                rParam2 = rs["Jobno"].ToString();
                rParam3 = rs["Item"].ToString();
                rParam4 = rs["TotalAmount"].ToString();
                rParam5 = rs["Qty"].ToString();
                rParam6 = rs["ItemDes"].ToString();
            }
            conn.Close();
        }
        public void K2GetProjectPremis()
        {
            string sqlCmd = "SELECT  distinct [RufNum]  FROM VW_Ctr_Permission Where";
            sqlCmd += "([RufNum] = '" + Param1 + "')";
            sqlCmd += "and Username ='" + Param2 + "' ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["RufNum"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }
        // WS 14/07/2017
        public DataSet K2BoundCustomerOversea()
        {
            string sqlcmd = "SELECT [cust_num] as 'code' , [name] as 'name' FROM [dbo].[VW_WF_Customer] WHERE [cust_num] like '%" + code + "%' OR [name] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BoundIncoterm()
        {
            string sqlcmd = "SELECT [inco_delterm] as 'code' , [description] as 'name' FROM [dbo].[VW_WF_Incoterm] WHERE [inco_delterm] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //SB 02/07/2017
        public DataSet BoundJob()
        {
            string sqlcmd = "SELECT [job] as 'code' , [description] as 'name' FROM [dbo].[job_mst] WHERE [job] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet BoundJobTgwithsuffix()
        {
            string sqlcmd = "SELECT [job] as 'code' ,CONVERT(varchar, suffix) +'-'+ [description] as 'name',suffix FROM [dbo].[job_mst] WHERE [job] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet BoundJobSuffix()
        {

            string sqlcmd = "SELECT [suffix] as 'code','' as 'name' FROM [dbo].[job_mst] WHERE [job] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public void BoundJobSuffixADtg()
        {
            string sqlCmd = "SELECT  suffix as 'code',CONVERT(varchar, suffix) +'-'+ [description] as 'name' FROM [dbo].[job_mst] WHERE [job] = '" + Param1 + "' and (CONVERT(varchar, suffix) +'-'+ [description]) = '" + Param2 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["code"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }

        public DataSet BoundJobOperation()
        {
            string sqlcmd = "select [oper_num] as 'code' ,  wc as 'name' from [dbo].[VW_Operation] where job ='" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet BoundJobOperationTG()
        {
            string sqlcmd = "select [oper_num] as 'code' ,  wc as 'name' from [dbo].[VW_Operation] where job ='" + Param1 + "' and suffix ='" + Param2 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet BoundMaterial()
        {
            string sqlcmd = " select item as 'code',ProductDescription as 'name' from [dbo].[VW_Item] where item  like '%" + code + "%' OR [ProductDescription] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet BoundSerailNum()
        {
            string sqlcmd = "select [ser_num] as 'code' , '' as 'name' from [dbo].[serial_mst] Where item ='" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public void GetUOMItem()
        {
            string sqlCmd = "select UOM from [dbo].[VW_Item] where item = '" + Param1 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["UOM"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }
        public DataSet BoundWHLocation()
        {
            string sqlcmd = "select whse as 'code' ,[loc] as 'name'  from [dbo].[VW_LocatioWH] Where item ='" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BoundReques()
        {
            string sqlcmd = " select Ltrim(emp_num) as 'code' ,name as name,dept,site_ref from [dbo].[VW_employee_mst] ";
            sqlcmd += " where name is not null  and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public void GetItemInfor()
        {
            string sqlCmd = "select loc,cost,qty_on_hand,whse  from [dbo].[VW_LocatioWH] Where item ='" + Param1 + "' and whse ='" + Param2 + "'and loc ='" + Param3 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["loc"].ToString();
                rParam2 = rs["cost"].ToString();
                rParam3 = rs["qty_on_hand"].ToString();
                rParam4 = rs["whse"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }


        //public DataSet CtrAuthorizeSelect()
        //{
        //    //CheckConSiteRef();
        //    string sqlcmd = "select [User],[K2ID],[Empname],[ID] From VW_Worklist_Remark Where K2ID='" + Param1 + "'";
        //    SqlConnection conn = new SqlConnection(con);
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        public DataSet K2BoundUser()
        {

            string sqlcmd = " select distinct [username] as code,name,dept from [dbo].[VW_Employee_All] ";
            sqlcmd += " where name is not null  and ([username] Like '%" + code + "%' or name Like '%" + name + "%')  ";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
            //SqlConnection conn = new SqlConnection(CheckConSiteRef());
            //conn.Open();
            //SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //conn.Close();
            //return ds;

        }

        //public DataSet CtrAuthorizeSelectDelete()
        //{
        //    //CheckConSiteRef();
        //    string sqlcmd = "DELETE [dbo].[ProcessRemarkRequest] WHERE ID = " + Param1;
        //    SqlConnection conn = new SqlConnection(conSLPKAPP);
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}

        //**********Ws 06/10/2017*************
        //public DataSet K2BoundLocationOversea()
        //{
        //    //string sqlcmd = "SELECT Site_Ref as code, Location as name FROM dbo.TB_WarehouseLocation WHERE [Site_Ref] like '%" + code + "%' and [Location] like '%" + name + "%' ";
        //    string sqlcmd = "SELECT Site_Ref as code, Location as name FROM dbo.TB_WarehouseLocation WHERE [Site_Ref] like '%" + Param1 + "%'";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;

        //}
        public DataSet K2BoundLocationOversea()
        {
            string sqlcmd = "SELECT Site_Ref as code, dept as name FROM dbo.dept_Overseas WHERE [Site_Ref] like '%" + Param1 + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        //-----WO Add06/09/2017---------------


        public DataSet K2BoundEnquiry()
        {
            string sqlcmd = "SELECT [EnquiryNo] as 'code' , [Subject] as 'name' FROM TB_Enquiry03 WHERE [EnquiryNo] like '%" + code + "%' OR [Subject] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public void LoadDetailEnquiry()
        {
            string sqlCmd = "SELECT [FONum],[ToSite],[ProjNum],[CustomerNo],[Requestor],[EstNum],[PONum],[CONum] FROM [VW_Enquiry_Export] where [EnquiryNo] = '" + Param1 + "' and [Factory] = '" + Param2 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["FONum"].ToString();
                rParam2 = rs["ToSite"].ToString();
                rParam3 = rs["ProjNum"].ToString();
                rParam4 = rs["CustomerNo"].ToString();
                rParam5 = rs["Requestor"].ToString();
                rParam6 = rs["EstNum"].ToString();
                rParam7 = rs["PONum"].ToString();
                rParam8 = rs["CONum"].ToString();
            }
            conn.Close();
        }

        public DataTable DTFactoryOfEnquiry()
        {
            string sqlCmd = "SELECT Distinct [Factory] as code,[Factory] as name FROM [VW_Enquiry_Export] where [EnquiryNo] = '" + Param1 + "'";
            ClassDBConnK2 K2Conn = new ClassDBConnK2();
            return K2Conn.ExecuteReader(sqlCmd);
        }

        public void LoadDetailJob()
        {
            string sqlCmd = "select j.job,j.item,j.qty_released,l.lot from job_mst j ";
            sqlCmd += "left join [dbo].[preassigned_lot_mst] l on j.job = l.ref_num ";
            sqlCmd += "where j.ord_num = '" + Param1 + "' and j.ord_line = '" + Param2 + "'";
            SiteRef = "ERP_PKM";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["job"].ToString();
                rParam2 = rs["item"].ToString();
                rParam3 = rs["qty_released"].ToString();
                rParam4 = rs["lot"].ToString();
            }
            conn.Close();
        }

        public DataSet K2BrowseEstLine()
        {

            string sqlCmd = "SELECT [co_line] as 'Code', [item] as 'Name' FROM [dbo].[coitem_mst] WHERE co_num like '%" + code + "%'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public void K2PototalCost()
        {

            string sqlCmd = "SELECT [po_num],[TotalAmount] FROM [VW_POLineAmount] where [po_num] = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["TotalAmount"].ToString();

            }
            conn.Close();

        }


        //-----WO End06/09/2017---------------


        public DataSet K2BoundCurrency2()
        {
            string sqlcmd = "SELECT  distinct[from_curr_code] as code, [description] as name  FROM [dbo].[VW_CurrentRate] WHERE [from_curr_code] like '%" + code + "%' OR '' like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        //public void K2BrowseProjectnvoice()
        //{
        //    string sqlcmd = "";
        //    sqlcmd += "Select [proj_num],[cust_num] from [dbo].[proj_mst] where [proj_num] = '" + Param1 + "'";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();
        //    if (rs.Read())
        //    {
        //        rParam1 = rs["cust_num"].ToString();
        //    }
        //    else
        //    {
        //        rParam1 = "";
        //    }

        //    conn.Close();


        //}
        //ws 02/09/2018
        public void K2BrowseProjectnvoice()
        {
            string sqlcmd = "";
            sqlcmd += "select x.[proj_num],x.[cust_num] from (Select [proj_num],[cust_num] from [dbo].[proj_mst]";
            sqlcmd += "union all ";
            sqlcmd += "Select [co_num] as 'proj_num',[cust_num] from [dbo].[co_mst]) x where x.proj_num = '" + Param1 + "'";
            //sqlcmd += "Select [proj_num],[cust_num] from [dbo].[proj_mst] where [proj_num] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["cust_num"].ToString();
            }
            else
            {
                rParam1 = "";
            }

            conn.Close();


        }

        public void K2BrowseCOvoice()
        {
            string sqlcmd = "";
            sqlcmd += "select [name],[city],[addr##1],[addr##2],[addr##3],[addr##4] from [dbo].[custaddr_mst] where [cust_num] = '" + Param1 + "' AND [cust_seq] = 0";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {

                rParam1 = rs["name"].ToString();
                rParam2 = rs["city"].ToString();
                rParam3 = rs["addr##1"].ToString();
                rParam4 = rs["addr##2"].ToString();
                rParam5 = rs["addr##3"].ToString();
                rParam6 = rs["addr##4"].ToString();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
                rParam6 = "";
            }

            conn.Close();


        }

        internal void ExchangeRate()
        {
            string sqlCmd = "SELECT [buy_rate],eff_date,[from_curr_code] from [dbo].[VW_CurrentRate] where [from_curr_code] ='" + Param1 + "'";
            sqlCmd += " and eff_date = (SELECT MAX(eff_date) from [dbo].[VW_CurrentRate] where [from_curr_code] ='" + Param1 + "') ";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["buy_rate"].ToString();
            }
            else
            {
                rParam1 = "";
            }
            conn.Close();

        }

        public DataSet K2BoundProductCodeOversea()
        {

            string sqlcmd = "SELECT [product_code] as 'code' , [description] as 'name' FROM [dbo].[VW_WF_ProductCode] WHERE [product_code] like '%" + code + "%' OR [description] like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }


        public void K2seq2()
        {

            string sqlCmd = "SELECT MemoBudget  from TB_Project_Location where  [ProjNum] = '" + Param1 + "' and [ShipTo] = '" + Param2 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["MemoBudget"].ToString();


            }
            conn.Close();

        }
        public DataSet K2seq()
        {

            //string sqlcmd = "SELECT DISTINCT [uf_mia] as code,'' as name FROM Vw_MiaAllForJob WHERE JobNum = '" + Param1 + "' AND task_num = '" + Param2 + "'";
            string sqlcmd = "SELECT [ShipTo] as 'code',[addr1]+'   '+[addr2]+'   '+[addr3]+'   '+[addr4] as 'name' FROM [TB_Project_Location] where [ProjNum] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //================================ Wisa.je 07/12/17 =======================================

        public void PKDV_Sale_Group()
        {
            string sqlCmd = "SELECT  [GroupId]  FROM VW_Sale_Group Where";

            sqlCmd += "[Username] ='" + Param2 + "' ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["GroupId"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }
       
        //================= Wisa.je 19/01/2018 =================================

        public DataSet InvoiceNOByShipment()
        {
            string sqlcmd = "SELECT [ms_num] as 'code' , [EstShipDate] as 'name' FROM [dbo].[ppcc_inv_ms]";
            sqlcmd += " where EstShipDate is not null and ([inv_num] like '%" + code + "%' OR [EstShipDate] like '%" + name + "%')";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

      //=====================WIsa.je 31/01/2018 =========================================

    
        internal void ProjectInfor()
        {
            string sqlCmd = "SELECT distinct [ref_num],[ProjectDesc],[Customer],[CustomerName],[Product],[ProductName],[CommittedPR],[CommittedPO],[CommittedMIA],[Acc. Committed Cost],[Estimate Cost] from [dbo].[VW_IC_MaterialIssurRetun_V2] where [ref_num] ='" + Param1 + "'";
            

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["ref_num"].ToString();
                rParam2 = rs["ProjectDesc"].ToString();
                rParam3 = rs["Customer"].ToString();
                rParam4 = rs["CustomerName"].ToString();
                rParam5 = rs["Product"].ToString();
                rParam6 = rs["ProductName"].ToString();
                rParam7 = rs["CommittedPR"].ToString();
                rParam8 = rs["CommittedPO"].ToString();
                rParam9 = rs["CommittedMIA"].ToString();
                rParam10 = rs["Acc. Committed Cost"].ToString();
                rParam11 = rs["Estimate Cost"].ToString();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
                rParam6 = "";
                rParam7 = "";
                rParam8 = "";
                rParam9 = "";
                rParam10 = "";
                rParam11 = "";
            }
            conn.Close();

        
    }

        internal void ProjectInforv2()
        {
            string sqlCmd = "SELECT top 1[ProjectNo],projc.[ProjectDesc],projc.[Customer] as 'ProjectCustomer' ,projc.[CustomerName],projc.[Product],projc.[ProductName]";
      sqlCmd += ",(isnull([CommittedPR],0)) as 'CommittedPR'";
      sqlCmd += ",(isnull([CommittedPO],0)) as 'CommittedPO'";
      sqlCmd += ",(isnull(projc.[CommittedMIABQ],0) + isnull(projc.[CommittedMIADI],0)) as 'CommittedMIA' ";
      sqlCmd += " ,(isnull([CommittedPR],0)+isnull([CommittedPO],0)+isnull(projc.[CommittedMIABQ],0) + isnull(projc.[CommittedMIADI],0)+isnull(projc.[CommittedAdV],0))  as 'Acc. Committed Cost'";
      sqlCmd += " ,(projc.[Plan_CostTotal]) as 'Estimate Cost',projc.[end_user_type] from [dbo].[TB_Rpt_ProjectCostDetail] projc with(nolock) where [ProjectNo] ='" + Param1 + "'";


      SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["ProjectNo"].ToString();
                rParam2 = rs["ProjectDesc"].ToString();
                rParam3 = rs["ProjectCustomer"].ToString();
                rParam4 = rs["CustomerName"].ToString();
                rParam5 = rs["Product"].ToString();
                rParam6 = rs["ProductName"].ToString();
                rParam7 = rs["CommittedPR"].ToString();
                rParam8 = rs["CommittedPO"].ToString();
                rParam9 = rs["CommittedMIA"].ToString();
                rParam10 = rs["Acc. Committed Cost"].ToString();
                rParam11 = rs["Estimate Cost"].ToString();
                rParam12 = rs["end_user_type"].ToString();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
                rParam6 = "";
                rParam7 = "";
                rParam8 = "";
                rParam9 = "";
                rParam10 = "";
                rParam11 = "";
                rParam12 = "";

            }
            conn.Close();


        }
        //==================== Wisa.je 01/02/2018 ==============================

        internal void IndustryInfor()
        {
            string sqlCmd = "SELECT Uf_IndustryFactor,Uf_IndustryGroup from [dbo].[VW_PJ_EstimateProject_V2]  where [QuotationNo] ='" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["Uf_IndustryFactor"].ToString();
                rParam2 = rs["Uf_IndustryGroup"].ToString();

            }
            else
            {
                rParam1 = "";
                rParam2 = "";

            }
            conn.Close();

        }

        internal void IndustryInforPJ02()
        {
            string sqlCmd = "SELECT Uf_IndustryFactor,Uf_IndustryGroup from [dbo].[VW_PJ_IndustProject]  where [ProjectNo] ='" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["Uf_IndustryFactor"].ToString();
                rParam2 = rs["Uf_IndustryGroup"].ToString();

            }
            else
            {
                rParam1 = "";
                rParam2 = "";

            }
            conn.Close();

        }

        // WS 2018-02-27 LG06//
        public DataSet K2BoundInvoice()
        {
            string sqlcmd = "SELECT  [inv_num] as code, '' as name FROM [dbo].[VW_Invoice] WHERE (tax_code1 = 'VAT0' or tax_code1 = 'NON') and [inv_num] like 'AEIN%' and ([inv_num] like '%" + code + "%' OR '' like '%" + name + "%')";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        //WS 2018-02-26//
        public void K2BrowseUnitCostbyItem()
        {

            string sqlCmd = "select item,unit_cost  FROM item_mst Where item='" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["unit_cost"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();

        }
        //PL 2018-02-26//
        //public DataSet LoadProjExportShip()
        //{

        //    string sqlcmd = " select al.proj_num as code,'Inv. No. : ' +  isnull(al.inv_num,'-') +  al.inv_num + ' Estimate Ship Date :' +  CONVERT(NVARCHAR, al.EstShipDate,103) as name from(select proj_num,inv_num,[EstShipDate]";
        //    sqlcmd += " from [ppcc_inv_ms] Where tax_code='VAT0' Union all select co_num as proj_num,'' as inv_num, NULL as [EstShipDate] from co_mst)al Where (al.proj_num like '%" + code + "%' OR al.[inv_num] like '%" + name + "%')";

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        //public DataSet LoadProjExportShip()
        //{

        //    string sqlcmd = " select al.proj_num as code,'Inv. No. : ' +  isnull(al.inv_num,'-') + ', Estimate Ship Date :' +  CONVERT(NVARCHAR, al.EstShipDate,103) as name from(select proj_num,inv_num,[EstShipDate]";
        //    sqlcmd += " from [ppcc_inv_ms] Where tax_code='VAT0' Union all select co_num as proj_num,'' as inv_num, NULL as [EstShipDate] from co_mst)al Where (al.proj_num like '%" + code + "%' OR al.[inv_num] like '%" + name + "%')";

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        public DataSet LoadProjExportShip()
        {

            string sqlcmd = " select al.proj_num as code,'Inv. No. : ' +  isnull(al.inv_num,'-') + ', Estimate Ship Date :' +  CONVERT(NVARCHAR, al.EstShipDate,103) as name from(select proj_num,inv_num,[EstShipDate]";
            sqlcmd += " from [ppcc_inv_ms] Where tax_code='VAT0' Union all select co_num as proj_num,'' as inv_num, NULL as [EstShipDate] from co_mst Union all select sro_num as proj_num,'' as inv_num, NULL as [EstShipDate] from fs_sro_mst)al Where (al.proj_num like '%" + code + "%' OR al.[inv_num] like '%" + name + "%')";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public DataSet K2BrowseDARPermissionGroup()
        {

            string sqlCmd = "SELECT [FullNameGroup] as code,[DisplyGroup] as name FROM [dbo].[TB_SH_DAT_PermissionGroup] WHERE  FullNameGroup like '%" + code + "%' OR DisplyGroup like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        //public DataSet K2BrowseProjSroEstProject()
        //{

        //    //string sqlCmd = "SELECT distinct [req_num] as 'Code',description as 'Name' FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE (req_num like '%" + code + "%' OR  description = '%" + name + "%') and Type='"  + Param1 +"'";
        //    string sqlCmd = "SELECT distinct [req_num] as 'Code',description as 'Name' FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE (req_num like '%" + code + "%' OR  description = '%" + name + "%')";

        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;

        //}
//Edit By NS 11/07/2018
  public DataSet K2BrowseProjSroEstProject()
        {

            //string sqlCmd = "SELECT distinct [req_num] as 'Code',description as 'Name' FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE (req_num like '%" + code + "%' OR  description = '%" + name + "%') and Type='"  + Param1 +"'";
            string sqlCmd = "SELECT distinct TOP 20 [req_num] as 'Code',description as 'Name' FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE (req_num like '%" + code + "%' OR  description = '%" + name + "%')";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public void K2BrowseProjSroEstProjectCust()
        {
            //Param1

            string sqlCmd = "SELECT distinct [req_num] as 'Code',description as 'Name',cust_num,name FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE req_num like '%" + Param1 + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam2 = rs["cust_num"].ToString();
                rParam3 = rs["name"].ToString();

            }
            else
            {

                rParam2 = "";
                rParam3 = "";

            }
            conn.Close();

        }
        public DataSet K2BrowseJobOrder()
        {

            string sqlCmd = "SELECT distinct [job] as 'Code',job as 'Name' FROM [dbo].[job_mst] WHERE type='J' AND stat='R' AND [job]='" + Param1 + "'AND job like '%" + code + "%' OR  job = '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet K2BrowseEstJobOrder()
        {

            string sqlCmd = "SELECT distinct [job] as 'Code',job as 'Name' FROM [dbo].[job_mst] WHERE type='E' AND job like '%" + code + "%' OR  job = '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        //public DataSet K2BrowseTark()
        //{

        //    string sqlcmd = "SELECT code,name,Protark FROM [dbo].[VW_Tark_Projec_Job_Co] WHERE Protark = '" + Param1 + "'";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    conn.Close();
        //    return ds;
        //}
        public DataSet K2BrowseTarkTG()
        {

            string sqlcmd = "SELECT distinct task_num as code,task_desc as name ,req_num FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE req_num = '" + Param1 + "' order by task_num ";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BrowseSeqTG()
        {

            string sqlcmd = "SELECT seq as code,task_num as name ,req_num FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE req_num = '" + Param1 + "' and  task_num = '" + Param2 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BrowseSeqTGService()
        {

            string sqlcmd = "SELECT seq as code,task_num as name ,req_num FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE req_num = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet K2BrowseServiceLine()
        {

            string sqlcmd = "SELECT distinct sro_line as code,sro_line as name ,req_num FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE req_num = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public void K2GetFONo()
        {
            string sqlCmd = "EXEC [SP_PD_CalFONum] '" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["PrefixEnq"].ToString();

            }
            else
            {
                rParam1 = "";

            }
            conn.Close();
        }

        public void K2LoadJobOrder()
        {
            string sqlCmd = "select [job] from [dbo].[job_mst] where stat= 'R'and [est_job] = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["job"].ToString();
                rParam2 = rs["job"].ToString();



            }
            else
            {
                rParam1 = "";


            }
            conn.Close();
        }

        public void K2LoadEstimateProject()
        {
            string sqlCmd = "select count([proj_num]) as 'CountProj' from [dbo].[proj_mst] where [proj_num] = '" + Param1 + "' and type='P'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["CountProj"].ToString();



            }
            else
            {
                rParam1 = "";


            }
            conn.Close();
        }


        public void K2LoadProjectTG()
        {
            string sqlCmd = "select TOP 1 [proj_num] from [dbo].[proj_mst] where [est_num] = '" + Param1 + "' and type='P'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["proj_num"].ToString();



            }
            else
            {
                rParam1 = "";


            }
            conn.Close();
        }

        public void LoadLotItem()
        {
            string sqlcmd = "SELECT [lot] ";
            sqlcmd += "from [dbo].[preassigned_lot_mst] where [item] ='" + Param1 + "' and ref_num ='" + Param2 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {

                rParam1 = rs["lot"].ToString();


            }
            else
            {
                rParam1 = "";

            }

            conn.Close();


        }

        public void K2BrowseProjSroDescTG()
        {
            string sqlCmd = "SELECT y.* FROM ( ";
            sqlCmd += "SELECT [sro_num] as 'Code',Description,[cust_num],[total_price] as Rev FROM [dbo].[fs_sro_mst] ";
            sqlCmd += "UNION ALL ( SELECT [proj_num] as 'Code',[proj_desc] as 'Description',[cust_num],[proj_rev] as Rev FROM [dbo].[proj_mst] ) ";
            sqlCmd += ")y WHERE y.Code = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Description"].ToString();
                rParam2 = rs["cust_num"].ToString();
                rParam3 = rs["Rev"].ToString();

            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
            }
            conn.Close();
        }
        public DataSet LoadLotItemTG()
        {
            
            //CheckConSiteRef();
            string sqlcmd = "select lot as code,lot as name from [dbo].[preassigned_lot_mst]";
            sqlcmd += "where [item] ='" + Param1 + "' and ref_num ='" + Param2 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        
        public void K2BrowseProjType()
        {
            string sqlCmd = "SELECT distinct [req_num],[Type] FROM [dbo].[VW_WF_ProjectEstProjectService] WHERE req_num='" + Param1 + "'";
          

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["req_num"].ToString();
                rParam2 = rs["Type"].ToString();
               

            }
            else
            {
                rParam1 = "";
                rParam2 = "";
               
            }
            conn.Close();
        }

        public DataSet K2BoundFONumber()
        {
            string sqlcmd = "Select distinct [FONum] as code, '' as name from [dbo].[VW_TB_PD_ProductionOrder_TG] where [FONum] like '%" + code + "%' OR [FONum] like '%" + name + "%'ORDER BY FONum ASC";
            //string sqlcmd = "Select [FONum] as code from [dbo].[VW_TB_PD_ProductionOrder_TG] where [FONum] like '%" + code + "%' ORDER BY FONum ASC";
            //ต้องเปลี่ยนการ Query ข้อมูล
            SqlConnection conn = new SqlConnection(con);//ต้องเปลี่ยน conn ถ้าเป็น K2
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        public void K2BrowseFOProject()
        {
            string sqlcmd = "";
            sqlcmd += "select distinct [ProjectNum],[CustomerNum],[Requestor],[EstJobOrderNo],[JobOrderNo],[Item],[LotNo],[QtyTotal] from [dbo].[VW_TB_PD_ProductionOrder_TG] where [FONum] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {

                rParam1 = rs["ProjectNum"].ToString();
                rParam2 = rs["CustomerNum"].ToString();
                rParam3 = rs["Requestor"].ToString();
                rParam4 = rs["EstJobOrderNo"].ToString();
                rParam5 = rs["JobOrderNo"].ToString();
                rParam6 = rs["Item"].ToString();
                //rParam7 = rs["ItemDescription"].ToString();
                rParam7 = rs["LotNo"].ToString();
                rParam8 = rs["QtyTotal"].ToString();
                //rParam6 = rs["addr##4"].ToString();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
                rParam6 = "";
                //rParam7 = "";
                rParam7 = "";
                rParam8 = "";
                //rParam6 = "";
            }

            conn.Close();


        }
        public DataSet K2AttachSL_Select2()
        {
            string sqlcmd = "SELECT * FROM VW_SLAttrachment WHERE RefNum = '" + ref_num + "' AND site_ref = '" + SiteRef + "'";
            ClassBrowse cbrown = new ClassBrowse();
            cbrown.SiteRef = SiteRef;
            SqlConnection conn = new SqlConnection(cbrown.CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;



        }
        public DataSet AttachSLSd_Select()
        {
            string sqlcmd = "SELECT sd.Project,do.AttachFile,do.Description FROM TB_PJ_ShopDrawingApprove sd LEFT JOIN TB_PJ_ShopDrawingApprove_Line do ON sd.ID = do.Ref_ID where sd.Project='" + ref_num + "'";
            ClassBrowse cbrown = new ClassBrowse();
            cbrown.SiteRef = SiteRef;
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
            



        }
        public DataTable K2AttachSL_Download()
        {
            string sqlCmd = "SELECT DocumentObject as Data,DocumentExtension as ContentType,DocumentName as Name FROM VW_SLAttrachment WHERE ID = '" + AttID + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (rs.Read())
            {


                dt.Load(rs);


            }
            conn.Close();
            return dt;

        }
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            //String strConnString = System.Configuration.ConfigurationManager
            //.ConnectionStrings["conString"].ConnectionString;
            ClassBrowse cbrown = new ClassBrowse();
            cbrown.SiteRef = SiteRef;
            SqlConnection conn = new SqlConnection(cbrown.CheckConSiteRef());
            SqlDataAdapter sda = new SqlDataAdapter();
            string sqlCmd = "SELECT DocumentObject as Data,DocumentExtension as ContentType,DocumentName as Name FROM VW_SLAttrachment WHERE ID = '" + AttID + "'";
            SqlCommand cmd = new SqlCommand(sqlCmd);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            try
            {
                conn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
                sda.Dispose();
                conn.Dispose();
            }
        }


        public void K2BoundWHMia()
        {

            string sqlCmd = "SELECT [whse] from [ppcc_mia_line] where [mia_num]= '" + Param1 + "'  and [Item]= '" + Param2 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {

                rParam1 = rs["whse"].ToString();
               
            }
            else
            {
                rParam1 = "";
              
            }

            conn.Close();

        }
        public DataSet EmpName()
        {

            string sqlcmd = " select distinct Ltrim(emp_num) as code,name,dept,site_ref from [dbo].[VW_employee_mst] ";
            sqlcmd += " where name is not null  and (Ltrim(emp_num) Like '%" + code + "%' or name Like '%" + name + "%')  ";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
        public DataSet WFDARRequestType()
        {
            string sqlCmd = "SELECT [RequestType] FROM  [TB_SH_DAR_RequestType] WHERE [Group] ='" + Param1 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            DataSet ds = new DataSet();
            DataTable DT = new DataTable();
            DT.Load(cmd.ExecuteReader());

            ds.Tables.Add(DT);
            conn.Close();
            return ds;
        }
        public DataSet WFDARRequestTypeAll()
        {
            string sqlCmd = "SELECT distinct [RequestType] FROM  [TB_SH_DAR_RequestType]";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            DataSet ds = new DataSet();
            DataTable DT = new DataTable();
            DT.Load(cmd.ExecuteReader());

            ds.Tables.Add(DT);
            conn.Close();
            return ds;
        }
        ////WS 18-05-2018 PJ15
        //public void K2BrowseCustomerOverseas()
        //{
        //    string sqlcmd = "";
        //    sqlcmd += "Select [CustAddress],[Rating],[CustFax],[CustPhone] from [dbo].[VW_WF_Customer] where [cust_num] = '" + Param1 + "'";
        //    SqlConnection conn = new SqlConnection(CheckConSiteRef());
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand(sqlcmd, conn);
        //    cmd.CommandType = CommandType.Text;
        //    // cmd.CommandTimeout = 300;
        //    SqlDataReader rs = cmd.ExecuteReader();
        //    if (rs.Read())
        //    {
        //        rParam1 = rs["CustAddress"].ToString();
        //        rParam2 = rs["Rating"].ToString();
        //        rParam3 = rs["CustFax"].ToString();
        //        rParam4 = rs["CustPhone"].ToString();
        //    }
        //    else
        //    {
        //        rParam1 = "";
        //        rParam2 = "";
        //        rParam3 = "";
        //        rParam4 = "";
        //    }

        //    conn.Close();


        //}
        //WS 12-11-2018 PJ15
        public void K2BrowseCustomerOverseas()
        {
            string sqlcmd = "";
            sqlcmd += "Select [CustAddress],[Rating],[CustFax],[CustPhone],[curr_code] from [dbo].[VW_WF_Customer] where [cust_num] = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["CustAddress"].ToString();
                rParam2 = rs["Rating"].ToString();
                rParam3 = rs["CustFax"].ToString();
                rParam4 = rs["CustPhone"].ToString();
                rParam5 = rs["curr_code"].ToString();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
            }

            conn.Close();


        }

        //TN create// 2018-05-22 
        public DataSet BoundCostCenterOverseaPL()
        {


            string sqlcmd = "SELECT [dept] as 'code' , [description] as 'name' FROM [dbo].[dept_Overseas] WHERE ([dept] like '%" + code + "%' OR [description] like '%" + name + "%') AND [Site_Ref] like '%" + Param1 + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }


        internal void LoadWFname()
        {
            string sqlCmd = "select [WorkflowType],[Description] from TB_WorkflowType where WorkflowType ='" + Param1 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam6 = rs["Description"].ToString();
            }
            else
            {
                rParam6 = "";
            }
            conn.Close();

        }


        //NS 2018-06-20
        public DataSet GvWorkflowSelectWFType()
        {
            //CheckConSiteRef(); VW_WorkflowType
            //string sqlcmd = "select WorkflowType ,MainType,Description,StatusType,PK_SiteRef,PKM_SiteRef,PN_SiteRef,PKT_SiteRef,HA_SiteRef,linkNew,Type,Export,PH_SiteRef,ID_SiteRef From [dbo].[VW_WorkflowType]";
            string sqlcmd = "select * From [dbo].[VW_WorkflowType]";
            //sqlcmd += "Where WorkflowType='" + Param1+"'";
            sqlcmd += " WHERE WorkflowType IS NOT NULL AND  (Description Like '%" + Param1 + "%' or '%" + Param1 + "%' = '%%' OR WorkFlowType Like '%" + Param1 + "%' or '%" + Param1 + "%' = '%%') Order by WorkflowType ASC";
            //sqlcmd += " and (WorkflowType = '" + Param2 + "' or '" + Param2 + "' = '') ";
            //sqlcmd += " AND (Description Like '%" + Param3 + "%' or '%" + Param3 + "%' = '%%') Order by WorkflowType ASC";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        //NS 2018-06-20

        
        public DataSet K2AttacWFManul_Select()
        {
            string sqlCmd = "select WFType, ID, NameHeader,ContentTypeHeader,DataHeader,SiteRef_PK,SiteRef_PKM,SiteRef_PKT,SiteRef_SPN,SiteRef_HA,SiteRef_PH,SiteRef_ID,SiteRef_TG,SiteRef_MY From [dbo].[TB_K2AttacWFManual] WHERE WFType='" + Param1 + "'";
            if (Param2 == "ERP_PK")
            {
                sqlCmd += " and SiteRef_PK = 1 ";
            }
            else if (Param2 == "ERP_PKM")
            {
                sqlCmd += " and SiteRef_PKM = 1 ";
            }
            else if (Param2 == "ERP_PKT")
            {
                sqlCmd += " and SiteRef_PKT = 1 ";
            }
            else if (Param2 == "ERP_SPN")
            {
                sqlCmd += " and SiteRef_SPN = 1 ";
            }
            else if (Param2 == "ERP_HA")
            {
                sqlCmd += " and SiteRef_HA = 1 ";
            }
            else if (Param2 == "ERP_PH")
            {
                sqlCmd += " and SiteRef_PH = 1 ";
            }
            else if (Param2 == "ERP_ID")
            {
                sqlCmd += " and SiteRef_ID = 1 ";
            }
            else if (Param2 == "ERP_TG")
            {
                sqlCmd += " and SiteRef_TG = 1 ";
            }
            else if (Param2 == "ERP_MY")
            {
                sqlCmd += " and SiteRef_MY = 1 ";
            }
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //NS 2018-07-02

        public DataSet K2AttacWFManul_SelectUrl()
        {
            string sqlCmd = "select WFType, ID, NameHeader,ContentTypeHeader,DataHeader,SiteRef_PK,SiteRef_PKM,SiteRef_PKT,SiteRef_SPN,SiteRef_HA,SiteRef_PH,SiteRef_ID,SiteRef_TG,SiteRef_MY From [dbo].[TB_K2AttacWFManual] WHERE WFType='" + Param1 + "' and AttacType='Url'";
            if (Param2 == "ERP_PK")
            {
                sqlCmd += " and SiteRef_PK = 1 ";
            }
            else if (Param2 == "ERP_PKM")
            {
                sqlCmd += " and SiteRef_PKM = 1 ";
            }
            else if (Param2 == "ERP_PKT")
            {
                sqlCmd += " and SiteRef_PKT = 1 ";
            }
            else if (Param2 == "ERP_SPN")
            {
                sqlCmd += " and SiteRef_SPN = 1 ";
            }
            else if (Param2 == "ERP_HA")
            {
                sqlCmd += " and SiteRef_HA = 1 ";
            }
            else if (Param2 == "ERP_PH")
            {
                sqlCmd += " and SiteRef_PH = 1 ";
            }
            else if (Param2 == "ERP_ID")
            {
                sqlCmd += " and SiteRef_ID = 1 ";
            }
            else if (Param2 == "ERP_TG")
            {
                sqlCmd += " and SiteRef_TG = 1 ";
            }
            else if (Param2 == "ERP_MY")
            {
                sqlCmd += " and SiteRef_MY = 1 ";
            }

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }

        //NS 2018-06-25
        public DataSet GVAtt_insert()
        {
            string sqlcmd = "EXEC SP_K2AttacWFManual_INSERT '" + Param1 + "','" + Param2 + "','" + ParamB + "','" + Param4 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }



        //NS 2018-06-25
        public DataSet GVAttDelete()
        {

            string sqlcmd = "DELETE [dbo].[TB_K2AttacWFManual] WHERE ID = '" + Param10 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        //NS 2018-06-26
        public DataSet GVAttaddUpdate()
        {
            //CheckConSiteRef();
            string sqlcmd = "EXEC SP_K2AttacWFManual_UPDATE '" + Param1 + "','" + paramb1 + "','" + paramb2 + "','" + paramb3 + "','" + paramb4 + "','" + paramb5 + "','" + paramb6 + "','" + paramb7 + "','" + paramb8 + "','" + paramb9 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //ns 2018-06-26
        public DataSet GVAttCheck()
        {

            string sqlcmd = "UPDATE [dbo].[TB_K2AttacWFManual] SET [SiteRef_PK] = @cbPK,[SiteRef_PKM] = @cbPKM,[SiteRef_PKT] = @cbPKT,[SiteRef_SPN] = @cbSPN,[SiteRef_HA] = @cbHA,[SiteRef_PH] = @cbPH,[SiteRef_ID] = @cbID,[SiteRef_TG] = @cbTG,[SiteRef_MY] = @cbMY WHERE [ID] = @ID";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        //ns 2018-06-27
        public DataTable K2AttachWF_Download()
        {
            string sqlCmd = "SELECT DocumentObject as Data,DocumentExtension as ContentType,DocumentName as Name FROM TB_K2AttacWfManual WHERE ID = '" + AttID + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (rs.Read())
            {


                dt.Load(rs);


            }
            conn.Close();
            return dt;

        }

        // NS 2018-06-27
        public void LoadAttachManualWF()
        {
            string sqlCmd = "SELECT  ID,ContentTypeHeader,NameHeader,AttacType FROM TB_K2AttacWfManual WHERE ID = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["AttacType"].ToString();
                rParam2 = rs["ContentTypeHeader"].ToString();

            }
            conn.Close();
        }

        public void CheckTAttacManualWF()
        {
            string sqlcmd = "SELECT COUNT(AttacType) As attactypeofwf FROM TB_K2AttacWFManual WHERE AttacType='URl' and WFType = '" + Param1 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                rParam1 = rs["attactypeofwf"].ToString();


            }
            conn.Close();

        }

        public void LodeSupportcont()
        {
            string sqlCmd = "SELECT [EstCostSubcont],[ForecastCostSubcont],[ActualSubcont],(case when ([ForecastCostSubcont]-[EstCostSubcont]) > 0 then 1 else 0 end) as Cal1,(case when ([ActualSubcont]-[EstCostSubcont]) > 0 then 1 else 0 end) Cal2  FROM [dbo].[VW_ProjApp_CostSummaryByCostCode]  WHERE [proj_num] = '" + Param1 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["EstCostSubcont"].ToString();
                rParam2 = rs["ForecastCostSubcont"].ToString();
                rParam3 = rs["ActualSubcont"].ToString();
                rParam4 = rs["Cal1"].ToString();
                rParam5 = rs["Cal2"].ToString();


            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
            }
            conn.Close();
        }
        public DataSet K2BoundAdvanceK2()
        {
            string sqlcmd = "SELECT [ProcessInstanceID] as 'code' , [DescriptionPayment] + ' ('+convert(nvarchar(100),[TotalAmount]) +')' as 'name' , [PaymentType] , [Status] FROM [dbo].[VW_AF_EPaymentApprovals] WHERE ([ProcessInstanceID] like '%" + code + "%' OR [DescriptionPayment] like '%" + name + "%') AND ([PaymentType] = 'Advance' AND [Status] = 'Complete')";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }


        public void K2CheckCreateByDAR()
        {
            string sqlCmd = "select CreateBy,ID from TB_SH_DAR";
            sqlCmd += " WHERE ID =" + Param2;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                //,SUBSTRING(job_title,3,100) As 'Jobtitle'
                rParam1 = rs["CreateBy"].ToString();
                //rParam1 = rs["job_title"].ToString();
            }
            conn.Close();
        }

        public void K2DARUpdateImportDoc()
        {
            string sqlCmd = "EXEC SP_SH_DAR_UpdateImportDoc '" + Param1 + "','" + Param2 + "'";


            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();


            conn.Close();
        }
        public void K2UpdateEstimateLoss()
        {
            string sqlCmd = "EXEC SP_UpdateFinalAction '" + Param1 + "','" + Param2 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();


            conn.Close();
        }
        public void K2Updateddelivery()
        {
            string sqlCmd = "EXEC SP_UpdateTransport '" + Param1 + "','" + Param2 + "','" + Param3 + "','" + Param4 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();


            conn.Close();
        }
        internal void ProjectDetail()
        {
            string sqlCmd = "Select [ProjectNo],[Customer],[CustomerName],[SaleEngineer],[SaleEngineerName],[ProjEngineer],[ProjEngineerName],[ProjectManager],[ProjectManagerName],[Plan_RevenueTH],[ProjectStartDate],[ProjectEndDate],[end_user_type] from [dbo].[TB_Rpt_ProjectCostDetail] where [ProjectNo] ='" + Param1 + "'";
          
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["ProjectNo"].ToString();
                rParam2 = rs["Customer"].ToString();
                rParam3 = rs["CustomerName"].ToString();
                rParam4 = rs["SaleEngineer"].ToString();
                rParam5 = rs["SaleEngineerName"].ToString();
                rParam6 = rs["ProjEngineer"].ToString();
                rParam7 = rs["ProjEngineerName"].ToString();
                rParam8 = rs["ProjectManager"].ToString();
                rParam9 = rs["Plan_RevenueTH"].ToString();
                rParam10 = rs["ProjectManagerName"].ToString();
                rParam11 = rs["ProjectStartDate"].ToString();
                rParam12 = rs["ProjectEndDate"].ToString();
                rParam13 = rs["end_user_type"].ToString();

             
            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
                rParam6 = "";
                rParam7 = "";
                rParam8 = "";
                rParam9 = "";
                rParam10 = "";
                rParam11 = "";
                rParam12 = "";
                rParam13 = "";
            }
            conn.Close();


        }

      
        internal void selectDataCOHA()
        {
            string sqlCmd = "Select [QuotationNo],[EstimateStatus],[QuotationDate],[ExpDate],[Customer],[DeliveryCusName],[CustomerName],[DeliveryDate],[CustomerAdd],[DeliveryAdd]";
            sqlCmd += ",[contact],[ContactOther],[Uf_CheckPaymentType],[Uf_CreditLimit],[COOutstanding],[AgingOutstanding],[Uf_CreditLimiteBalance],[Outstanding],[Current],[1-30 Days]";
            sqlCmd += ",[31-60 Days],[61-90 Days],[91-120 Days],[Over120Days],[Rating],[CustRating],[tax_code1],[TaxRate1],[terms_code],[TermDesc]";
            sqlCmd += ",[Cur],[ExchangeRate],[SaleEngineer],[SaleEngineerName],[SaleSuper],[SaleSuperName],[Warranty],[PaymentTerm],[Remark],[SLK2Remark]";
            sqlCmd += ",[TotalAmount],[PerHeadDiscount],[AmtHeadDiscount],[Balance],[VatAmount],[TotalAmtIncVat],[Uf_EndUserType],[Uf_SalesForceNo],[Step],[ReviseType]";
            sqlCmd += ",[Uf_RequistorID],[Uf_Project],[Uf_FinalAction],[Uf_DownPaymentAmt],[Uf_AccountConfirmInvoice],[ProductType],[SourceSite],[CoNum],[PR_num],[PO_num]";
            sqlCmd += "from [dbo].[VW_WF_SA_Estimate_HA]";
            sqlCmd += "where [CoNum] ='" + Param1 + "'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                rParam1 = rs["QuotationNo"].ToString();
                rParam2 = rs["EstimateStatus"].ToString();
                rParam3 = rs["QuotationDate"].ToString();
                rParam4 = rs["ExpDate"].ToString();
                rParam5 = rs["Customer"].ToString();
                rParam6 = rs["DeliveryCusName"].ToString();
                rParam7 = rs["CustomerName"].ToString();
                rParam8 = rs["DeliveryDate"].ToString();
                rParam9 = rs["CustomerAdd"].ToString();
                rParam10 = rs["DeliveryAdd"].ToString();

                rParam11 = rs["contact"].ToString();
                rParam12 = rs["ContactOther"].ToString();
                rParam13 = rs["Uf_CheckPaymentType"].ToString();
                rParam14 = rs["Uf_CreditLimit"].ToString();
                rParam15 = rs["COOutstanding"].ToString();
                rParam16 = rs["AgingOutstanding"].ToString();
                rParam17 = rs["Uf_CreditLimiteBalance"].ToString();
                rParam18 = rs["Outstanding"].ToString();
                rParam19 = rs["Current"].ToString();
                rParam20 = rs["1-30 Days"].ToString();
//[31-60 Days],[61-90 Days],[91-120 Days],[Over120Days],[Rating],[CustRating],[tax_code1],[TaxRate1],[terms_code],[TermDesc]";
                rParam21 = rs["31-60 Days"].ToString();
                rParam22 = rs["61-90 Days"].ToString();
                rParam23 = rs["91-120 Days"].ToString();
                rParam24 = rs["Over120Days"].ToString();
                rParam25 = rs["Rating"].ToString();
                rParam26 = rs["CustRating"].ToString();
                rParam27 = rs["tax_code1"].ToString();
                rParam28 = rs["TaxRate1"].ToString();
                rParam29 = rs["terms_code"].ToString();
                rParam30 = rs["TermDesc"].ToString();
//",[Cur],[ExchangeRate],[SaleEngineer],[SaleEngineerName],[SaleSuper],[SaleSuperName],[Warranty],[PaymentTerm],[Remark],[SLK2Remark]";
                rParam31 = rs["Cur"].ToString();
                rParam32 = rs["ExchangeRate"].ToString();
                rParam33 = rs["SaleEngineer"].ToString();
                rParam34 = rs["SaleEngineerName"].ToString();
                rParam35 = rs["SaleSuper"].ToString();
                rParam36 = rs["SaleSuperName"].ToString();
                rParam37 = rs["Warranty"].ToString();
                rParam38 = rs["PaymentTerm"].ToString();
                rParam39 = rs["Remark"].ToString();
                rParam40 = rs["SLK2Remark"].ToString();
//[TotalAmount],[PerHeadDiscount],[AmtHeadDiscount],[Balance],[VatAmount],[TotalAmtIncVat],[Uf_EndUserType],[Uf_SalesForceNo],[Step]
                rParam41 = rs["TotalAmount"].ToString();
                rParam42 = rs["PerHeadDiscount"].ToString();
                rParam43 = rs["AmtHeadDiscount"].ToString();
                rParam44 = rs["Balance"].ToString();
                rParam45 = rs["VatAmount"].ToString();
                rParam46 = rs["TotalAmtIncVat"].ToString();
                rParam47 = rs["Uf_EndUserType"].ToString();
                rParam48 = rs["Uf_SalesForceNo"].ToString();
                rParam49 = rs["Step"].ToString();
                rParam50 = rs["ReviseType"].ToString();
//,[Uf_RequistorID],[Uf_Project],[Uf_FinalAction],[Uf_DownPaymentAmt],[Uf_AccountConfirmInvoice],[ProductType],[SourceSite],[CoNum],[PR_num],[PO_num]
                rParam51 = rs["Uf_RequistorID"].ToString();
                rParam52 = rs["Uf_Project"].ToString();
                rParam53 = rs["Uf_FinalAction"].ToString();
                rParam54 = rs["Uf_DownPaymentAmt"].ToString();
                rParam55 = rs["Uf_AccountConfirmInvoice"].ToString();
                rParam56 = rs["ProductType"].ToString();
                rParam57 = rs["SourceSite"].ToString();
                rParam58 = rs["CoNum"].ToString();
                rParam59 = rs["PR_num"].ToString();
                rParam60 = rs["PO_num"].ToString();

               

            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
                rParam4 = "";
                rParam5 = "";
                rParam6 = "";
                rParam7 = "";
                rParam8 = "";
                rParam9 = "";
                rParam10 = "";

                rParam11 = "";
                rParam12 = "";
                rParam13 = "";
                rParam14 = "";
                rParam15 = "";
                rParam16 = "";
                rParam17 = "";
                rParam18 = "";
                rParam19 = "";
                rParam20 = "";

                rParam21 = "";
                rParam22 = "";
                rParam23 = "";
                rParam24 = "";
                rParam25 = "";
                rParam26 = "";
                rParam27 = "";
                rParam28 = "";
                rParam29 = "";
                rParam30 = "";

                rParam31 = "";
                rParam32 = "";
                rParam33 = "";
                rParam34 = "";
                rParam35 = "";
                rParam36 = "";
                rParam37 = "";
                rParam38 = "";
                rParam39 = "";
                rParam40 = "";

                rParam41 = "";
                rParam42 = "";
                rParam43 = "";
                rParam44 = "";
                rParam45 = "";
                rParam46 = "";
                rParam47 = "";
                rParam48 = "";
                rParam49 = "";
                rParam50 = "";

                rParam51 = "";
                rParam52 = "";
                rParam53 = "";
                rParam54 = "";
                rParam55 = "";
                rParam56 = "";
                rParam57 = "";
                rParam58 = "";
                rParam59 = "";
                rParam60 = "";
            }
            conn.Close();


        }

       
        public void calmaxactual()
        {
            string sqlCmd = "select Max([ActualCompleteDate]) as MaxCompleteDate  from [TB_PJ_ShopDrawingApprove_Line]";
            sqlCmd += " WHERE Ref_ID =" + Param1;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["MaxCompleteDate"].ToString();
               
            }
            conn.Close();
        }
        public void calKpidate()
        {
            string sqlCmd = "SELECT DATEDIFF(d, (convert(DATETIME,'"+Param1+"',103)), (convert(DATETIME,'"+Param2+"',103)))";
            sqlCmd += "- DATEDIFF(wk, (convert(DATETIME,'"+Param1+"',103)), (convert(DATETIME,'"+Param2+"',103)))";
            sqlCmd += "* 2 - CASE WHEN DATENAME(dw, (convert(DATETIME,'"+Param1+"',103)))";
            sqlCmd += "<> 'Saturday' AND DATENAME(dw, (convert(DATETIME,'"+Param2+"',103)))";
            sqlCmd += "= 'Saturday' THEN 1 WHEN DATENAME(dw, (convert(DATETIME,'"+Param1+"',103))) = 'Saturday' AND DATENAME(dw, (convert(DATETIME,'"+Param2+"',103)))";
            sqlCmd += " <> 'Saturday' THEN - 1 ELSE 0 END +1 AS date_count";
 
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["date_count"].ToString();

            }
            conn.Close();
        }

        public void checkProjTips()
        {
            string sqlCmd = "SELECT count([NameAtt]) as Cnum FROM [dbo].[TB_ProjectAttNote] WHERE [ProjNum] =  '" + Param1 + "' and NameAtt like 'Tips%'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam4 = rs["Cnum"].ToString();


            }

            conn.Close();
        }


        public DataSet K2BoundJobOrder()
        {
            string sqlcmd = "Select [job] as code, '' as name from [dbo].[Job_mst] where [job] like '%" + code + "%' OR [job] like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

      
        public void getpermission()
        {
            string sqlCmd = "select  pay_type_name ,pay_type_name ,Permission_Type From [dbo].[ppcc_esy_vch_pay_type] Where pay_type_name = '" + Param1 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["pay_type_name"].ToString();
                rParam2 = rs["pay_type_name"].ToString();
                rParam3 = rs["Permission_Type"].ToString();
              


            }
            else
            {
                rParam1 = "";
                rParam2 = "";
                rParam3 = "";
            }
            conn.Close();
        }
        public void checkERegulars()
        {
            string sqlCmd = "EXEC SP_AF_EVS_CheckERegulars '" + Param1 + "','" + Param2 + "','" + Param3 + "','" + Param4 + "'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Msg"].ToString();


            }

            conn.Close();
        }

        public DataSet K2BoundVatCode()
        {
            string sqlcmd = "Select tax_code as code, Description as name from [dbo].[taxcode_mst] where tax_code like '%" + code + "%' OR Description like '%" + name + "%'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public void CheckVat_AF24()
        {
            string sqlCmd = "select 1 from  [dbo].[TB_AF_EasyVoucher_Line] evl ";
            sqlCmd += "left join [SLDB1\\SYTELINEDBC1].[CRP2_PKS_App].[dbo].[ppcc_esy_vch_pay_type] pt ";
            sqlCmd += "on evl.[PayMentID] = pt.pay_type_num ";
            sqlCmd += "where evl.Ref_ID = '" + Param1 + "'";
            sqlCmd += "and pt.Flag_vat = '1'";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = "1";


            }
            else
            {
                rParam1 = "0";
            }
            conn.Close();
        }
        public void K2GetPaymentTerm()
        {
            string sqlCmd = "SELECT Terms_Code,[Add1],[Add2] ,[Add3],[Add4],[City],Uf_Vendor_Branch,Uf_Vendor_BranchID,Tax_ID FROM [dbo].[VW_Vendors] WHERE vend_num = '" + Param1 + "'";


            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Terms_Code"].ToString();
                rParam2 = rs["Add1"].ToString() + "  " + rs["Add2"].ToString() + "  " + rs["Add3"].ToString() + "  " + rs["Add4"].ToString() + "  " + rs["City"].ToString();
                rParam3 = rs["Add1"].ToString();
                rParam4 = rs["Add2"].ToString();
                rParam5 = rs["Add3"].ToString();
                rParam6 = rs["Add4"].ToString();
                rParam7 = rs["Uf_Vendor_Branch"].ToString();
                rParam8 = rs["Uf_Vendor_BranchID"].ToString();
                rParam9 = rs["Tax_ID"].ToString();
            }
            else
            {
                rParam1 = "";
                rParam2 = "";

            }
            conn.Close();
        }
        public void CheckPayTypeNum()
        {
            string sqlCmd = "select  pay_type_num From [dbo].[ppcc_esy_vch_pay_type] Where pay_type_name ='" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["pay_type_num"].ToString();


            }

            conn.Close();
        }

        public DataSet LoadGroupExp()
        {
            string sqlCmd = "select distinct pay_group_th as code,pay_group as name From [dbo].[ppcc_esy_vch_pay_type]";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            DataSet ds = new DataSet();
            DataTable DT = new DataTable();
            DT.Load(cmd.ExecuteReader());

            ds.Tables.Add(DT);
            conn.Close();
            return ds;
        }

        public void LoadDataItemDetail()
        {
            string sqlCmd = "select * from [VW_ItemSearch] where item = '" + Param1 + "'  and site_ref = '" + Param2 + "' ";

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["LongDescription"].ToString();
                rParam2 = rs["Stock"].ToString();


            }

            conn.Close();
        }

        //Revise WS 2018-11-13
        public void K2LoadProjectOverseaPM()
        {
            //string sqlCmd = "Select Years,TimePerYears,Total,PM,StandardFactor,EstCost,ProjectValue  From [dbo].[TB_PJ_ProjectOpenOversea] where [Project]='" + Param1 + "' and [Site_Ref]='" + Param2 + "'";

            string sqlCmd = "Select Years,TimePerYears,Total,StandardFactor,EstCost,ProjectValue  From [dbo].[TB_PJ_ProjectOpenOversea] where [Project]='" + Param1 + "' and [Site_Ref]='" + Param2 + "'";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["Years"].ToString();
                rParam2 = rs["TimePerYears"].ToString();
                rParam3 = rs["Total"].ToString();
                //rParam4 = rs["PM"].ToString();
                rParam5 = rs["ProjectValue"].ToString();
                rParam6 = rs["StandardFactor"].ToString();
                rParam7 = rs["EstCost"].ToString();


            }
            conn.Close();
        }


        public DataSet K2BoundProceesInprocessToComplete()
        {
            string sqlcmd = " SELECT TOP 50 [ProcInstID],[SiteRef] FROM [dbo].[VW_CheckGotoComplete] ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }
       

 // 2018-12-10 WS // SG02
        public DataSet K2BoundCatagory()
        {
            string sqlcmd = "SELECT Name as code, Detail as Name FROM [dbo].[TB_SG_SocialMediaContent_Catagory]";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        // 2018-12-10 WS // SG02
        public DataSet K2BoundMedia()
        {
            string sqlcmd = "SELECT Name as code, Detail as Name FROM [dbo].[TB_SG_SocialMediaContent_Media]";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        public void calminplan()
        {
            string sqlCmd = "select Max([ActualCompleteDate]) as MaxCompleteDate,min([PlanStartDate]) as MinplanDate  from [TB_PJ_ShopDrawingApprove_Line]";
            sqlCmd += " WHERE Ref_ID =" + Param1;

            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["MaxCompleteDate"].ToString();
                rParam2 = rs["MinplanDate"].ToString();


            }
            conn.Close();
        }
        //WS create// 2019-01-30 
        public DataSet BoundCostCenterOverseaPLV2()
        {


            string sqlcmd = "SELECT [dept] as 'code' , [description] as 'name' FROM [dbo].[dept_mst] WHERE ([dept] like '%" + code + "%' OR [description] like '%" + name + "%') AND [Site_Ref] like '%" + Param1 + "%'";
            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;

        }



        public void K2LoadEstimateJobOrder()
        {
            string sqlCmd = "select [EstimateCost] from [dbo].[VW_Rpt_JobVarianceSum] where suffix='0'and Job = '" + Param1 + "'";

            SqlConnection conn = new SqlConnection(CheckConSiteRef());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {

                rParam1 = rs["EstimateCost"].ToString();



            }
            else
            {
                rParam1 = "";


            }
            conn.Close();
        }
        
    }

}