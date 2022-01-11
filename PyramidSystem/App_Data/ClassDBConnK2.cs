using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
using System.Collections;

namespace Workflow_Application
{
    class ClassDBConnK2
    {
        public static String SiteRef;
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
        string ServerK2Remark = System.Configuration.ConfigurationManager.AppSettings["ServerK2Remark"];
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringK2"].ToString());
        //SqlConnection Con = new SqlConnection("Data Source=K2DEVDB1\\K2DEVDBC1;Initial Catalog=K2;Persist Security Info=True;User ID=sa;Password=P@ssw0rd; Connect Timeout=0; pooling=true; Max Pool Size=5000");

        SqlCommand Com = new SqlCommand();

        string SQL;
        //DataTable dtTest = new DataTable();
        public string ID, Site_ref, WorkflowType, CreateBy, Resource, Cost_Center, Subject = "", planner;
        public DataTable ExecuteReader(string SQL)
        {
            DataTable DT = new DataTable();
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

        public DataTable UpdateStepCompleteProject(String ID, String ProcID)
        {
            SQL = " exec [dbo].[SP_UpdateStep_PJ06] " + ID + ",'" + ProcID + "'";
            return ExecuteReader(SQL);
        }
        public DataTable QueryDataTable1(CommandType CmdType, String strQuery, ArrayList Params)
        {
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            //Con = new SqlConnection();
            Con.Open();

            Com = new SqlCommand();

            Com.Connection = Con;
            Com.CommandType = CmdType;
            Com.CommandText = strQuery;

            for (int i = 0; i < Params.Count; i++)
            {
                Com.Parameters.Add(Params[i]);
            }

            try
            {
                dtAdapter = new SqlDataAdapter(Com);
                dtAdapter.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new System.Exception();
            }
            finally
            {
                Con.Close();
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

        public DataTable CountryEvent()
        {
            SQL = "  select c.CustomerId,c.CustomerName from mt.Customer c where c.IsEnableStatus = 1 ";
            return ExecuteReader(SQL);
        }

        public DataTable LoadPD04Head(String ID)
        {
            SQL = " select * from [dbo].[TB_AdditionalMaterial] ";
            SQL += " where ID = '" + ID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadCountry(String StrQuickSearch)
        {
            SQL = " select [country] as code,[Uf_CountryTH] as name from [dbo].[VW_country_mst] Where (country Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Uf_CountryTH Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadGVItem(String Ref_ID)
        {
            SQL = "  select * from [dbo].[TB_AdditionalMaterial_Item] ";
            SQL += " where ProcessInstanceID is not null and Ref_ID = '" + Ref_ID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadProvince(String StrQuickSearch)
        {
            SQL = " select [state] as code,[description] as name from [dbo].[VW_state_mst] Where (state Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  description Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEmp(String Site_ref)
        {
            SQL = " select  Site_ref,Emp_num,name,dept,emp_type,job_title,email,uf_Level,username,description ";
            SQL += " from [dbo].[VW_Employee_All] ";
            SQL += " Where (Site_ref = '" + Site_ref + "' OR '" + Site_ref + "' = '') ";
            return ExecuteReader(SQL);
        }


        public DataTable LoadDataWFSearch(string PageIndex, string K2ID, string WFType, string Originator
            , string Folio, string StartDate, string EndDate, string Activity, int WF, string User)
        {
            //SQL = " select * from [dbo].[VW_Process_Instance] ";
            //if (QuickID == "0")
            //{
            //    SQL += " where (convert(varchar(1000),[Process Instance ID]) Like '%"+ txtStr +"%') ";
            //    SQL += " OR (Folio Like '%" + txtStr + "%') OR ([Process Name] Like '%" + txtStr + "%') OR (convert(varchar(10),StartDate,103) Like '%" + txtStr + "%') ";
            //    SQL += " OR (convert(varchar(10),EndDate,103) Like '%" + txtStr + "%') OR (Status Like '%" + txtStr + "%') OR (Originator Like '%" + txtStr + "%') ";
            //}
            //else if (QuickID == "1")
            //{

            //}
            //else if (QuickID == "2")
            //{

            //}
            //SQL += " Order by [Process Instance ID] desc ";
            SQL = " exec [dbo].[SP_Results_Workflow] '" + PageIndex + "','10','" + K2ID + "' ,4,'" + WFType + "' ";
            SQL += " ,'" + Originator + "','" + Folio + "','" + StartDate + "','" + EndDate + "','" + Activity + "','" + WF + "','" + User + "' ";
            return ExecuteReader(SQL);
        }
        // #region SelectDropdown
        //public void ddl_Test()
        //{
        //    dtTest = CountryEvent();
        //}
        //public void ddlControl(DropDownList ddl, string strTextField, string strValueFiled)
        //{
        //    ddl.DataSource = dtTest;
        //    ddl.DataTextField = strTextField;
        //    ddl.DataValueField = strValueFiled;
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem("== Select Value ==", "0"));
        //}
        // #endregion

        public DataTable LoadMainMenuType(String pSite_Ref)
        {
            SQL = @" select  mt.ID,mt.MainTypeID,mt.Description 
                    from [dbo].[TB_WorkflowMainType]  mt
                    inner join [dbo].[TB_WorkflowType] ft on mt.MainTypeID = ft.MainType
                    where 1 =1 ";
            if (pSite_Ref == PK)
            {
                SQL += " and ft.PK_SiteRef = 1 ";
            }
            else if (pSite_Ref == PKM)
            {
                SQL += " and ft.PKM_Siteref = 1 ";
            }
            else if (pSite_Ref == PKT)
            {
                SQL += " and ft.PKT_SiteRef = 1 ";
            }
            else if (pSite_Ref == SPN)
            {
                SQL += " and ft.PN_SiteRef = 1 ";
            }
            else if (pSite_Ref == PH)
            {
                SQL += " and ft.PH_SiteRef = 1 ";
            }
            else if (pSite_Ref == IND)
            {
                SQL += " and ID_SiteRef = 1 ";
            }
            else if (pSite_Ref == TG)
            {
                SQL += " and TG_SiteRef = 1 ";
            }
            else if (pSite_Ref == HA)
            {
                SQL += " and HA_SiteRef = 1 ";
            }
            else if (pSite_Ref == CHA)
            {
                SQL += " and HA_SiteRef = 1 ";
            }
            else if (pSite_Ref == MY)
            {
                SQL += " and MY_SiteRef = 1 ";
            }
            SQL += " group by mt.ID,mt.MainTypeID,mt.Description  ";
            SQL += " order by MainTypeID asc ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadWFName(String MainType, String pSite_Ref)
        {
            SQL = " select linkNew,WorkflowType,Description,Link from " +
                     " [dbo].[TB_WorkflowType] " +
                     " where type = 'K2' and MainType = '" + MainType + "' and StatusType = 1  and link is not null and link not like '%SyteLine%' ";
            if (pSite_Ref == PK)
            {
                SQL += " and PK_SiteRef = 1 ";
            }
            else if (pSite_Ref == PKM)
            {
                SQL += " and PKM_Siteref = 1 ";
            }
            else if (pSite_Ref == PKT)
            {
                SQL += " and PKT_SiteRef = 1 ";
            }
            else if (pSite_Ref == SPN)
            {
                SQL += " and PN_SiteRef = 1 ";
            }
            else if (pSite_Ref == PH)
            {
                SQL += " and PH_SiteRef = 1 ";
            }
            else if (pSite_Ref == IND)
            {
                SQL += " and ID_SiteRef = 1 ";
            }
            else if (pSite_Ref == TG)
            {
                SQL += " and TG_SiteRef = 1 ";
            }
            else if (pSite_Ref == HA)
            {
                SQL += " and HA_SiteRef = 1 ";
            }
            else if (pSite_Ref == CHA)
            {
                SQL += " and HA_SiteRef = 1 ";
            }
            else if (pSite_Ref == MY)
            {
                SQL += " and MY_SiteRef = 1 ";
            }
            SQL += " order by WorkflowType asc ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadWF_Desription(String WFType)
        {
            SQL = @"  select linkNew,WorkflowType,Description 
                     from  [dbo].[TB_WorkflowType]  
                     where WorkflowType = '" + WFType + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEmployeeLogon(string Logon)
        {
            SQL = @" select * from [dbo].[VW_Employee_All]
                    where username = REPLACE('" + Logon + "','PATKOL\\','') ";
            return ExecuteReader(SQL);
        }
        public DataTable CreateNewItemCode(string ItemCodeGenerate)
        {
            SQL = " exec [dbo].[SP_CreateNewItemCode] '" + @ID + "','" + @Site_ref + "','" + @WorkflowType + "', ";
            SQL += "'" + @CreateBy + "','" + @Resource + "','" + @Cost_Center + "','" + @Subject + "','" + @ItemCodeGenerate + "' ";
            return ExecuteReader(SQL);

        }
        public DataTable CountWF(String Type, String UserAD)
        {
            SQL = "exec [dbo].[SP_Count_Workflow] '" + @Type + "','" + UserAD + "' ";

            return ExecuteReader(SQL);
        }
        public DataTable ListWFTop5(String UserAD)
        {
            SQL = " exec [dbo].[SP_Results_Workflow] '1','5','',4,'','','','','','','3','" + UserAD + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadDataTable(string TableName, string ID)
        {
            SQL = " select * from " + TableName + " where ID = " + ID + " ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadTableName(String WFType)
        {
            SQL = " select TB_Name from TB_K2TableName where WFType = '" + WFType + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadTypeInsurance(String GroupID)
        {
            SQL = " select DDLName as code,DDLVules as name from TB_DropDownListDetail where (GroupID = '" + GroupID + "' or '" + GroupID + "' = '') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadVendorSearch(String Site_Ref, String vend_num, String Name, String vendorType, String PaymentCondition
          , String Tems_code, String Terms_Description)
        {
            SQL = " select TOP(200) * from VW_Vendors ";
            SQL += " where Category <> 'E101' and (vend_num like '%" + vend_num + "%' or '%" + vend_num + "%' = '') ";
            SQL += " and (Name like '%" + Name + "%' or '%" + Name + "%' = '%%') ";
            SQL += " and (vendorType like '%" + vendorType + "%' or '%" + vendorType + "%' = '%%') ";
            SQL += " and (PaymentCondition Like '%" + PaymentCondition + "%' or '%" + PaymentCondition + "%' = '%%') ";
            SQL += " and (Terms_code like '%" + Tems_code + "%' or '%%" + Tems_code + "' = '%%') ";
            SQL += " and (Terms_Description like '%" + Terms_Description + "%' or '%" + Terms_Description + "%' = '%%')  ";
            SQL += " and (site_ref = '" + Site_Ref + "' or '" + Site_Ref + "' = '') ";
            return ExecuteReader(SQL);
        }
        public DataTable CustSearch(String Site_Ref, String cust_num, String name)
        {
            SQL = " select TOP(200) * from [dbo].[VW_Customer] ";
            SQL += " where (cust_num like '%" + cust_num + "%' or '%" + cust_num + "%' = '%%')";
            SQL += " and (name  like '%" + name + "%' or '%" + name + "%' = '%%')";
            SQL += " and (site_ref = '" + Site_Ref + "' or '" + Site_Ref + "' = '') ";
            return ExecuteReader(SQL);
        }
        public DataTable ItemSearch(string PageIndex, String Site_ref, String ItemCode, String Char, String Desc, String Active, String Obsolete, String Slow_Moving)
        {

            //SQL = " select * from [VW_ItemSearch]  ";
            // SQL += "  where (Site_ref = '" + Site_ref + "' or '" + Site_ref + "' = '') ";
            // SQL += "  and  (item Like '%" + ItemCode + "%' or '%" + ItemCode + "%' = '%%')";
            // SQL += "  and (Characteristic Like '%" + Char + "%' OR '%" + Char + "%' = '%%')";
            // SQL += "  and (Description Like '%" + Desc + "%' or '%" + Desc + "%' = '%%')";
            // SQL += "  and (Status in ('"+ Active +"','"+ Obsolete +"','"+ Slow_Moving +"')) ";
            SQL = " exec [dbo].[SP_Results_ItemSearch] '" + PageIndex + "','10','4','" + Site_ref + "','" + ItemCode + "' ";
            SQL += " ,'" + Char + "','" + Desc + "','" + Active + "','" + Obsolete + "','" + Slow_Moving + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadDataItemDetail(String Code, String Site_Ref) //JT 17/04/2019
        {
            SQL = " select * from [VW_ItemSearch] where item = '" + Code + "'  and site_ref = '" + Site_Ref + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable VendorSearch(String VendorCode, String Name)
        {
            SQL = "select * from VW_Vendors";
            SQL += " where vend_num like '%" + VendorCode + "%' AND LongName like '%" + Name + "%'";

            return ExecuteReader(SQL);
        }
        public DataTable CustSearch(String CustCode, String Name)
        {
            SQL = "select * from VW_Customer";
            SQL += " where cust_num like '%" + CustCode + "%' AND LongName like '%" + Name + "%'";

            return ExecuteReader(SQL);
        }
        public DataTable LoadddlWFType()
        {
            SQL = " select distinct WorkflowType as code,WorkflowType + ' / ' + Description as name from [dbo].[TB_WorkflowType] ";
            SQL += " where WorkflowType is not null and Description is not null order by WorkflowType asc ";
            return ExecuteReader(SQL);
        }

        public DataTable LoadddlWFTypeForMyTask()
        {
            SQL = " select distinct WorkflowType as code,WorkflowType + ' / ' + Description as name from [dbo].[TB_WorkflowType] ";
            SQL += " where WorkflowType is not null and Description is not null AND LEN(WorkflowType) =  4 order by WorkflowType asc  ";
            return ExecuteReader(SQL);
        }

        public DataTable LoadddlMainType()
        {
            //SQL = " select MainTypeID as code,MainTypeID + ' /' + Description as name from [dbo].[TB_WorkflowMainType] ";
            //SQL += " where MainTypeID is not null and MainTypeID not in ('1000','2000') order by MainTypeID asc ";
            SQL = " select distinct wmt.MainTypeID as code,wmt.MainTypeID + ' /' + wmt.Description as name ";
            SQL += " from [dbo].[TB_WorkflowMainType] wmt";
            SQL += " inner join [dbo].[TB_WorkflowType] wt on wmt.MainTypeID = wt.MainType";
            SQL += " where wmt.MainTypeID is not null and wmt.MainTypeID not in ('1000','2000')";
            SQL += " and wt.Export = 1";
            SQL += " order by wmt.MainTypeID asc ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadddlWorkflowName(String WFType)
        {
            SQL = " select WorkflowType as code,Description as name from [dbo].[TB_WorkflowType] ";
            SQL += " where MainType = '" + WFType + "' and Export = 1 ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadDept(String Site_ref, String StrQuickSearch)
        {
            SQL = " select dept as code,description as name from VW_Dept ";
            SQL += " where dept <> '0000' and description is not null ";
            SQL += " and (site_ref = '" + Site_ref + "' or '" + Site_ref + "' = '') ";
            SQL += " and (dept Like '%" + StrQuickSearch + "%' or description Like '%" + StrQuickSearch + "%') ";
            return ExecuteReader(SQL);
        }
       
        public DataTable LoadEmployee_Search(String Site_Ref, String res_id, String Fullname, String eMail, String Extension
            , String Level, String scostcenter, String ecostcenter, string sstartdate, string estartdate
            , string sEnddate, string eEnddate, String Emp_Status)
        {
            SQL = " select * From [dbo].[VW_EmployeesSerch] WHERE 1=1 ";
            SQL += " and (Site_ref = '" + Site_Ref + "' or '" + Site_Ref + "' = '') ";
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
            SQL += " and (Emp_StatusDesc = '" + Emp_Status + "' or '" + Emp_Status + "' = '') ";
          
            return ExecuteReader(SQL);
        }

        public DataTable LoadEmployee_SearchModal(String Site_Ref, String Search)
        {
       
            SQL = " select DISTINCT res_id ,Fullname ,JobTitle,Level,costcenter From [dbo].[VW_Pyramid_Emp] where ";
            SQL += "( res_id Like '%" + Search + "%' OR Fullname Like '%" + Search + "%') ";
            //SQL += " AND (Fullname Like  '%" + Search + "%' or '%" + Search + "%' = '%%') ";

            //SQL +=  (res_id Like '%" + SearchValue + "%' OR itmUf_LongDesc Like '%" + SearchValue + "%')";

            //SQL += " where (res_id Like '%" + Search + "%' or '%" + Search + "%' = '%%') ";
            //SQL += " And (Fullname Like '%" + Search + "%' or '%" + Search + "%' = '%%') ";


            //SQL += "";
            //SQL += " and (Site_ref = '" + Site_Ref + "' or '" + Site_Ref + "' = '') ";

            //SQL += " (res_id Like '%" + Search + "%' or '%" + Search + "%' = '%%') ";
            //SQL += " AND (Fullname Like '%" + Search + "%' or '%" + Search + "%' = '%%') ";
            //SQL += " or (FullnameEN Like '%" + Search + "%' or '%" + Search + "%' = '%%')) And Level != '' And Emp_StatusDesc = 'Active' ";


            return ExecuteReader(SQL);
        }
        public DataTable LoadAttachFile(String WorkflowType, String WorkflowID)
        {
            SQL = " select *,Attachment as FileName,ProcInsID + '/' + Attachment as FullFileName,'1' AtType  ";
            SQL += " From [dbo].[TB_Attachments] where WorkflowType = '" + WorkflowType + "' and WorkflowID = '" + WorkflowID + "' and WorkflowID <> '' ";
            //SQL = " select ID,Site_ref,'' as ProcInsID,WorkflowType,WorkflowID,'' as Attachment,CreateBy,CreateDate,'' as Step,'' as FileName,Attachment as FullFilename,'0' AtType ";
            //SQL += " from TB_WorkflowAttachment where workflowType = '" + WorkflowType + "' and WorkflowID = '" + WorkflowID + "' ";
            //SQL += " union all ";
            //SQL += " select *,Attachment as FileName,ProcInsID + '/' + Attachment as FullFileName ,'1' AtType ";
            //SQL += " From [dbo].[TB_Attachments] where WorkflowType = '" + WorkflowType + "' and WorkflowID = '" + WorkflowID + "' and WorkflowID <> '' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadOldAttactment(String WorkflowType, String WorkflowID)
        {
            SQL = " select ID,Site_ref,'' as ProcInsID,WorkflowType,WorkflowID,'' as Attachment,CreateBy,CreateDate,'' as Step,'Link Download Old Attachment' as FileName,Attachment as FullFilename,'0' AtType ";
            SQL += " from  TB_WorkflowAttachment where workflowType = '" + WorkflowType + "' and WorkflowID = '" + WorkflowID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadVW_Export(String WFType)
        {
            SQL = " select * from TB_K2TableName ";
            SQL += " where WFType = '" + WFType + "' AND  (Type <> 'L')";
            return ExecuteReader(SQL);
        }
        //public DataTable LoadDataExportByVW(String VWName, String sDate, String eDate, String Activity, String Costcenter)
        //{
        //    if (Activity == "==ALL==")
        //    {
        //        Activity = "";
        //    }

        //    SQL = " select * from " + VWName + " ";
        //    SQL += " where Convert(date,Createdate,103) between Convert(date,'" + sDate + "',103) and Convert(date,'" + eDate + "',103) ";
        //    SQL += " and (Status = '" + Activity + "' or '" + Activity + "' = '') ";
        //    SQL += " and ([Cost Center] like '%" + Costcenter + "%' or '" + Costcenter + "' = '') ";
        //    return ExecuteReader(SQL);
        //}

        public DataTable LoadDataExportByVW(String VWName, String sDate, String eDate, String Activity, String Costcenter, String Site_Ref)
        {
            if (Activity == "==ALL==")
            {
                Activity = "";
            }


            SQL = " select * from " + VWName + " ";
            SQL += " where Convert(date,Createdate,103) between Convert(date,'" + sDate + "',103) and Convert(date,'" + eDate + "',103) ";
            if (Site_Ref == "ALL")
            {
                Site_Ref = "";
                SQL += "and (Site_ref  like '%" + Site_Ref + "%' or '" + Site_Ref + "'= '') ";
            }
            else
            {
                SQL += " and (Site_ref = '" + Site_Ref + "' or '" + Site_Ref + "' = '') ";
            }


            SQL += " and (Status like '%" + Activity + "%' or '%" + Activity + "%' = '') ";
            SQL += " and ([Cost Center] like '%" + Costcenter + "%' or '" + Costcenter + "' = '') ";

            return ExecuteReader(SQL);
        }
        public DataTable LoadItemDescription(String Item, String Site_Ref) //JT 17/04/2019
        {
            SQL = " select LongDescription from VW_ItemSearch where item = '" + Item + "' and site_ref = '" + Site_Ref + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadItemWareHouse(String Item, String Site_Ref)
        {
            SQL = " select * from VW_ItemWarehouse ";
            SQL += " where item = '" + Item + "' and site_ref = '" + Site_Ref + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable PrefixAJ(String Prefix)
        {
            SQL = " [dbo].[SP_GenerateAjNumber] '" + Prefix + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEnquiry(String StrQuickSearch)
        {
            SQL = " select ID as code,Subject as name,Site_Ref as FormSite,ProcessInstanceID,ToSite,Resource_ID as  Resource,name as ResourceName,Resource_Dep as ResourceDesp,Customer,CustomerName ";
            SQL += " from [dbo].[VW_Enquiry] ";
            SQL += " where (ID Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' ";
            SQL += " or Subject Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' ";
            SQL += " or ProcessInstanceID Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEnquiryForFO(String StrQuickSearch)
        {
            SQL = " select ID as code,Subject as name,Site_Ref as FormSite,ProcessInstanceID,ToSite,Resource_ID as  Resource,name as ResourceName,Resource_Dep as ResourceDesp,Customer,CustomerName,FO_Number ";
            SQL += " from [dbo].[VW_Enquiry_For_FO] ";
            SQL += " where (ID Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' ";
            SQL += " or Subject Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' ";
            SQL += " or ProcessInstanceID Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadToDept(String Site_Ref)
        {
            SQL = " select dept as code,dept + ' / ' + description as name from [dbo].[VW_Dept] ";
            SQL += " where site_ref = '" + Site_Ref + "' ";

            if (Site_Ref == PKM)
            {
                SQL += " and dept Like '4F%' ";
            }
            return ExecuteReader(SQL);
        }
        public DataTable LoadEmployeeByEmpID(String EmpID)
        {
            SQL = " select username from [dbo].[VW_Employee_All] ";
            SQL += " where Ltrim(Emp_num) = '" + EmpID + "' and username is not null ";
            return ExecuteReader(SQL);

        }
        public DataTable LoadNameByUserAD(String UserAD)
        {
            SQL = " select distinct Ltrim(Emp_num) as Emp_num,name,dept from [dbo].[VW_Employee_All] ";
            SQL += " where username = '" + UserAD + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadItem_Line(String RefID, String UserAD)
        {
            //SQL = "select * from [dbo].[VW_Factory_Order_Line] ";
            //SQL += " where Ref_ID = '" + RefID + "' ";
            SQL = " exec [dbo].[SP_FactoryOrder_Line_select] '" + RefID + "','" + UserAD + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable ChckProcRemark(String RemarkProcIns)
        {
            SQL = " select * from [SLDB1" + @"\" + "SYTELINEDBC1]." + ServerK2Remark + ".[dbo].[ProcessRemarkRequest] ";
            SQL += " where Status = 'Awaiting' and RemarkProcInstID = '" + RemarkProcIns + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable CheckStepFC(String ID)
        {
            SQL = " select Step from TB_FactoryOrder_2 where ID = '" + ID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable UpdateCheckItem(Boolean Check, String ID)
        {
            SQL = " update TB_FactoryOrder_EstimateItem set [Check] = '" + Check + "' ";
            SQL += " where ID = '" + ID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable InsertSerial(String WT, String Site_ref, String Serial, String UserAD
            , String Item, String Ref_ID)
        {
            SQL = " insert into TB_FactoryOrder_Serial ";
            SQL += " ([WorkflowType] ";
            SQL += " ,[Site_ref] ";
            SQL += " ,[SerialNo] ";
            SQL += " ,[CreateBy] ";
            SQL += " ,[CreateDate] ";
            SQL += " ,[Item] ";
            SQL += " ,[Ref_ID]) ";
            SQL += " values ('" + WT + "','" + Site_ref + "','" + Serial + "','" + UserAD + "',getdate(),'" + Item + "','" + Ref_ID + "') ";
            return ExecuteReader(SQL);
        }
        public DataTable DeleteSerial(String ID)
        {
            SQL = " delete TB_FactoryOrder_Serial where ID = '" + ID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadHistory(String ProcID)
        {
            SQL = " select * from [dbo].[VW_WF_HistoryActivity] ";
            SQL += " where ProcInstID = '" + ProcID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadHistoryWF(String ProcID)
        {
            SQL = " select [Process Instance ID],Folio,StartDate,Originator from [dbo].[VW_Process_Instance_Search] ";
            SQL += " where [Process Instance ID] = '" + ProcID + "' ";
            SQL += " Group by [Process Instance ID],Folio,StartDate,Originator";
            return ExecuteReader(SQL);
        }
        public DataTable LoadHistoryName(String Name, String ProcID)
        {
            SQL = " select * from [dbo].[VW_WF_History] ";
            SQL += " where ProcInstID = '" + ProcID + "' ";
            SQL += " and Name = '" + Name + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadOldAttachment(String WorkflowType, String WorkflowID)
        {
            SQL = " select ID,'' as FileName,Attachment as FullFileName from TB_WorkflowAttachment ";
            SQL += " where WorkflowType = '" + WorkflowType + "' and WorkflowID = '" + WorkflowID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable UpdateConfirmDate(String Site_Ref, String ID, String Job, String Item)
        {
            SQL = " exec [dbo].[SP_JobOrderConfirmDate_Update] '" + Site_Ref + "','" + ID + "','" + Job + "','" + Item + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable checkK2AdditionalMat(String RefID)
        {
            SQL = " select ProcessInstanceID from TB_AdditionalMaterial_Item where Ref_ID = " + RefID + " and ProcessInstanceID is not null ";
            return ExecuteReader(SQL);
        }
        public DataTable FindReportWFLink(String WFType)
        {
            SQL = " select Report,Ltrim(Report_Type) as Report_Type,WFType from TB_K2TableName where WFType = '" + WFType + "' and Report is not null ";
            return ExecuteReader(SQL);
        }
        public DataTable CheckWFId(String WFType)
        {
            SQL = " select ID ";
            SQL += " from TB_WorkflowType where WorkflowType = '" + WFType + "' and StatusType = 1 ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadStatusName(String ProcessID)
        {
            SQL = " select distinct Activity from [dbo].[VW_Process_Status] where [Process Instance ID] = '" + ProcessID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadUserNameEnquiryFO(String ProcInID)
        {
            SQL = " select RequestResource_ID from TB_FactoryOrder_2 ";
            SQL += " where ProcessInstanceID = '" + ProcInID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadDeliveryGoodsLine(String Ref_ID)
        {
            SQL = " select * from TB_DeliveryGoodsPKM_Lines where Ref_ID = '" + Ref_ID + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable UpdateStep(String ID, String ProcID)
        {
            SQL = " exec [dbo].[SP_UpdateStep_FO] " + ID + ",'" + ProcID + "'";
            return ExecuteReader(SQL);
        }
        public DataTable InsertTableEN(String CreateBy, String FO_num)
        {
            SQL = " exec [dbo].[SP_PD08-Factory_Order_for_receive_drawing] '','','','','','','','" + CreateBy + "','','','','','','','','','','" + FO_num + "' ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadDataEN(String ID)
        {
            SQL = " select fd.*,em.username from TB_FactoryOrder_for_Receive_Drawing fd ";
            SQL += " left outer join VW_Employee_All em on fd.Site_ref = em.Site_ref and ltrim(fd.Resource_ID) = ltrim(em.Emp_num) ";
            SQL += " where ID = '" + ID + "' ";
            return ExecuteReader(SQL);
        }

        public DataTable LoadDataActivity(String VWName)
        {
            SQL = " select distinct (CASE WHEN [Status] = 'Rejected' THEN 'Reject' WHEN [Status] = 'Completed' THEN 'Complete' WHEN [Status] = 'Deleted' THEN 'Delete' ELSE [Status] END) as code,(CASE WHEN [Status] = 'Rejected' THEN 'Reject' WHEN [Status] = 'Completed' THEN 'Complete' WHEN [Status] = 'Deleted' THEN 'Delete' ELSE [Status] END) as name  ";
            SQL += " from " + VWName + " ";
            return ExecuteReader(SQL);
        }

        internal DataTable LoadPR(string StrQuickSearch)
        {
            SQL = " SELECT code, name FROM Vw_PurchaseReqRefJob";
            SQL += " where (code Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%') ";
            return ExecuteReader(SQL);
        }

        public DataTable LoadNCRNumber(string Prefix)
        {
            SQL = " SELECT MAX(NCR_number)+1 as NCR_Number FROM TB_ChangeCost2";
            SQL += " where left(NCR_Number,2)= left('" + Prefix + "',2)";

            return ExecuteReader(SQL);
        }

        public DataTable LoadProjectNOnAG(string StrQuickSearch)
        {

            SQL = " select [ProjectNum] as code,[ProjectDesc] as name,[customerCode] from [dbo].[VW_ProjectNonAging] ";
            SQL += "  where ([ProjectNum] like '%" + StrQuickSearch + "%' or [ProjectDesc] Like '%" + StrQuickSearch + "%')";

            return ExecuteReader(SQL);
        }

        public DataTable LoadProjectExport(string StrQuickSearch)
        {

            SQL = " select [ProjectNum] as code,[ProjectDesc] as name,[customerCode] from [dbo].[VW_ProjectNonAging] ";
            SQL += "  where ([ProjectNum] like '%" + StrQuickSearch + "%' or [ProjectDesc] Like '%" + StrQuickSearch + "%')";

            return ExecuteReader(SQL);
        }


        public DataTable LoadDataCharge(String Running)
        {

            string SQL = "select [ChargeComputer],[ChargeTelephone],[ChargePrint],[ChargeCopyDoc_],[ChargeSpecial],[ChargeServiceRP],[Remark],Ref_ID,Bu from TB_AF_ITCharge_Line where Ref_ID = '" + Running + "'";
            return ExecuteReader(SQL);

            //string SQL = "select [ChargeComputer],[ChargeTelephone],[ChargePrint],[ChargeCopyDoc_],[ChargeSpecial],[Total],Ref_ID,Bu from TB_AF_ITCharge_Line where Ref_ID = '" + Running + "'";
            ////,ChargeComputer,ChargeTelephone,ChargePrint,ChargeCopyDoc_,ChargeSpecial,Total
            ////return ExecuteReader(sqlCmd);
            ////SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            ////cmd.CommandType = CommandType.Text;
            ////// cmd.CommandTimeout = 300;
            ////SqlDataReader rs = cmd.ExecuteReader();

            ////SqlConnection conn = new SqlConnection(con);
            ////conn.Open();
            ////SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            ////DataTable dt = new DataTable();
            ////da.Fill(dt);
            ////conn.Close();
            ////return dt;
            //return ExecuteReader(SQL);
        }

        public void ImportDataCharge(string Running, string FullPath)
        {

            string sqlCmd = "EXEC SP_AF_ImportDataCharge '" + FullPath + "','" + Running + "'";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringK2"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            cmd.ExecuteReader();


            conn.Close();

        }
        //------Update By SB 02/02/2017 Start Version Loq

        public DataTable LoadDataSCCharge(String Running)
        {
            string SQL = "select [MIACharge],[TransportCharge],[PRCharge],[ToolTagCharge],[WarehouseCharge],[Remark],Ref_ID,Bu from TB_AF_SCCharge_Line where Ref_ID = '" + Running + "'";
            return ExecuteReader(SQL);
        }

        public void ImportDataSCCharge(string Running, string FullPath)
        {

            string sqlCmd = "EXEC SP_AF_ImportDataSCCharge '" + FullPath + "','" + Running + "'";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringK2"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            cmd.ExecuteReader();


            conn.Close();

        }

        //---------------Update By SB 07/02/2017 
        public DataTable LoadDataAFCharge(String Running)
        {

            string SQL = "select [AccountPayable],[AccountReceiveble],[Advance],[PettyCash],[ProjectWIP],[Service],[ProjectLoss] ,[InterestExpense],[RemarkAF],Ref_ID,Bu from TB_AF_AFCharge_Line where Ref_ID = '" + Running + "'";
            return ExecuteReader(SQL);

            //string SQL = "select [ChargeComputer],[ChargeTelephone],[ChargePrint],[ChargeCopyDoc_],[ChargeSpecial],[Total],Ref_ID,Bu from TB_AF_ITCharge_Line where Ref_ID = '" + Running + "'";
            ////,ChargeComputer,ChargeTelephone,ChargePrint,ChargeCopyDoc_,ChargeSpecial,Total
            ////return ExecuteReader(sqlCmd);
            ////SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            ////cmd.CommandType = CommandType.Text;
            ////// cmd.CommandTimeout = 300;
            ////SqlDataReader rs = cmd.ExecuteReader();

            ////SqlConnection conn = new SqlConnection(con);
            ////conn.Open();
            ////SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conn);
            ////DataTable dt = new DataTable();
            ////da.Fill(dt);
            ////conn.Close();
            ////return dt;
            //return ExecuteReader(SQL);
        }
        //---------------Update By SB 09/02/2017 
        public void ImportDataAFCharge(string Running, string FullPath)
        {

            string sqlCmd = "EXEC SP_AF_ImportDataAFCharge '" + FullPath + "','" + Running + "'";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringK2"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            cmd.ExecuteReader();


            conn.Close();

        }

        //Start WO Add 13/02/2017----------------------------------------------------------------------------------------------------------------

        public DataTable LoadDataHRCharge(String Running)
        {
            //string SQL = "select [PayRoll],[KeyJob],[Recruitment],[CarFix],[CarVariable],[DomesticInter] ,[DomesticLocal],[Training],[Messenger],[Building1],[Building2],[Remark],Ref_ID,Bu from TB_AF_HRCharge_Line where Ref_ID = '" + Running + "'";
            string SQL = "select [PayRoll],[KeyJob],[Recruitment],[CarFix],[CarVariable],[DomesticInter] ,[DomesticLocal],[Training],[Building1],[Building2],[Commonarea],[Remark],Ref_ID,Bu from TB_AF_HRCharge_Line where Ref_ID = '" + Running + "'";
            return ExecuteReader(SQL);
        }

        public void ImportDataHRCharge(string Running, string FullPath)
        {

            string sqlCmd = "EXEC SP_AF_ImportDataHRCharge '" + FullPath + "','" + Running + "'";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringK2"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            cmd.ExecuteReader();


            conn.Close();

        }

        //End WO Add 13/02/2017----------------------------------------------------------------------------------------------------------------
        //Start WO Add 15/02/2017----------------------------------------------------------------------------------------------------------------
        public DataTable LoadddlMainTypeAll()
        {
            //SQL = " select MainTypeID as code,MainTypeID + ' /' + Description as name from [dbo].[TB_WorkflowMainType] ";
            //SQL += " where MainTypeID is not null and MainTypeID not in ('1000','2000') order by MainTypeID asc ";
            SQL = " select distinct wmt.MainTypeID as code,wmt.MainTypeID + ' /' + wmt.Description as name ";
            SQL += " from [dbo].[TB_WorkflowMainType] wmt";
            //SQL += " inner join [dbo].[TB_WorkflowType] wt on wmt.MainTypeID = wt.MainType";
            //SQL += " where wmt.MainTypeID is not null and wmt.MainTypeID not in ('1000','2000')";
            //SQL += " and wt.Export = 1";
            SQL += " order by wmt.MainTypeID asc ";
            return ExecuteReader(SQL);
        }
        //End WO Add 15/02/2017----------------------------------------------------------------------------------------------------------------
        //Start WO Add 17/02/2017----------------------------------------------------------------------------------------------------------------

        public DataTable LoadDataENCharge(String Running)
        {
            string SQL = "select [Total],[Remark],Ref_ID,Bu from TB_AF_ENCharge_Line where Ref_ID = '" + Running + "'";
            return ExecuteReader(SQL);
        }

        public void ImportDataENCharge(string Running, string FullPath)
        {

            string sqlCmd = "EXEC SP_AF_ImportDataENCharge '" + FullPath + "','" + Running + "'";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringK2"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            cmd.ExecuteReader();


            conn.Close();

        }

        //End WO Add 17/02/2017----------------------------------------------------------------------------------------------------------------
        //Start WO Add 18/02/2017----------------------------------------------------------------------------------------------------------------

        public DataTable LoadDataSHECharge(String Running)
        {
            string SQL = "select [HalfDayCost],[FullTimeCost],[EmpTotal],[ChangePerHead],[CostofSite],[CostofReport],[Remark],Ref_ID,Bu from TB_AF_SHECharge_Line where Ref_ID = '" + Running + "'";
            return ExecuteReader(SQL);
        }
        public void ImportDataSHECharge(string Running, string FullPath)
        {

            string sqlCmd = "EXEC SP_AF_ImportDataSHECharge '" + FullPath + "','" + Running + "'";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringK2"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            cmd.ExecuteReader();


            conn.Close();

        }

        //End WO Add 18/02/2017----
        //Start SB Add 16/03/2017----
        public DataTable LoadDoc(string StrQuickSearch)
        {

            SQL = " select [Document_ID] as code,[Detail] as name from [dbo].[TB_IT_DocumentSupport] ";
            SQL += "  where ([Document_ID] like '%" + StrQuickSearch + "%' or [Detail] Like '%" + StrQuickSearch + "%')";

            return ExecuteReader(SQL);
        }

        //------------------Wisa 23-05-2017-------------------------
        public DataTable LoadCustomerBranch(String StrQuickSearch)
        {
            SQL = " SELECT [Branch] , [Address] , [Contact], [cust_seq],[Phone] FROM [dbo].[VW_custbranch] where [cust_num] = '" + StrQuickSearch + "'  ";
            return ExecuteReader(SQL);
        }
        //--------------- SB 08-06-2017 ---------------------------
        public DataTable PrefixPR(String Prefix)
        {
            SQL = " [dbo].[SP_GeneratePRNumber] '" + Prefix + "' ";
            return ExecuteReader(SQL);
        }

        internal DataTable LoadProj_numOversea(string StrQuickSearch)
        {
            SQL = @" SELECT [Project] as 'code' , [ProjectDes] as 'name' FROM [dbo].[VW_ProjectOpenOversea] WHERE 
                     where  ([Project] Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  ProjectDes Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }
        //------------ SB 17-07-2017 ---------------------------
        public DataTable LoadddlMainTypeNew(String pSite_Ref)
        {
            SQL = " select distinct wmt.MainTypeID as code,wmt.MainTypeID + ' /' + wmt.Description as name ";
            SQL += " from [dbo].[TB_WorkflowMainType] wmt inner join [dbo].[TB_WorkflowType] ft on wmt.MainTypeID = ft.MainType";
            SQL += " where 1 =1 ";
            if (pSite_Ref == PK)
            {
                SQL += " and ft.PK_SiteRef = 1 ";
            }
            else if (pSite_Ref == PKM)
            {
                SQL += " and ft.PKM_Siteref = 1 ";
            }
            else if (pSite_Ref == PKT)
            {
                SQL += " and ft.PKT_SiteRef = 1 ";
            }
            else if (pSite_Ref == SPN)
            {
                SQL += " and ft.PN_SiteRef = 1 ";
            }
            else if (pSite_Ref == PH)
            {
                SQL += " and ft.PH_SiteRef = 1 ";
            }
            else if (pSite_Ref == IND)
            {
                SQL += " and ft.ID_SiteRef = 1 ";
            }
            else if (pSite_Ref == TG)
            {
                SQL += " and ft.TG_SiteRef = 1 ";
            }
            else if (pSite_Ref == HA)
            {
                SQL += " and ft.HA_SiteRef = 1 ";
            }
            else if (pSite_Ref == MY)
            {
                SQL += " and ft.MY_SiteRef = 1 ";
            }

            SQL += " order by wmt.MainTypeID asc ";
            return ExecuteReader(SQL);
        }
        //public DataTable LoadWFNameNew(String MainType, String pSite_Ref)
        // {
        //     SQL = @"select distinct substring(WorkflowType,0,5) as code,WorkflowType + ' / ' + Description as name from [dbo].[TB_WorkflowType] ft ";
        //     SQL += " where MainType = '" + MainType + "' ";

        //     if (pSite_Ref == PK)
        //     {
        //         SQL += " and ft.PK_SiteRef = 1 ";
        //     }
        //     else if (pSite_Ref == PKM)
        //     {
        //         SQL += " and ft.PKM_Siteref = 1 ";
        //     }
        //     else if (pSite_Ref == PKT)
        //     {
        //         SQL += " and ft.PKT_SiteRef = 1 ";
        //     }
        //     else if (pSite_Ref == SPN)
        //     {
        //         SQL += " and ft.PN_SiteRef = 1 ";
        //     }
        //     else if (pSite_Ref == PH)
        //     {
        //         SQL += " and ft.PH_SiteRef = 1 ";
        //     }
        //     SQL += " order by substring(WorkflowType,0,5) asc ";
        //     return ExecuteReader(SQL);
        // }
        //Start SB Add 26/07/2017----------------------------------------------------------------------------------------------------------------
        public DataTable LoadWFNameNew(String MainType, String pSite_Ref)
        {
            SQL = @"select distinct substring(WorkflowType,0,5) as code,substring(WorkflowType,0,5) + ' / ' + Description as name from [dbo].[TB_WorkflowType] ft ";
            SQL += " where MainType = '" + MainType + "' AND StatusType = 1 AND WorkflowType is not null and Description is not null";

            if (pSite_Ref == PK)
            {
                SQL += " and ft.PK_SiteRef = 1 ";
            }
            else if (pSite_Ref == PKM)
            {
                SQL += " and ft.PKM_Siteref = 1 ";
            }
            else if (pSite_Ref == PKT)
            {
                SQL += " and ft.PKT_SiteRef = 1 ";
            }
            else if (pSite_Ref == SPN)
            {
                SQL += " and ft.PN_SiteRef = 1 ";
            }
            else if (pSite_Ref == PH)
            {
                SQL += " and ft.PH_SiteRef = 1 ";
            }
            else if (pSite_Ref == IND)
            {
                SQL += " and ft.ID_SiteRef = 1 ";
            }
            else if (pSite_Ref == TG)
            {
                SQL += " and ft.TG_SiteRef = 1 ";
            }
            else if (pSite_Ref == HA)
            {
                SQL += " and ft.HA_SiteRef = 1 ";
            }
            else if (pSite_Ref == MY)
            {
                SQL += " and ft.MY_SiteRef = 1 ";
            }
            SQL += " Order by substring(WorkflowType,0,5) asc ";
            return ExecuteReader(SQL);

        }
        public DataTable LoadddlMainTypeSite_Ref(String pSite_Ref)
        {
            SQL = @"select distinct substring(WorkflowType,0,5) as code,substring(WorkflowType,0,5) + ' / ' + Description as name from [dbo].[TB_WorkflowType] ft ";
            SQL += " where StatusType = 1 AND WorkflowType is not null and Description is not null";

            if (pSite_Ref == PK)
            {
                SQL += " and ft.PK_SiteRef = 1 ";
            }
            else if (pSite_Ref == PKM)
            {
                SQL += " and ft.PKM_Siteref = 1 ";
            }
            else if (pSite_Ref == PKT)
            {
                SQL += " and ft.PKT_SiteRef = 1 ";
            }
            else if (pSite_Ref == SPN)
            {
                SQL += " and ft.PN_SiteRef = 1 ";
            }
            else if (pSite_Ref == PH)
            {
                SQL += " and ft.PH_SiteRef = 1 ";
            }
            else if (pSite_Ref == IND)
            {
                SQL += " and ft.ID_SiteRef = 1 ";
            }
            else if (pSite_Ref == TG)
            {
                SQL += " and ft.TG_SiteRef = 1 ";
            }
            else if (pSite_Ref == HA)
            {
                SQL += " and ft.HA_SiteRef = 1 ";
            }
            else if (pSite_Ref == MY)
            {
                SQL += " and ft.MY_SiteRef = 1 ";
            }
            //SQL += " order by wmt.MainTypeID asc ";
            return ExecuteReader(SQL);
        }
        public DataTable LoadEmpName(String StrQuickSearch)
        {
            SQL = " select Ltrim(emp_num) as code,name,dept from [dbo].[VW_Employee_All] ";
            SQL += " where name is not null  and (Ltrim(emp_num) Like '%" + StrQuickSearch + "%' or name Like '%" + StrQuickSearch + "%')  ";
            return ExecuteReader(SQL);
        }


        public DataTable LoadTypeOverea(String SiteRef)
        {
            SQL = @"  select * 
                     from  [dbo].[VW_SiteRef]  
                     where SiteRef = '" + SiteRef + "' ";
            return ExecuteReader(SQL);
        }
        //public DataTable ItemSearchOrderBy(string PageIndex, String Site_ref, String ItemCode, String Char, String Desc, String Active, String Obsolete, String Slow_Moving, String SortName, String SortType, String plannerCode, String StockType)
        //{

        //    //SQL = " select * from [VW_ItemSearch]  ";
        //    // SQL += "  where (Site_ref = '" + Site_ref + "' or '" + Site_ref + "' = '') ";
        //    // SQL += "  and  (item Like '%" + ItemCode + "%' or '%" + ItemCode + "%' = '%%')";
        //    // SQL += "  and (Characteristic Like '%" + Char + "%' OR '%" + Char + "%' = '%%')";
        //    // SQL += "  and (Description Like '%" + Desc + "%' or '%" + Desc + "%' = '%%')";
        //    // SQL += "  and (Status in ('"+ Active +"','"+ Obsolete +"','"+ Slow_Moving +"')) ";
        //    SQL = " exec [dbo].[SP_Results_ItemSearch_OrderByPlanner] '" + PageIndex + "','10','4','" + Site_ref + "','" + ItemCode + "' ";
        //    SQL += " ,'" + Char + "','" + Desc + "','" + Active + "','" + Obsolete + "','" + Slow_Moving + "','" + SortName + "','" + SortType + "','" + plannerCode + "','" + StockType + "'";
        //    return ExecuteReader(SQL);
        //}
        public DataTable ItemSearchOrderBy(string PageIndex, String Site_ref, String ItemCode, String Char, String Desc, String Active, String Obsolete, String Slow_Moving, String SortName, String SortType, String plannerCode, String StockType)
        {

            //SQL = " select * from [VW_ItemSearch]  ";
            // SQL += "  where (Site_ref = '" + Site_ref + "' or '" + Site_ref + "' = '') ";
            // SQL += "  and  (item Like '%" + ItemCode + "%' or '%" + ItemCode + "%' = '%%')";
            // SQL += "  and (Characteristic Like '%" + Char + "%' OR '%" + Char + "%' = '%%')";
            // SQL += "  and (Description Like '%" + Desc + "%' or '%" + Desc + "%' = '%%')";
            // SQL += "  and (Status in ('"+ Active +"','"+ Obsolete +"','"+ Slow_Moving +"')) ";

            SQL = " exec [dbo].[SP_Results_ItemSearch_OrderByPlanner] '" + PageIndex + "','10','4','" + Site_ref + "','" + ItemCode + "' ";
            //SQL = " exec [dbo].[SP_Results_ItemSearch_OrderByTest] '" + PageIndex + "','10','4','" + Site_ref + "','" + ItemCode + "' ";
            SQL += " ,'" + Char + "','" + Desc + "','" + Active + "','" + Obsolete + "','" + Slow_Moving + "','" + SortName + "','" + SortType + "','" + plannerCode + "','" + StockType + "'";
            return ExecuteReader(SQL);
        }
        //public DataTable LoadItemWareHouseLoc(String Item, String Site_Ref)
        //{
        //    SQL = " select * from VW_ItemWarehouseLoc ";
        //    SQL += " where item = '" + Item + "' and site_ref = '" + Site_Ref + "' ";
        //    return ExecuteReader(SQL);
        //}
        public DataTable LoadItemWareHouseLoc(String Item, String Site_Ref) //JT 17/04/2019
        {
            SQL = " select * from VW_ItemWarehouseLoc_APS ";
            //SQL = " select * from VW_ItemWarehouseLoc ";
            SQL += " where item = '" + Item + "' and site_ref = '" + Site_Ref + "'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadProj(String StrQuickSearch, String site)
        {
            //SQL = " select * ";
            //SQL += " from [dbo].[VW_WF_Project] ";
            //SQL += " where (projectNum Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '' or ProjectDesc Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '') ";
            SQL = @" SELECT [Project] as 'code' , [ProjectDes] as 'name' FROM [dbo].[VW_ProjectOpenOversea] WHERE [Site_ref]='" + site + "' and ([Project] like '%" + StrQuickSearch + "%' OR [ProjectDes] like '%" + StrQuickSearch + "%')";

            return ExecuteReader(SQL);
        }
        //========================== Wisa.je 26/01/2018 =========================
        public DataTable LoadProject(string StrQuickSearch)
        {

            SQL = " select [Proj_Num] as code,[Proj_Desc] as name from [dbo].[VW_Proj_mst] ";
            SQL += "  where ([Proj_Num] like '%" + StrQuickSearch + "%' or [Proj_Desc] Like '%" + StrQuickSearch + "%')";

            return ExecuteReader(SQL);
        }

        public DataTable LoadCurren(String StrQuickSearch)
        {
            SQL = " select [Code] as code,[Name] as name from [dbo].[VW_Currency] Where (Code Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Name Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }

        //========================= Wisa.je 22/02/2018 =================================
        public DataTable LoadDataHDCharge(String Running)
        {
            //string SQL = "select [PayRoll],[KeyJob],[Recruitment],[CarFix],[CarVariable],[DomesticInter] ,[DomesticLocal],[Training],[Messenger],[Building1],[Building2],[Remark],Ref_ID,Bu from TB_AF_HRCharge_Line where Ref_ID = '" + Running + "'";
            string SQL = "select [Training],[Remark],Ref_ID,Bu from TB_AF_HDCharge_Line where Ref_ID = '" + Running + "'";
            return ExecuteReader(SQL);
        }
        public void ImportDataHDCharge(string Running, string FullPath)
        {

            string sqlCmd = "EXEC SP_AF_ImportDataHDCharge '" + FullPath + "','" + Running + "'";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringK2"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand(sqlCmd, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 300;
            cmd.ExecuteReader();


            conn.Close();

        }
        //CP Add 07/03/2018
        public DataTable ItemSearchExpot(string PageIndex, String Site_ref, String ItemCode, String Char, String Desc, String Active, String Obsolete, String Slow_Moving, String SortName, String SortType, String plannerCode, String StockType)
        {

            //SQL = " select * from [VW_ItemSearch]  ";
            // SQL += "  where (Site_ref = '" + Site_ref + "' or '" + Site_ref + "' = '') ";
            // SQL += "  and  (item Like '%" + ItemCode + "%' or '%" + ItemCode + "%' = '%%')";
            // SQL += "  and (Characteristic Like '%" + Char + "%' OR '%" + Char + "%' = '%%')";
            // SQL += "  and (Description Like '%" + Desc + "%' or '%" + Desc + "%' = '%%')";
            // SQL += "  and (Status in ('"+ Active +"','"+ Obsolete +"','"+ Slow_Moving +"')) ";

            SQL = " exec [dbo].[SP_Results_ItemSearch_OrderByPlannerExport] '" + PageIndex + "','10','4','" + Site_ref + "','" + ItemCode + "' ";
            //SQL = " exec [dbo].[SP_Results_ItemSearch_OrderByTest] '" + PageIndex + "','10','4','" + Site_ref + "','" + ItemCode + "' ";
            SQL += " ,'" + Char + "','" + Desc + "','" + Active + "','" + Obsolete + "','" + Slow_Moving + "','" + SortName + "','" + SortType + "','" + plannerCode + "','" + StockType + "'";
            return ExecuteReader(SQL);
        }
        // WS 10-12-2018 // SG02
        public DataTable LoadCatagoryofContent(String StrQuickSearch)
        {
            SQL = "SELECT Name as code, Detail as Name FROM [dbo].[TB_SG_SocialMediaContent_Catagory] Where (Name Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Detail Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }

        // WS 10-12-2018 // SG02
        public DataTable LoadMedia(String StrQuickSearch)
        {
            SQL = "SELECT Name as code, Detail as Name FROM [dbo].[TB_SG_SocialMediaContent_Media] Where (Name Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%' or  Detail Like '%" + StrQuickSearch + "%' or '%" + StrQuickSearch + "%' = '%%')";
            return ExecuteReader(SQL);
        }


        public DataTable checkItemCodeInfo(string ItemCode)//JT08/03/2019
        {

            SQL = "SELECT [ID],[ProcessInstanceID],[Site_Ref] FROM [dbo].[TB_CreateNewItemCode] WHERE [ItemCodeFinal] =  '" + ItemCode + "'";
            return ExecuteReader(SQL);
        }


        public DataTable K2BrowseItemLasrPurchase(string ItemCode, string Site_Ref)
        {

            SQL = "SELECT TOP 1 ISNULL([cost],0) as  [cost] FROM [dbo].[matltran_mst] WHERE [item] =  '" + ItemCode + "' And [trans_type] in ('R' , 'M') And [ref_type] = 'P' And [site_ref] = '" + Site_Ref + "' Order By [trans_num] Desc ";         
            return ExecuteReader(SQL);
        }


        public DataTable LoadPosition(String Site_ref, String Dept, string Level)
        {

            SQL = "SELECT job_id,class,Uf_hrlevel,Uf_Jobtitle,Uf_Jobtitle from position_mst";
            SQL += " where  stat = 'A' and class = '" + Dept + "' and Uf_hrlevel = '" + Level + "'";
            return ExecuteReader(SQL);
        }



      



    }



}
