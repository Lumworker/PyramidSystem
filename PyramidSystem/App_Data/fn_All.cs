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
using System.IO;

using System.Globalization;
using MobileTask.AppCode;

namespace Workflow_Application
{
    class fn_All
    {
        String a;
        ClassDBConnK2 DBConnK2 = new ClassDBConnK2();
        ClassDBConnSL DBConnSL = new ClassDBConnSL();
        ClassBrowseNew cbrown = new ClassBrowseNew();
        DataTable DTLogonNew = new DataTable();
        DataTable DTDDL = new DataTable();
        DataTable DTTemp = new DataTable();

        public string UserDomain; //JT 09/10/2018   
       
        //public void LoadCombo(AjaxControlToolkit.ComboBox cb, DataTable dt)
        //{
        //    cb.DataSource = dt; 
        //    cb.DataValueField = "code";
        //    cb.DataTextField = "name";
        //    cb.DataBind();
        //    cb.Items.Insert(0, new ListItem("", ""));
        //}
        public string getLogonName()
        {
            string Str = "";
            DTLogonNew = LoadEmployeeAll();
            if (DTLogonNew.Rows.Count > 0)
            {
                Str = DTLogonNew.Rows[0]["name"].ToString();
            }
            return Str;
        }

        public string getLogonEmp_Level()
        {
            string Str = "";
            DTLogonNew = LoadEmployeeAll();
            if (DTLogonNew.Rows.Count > 0)
            {
                Str = DTLogonNew.Rows[0]["uf_Level"].ToString().Trim();
            }
            return Str;
        }
        public string getLogonUser()
        {
            string Str = "";
            DTLogonNew = LoadEmployeeAll();
            if (DTLogonNew.Rows.Count > 0)
            {
                Str = DTLogonNew.Rows[0]["username"].ToString();
            }
            return Str;
        }
        public string getLogonSite_Ref()
        {
            string Str = "";
            DTLogonNew = LoadEmployeeAll();
            if (DTLogonNew.Rows.Count > 0)
            {
                Str = DTLogonNew.Rows[0]["site_ref"].ToString();
            }
            return Str;
        }
        public string getLogonCost_Center()
        {
            string Str = "";
            DTLogonNew = LoadEmployeeAll();
            if (DTLogonNew.Rows.Count > 0)
            {
                Str = DTLogonNew.Rows[0]["dept"].ToString();
            }
            return Str;
        }
        public string getLogonDepart()
        {
            string Str = "";
            DTLogonNew = LoadEmployeeAll();
            if (DTLogonNew.Rows.Count > 0)
            {
                Str = DTLogonNew.Rows[0]["dept"].ToString().Substring(0, 3);
            }
            return Str;
        }
        public string getLogonEmp_Num()
        {
            string Str = "";
            DTLogonNew = LoadEmployeeAll();
            if (DTLogonNew.Rows.Count > 0)
            {
                Str = DTLogonNew.Rows[0]["Emp_Num"].ToString().Trim();
            }
            return Str;
        }
        public DataTable LoadEmployeeAll()
        {
         a = HttpContext.Current.Request.LogonUserIdentity.Name;

            //a = "KANDA.CH";
           
           // a = "kitchawan.sa";// Sale
            //a = "Chutikarn.sr";// Admin
           // a = "bunjob";//Admin Header
        


            DataTable DT = new DataTable();
            DT = DBConnK2.LoadEmployeeLogon(a);
            //DT = DBConnSL.LoadEmployeeLogon(a);
            return DT;
        }
        public string fn_FormatDecimal(String Str)
        {
            Decimal Value = 0;
            if (Str != "")
            {
                Value = Convert.ToDecimal(Str);
                Str = string.Format("{0:n}", Value);
            }
            return Str;
        }
       
       

