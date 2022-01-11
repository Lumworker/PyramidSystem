using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Workflow_Application
{
    class ClassDBConnSL
    {
        public string StrDB, rParamSL;
        SqlConnection Con = new SqlConnection();
        string Site = System.Configuration.ConfigurationManager.AppSettings["Site"];
        string PK = System.Configuration.ConfigurationManager.AppSettings["PK"];
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

        string CPK = System.Configuration.ConfigurationManager.AppSettings["CPK"];

        string default_Site_Ref = System.Configuration.ConfigurationManager.AppSettings["default_Site_Ref"];
        string ServerK2 = System.Configuration.ConfigurationManager.AppSettings["ServerK2"];

        SqlConnection ConPK = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_PK"].ToString());
        SqlConnection ConPKM = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_PKM"].ToString());
        SqlConnection ConPKT = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_PKT"].ToString());
        SqlConnection ConSPanel = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_SPN"].ToString());
        //SqlConnection ConOversea = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLOversea"].ToString());
        SqlConnection ConOverseaPH = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLOverseaPH"].ToString());
        SqlConnection ConOverseaID = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLOverseaID"].ToString());
        SqlConnection ConOverseaMY = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLOverseaMY"].ToString());
        SqlConnection ConCTG = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLCRP2_TG"].ToString());
        SqlConnection ConTG = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_TG"].ToString());
        SqlConnection ConCHA = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLCRP2_HA"].ToString());

        SqlConnection ConHA = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLERP_HA"].ToString());

        SqlConnection ConCPK = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLCRP_PK"].ToString());

        SqlCommand Com = new SqlCommand();
        public static String conSLPK = "Data Source=SLDB1\\SYTELINEDBC1;Initial Catalog=ERP_PKS_App;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000";

        string SQL;
        public DataTable dtTest = new DataTable();
        public DataTable ExecuteReader(string SQL)
        {
            if (StrDB == null || StrDB == "")
            {
                StrDB = default_Site_Ref;
            }
            DataTable DT = new DataTable();
            if (StrDB == PK)
            {

                Con = ConPK;
            }
            else if (StrDB == PKM)
            {
                Con = ConPKM;
            }
            else if (StrDB == CPK)
            {
                Con = ConCPK;
            }
            else if (StrDB == PKT)
            {
                Con = ConPKT;
            }
            else if (StrDB == SPN)
            {
                Con = ConSPanel;
            }
            else if (StrDB == PH)
            {
                Con = ConOverseaPH;
            }
            else if (StrDB == IND)
            {
                Con = ConOverseaID;
            }
            else if (StrDB == MY)
            {
                Con = ConOverseaMY;
            }
            else if (StrDB == TG)
            {
                Con = ConTG;
            }
            else if (StrDB == CTG)
            {
                Con = ConCTG;
            }
            else if (StrDB == HA)
            {
                Con = ConHA;
            }
            else if (StrDB == CHA)
            {
                Con = ConCHA;
            }
            else
            {
                Con = ConPK;
            }

            try
            {
                Con.Open();
                Com.Connection = Con;
                Com.CommandType = CommandType.Text;
                Com.CommandText = SQL;
                Com.CommandTimeout = 0;
                DT.Load(Com.ExecuteReader());
            }
            //catch(SqlException ex)
            catch (SqlException ex)
            {
                //Response.Write(ex.Message);
                Con.Close();
                Com.Dispose();
                return DT;
            }
            Con.Close();
            Com.Dispose();
            return DT;
        }
        public Boolean ExecuteNonQuery(string SQL)
        {
            if (StrDB == null || StrDB == "")
            {
                StrDB = default_Site_Ref;
            }
            if (StrDB == PK)
            {
                Con = ConPK;
            }
            else if (StrDB == PKM)
            {
                Con = ConPKM;
            }
            else if (StrDB == PKT)
            {
                Con = ConPKT;
            }
            else if (StrDB == SPN)
            {
                Con = ConSPanel;
            }
            else if (StrDB == TG)
            {
                Con = ConTG;
            }
            else if (StrDB == HA)
            {
                Con = ConHA;
            }
            else if (StrDB == CHA)
            {
                Con = ConCHA;
            }
            try
            {
                Con.Open();
                Com.Connection = Con;
                Com.CommandType = CommandType.Text;
                Com.CommandText = SQL;
                Com.CommandTimeout = 0;
                Com.ExecuteNonQuery();
                Con.Close();
                Com.Dispose();
                return true;
            }
            //catch( SqlException ex)
            catch (SqlException ex)
            {
                //Response.Write(ex.Message);         
                Con.Close();
                Com.Dispose();
                return false;
            }
        }
        public DataTable GetDataTableNull()
        {
            DataTable DtNull = new DataTable();
            DtNull.Columns.Add("str");
            DataRow dr = null;
            dr = DtNull.NewRow();
            dr["str"] = "";
            DtNull.Rows.Add(dr);
            return DtNull;
        }
        //Data Dropdown
        public DataTable LoadDataProjCust(String Proj)
        {
            SQL = " select customername from [dbo].[VW_WF_Project] where projectnum = '" + Proj + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable DTSite_Ref()
        {
            SQL = @" SELECT SiteRef as code,Corp_NameEN as name
                    FROM [PATKOL_K2APP_DATA].[dbo].VW_SiteDatabase
                    order by siteCode ASC";
            //WHERE SiteRef Like '" + Site + "%' and SiteRef <> 'CRP2_PKSS' order by siteCode ASC";
            //WHERE SiteRef Like 'CRP2_%' and SiteRef <> 'CRP2_PKSS' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadSiteName(String Site_Ref)
        {
            SQL = @" SELECT SiteRef as code,case when siteCode = 'A' then 'PATKOL PUBPLIC COMPANY' else (case when  siteCode = 'B' then 'PATKOL MANUFACTURING COMPANY'  else (case when  siteCode = 'C' then 'PATKOL TRADING COMPANY' else 'S Panel COMPANY' end) end) end as name
                    FROM [PATKOL_K2APP_DATA].[dbo].SiteDatabase
                    WHERE SiteRef = '" + Site_Ref + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadBranch2(String StrQuickSearch)
        {
            SQL = " select Value as code,Description as name from [dbo].[VW_WF_VendorType] where (Value Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Description Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadCurrency(String StrQuickSearch)
        {
            SQL = " select [curr_code] as code,[description] as name from [dbo].[VW_WF_Currency] Where (curr_code Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  description Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadSector(String StrQuickSearch)
        {
            SQL = " select [Sector_id] as code,[Sector_desc] as name from [dbo].[VW_WF_Sector] Where (Sector_id Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Sector_desc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadProjChangeCost(String StrQuickSearch)
        {
            SQL = @" select ProjectNum as [code],ProjectDesc as [name] ";
            SQL += " from [dbo].[VW_WF_ProjectforChangeCost] ";
            SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadSubSector(String StrQuickSearch)
        {
            SQL = " select [SubSector_id] as code,[SubSector_desc] as name from [dbo].[VW_WF_SubSector] Where (SubSector_id Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  SubSector_desc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')  ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadSubSector2(String StrQuickSearch)
        {
            SQL = " select [SubSector_id] as code,[SubSector_desc] as name from [dbo].[VW_WF_SubSector] Where  (SubSector_id Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  SubSector_desc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadVendor2(String StrQuickSearch)
        {
            SQL = " select vend_num as code,Uf_Vendor_LongVendorName as name from [dbo].[VW_WF_Vendor] where (vend_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Uf_Vendor_LongVendorName Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadProj(String StrQuickSearch)
        {
            //SQL = " select * ";
            //SQL += " from [dbo].[VW_WF_Project] ";
            //SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            SQL = @" select al1.ProjectNum as code,al1.ProjectDesc as name  from (select pro.Proj_num as ProjectNum,pro.proj_desc as ProjectDesc
                    from proj_mst pro
                    where pro.Type = 'P') al1 ";
            SQL += " where ProjectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or ProjectDesc like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadProjExport(String StrQuickSearch)
        {
            //SQL = " select * ";
            //SQL += " from [dbo].[VW_WF_Project] ";
            //SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            SQL = @" select Top 20 [ProjectNum] as code,[ProjectDesc] as name from VW_WF_Project ";
            SQL += " where ProjectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or ProjectDesc like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadDataProj(String Proj)
        {
            SQL = " select * from [dbo].[VW_WF_Project] where projectnum = '" + Proj + "' ";
            return ExecuteReader(SQL);
        }

        //        public DataTable LoadCust(String StrQuickSearch)
        //        {
        //            SQL = @" select [cust_num] as code,[name] as name,[Rating],[CustAddress],[curr_code],[CustTax],[CustPhone],[CustFax]
        //                     ,[AgeBal1],[AgeBal2],[AgeBal3],[AgeBal4],[AgeBal5],[AgeBal6],[Post_Balance],[DescriptionRating],[Current_Aging] from [dbo].[VW_WF_Customer] where (cust_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or [name] Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
        //            return ExecuteReader(SQL);
        //        }
        public DataTable LoadCust(String StrQuickSearch)
        {
            SQL = @" select [cust_num] as code,[name] as name,[Rating],[CustAddress],[curr_code],[CustTax],[CustPhone],[CustFax]
                     ,[AgeBal1],[AgeBal2],[AgeBal3],[AgeBal4],[AgeBal5],[AgeBal6],[Post_Balance],[DescriptionRating],[Current_Aging] from [dbo].[VW_WF_Customer] where (cust_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or [name] Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }

        public DataTable LoadCustAging(String StrQuickSearch)
        {
            SQL = @" select [cust_num] as code,[name] as name,[Rating],[CustAddress],[curr_code],[CustTax],[CustPhone],[CustFax]
                     ,[1-30 Days],[31-60 Days],[61-90 Days],[91-120 Days],[Over120Days],[Outstanding],[Current],[DescriptionRating] from [dbo].[VW_WF_CustomerAging] where (cust_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or [name] Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        //        public DataTable LoadBranch(String Cust_Num,String StrQuickSearch)
        //        {
        //            SQL = @" select cust_seq as code,name from [dbo].[VW_Cust_Branch]
        //                     where (cust_seq Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  name Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
        //            SQL += " and cust_num = '"+ Cust_Num +"' ";
        //            return ExecuteReader(SQL);
        //        }
        public DataTable LoadBranch(String Cust_Num, String StrQuickSearch)
        {
            SQL = @" select cust_num as code,name from [dbo].[VW_Cust_Branch]
                     where (cust_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  name Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            SQL += " and cust_num = '" + Cust_Num + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadTask(String StrQuickSearch)
        {
            SQL = " select task_num as code,task_desc as name from [dbo].projtask_mst where (proj_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  task_desc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadTaskDesc(String Proj, String Task)
        {
            SQL = " select task_num as code,task_desc as name from [dbo].projtask_mst ";
            SQL += " where proj_num = '" + Proj + "' ";
            SQL += " and task_num = '" + Task + "' ";
            return ExecuteReader(SQL);
        }
        //public DataTable LoadEmp(String StrQuickSearch)
        //{
        //    SQL = " select Ltrim(emp_num) as code,name,dept from [dbo].[employee_mst] ";
        //    SQL += " where emp_type <> 'N' and  name is not null  and (Ltrim(emp_num) Like '%" + StrQuickSearch + "%' or name Like '%" + StrQuickSearch + "%')  ";
        //    return ExecuteReader(SQL);
        //}
        public DataTable LoadEmp(String StrQuickSearch)
        {
            SQL = " select Ltrim(emp_num) as code,name,dept from [dbo].[VW_employee_mst] ";
            SQL += " where emp_type <> 'N' and  name is not null  and (Ltrim(emp_num) Like '%" + StrQuickSearch + "%' or name Like '%" + StrQuickSearch + "%')  ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEstProj_num(String StrQuickSearch)
        {
            SQL = @" select  Uf_LastInvoiceAmt,Uf_DownPaymentAmt,proj_num as code,proj_desc as name from proj_mst
                     where type = 'E' and (proj_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  proj_desc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable Loadinco_delterm(String StrQuickSearch)
        {
            SQL = @" select inco_delterm as code,description as name from [dbo].[inco_del_term] 
                     where (inco_delterm Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  description Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEmployee_Search(String res_id, String Fullname, String eMail, String Extension
            , String Level, String scostcenter, String ecostcenter, string sstartdate, string estartdate
            , string sEnddate, string eEnddate)
        {
            SQL = " select * From [dbo].[VW_EmployeesSerch] WHERE 1=1 ";
            SQL += " AND (res_id Like '%" + res_id + "%' or '%" + res_id + "%' = '%%') ";
            SQL += " AND ((Fullname Like '%" + Fullname + "%' or '%" + Fullname + "%' = '%%') ";
            SQL += " or (FullnameEN Like '%" + Fullname + "%' or '%" + Fullname + "%' = '%%')) ";
            SQL += " AND (eMail Like '%" + eMail + "%' or '%" + eMail + "%' = '%%') ";
            SQL += " AND (Extension Like '%" + Extension + "%' or '%" + Extension + "%' = '%%') ";
            SQL += " AND (Level Like  '%" + Level + "%' or '%" + Level + "%' = '%%') ";
            SQL += " AND (costcenter >= '" + scostcenter + "' or '" + scostcenter + "' = '') ";
            SQL += " AND (costcenter <= '" + ecostcenter + "' or '" + ecostcenter + "' = '') ";
            SQL += " and (startdate >= convert(date,'" + sstartdate + "',103) or convert(date,'" + sstartdate + "',103) = '') ";
            SQL += " and (Startdate <= convert(date,'" + estartdate + "',103) or convert(date,'" + estartdate + "',103) = '') ";
            SQL += " and (enddate >= convert(date,'" + sEnddate + "',103) or convert(date,'" + sEnddate + "',103) = '') ";
            SQL += " and (enddate <= convert(date,'" + eEnddate + "',103) or convert(date,'" + eEnddate + "',103) = '') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadVendorSearch(String vend_num, String Name, String vendorType, String PaymentCondition
            , String Tems_code, String Terms_Description)
        {
            SQL = " select * from VW_Vendors ";
            SQL += " where (vend_num like '%" + vend_num + "%' or '%" + vend_num + "%' = '') ";
            SQL += " and (Name like '%" + Name + "%' or '%" + Name + "%' = '%%') ";
            SQL += " and (vendorType like '%" + vendorType + "%' or '%" + vendorType + "%' = '%%') ";
            SQL += " and (PaymentCondition Like '%" + PaymentCondition + "%' or '%" + PaymentCondition + "%' = '%%') ";
            SQL += " and (Terms_code like '%" + Tems_code + "%' or '%%" + Tems_code + "' = '%%') ";
            SQL += " and (Terms_Description like '%" + Terms_Description + "%' or '%" + Terms_Description + "%' = '%%')  ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadCustomerSearch(String cust_num, String name, String curr_code)
        {
            SQL = " select * from [dbo].[VW_Customer] ";
            SQL += " where (cust_num like '%" + cust_num + "%' or '%" + cust_num + "%' = '%%')";
            SQL += " and (name  like '%" + name + "%' or '%" + name + "%' = '%%')";
            SQL += " and (curr_code  like '%" + curr_code + "%' or '%" + curr_code + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadUserAD(String QuickSearch)
        {
            SQL = " select username as code,name from employee_mst ";
            SQL += " where (username Like '%" + QuickSearch + "%' or '%" + QuickSearch + "%' = '%%' ";
            SQL += " or name like '%" + QuickSearch + "%' or '%" + QuickSearch + "%' = '%%') ";
            SQL += " and username is not null ";
            SQL += " order by username asc ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadDept(String StrQuickSearch)
        {
            SQL = " select dept as code,description as name from VW_Dept ";
            SQL += " where dept <> '0000' and description is not null ";
            SQL += " and (dept Like '%" + StrQuickSearch + "%' or description Like '%" + StrQuickSearch + "%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEstimate(String StrQuickSearch)
        {
            SQL = " select co_num as code,est_num as name from [dbo].[VW_Estimate] ";
            SQL += " where (co_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadPR(String StrQuickSearch)
        {
            SQL = " select req_num as code,'' as name from [dbo].[VW_Purchade_Requisition]  ";
            SQL += " where (req_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadPO(String StrQuickSearch)
        {
            SQL = " select po_num as code,'' as name from [dbo].[VW_Purchade_Order]  ";
            SQL += " where (po_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadProj_Sro(String StrQuickSearch)
        {
            SQL = " select proj_num as code, proj_desc as name from [dbo].[VW_Project] ";
            SQL += " where (proj_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or proj_desc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadCO(String PO)
        {
            SQL = " select * from [dbo].[VW_CO] ";
            SQL += " where cust_po = '" + PO + "' ";
            return ExecuteReader(SQL);
        }

        //Add By Wiroj
        public DataTable LoadSerailNum(String JobOrder, String StrQuickSearch)
        {
            SQL = " select [ser_num] as code , '' as name from [dbo].[VW_Serial] where  job = '" + JobOrder + "' and ([ser_num] like '%" + StrQuickSearch + "%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadOper(String JobOrder, String StrQuickSearch)
        {
            SQL = " select [oper_num] as code ,  wc as name from [dbo].[VW_Operation] where job = '" + JobOrder + "' and ([job] = '" + StrQuickSearch + "') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadMate(String co_num, String StrQuickSearch)
        {
            // SQL = " select [item] as code , [description] as name from [dbo].[VW_Material] where ([item] like '%" + StrQuickSearch + "%' or description Like '%" + StrQuickSearch + "%') ";
            SQL = " select item as code,ProductDescription as name from [dbo].[VW_Item] ";
            SQL += " where (co_num = '" + co_num + "' or '" + co_num + "' = '') and (item = '" + StrQuickSearch + "' or '" + StrQuickSearch + "' = '') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadWH(String StrQuickSearch)
        {
            SQL = " select [whse] as code , [name] as name , loc , cost , u_m from [dbo].[VW_Warehouse] where ([item] = '" + StrQuickSearch + "')";
            return ExecuteReader(SQL);
        }
        public DataTable Loadwhse(String StrQuickSearch)
        {
            SQL = " select [whse] as code , [name] as name , loc , cost , u_m , qty_on_hand from [dbo].[VW_Warehouse] where [whse] = '" + StrQuickSearch + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadJob(String StrQuickSearch)
        {
            SQL = " select [job] as code , [description] as name from [dbo].[VW_JobOrder] where ([job] like '%" + StrQuickSearch + "%' or description Like '%" + StrQuickSearch + "%')";
            return ExecuteReader(SQL);
        }
        public DataTable CheckJobName(String StrQuickSearch)
        {
            SQL = " select [job] as code , [description] as name from [dbo].[VW_JobOrder] where ([job] like '%" + StrQuickSearch + "%' or description Like '%" + StrQuickSearch + "%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadLot(String Item, String QuickSearch)
        {
            SQL = " select lot as code,'' as name from [dbo].[VW_lot] ";
            SQL += " where item = '" + Item + "' and (lot Like '%" + QuickSearch + "%' or '%" + QuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadSerail(String Job)
        {
            SQL = " select s.*,ts.SerialNo,case when ts.SerialNo is null then '0' else '1' end as 'Check',ts.ID from [dbo].[VW_Serial] s ";
            SQL += " left outer join " + ServerK2 + ".[K2].[dbo].TB_FactoryOrder_Serial ts on ts.Site_ref = s.site_ref ";
            SQL += " and ts.SerialNo = s.ser_num and ts.Item = s.item ";
            SQL += " where Job = '" + Job + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadItemCodeCard(String StrQuickSearch, string Site_ref) //JT08/03/2019
        {
            SQL = " SELECT [WFtype] , [Qty] , [site_ref] , item FROM [dbo].[VW_ItemCodeCard] where [site_ref] = '" + Site_ref + "' and item = '" + StrQuickSearch + "'  ";
            return ExecuteReader(SQL);
        }

        public DataTable LoadItemCodeCardPR(String StrQuickSearch, string Site_Ref)//JT08/03/2019
        {
            SQL = " SELECT * FROM [dbo].[VW_ItemCodeCardPR] where [site_ref] = '" + Site_Ref + "' and item = '" + StrQuickSearch + "'  ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadItemCodeCardMIA(String StrQuickSearch, string Site_Ref)//JT08/03/2019
        {
            SQL = " SELECT * FROM [dbo].[VW_ItemCodeCardMIA] where [site_ref] = '" + Site_Ref + "' and item = '" + StrQuickSearch + "'  ";
            return ExecuteReader(SQL);
        }
        public DataTable Loadwhse(String StrQuickSearch, String StritemSearch)
        {
            SQL = " select [whse]  , [name] as name , loc , cost , u_m , qty_on_hand from [dbo].[VW_Warehouse] where [whse] = '" + StrQuickSearch + "' and [item] = '" + StritemSearch + "'";
            return ExecuteReader(SQL);
        }
        public DataTable LoadwhseItem(String StrQuickSearch, String StrQuickSearch2)
        {
            SQL = " select TOP 1 loc , cost , u_m , qty_on_hand from [dbo].[VW_LocatioWH] where [whse] = '" + StrQuickSearch + "' AND item = '" + StrQuickSearch2 + "' ORDER BY qty_on_hand DESC";
            return ExecuteReader(SQL);
        }
        public DataTable LoadCustomerCard(String StrQuickSearch, string Site_Ref) //JT 26/02/2019
        {
            SQL = " SELECT [type] , [Qty] , Customer , [site_ref] FROM [dbo].[VW_CustomerCard] where [site_ref] = '" + Site_Ref + "' and Customer = '" + StrQuickSearch + "'  ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadCustomerCardProject(String StrQuickSearch, string Site_Ref) //JT 26/02/2019
        {
            SQL = " SELECT * FROM [dbo].[VW_CustomerCardProject] where [site_ref] = '" + Site_Ref + "' and Customer = '" + StrQuickSearch + "'  ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadVendorCard(String StrQuickSearch, string site_ref) //JT 26/02/2019
        {
            SQL = " SELECT [type] , [Qty] , Vendor , [site_ref] FROM [dbo].[VW_VendorCard] where [site_ref] = '" + site_ref + "' and Vendor = '" + StrQuickSearch + "'  ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadVendorCardPO(String StrQuickSearch, string site_ref) //JT 26/02/2019
        {
            SQL = " SELECT * FROM [dbo].[VW_VendorCardPO] where [site_ref] = '" + site_ref + "' and Vendor = '" + StrQuickSearch + "'  ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadProj_Cost(String StrQuickSearch)
        {
            SQL = "SELECT * FROM [dbo].[VW_ProjCostSum] where [proj_num] = '" + StrQuickSearch + "' AND [Type] = 'Total' ";
            return ExecuteReader(SQL);
        }

        internal DataTable LoadProj_num(string StrQuickSearch)
        {
            SQL = @" select proj_num as code,proj_desc as name from proj_mst
                     where  (proj_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  proj_desc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }

        public DataTable LoadProjComplete(String StrQuickSearch)
        {
            //SQL = " select * ";
            //SQL += " from [dbo].[VW_WF_Project] ";
            //SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            SQL = @"select pro.Proj_num as Code,pro.proj_desc as Name
                    from proj_mst pro
                    where pro.Type = 'P' and pro.Uf_K2ID is Null and";
            SQL += " pro.Proj_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or pro.proj_desc like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' ";
            return ExecuteReader(SQL);
            //pro.Type = 'P' and pro.Uf_K2ID is Null and
        }
        public DataTable LoadProjComplete2(String StrQuickSearch)
        {
            //SQL = " select * ";
            //SQL += " from [dbo].[VW_WF_Project] ";
            //SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            SQL = @"select pro.Proj_num as Code,pro.proj_desc as Name
                    from proj_mst pro
                    where ";
            SQL += "  Uf_K2ID is null and (pro.Proj_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or pro.proj_desc like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadTerm(String StrQuickSearch)
        {
            SQL = " select [terms_code] as code,[description] as name from [dbo].[terms_mst] Where (terms_code Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  description Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }

        //------Update By SB 02/02/2017 Start Version Loq

        public DataTable LoadDescProj_Sro(String StrQuickSearch)
        {
            SQL = "SELECT y.* FROM ( ";
            SQL += "SELECT [sro_num] as 'Code',Description as 'Name',[cust_num] FROM [dbo].[fs_sro_mst] ";
            SQL += "UNION ALL ( SELECT [proj_num] as 'Code',[proj_desc] as 'Description',[cust_num] FROM [dbo].[proj_mst] WHERE [type] = 'P') ";
            SQL += ")y WHERE y.Code like '%" + StrQuickSearch + "%' OR y.Name LIKE '%" + StrQuickSearch + "%'";

            return ExecuteReader(SQL);
        }

        public DataTable LoadItemDesc(String StrQuickSearch)
        {
            SQL = " select [Item] as code,[description] as name from [dbo].[Item_mst] Where ([Item] Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  description Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        //===================== Wisa.je 31/01/2018 ==============================
        public DataTable LoadMile(string StrQuickSearch)
        {

            SQL = " select [ms_num] as code,[ref_desc1] as name from [dbo].[ppcc_inv_ms] ";
            SQL += "  where ([ms_num] like '%" + StrQuickSearch + "%' or [ref_desc1] Like '%" + StrQuickSearch + "%')";

            return ExecuteReader(SQL);
        }
        public DataTable LoadInv(String StrQuickSearch)
        {
            SQL = " select [ms_num] as code,[inv_num] as name from [dbo].[ppcc_inv_ms] Where (ms_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  inv_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }

        public DataTable LoadProjExportShip(String StrQuickSearch)
        {
            //SQL = " select * ";
            //SQL += " from [dbo].[VW_WF_Project] ";
            //SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            SQL = @" select * from VW_WF_ExportShipment";
            SQL += " where proj_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadProjectEstProjectService(String StrQuickSearch)
        {
            //SQL = " select * ";
            //SQL += " from [dbo].[VW_WF_Project] ";
            //SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            SQL = @" select distinct [name] as description from VW_WF_ProjectEstProjectService";
            SQL += " where req_num Like '%" + StrQuickSearch + "%'";
            return ExecuteReader(SQL);
        }
        public DataTable LoadProjectEstProjectServicePRO(String StrQuickSearch)
        {
            //SQL = " select * ";
            //SQL += " from [dbo].[VW_WF_Project] ";
            //SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            SQL = @" select distinct [description] as name from VW_WF_ProjectEstProjectService";
            SQL += " where req_num Like '%" + StrQuickSearch + "%'";
            return ExecuteReader(SQL);
        }


        //        public DataTable DTSite_Ref()
        //        {
        //            //string SQL;
        //            SQL = @" SELECT SiteRef as code,ConfName as name
        //                    FROM [PATKOL_K2APP_DATA].[dbo].SiteDatabase
        //                    WHERE SiteRef = '" + StrDB + "%' AND ConfName is not null order by ConfName ASC";
        //            //WHERE SiteRef Like 'CRP2_%' and SiteRef <> 'CRP2_PKSS' ";
        //            return ExecuteReader(SQL);
        //        }

        //        public String CheckConSiteRef()
        //        {
        //            string SQL;
        //            SQL = @" SELECT SiteRef as code,ConfName as name
        //                    FROM [PATKOL_K2APP_DATA].[dbo].SiteDatabase
        //                    WHERE SiteRef = '" + StrDB + "%' AND ConfName is not null order by ConfName ASC";
        //            return ExecuteReader(SQL);
        //        }

        public void GetSiteConfName(string SiteRef)
        {
            string sqlCmd = " SELECT ConfName FROM [PATKOL_K2APP_DATA].[dbo].SiteDatabase WHERE SiteRef ='" + SiteRef + "'";
            SqlConnection conn = new SqlConnection(conSLPK);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            SqlDataReader rs = cmd.ExecuteReader();

            if (rs.Read())
            {
                //,SUBSTRING(job_title,3,100) As 'Jobtitle'
                rParamSL = rs["ConfName"].ToString();
                //rParam1 = rs["job_title"].ToString();


            }
            conn.Close();
        }
        // WS 09-04-2018 //
        public DataTable LoadSubSector3(String StrQuickSearch)
        {
            SQL = " select [SubSector_id] as code,[SubSector_desc] as name from [dbo].[VW_WF_SubSector] Where (Sector_id Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  SubSector_desc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        // WS 20-04-2018 //
        public DataTable Costcenter(String StrQuickSearch)
        {
            SQL = " select distinct  Dept as code,[Description] as name from [dbo].[dept_mst] Where (Dept Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Description Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        internal DataTable LoadProjManager(string StrQuickSearch)
        {
            SQL = @" select proj_mgr from VW_WF_Project
                     where  (ProjectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        internal DataTable LoadProjManagerName(string StrQuickSearch)
        {
            SQL = @" select proj_mgr_name from VW_WF_Project
                     where  (ProjectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        internal DataTable LoadProjEngineer(string StrQuickSearch)
        {
            SQL = @" select ProjEngineer from VW_WF_Project
                     where  (ProjectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        internal DataTable LoadProjEngineerName(string StrQuickSearch)
        {
            SQL = @" select ProjEngineerName from VW_WF_Project
                     where  (ProjectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        internal DataTable LoadSalesEngineer(string StrQuickSearch)
        {
            SQL = @" select SaleEngineer from VW_WF_Project
                     where  (ProjectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        internal DataTable LoadSalesEnigneerName(string StrQuickSearch)
        {
            SQL = @" select SaleEngineerName from VW_WF_Project
                     where  (ProjectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        //         internal DataTable LoadSalesEnigneerOverseas(string StrQuickSearch)
        //        {
        //            SQL = @" select Ltrim(emp_num) as code,name,dept,site_ref from [dbo].[VW_employee_mst]
        //                where (emp_type <> 'N' and name is not null  and (Ltrim(emp_num) Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
        //            return ExecuteReader(SQL);
        //        }    

        //WS 2018-07-04 PJ15
        public DataTable LoadSalesEnigneerOverseas(string StrQuickSearch)
        {
            SQL = @" select distinct Ltrim(emp_num) as code,name,dept,site_ref from [dbo].[VW_employee_mst]
                where name is not null  and (Ltrim(emp_num) Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadProductCodeOverseas(string StrQuickSearch)
        {
            SQL = "SELECT [product_code] as 'code' , [description] as 'name' FROM [dbo].[VW_WF_ProductCode] WHERE [product_code] like '%" + StrQuickSearch + "%' OR [description] like '%" + StrQuickSearch + "%'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadIncotermOverseas(string StrQuickSearch)
        {
            SQL = "SELECT [inco_delterm] as 'code' , [description] as 'name' FROM [dbo].[VW_WF_Incoterm] WHERE [inco_delterm] like '%" + StrQuickSearch + "%' OR [description] like '%" + StrQuickSearch + "%'";
            return ExecuteReader(SQL);
        }




        //WS Overseas 08-05-2018 AF01
        public DataTable LoadCurrencyOverseas(String StrQuickSearch)
        {
            SQL = " select [code] as code, name from [dbo].[VW_WF_Currency] Where (code Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  name Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }

        //WS Overseas 18-05-2018 
        public DataTable BoundCostCenterOversea(String StrQuickSearch)
        {
            SQL = " select [dept] as code, [description] as name from [dbo].[dept_Overseas] Where (dept Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  description Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }

        //WS 2018-06-07 AF01
        public DataTable LoadBranch1(String Cust_Num, String StrQuickSearch)
        {
            SQL = @" select  cust_seq as code, cust_num as name from [dbo].[VW_WF_CustomerBranch]
                     where (cust_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  cust_seq Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            SQL += " and cust_num = '" + Cust_Num + "' ";
            return ExecuteReader(SQL);
        }




        public DataTable K2BoundSRO(String StrQuickSearch)
        {
            SQL = " select [vend_num] as code, [Name] as name from [dbo].[VW_WF_Vendors] Where (vend_num Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Name Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEmployeeLogon(string Logon)
        {
            SQL = @" select * from [dbo].[VW_Employee_All]
                    where username = REPLACE('" + Logon + "','PATKOL\\','') ";
            return ExecuteReader(SQL);
        }

        public DataTable LoadGroupExp()
        {
            SQL = " select distinct pay_group as code,pay_group as name From [dbo].[ppcc_esy_vch_pay_type]";
            return ExecuteReader(SQL);
        }
        public DataTable LoadGroupExpType(string StrQuickSearch)
        {
            SQL = " select  pay_type_num as code,pay_type_name as name From [dbo].[ppcc_esy_vch_pay_type] Where pay_group ='" + StrQuickSearch + "'";
            return ExecuteReader(SQL);
        }





        public DataTable LoadExportinvoice(string StrQuickSearch)
        {
            SQL = @" SELECT [ProcessInstanceID] as code, [InvoiceNumber] as name from [dbo].[VW_WF_ExportInvoice]
                where  (ProcessInstanceID Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  InvoiceNumber Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }

        public DataTable paygroup(string StrQuickSearch)
        {
            string SQL = "select  pay_type_name as code,pay_type_name as name From [dbo].[ppcc_esy_vch_pay_type] Where pay_group ='" + StrQuickSearch + "'";
            return ExecuteReader(SQL);
        }

    }
}