        public string fn_ConvertDate(String StrDate)
        {
            DateTime DValue;
            if (StrDate != "")
            {
                DValue = Convert.ToDateTime(StrDate);
                StrDate = Convert.ToString(DValue.ToString("dd/MM/yyyy"));
            }
            return StrDate;
        }
        public string fn_ConvertDateDAR(String StrDate)
        {
            DateTime DValue;
            if (StrDate != "")
            {
                DValue = Convert.ToDateTime(StrDate);
                StrDate = Convert.ToString(DValue.ToString("dd-MM-yyyy"));
            }
            return StrDate;
        }
        public void LoadSite_Ref(DropDownList DDL)
        {
            DTDDL = DBConnSL.DTSite_Ref();
            LoadDDL(DDL, DTDDL);
        }
        public void LoadDDL(DropDownList DDL, DataTable DT)
        {
            DDL.DataSource = DT;
            DDL.DataTextField = "name";
            DDL.DataValueField = "code";
            DDL.DataBind();

        }
        public void LoadDDL1(DropDownList DDL, DataTable DT)
        {
            DDL.DataSource = DT;
            DDL.DataTextField = "name";
            DDL.DataValueField = "code";
            DDL.DataBind();
            DDL.Items.Insert(0, new ListItem("==SELECT==", ""));
        }
        public void LoadDDL2(DropDownList DDL, DataTable DT)
        {
            DDL.DataSource = DT;
            DDL.DataTextField = "name";
            DDL.DataValueField = "code";
            DDL.DataBind();
            DDL.Items.Insert(0, new ListItem("ALL", ""));
        }
        public void LoadDDL_Null(DropDownList DDL, DataTable DT)
        {
            DDL.Items.Insert(0, new ListItem("==SELECT==", ""));
        }
        public void LoadDDLCode_Name(DropDownList DDL, DataTable DT)
        {
            DDL.DataSource = DT;
            DDL.DataTextField = "name";
            DDL.DataValueField = "code";
            DDL.DataBind();
            DDL.Items.Insert(0, new ListItem("==SELECT==", ""));
        }
        public void LoadDDLAll(DropDownList DDL, DataTable DT)
        {
            DDL.DataSource = DT;
            DDL.DataTextField = "name";
            DDL.DataValueField = "code";
            DDL.DataBind();
            DDL.Items.Insert(0, new ListItem("==ALL==", ""));
        }
        public String Cal(String Value1, String Value2)
        {
            String StrValue = "0";
            decimal Value = 0;
            decimal V1 = 0;
            decimal V2 = 0;
            if (Value1 == "")
            {
                Value1 = "0";
            }
            V1 = Convert.ToDecimal(Value1);
            if (Value2 == "")
            {
                Value2 = "0";
            }
            V2 = Convert.ToDecimal(Value2);
            Value = V1 + V2;
            StrValue = fn_FormatDecimal(Convert.ToString(Value));
            return Convert.ToString(StrValue);
        }
        public String Cal2(String Value1, String Value2)
        {
            String StrValue = "0";
            decimal Value = 0;
            decimal V1 = 0;
            decimal V2 = 0;
            if (Value1 == "")
            {
                Value1 = "0";
            }
            V1 = Convert.ToDecimal(Value1);
            if (Value2 == "")
            {
                Value2 = "0";
            }
            V2 = Convert.ToDecimal(Value2);
            if (V1 != 0 && V2 != 0)
            {
                Value = V1 / V2;
            }
            else
            {
                Value = 0;
            }
            StrValue = fn_FormatDecimal(Convert.ToString(Value));
            return Convert.ToString(StrValue);
        }
        public String CalFore(String Er,String Value1, String Value2)
        {
            String StrValue = "0";
            decimal Value = 0;
            decimal V1 = 0;
            decimal V2 = 0;
            decimal Exc = 0;
            if (Er == "")
            {
                Er = "0";
            }
            Exc = Convert.ToDecimal(Er);
            if (Value1 == "")
            { 
                Value1 = "0";
            }
            V1 = Convert.ToDecimal(Value1);
            if (Value2 == "")
            {
                Value2 = "0";
            }
            V2 = Convert.ToDecimal(Value2);
            Value = (V1 + V2) * Exc;
            StrValue = fn_FormatDecimal(Convert.ToString(Value));
            return Convert.ToString(StrValue);
        }
        public String CalFore3(String Value1, String Value2, String Er)
        {
            String StrValue = "0";
            decimal Value = 0;
            decimal V1 = 0;
            decimal V2 = 0;
            decimal Exc = 0;
            if (Er == "")
            {
                Er = "0";
            }
            Exc = Convert.ToDecimal(Er);
            if (Value1 == "")
            {
                Value1 = "0";
            }
            V1 = Convert.ToDecimal(Value1);
            if (Value2 == "")
            {
                Value2 = "0";
            }
            V2 = Convert.ToDecimal(Value2);
            Value = (V1 + V2) - Exc;
            StrValue = fn_FormatDecimal(Convert.ToString(Value));
            return Convert.ToString(StrValue);
        }
        public String CalFore2(String Er, String Value1)
        {
            String StrValue = "0";
            decimal Value = 0;
            decimal V1 = 0;
            decimal Exc = 0;
            if (Er == "")
            {
                Er = "0";
            }
            Exc = Convert.ToDecimal(Er);
            if (Value1 == "")
            {
                Value1 = "0";
            }
            V1 = Convert.ToDecimal(Value1);
            Value = V1 * Exc;
            StrValue = fn_FormatDecimal(Convert.ToString(Value));
            return Convert.ToString(StrValue);
        }
        

      
        public String DefaulValue(String Str)
        {
            String Value = "0";
            if (Str == "")
            {
                Str = "0";
            }
            Value = fn_FormatDecimal(Str);
            return Value;
        }
        public String LoadWFType_Desc(String Str)
        {
            DTTemp = DBConnK2.LoadWF_Desription(Str);
            if (DTTemp.Rows.Count > 0)
            {
                Str = DTTemp.Rows[0]["Description"].ToString().Trim();
            }
            else
            {
                Str = "";
            }

            return Str;
        }
        public DataTable LoadDataToTable(DataTable DT,String Site_Ref)
        {
            DataTable dtTemp = new DataTable();
            DataRow dr;
            dtTemp = new DataTable();
            dtTemp.Clear();
            dtTemp.Columns.Add("Code");
            dtTemp.Columns.Add("Name");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                dr = dtTemp.NewRow();
                dr["Code"] = DT.Rows[i]["code"].ToString();
                dr["Name"] = DT.Rows[i]["name"].ToString();
                dtTemp.Rows.Add(dr);
            }

            return dtTemp;
        }
        public String LoadCost_Center(String Str)
        {
            DataTable DT = new DataTable();
            DT = DBConnSL.LoadEmp(Str);
            if (DT.Rows.Count > 0)
            {
                Str = DT.Rows[0]["dept"].ToString();
            }
            else { Str = ""; }
            
            return Str;
        }
        public String LoadCWF(String UserAD)
        {
            String CountWF = "0";
            DTTemp = DBConnK2.CountWF("1",UserAD);
            if (DTTemp.Rows.Count > 0)
            {
                CountWF = DTTemp.Rows[0]["CWF"].ToString();
            }
            return CountWF;
        }
        public String GetTableName(string TableName, string ID, string ColumnName)
        {
            String Str = "";
            DataTable DT = new DataTable();
            DT = DBConnK2.LoadDataTable(TableName, ID);
            if (DT.Rows.Count > 0)
            {
                Str = DT.Rows[0][ColumnName].ToString();
            }
            return Str;
        } 
        public String GetDataFormTalbe(string WorkflowType, string ID, string ColumnName)
        {
            String StrTBName = "";
            String Str = "";
            DataTable DT = new DataTable();
            DT = DBConnK2.LoadTableName(WorkflowType);
            if (DT.Rows.Count > 0)
            {
                StrTBName = DT.Rows[0]["TB_Name"].ToString();
                Str = GetTableName(StrTBName, ID, ColumnName);
            }
            return Str;
        }
        public void CreateFolder(DirectoryInfo DirInfo)
        {
            try
            {
                if (DirInfo.Exists != null)
                {
                    DirInfo.Create();
                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteFolder(DirectoryInfo DirInfo)
        {
            try
            {
                if (DirInfo.Exists != null)
                {
                    DirInfo.Delete();

                }
            }
            catch (Exception ex)
            {

            }
        }
        public Boolean RenameFolder(String FullPathFolderName, String NewFolderName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(FullPathFolderName);
            try
            {
                if (dirInfo.Exists != null)
                {
                    Directory.Move(FullPathFolderName, NewFolderName);
                    //dirInfo.RenameFolder(FullPathFolderName, NewFolderName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean DeleteFile(String FullPathFileName)
        {
            FileInfo FileIn = new FileInfo(FullPathFileName);
            try
            {
                if (FileIn.Exists)
                {
                    FileIn.Delete();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
        public String FoundNameforCodeLoadTask(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadTask(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }
          
            return Name;
        }
        public String FoundNameforCodeLoadTask2(String Proj_num,String Code, String DBName)
        {
            string Name = ""; 
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadTaskDesc(Proj_num, Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
     public String FoundNameforCodeLoadCust(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadCustAging(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }
          
            return Name;
        
        }
     public String FoundNameforCodeLoadCusttotolamount(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadCustAging(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["TotalActualCost"].ToString();
             }
         }

         return Name;

     }
     public String FoundNameforCodeLoadCustDesc(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadCustAging(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["DescriptionRating"].ToString();
             }
         }

         return Name;
     }
        public String FoundNameforCodeLoadEnquiry(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DTData = DBConnK2.LoadEnquiry(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        public String FoundNameforCodeLoadBranch(String Code,String Str, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadBranch(Code, Str);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }
         
            return Name;
        }
        public String FoundNameforCodeLoadEstProj_num(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadEstProj_num(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }
        
            return Name;
        }
        public String FoundNameforCodeLoadEstProj_numAmount(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadDataProj(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["TotalActualCost"].ToString();
                }
            }

            return Name;
        }
        public String FoundNameforCodeLoadEmp(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadEmp(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }
         
            return Name;
        }
        //public String FoundNameforCodeSite_ref(String Code, String DBName)
        //{
        //    string Name = "";
        //    if (Code != "")
        //    {
        //        DataTable DTData = new DataTable();
        //        DBConnSL.StrDB = DBName;
        //        DTData = DBConnSL.DTSite_Ref(Code);
        //        if (DTData.Rows.Count > 0)
        //        {
        //            Name = DTData.Rows[0]["name"].ToString();
        //        }
        //    }

        //    return Name;
        //}
        public String FoundNameforCodeLoadinco_delterm(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.Loadinco_delterm(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }
            return Name;
        }
        public String FoundNameforCodeLoadJobOrder(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.CheckJobName(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        public int LoadWFID(String WFType)
        {
            int WFID = 0;
            DataTable DTCheckWFId = new DataTable();
            DTCheckWFId = DBConnK2.CheckWFId(WFType);
            if (DTCheckWFId.Rows.Count > 0) 
            {
                WFID = Convert.ToInt32(DTCheckWFId.Rows[0]["ID"].ToString());
            }
            return WFID;
        }
        
            //    Public Function RenameFile(ByVal FullPathFileName As String, ByVal NewFileName As String) As Boolean
    //    Try

    //        Dim fFile As New FileInfo(FullPathFileName)
    //        If fFile.Exists Then
    //            FileIO.FileSystem.RenameFile(FullPathFileName, NewFileName)
    //            Return True
    //        Else
    //            Return False
    //        End If
    //    Catch ex As Exception
    //        Return False
    //    End Try

    //End Function

        internal string FoundNameforCodeLoadProj_num(string Code, string DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadProj_num(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        internal string FoundNameforCodeLoadBranch(string Code, string DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadBranch2(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;

        }
        public String FoundNameforCodeLoadProvince(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnK2.LoadProvince(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        internal string FoundNameforCodeLoadCurrency(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadCurrency(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        internal string FoundNameforCodeLoadCountry(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnK2.LoadCountry(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        internal string FoundNameforCodeLoadSubSector(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadSubSector(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        internal string FoundNameforCodeLoadSector(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadEmp(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        internal string FoundNameforCodeLoadVendor(string Code, string DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadVendor2(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;

        }

        internal string Cal3(string Value1, string Value2)
        {
            String StrValue = "0";
            decimal Value = 0;
            decimal V1 = 0;
            decimal V2 = 0;
            if (Value1 == "")
            {
                Value1 = "0";
            }
            V1 = Convert.ToDecimal(Value1);
            if (Value2 == "")
            {
                Value2 = "0";
            }
            V2 = Convert.ToDecimal(Value2);

            Value = V1 - V2;


            StrValue = fn_FormatDecimal(Convert.ToString(Value));
            return Convert.ToString(StrValue);
        }
        public String FoundNameforCodeLoadProj(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadProj(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }


        internal string FoundNameforCodeLoadProjectNOnAG(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnK2.LoadProjectNOnAG(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }

        internal string FoundNameforCodeLoadProjectExport(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnK2.LoadProjectExport(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }
        //------Update By SB 02/02/2017 Start Version Loq
        //------Update By SB 16/03/2017 Start Version Loq
        public String FoundNameforCodeLoadDoc(String Code, String DBName)
        {
            string Name = "";

            DataTable DTData = new DataTable();
            DBConnSL.StrDB = DBName;
            DTData = DBConnK2.LoadDoc(Code);
            if (DTData.Rows.Count > 0)
            {
                Name = DTData.Rows[0]["name"].ToString();
            }


            return Name;
        }


      
            public string fn_ConvertDateTime(String StrDate)
        {
            DateTime DValue;
            if (StrDate != "")
            {
                DValue = Convert.ToDateTime(StrDate);
                StrDate = Convert.ToString(DValue.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            return StrDate;
        }
            public string getLogonUsername()
            {
                string Str = "";
                DTLogonNew = LoadEmployeeAll();
                if (DTLogonNew.Rows.Count > 0)
                {
                    Str = DTLogonNew.Rows[0]["username"].ToString().Trim();
                }
                return Str;
            }

            internal string FoundNameforCodeLoadProj_numOversea(string Code, string DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnK2.LoadProj_numOversea(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }
            public String FoundNameforCodeLoadEmpName(String Code, String DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnK2.LoadEmpName(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }
            public string getStatusSiteOversea(String SiteRef)
            {
                string OverseaType = "";
                DTTemp = DBConnK2.LoadTypeOverea(SiteRef);
                if (DTTemp.Rows.Count > 0)
                {
                    OverseaType = DTTemp.Rows[0]["OverseaType"].ToString().Trim();
                }

                return OverseaType;
            }



            public string getLocationSiteOversea(String SiteRef)
            {
                string OverseaLocation = "";
                DTTemp = DBConnK2.LoadTypeOverea(SiteRef);
                if (DTTemp.Rows.Count > 0)
                {
                    OverseaLocation = DTTemp.Rows[0]["Location"].ToString().Trim();
                }

                return OverseaLocation;
            }
            internal string FoundNameforCodeProjAndSRO(string Code, string DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadDescProj_Sro(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }
            public String FoundNameforCodeLoadItemDesc(String Code, String DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadItemDesc(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }

            //============================= Wisa.je 26/01/2018 =============================================
            public String FoundNameforCodeLoadProject(String Code, String DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnK2.LoadProject(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }

            public String FoundNameforCodeLoadCurren(String Code, String DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnK2.LoadCurren(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }
            public String FoundNameforMile(String Code, String DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadMile(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }
            public String FoundNameforInv(String Code, String DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadInv(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }

           

            public String FoundCustNumforExportShip(String Code, String DBName)
            {
                string cust_num = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadProjExportShip(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        cust_num = DTData.Rows[0]["cust_num"].ToString();
                    }
                }

                return cust_num;
            }
            public String FoundEstShipDateforExportShip(String Code, String DBName)
            {
                string EstShipDate = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadProjExportShip(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        EstShipDate = DTData.Rows[0]["EstShipDate"].ToString();
                    }
                }

                return EstShipDate;
            }

            public String FoundInvoiceforExportShip(String Code, String DBName)
            {
                string inv_num = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadProjExportShip(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        inv_num = DTData.Rows[0]["inv_num"].ToString();
                    }
                }

                return inv_num;
            }


            public String  FoundEstProjectServiceTGCustName(String Code, String DBName)
            {
                string description = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadProjectEstProjectService(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        description = DTData.Rows[0]["description"].ToString();
                        
                    }
                }

                return description;
              
            }
            public String FoundEstProjectServiceTG(String Code, String DBName)
            {
                string name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadProjectEstProjectServicePRO(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return name;

            }
            public string FoundNameforSector(String Code, String DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadSector(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;
            }
            internal string FoundNameforCreditTerm(string Code, string DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.LoadTerm(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;

            }

            // WS 20-04-2018 //
            internal string FoundNameforCostCenter(string Code, string DBName)
            {
                string Name = "";
                if (Code != "")
                {
                    DataTable DTData = new DataTable();
                    DBConnSL.StrDB = DBName;
                    DTData = DBConnSL.Costcenter(Code);
                    if (DTData.Rows.Count > 0)
                    {
                        Name = DTData.Rows[0]["name"].ToString();
                    }
                }

                return Name;

            }
        // WS 21-04-2018 LG04
        internal string FoundNameforCodeLoadProjectExport2(String Code, String DBName)
        {
            string Name = "";
            if (Code != "")
            {
                DataTable DTData = new DataTable();
                DBConnSL.StrDB = DBName;
                DTData = DBConnSL.LoadProjExport(Code);
                if (DTData.Rows.Count > 0)
                {
                    Name = DTData.Rows[0]["name"].ToString();
                }
            }

            return Name;
        }

     //WS 21-04-2018 LG04
     public String FoundNameforCodeLoadCustDesc2(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadCust(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["DescriptionRating"].ToString();
             }
         }

         return Name;
     }
     internal string FoundNameforCodeLoadProjectManager(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadProjManager(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["proj_mgr"].ToString();
             }
         }

         return Name;
     }
     internal string FoundNameforCodeLoadProjectManagerName(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadProjManagerName(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["proj_mgr_name"].ToString();
             }
         }

         return Name;
     }
     internal string FoundNameforCodeLoadProjectEngineer(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadProjEngineer(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["ProjEngineer"].ToString();
             }
         }

         return Name;
     }
     internal string FoundNameforCodeLoadProjectEngineerName(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadProjEngineerName(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["ProjEngineerName"].ToString();
             }
         }

         return Name;
     }
     internal string FoundNameforCodeLoadSalesEngineer(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadSalesEngineer(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["SaleEngineer"].ToString();
             }
         }

         return Name;
     }
     internal string FoundNameforCodeLoadSalesEngineerName(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadSalesEnigneerName(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["SaleEngineerName"].ToString();
             }
         }

         return Name;
     }
        // WS 07-05-2018 PJ16
     internal string FoundNameforCodeLoadSalesEngineerOverseas(String Code, String DBName)
     {
         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadSalesEnigneerOverseas(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["name"].ToString();
             }
         }

         return Name;
     }



 internal string FoundNameforCodeLoadProductCodeOverseas(String Code, String DBName)
     {

         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadProductCodeOverseas(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["name"].ToString();
             }
         }

         return Name;
     }




 internal string FoundNameforCodeLoadIncotermOverseas(String Code, String DBName)
     {

         string Name = "";
         if (Code != "")
         {
             DataTable DTData = new DataTable();
             DBConnSL.StrDB = DBName;
             DTData = DBConnSL.LoadIncotermOverseas(Code);
             if (DTData.Rows.Count > 0)
             {
                 Name = DTData.Rows[0]["name"].ToString();
             }
         }

         return Name;
     }





 //WS 09-05-2018 AF01
 internal string FoundNameforCodeLoadSectorOversea(String Code, String DBName)
 {
     string Name = "";
     if (Code != "")
     {
         DataTable DTData = new DataTable();
         DBConnSL.StrDB = DBName;
         DTData = DBConnSL.LoadSector(Code);
         if (DTData.Rows.Count > 0)
         {
             Name = DTData.Rows[0]["name"].ToString();
         }
     }

     return Name;
 }
 internal string FoundNameforCodeLoadCurrencyV1(String Code, String DBName)
 {
     string Name = "";
     if (Code != "")
     {
         DataTable DTData = new DataTable();
         DBConnSL.StrDB = DBName;
         DTData = DBConnSL.LoadCurrency(Code);
         if (DTData.Rows.Count > 0)
         {
             Name = DTData.Rows[0]["name"].ToString();
         }
     }

     return Name;
 }
 // WS 18-05-2018 //
 public String FoundNameforCostCenterOverseas(string Code, string DBName)
 {
     string Name = "";
     if (Code != "")
     {
         DataTable DTData = new DataTable();
         DBConnSL.StrDB = DBName;
         DTData = DBConnSL.BoundCostCenterOversea(Code);
         if (DTData.Rows.Count > 0)
         {
             Name = DTData.Rows[0]["name"].ToString();
         }
     }

     return Name;

 }
 public String FoundNameforK2BoundSRO(string Code, string DBName)
 {
     string Name = "";
     if (Code != "")
     {
         DataTable DTData = new DataTable();
         DBConnSL.StrDB = DBName;
         DTData = DBConnSL.K2BoundSRO(Code);
         if (DTData.Rows.Count > 0)
         {
             Name = DTData.Rows[0]["name"].ToString();
         }
     }

     return Name;
 }


 //WS 2018/06/20 AF18
 public String FoundNameforCodeLoadCust1(String Code, String DBName)
 {
     string Name = "";
     if (Code != "")
     {
         DataTable DTData = new DataTable();
         DBConnSL.StrDB = DBName;
         DTData = DBConnSL.LoadCust(Code);
         if (DTData.Rows.Count > 0)
         {
             Name = DTData.Rows[0]["name"].ToString();
         }
     }

     return Name;

 }
 public string FoundNameforExportinvoice(string Code, string DBName)
 {
     string Name = "";
     if (Code != "")
     {
         DataTable DTData = new DataTable();
         DBConnSL.StrDB = DBName;
         DTData = DBConnSL.LoadExportinvoice(Code);
         if (DTData.Rows.Count > 0)
         {
             Name = DTData.Rows[0]["name"].ToString();
         }
     }

     return Name;
 }

 public String GetUser() // JT 09/10/2018
 {
     UserDomain = HttpContext.Current.Request.LogonUserIdentity.Name;
     //UserDomain = "a";
     UserDomain = UserDomain.Replace("PATKOL\\", "");
     return UserDomain;
 }


 public String ReplaceSpecialText(String text)  //JT 16/10/2018
 {
     //String value = "";
     text = text.Replace(">", "&lt;");
     text = text.Replace("<", "&gt;");
     text = text.Replace("&", "&amp;");
     text = text.Replace("\"", "&quot;");
     text = text.Replace("'", "&apos;");
     return text;

 }
 // WS 10-12-2018 // SG02
 internal string FoundNameforCatagoryofContent(string Code, string DBName)
 {
     string Name = "";
     if (Code != "")
     {
         DataTable DTData = new DataTable();
         DBConnSL.StrDB = DBName;
         DTData = DBConnK2.LoadCatagoryofContent(Code);
         if (DTData.Rows.Count > 0)
         {
             Name = DTData.Rows[0]["name"].ToString();
         }
     }

     return Name;

 }
 // WS 10-12-2018 // SG02
 internal string FoundNameforMedia(string Code, string DBName)
 {
     string Name = "";
     if (Code != "")
     {
         DataTable DTData = new DataTable();
         DBConnSL.StrDB = DBName;
         DTData = DBConnK2.LoadMedia(Code);
         if (DTData.Rows.Count > 0)
         {
             Name = DTData.Rows[0]["name"].ToString();
         }
     }

     return Name;

 }
    }
}
