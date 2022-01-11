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

namespace PyramidSystem.ModelData
{
    public class ClassHRPortal
    {
        SqlConnection Con = new SqlConnection();
        SqlConnection ConHRPortal = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSLHRPortal"].ToString());
        SqlCommand Com = new SqlCommand();

        public DataTable ExecuteReader(string SQL)//JT 06/03/2019
        {
            DataTable DT = new DataTable();
            Con = ConHRPortal;
            try
            {
                Con.Open();
                Com.Connection = Con;
                Com.CommandType = CommandType.Text;
                Com.CommandText = SQL;
                Com.CommandTimeout = 0;
                DT.Load(Com.ExecuteReader());

            }

            catch (SqlException ex)
            {
                Con.Close();
                Com.Dispose();
                return DT;
            }
            Con.Close();
            Com.Dispose();
            return DT;

        }

        public DataTable InsertPyramid_Header(string PyramidID, string Company, string GroupPyramid, string Dept, string Revision, string EffectDate, string Action, string Createby, string Status)
        {
            string SQL = "exec  [dbo].[SP_Pyramid_Header] '" + PyramidID + "','" + Company + "', '" + GroupPyramid + "' , '" + Dept + "' , '" + Revision + "' , '" + EffectDate + "', '" + Action + "', '" + Createby + "' , '" + Status + "'";
            return ExecuteReader(SQL);
        }

        public DataTable SeacrhPyramid(string Company, string GroupPyramid, string Dept, string Revision, string EffectDate, string Status)
        {

            string SQL = " select * from [dbo].[VW_Pyramid_HeaderSearch] ";
            SQL += " where (Company like '%" + Company + "%' or '%" + Company + "%' = '%%')";
            SQL += " and (Revision  like '%" + Revision + "%' or '%" + Revision + "%' = '%%')";
            SQL += " and (Dept  like '%" + Dept + "%' or '%" + Dept + "%' = '%%')";
            SQL += " and (EffectDate  like '%" + EffectDate + "%' or '%" + EffectDate + "%' = '%%')";
            SQL += " and (GroupPyramid  like '%" + GroupPyramid + "%' or '%" + GroupPyramid + "%' = '%%')";

            if (Status != "") {
            SQL += " and (Stat = '" + Status + "')";
            }
          
            //SQL += " and (Stat  like '%" + Status + "%' or '%" + Status + "%' = '%%')";
            SQL += "Order by GroupName , DeptName";

            return ExecuteReader(SQL);
        }

        //27/06/2019
        public DataTable insert_PyramidLine(string Pyramid_ID, string RoleID, string RefRoleID, string Role, string RoleCode, string EmpNum, string EmpName, string Dept,
        string Level_Emp, string Position, string Acting,string ActingMain, string ActingType, string SpecialGroup, string Remark, string CreateBy, string Action, string Status, string Position_Code)
        {
            string DataRole = SetRole(Role);

            string SQL = "exec  [dbo].[SP_Pyramid_Line] '" + Pyramid_ID + "','" + RoleID + "', '" + RefRoleID + "' , '" + DataRole + "' ,'" + RoleCode + "' , '" + EmpNum + "' ,'" + EmpName + "', '" + Dept + "', '" + Level_Emp + "', '" + Position + "', '" + Acting + "'";
            SQL += ",'" + ActingMain + "', '" + ActingType + "', '" + SpecialGroup + "' , '" + Remark + "', '" + CreateBy + "', '" + Action + "', '" + Role + "', '" + Status + "', '" + Position_Code + "'";
            return ExecuteReader(SQL);
        }

        public DataTable insert_Pyramid_DotLineCommand(string ID, string Pyramid_ID, string RoleID, string RefRoleID, string Role, string EmpNum,
        string EmpName, string Dept, string Level_Emp, string Position, string SpecialGroup, string Remark, string Action, string CreateBy, string Position_Code_Command)
        {
            string SQL = "exec  [dbo].[SP_Pyramid_DotLineCommand] '" + ID + "','" + Pyramid_ID + "','" + RoleID + "', '" + RefRoleID + "' , '" + Role + "'";
            SQL += ", '" + EmpNum + "' ,'" + EmpName + "', '" + Dept + "', '" + Level_Emp + "', '" + Position + "'";
            SQL += ",'" + SpecialGroup + "', '" + Remark + "', '" + CreateBy + "' , '" + Action + "' , '" + Position_Code_Command + "'  ";
            return ExecuteReader(SQL);
        }



        public string SetRole(string Role)
        {
            if (Role == "M13-M12")
            {
                Role = "M12-M13";
            }
            else if (Role == "S11-S9")
            {
                Role = "S9-S11";
            }
            else if (Role == "G8-G5")
            {
                Role = "G5-G8";
            }
            else if (Role == "O3-O2")
            {
                Role = "O2-O3";
            }
            else if (Role == "D2-D1")
            {
                Role = "D1-D2";
            }



            return Role;
        }



        public DataTable LoadPersonEdit_Pyramid(string RoleID)
        {
            string SQL = " select * from [dbo].[VW_Pyramid_Line] ";
            SQL += " where RoleID_Line = '" + RoleID + "'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadGroup(string Comp_Code, String Search)
        {
            string SQL = " select * from [dbo].[TB_Pyramid_Group] ";
            SQL += " where Comp_Code = '" + Comp_Code + "'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadSpcGroup(String Search)
        {
            string SQL = " select * from [dbo].[TB_Pyramid_SpecialGroup] where PicName != ''";
            //SQL += " where Spc_Code = '" + Search + "'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadRefRole(String RoleID)
        {
            string SQL = " select * from [dbo].[TB_Pyramid_Line] where RoleID = " + RoleID + "  ''";
            //SQL += " where Spc_Code = '" + Search + "'";
            return ExecuteReader(SQL);
        }



        public DataTable LoadDept(string GroupID, String Search, string CompCode)
        {
            string SQL = " select * from [dbo].[TB_Pyramid_Dept] ";
            SQL += " where GroupID = '" + GroupID + "' and CompCode = '" + CompCode + "'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadCompany()
        {
            string SQL = " select * from [dbo].[TB_Pyramid_Company] ";
            return ExecuteReader(SQL);
        }


        public string ConVertCodeToName_Company(string DataCompany)
        {

            if (DataCompany == "HA")
            {
                DataCompany = "HEATAWAY COMPANY LIMITED";
            }
            else if (DataCompany == "PK")
            {
                DataCompany = "PATKOL PUBLIC COMPANY LIMITED";
            }
            else if (DataCompany == "ID")
            {
                DataCompany = "PT.INDONESIA PATKOL SERVICE";
            }
            else if (DataCompany == "MY")
            {
                DataCompany = "PATKOL MALAYSIA SDN. BHD.";
            }
            else if (DataCompany == "PH")
            {
                DataCompany = "PATKOL PHILIPPINES CORPORATION";
            }
            else if (DataCompany == "PKM")
            {
                DataCompany = "PATKOL MANUFACTURING COMPANY LIMITED";
            }
            else if (DataCompany == "PKT")
            {
                DataCompany = "PATKOL TRADING COMPANY LIMITED";
            }

            else if (DataCompany == "SPN")
            {
                DataCompany = "S PANEL COMPANY LIMITED";
            }
            else if (DataCompany == "TG")
            {
                DataCompany = "TYGIENIC COMPANY LIMITED";
            }


            return DataCompany;
        }

        public string ConVertCodeToName_Group(string Data)
        {

            if (Data == "HA")
            {
                Data = "HEATAWAY COMPANY LIMITED";
            }
            else if (Data == "PK")
            {
                Data = "PATKOL PUBLIC COMPANY LIMITED";
            }
            else if (Data == "ID")
            {
                Data = "PT.INDONESIA PATKOL SERVICE";
            }
            else if (Data == "MY")
            {
                Data = "PATKOL MALAYSIA SDN. BHD.";
            }
            else if (Data == "PH")
            {
                Data = "PATKOL PHILIPPINES CORPORATION";
            }
            else if (Data == "PKM")
            {
                Data = "PATKOL MANUFACTURING COMPANY LIMITED";
            }
            else if (Data == "PKT")
            {
                Data = "PATKOL TRADING COMPANY LIMITED";
            }

            else if (Data == "SPN")
            {
                Data = "S PANEL COMPANY LIMITED";
            }
            else if (Data == "TG")
            {
                Data = "TYGIENIC COMPANY LIMITED";
            }


            return Data;
        }



        public DataTable CheckRefRoleID(string RoleID)
        {
            string SQL = "exec  [dbo].[SP_Pyramid_CheckRefRoleID] '" + RoleID + "'";
            return ExecuteReader(SQL);
        }


        public DataTable getPathSpcGroup(string Code)
        {
            string SQL = " select * from [dbo].[TB_Pyramid_SpecialGroup] ";
            SQL += " where Spc_Code = '" + Code.Trim() + "'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadEmployee_SearchModal(String Site_Ref, String Search)
        {
            string SQL = " select distinct Emp_Num,[Emp_Name],[Position] ,[Emp_Level],[CostCenter] ,[job_id]from [dbo].[VW_Pyramid_Emp] ";
            SQL += "where ( Emp_Num Like '%" + Search + "%' OR Emp_Name Like '%" + Search + "%') ";
            return ExecuteReader(SQL);
        }


        public DataTable LoadPyramidLine(String PyramidID)
        {
            string SQL = " select Top 1 * from [dbo].[VW_Pyramid_Line] where Role_Line = 'E17' and Pyramid_ID_Line = '" + PyramidID + "'";
            //SQL += " where Spc_Code = '" + Search + "'";
            return ExecuteReader(SQL);
        }


        public DataTable CountNormal(String PyramidID)
        {
            string SQL = "select COUNT(RoleID_Line) as CountNormal  from [dbo].[VW_Pyramid_Line] where Pyramid_ID_Line = '" + PyramidID + "' and Acting_Line = 0 and EmpNum_Line != '0' and EmpNum_Line != 'S0001'";
            return ExecuteReader(SQL);
        }

        public DataTable CountActing(String PyramidID)
        {
            string SQL = "select COUNT(RoleID_Line) as CountActing from [dbo].[VW_Pyramid_Line] where Pyramid_ID_Line = '" + PyramidID + "' and Acting_Line = 1 and EmpNum_Line != '0' and EmpNum_Line != 'S0001'";
            return ExecuteReader(SQL);
        }

        public DataTable CountSub(String PyramidID)
        {
            string SQL = "select COUNT(RoleID_Line) as CountSub from [dbo].[VW_Pyramid_Line] where Pyramid_ID_Line = '" + PyramidID + "' and Acting_Line = 0 and EmpNum_Line != '0' and EmpNum_Line = 'S0001'";
            return ExecuteReader(SQL);
        }

        public DataTable CountSkip(String PyramidID)
        {
            string SQL = "select COUNT(RoleID_Line) as CountSkip from [dbo].[VW_Pyramid_Line] where Pyramid_ID_Line = '" + PyramidID + "' and Acting_Line = 0 and EmpNum_Line = '0' and EmpNum_Line != 'S0001'";
            return ExecuteReader(SQL);
        }

        public DataTable CountNew(String PyramidID)
        {
            string SQL = "select COUNT(RoleID_Line) as CountNew from [dbo].[VW_Pyramid_Line] where Pyramid_ID_Line = '" + PyramidID + "' and EmpNum_Line = '1' ";
            return ExecuteReader(SQL);
        }

        public DataTable CountReplace(String PyramidID)
        {
            string SQL = "select COUNT(RoleID_Line) as CountReplace from [dbo].[VW_Pyramid_Line] where Pyramid_ID_Line = '" + PyramidID + "' and EmpNum_Line = '2' ";
            return ExecuteReader(SQL);
        }

        public DataTable ChkRefSkip(String RefRoleID)
        {
            string SQL = "select   * from [dbo].[VW_Pyramid_Line] where RoleID_Line = '" + RefRoleID + "'";
            return ExecuteReader(SQL);
        }

        public string getCountNormal(String PyramidID)
        {
            DataTable DT = new DataTable();
            string Str = "";

            DT = CountNormal(PyramidID);
            if (DT.Rows.Count > 0)
            {
                Str = DT.Rows[0]["CountNormal"].ToString();
            }
            return Str;
        }
        public string getCountActing(String PyramidID)
        {
            DataTable DT = new DataTable();
            string Str = "";

            DT = CountActing(PyramidID);
            if (DT.Rows.Count > 0)
            {
                Str = DT.Rows[0]["CountActing"].ToString();
            }
            return Str;
        }
        public string getCountSub(String PyramidID)
        {
            DataTable DT = new DataTable();
            string Str = "";

            DT = CountSub(PyramidID);
            if (DT.Rows.Count > 0)
            {
                Str = DT.Rows[0]["CountSub"].ToString();
            }
            return Str;
        }

        public string getCountSkip(String PyramidID)
        {
            DataTable DT = new DataTable();
            string Str = "";

            DT = CountSkip(PyramidID);
            if (DT.Rows.Count > 0)
            {
                Str = DT.Rows[0]["CountSkip"].ToString();
            }
            return Str;
        }

        public string getCountNew(String PyramidID)
        {
            DataTable DT = new DataTable();
            string Str = "";

            DT = CountNew(PyramidID);
            if (DT.Rows.Count > 0)
            {
                Str = DT.Rows[0]["CountNew"].ToString();
            }
            return Str;
        }

        public string getCountReplace(String PyramidID)
        {
            DataTable DT = new DataTable();
            string Str = "";

            DT = CountReplace(PyramidID);
            if (DT.Rows.Count > 0)
            {
                Str = DT.Rows[0]["CountReplace"].ToString();
            }
            return Str;
        }


        public DataTable LoadPyramidID(string EmpNum)
        {

            string SQL = " select Pyramid_ID_Line from [dbo].[VW_Pyramid_Line] ";
            SQL += "where EmpNum_Line = '" + EmpNum + "'";
            return ExecuteReader(SQL);
        }

        public DataTable LoadLocation(string Search)
        {

            string SQL = " select [Location],[Desc_Location] from [dbo].[TB_Pyramid_Location]";            
            return ExecuteReader(SQL);
        }

        public DataTable LoadPyramid(string PyramidID)
        {
            //PyramidID = "31";

            string SQL = " select * from [dbo].[VW_Pyramid_Line] ";
            SQL += "where Pyramid_ID_Line = '" + PyramidID + "'";
            SQL += "Order by Dept_Line";
            //SQL += " where Role_Line != 'E17' and  Role_Line != 'E16' and Role_Line != 'E15' and  EmpNum_Line = '" + EmpNum + "'and  Acting_Line = 0 and Company = '" + company +"'";         
            return ExecuteReader(SQL);
        }

        public DataTable LoadLevelMain(string EmpNum)
        {
            //PyramidID = "31";

            string SQL = " select Top 1 * from [dbo].[VW_EmployeesSerch] ";
            SQL += "where res_id = '" + EmpNum + "'";

            //SQL += " where Role_Line != 'E17' and  Role_Line != 'E16' and Role_Line != 'E15' and  EmpNum_Line = '" + EmpNum + "'and  Acting_Line = 0 and Company = '" + company +"'";         
            return ExecuteReader(SQL);
        }


        //LEN(Emp_Num) = 5 

        public string ChkX2(string RefRoleID)
        {
            DataTable DT = new DataTable();

            string str = "";

            int turn = 10;

            for (int i = 0; i < turn; i++)
            {

                DT = ChkRefSkip(RefRoleID);


                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {

                        string RoleID_Line = row["RoleID_Line"].ToString();
                        string RefRoleID_Line = row["RefRoleID_Line"].ToString();
                        string EmpNum_Line = row["EmpNum_Line"].ToString();

                        if (EmpNum_Line != "0")
                        {
                            str = RoleID_Line;
                            break;
                        }
                        else
                        {
                            RefRoleID = RefRoleID_Line;

                        }

                    }
                }


            }




            return str;
        }


        public string checkRefSkip(String RefRoleID)
        {
            DataTable DT = new DataTable();

            string Str = "0";

            DT = ChkRefSkip(RefRoleID);



            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                    string RoleID_Line = row["RoleID_Line"].ToString();
                    string RefRoleID_Line = row["RefRoleID_Line"].ToString();
                    string EmpNum_Line = row["EmpNum_Line"].ToString();

                    if (EmpNum_Line == "0") // ถ้าเป็นSkip
                    {

                        Str = ChkX2(RefRoleID_Line);



                    }
                    else
                    {
                        Str = RefRoleID;   // ส่งRefRoleของ Skipกลับไป
                    }

                }
            }

            return Str;
        }




        public string getLevel(String EmpNum)
        {
            DataTable DT = new DataTable();

            string Str = "";

            DT = LoadLevelMain(EmpNum);



            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {

                    Str = row["Level"].ToString();


                }
            }

            return Str;
        }



        public DataTable ClonePyramid(String PyramidID, String CompanyCode, String Dept, String CreateBy)
        {
            string SQL = "exec  [dbo].[SP_Pyramid_Clone] '" + PyramidID + "','" + CompanyCode + "', '" + Dept + "' , '" + CreateBy + "'";
            return ExecuteReader(SQL);
        }




        public DataTable SeacrhSummaryDetail(string CompanyCode, string GroupPyramid, string Division, string Costcerter, string Location, string Level, string EmpStatus)
        {



            string SQL = "SELECT [Comp_Name],[GroupName],[Division],[Dept],hr.Emp_Location as 'Location',[Level_Emp],[EmpType],COUNT([EmpNum]) as 'EmpQty'";
            SQL += "FROM [dbo].[VW_Pyramid_EmpMain] emp ";
            SQL += "LEFT JOIN [dbo].[TB_HR_Employee] hr ";
            SQL += " ON emp.[EmpNum] = hr.Emp_Num AND hr.[Language] = 'TH' ";

            SQL += " where (Company  like '%" + CompanyCode + "%' or '%" + CompanyCode + "%' = '%%')";
            SQL += " and (GroupPyramid  like '%" + GroupPyramid + "%' or '%" + GroupPyramid + "%' = '%%')";
            SQL += " and (Division like '%" + Division + "%' or '%" + Division + "%' = '%%')";
            SQL += " and (Dept like '%" + Costcerter + "%' or '%" + Costcerter + "%' = '%%')";
            SQL += " and (hr.Emp_Location like '%" + Location + "%' or '%" + Location + "%' = '%%')";
            SQL += " and (Level_Emp like '%" + Level + "%' or '%" + Level + "%' = '%%')";
            SQL += " and (EmpType like '%" + EmpStatus + "%' or '%" + EmpStatus + "%' = '%%')";

            //SQL += "WHERE[Division] = 'IT' AND [site_ref] = 'ERP_PK'";

            SQL += "GROUP BY[Comp_Name],[GroupName],[Division],[Dept], hr.Emp_Location,[Level_Emp],[EmpType],[EmpLevel_Hir],[EmpType_Hir]";
            SQL += "ORDER BY[Comp_Name],[GroupName],[Division],[Dept], hr.Emp_Location,[EmpLevel_Hir],[EmpType_Hir]";

            return ExecuteReader(SQL);
        }


        public DataTable SeacrhSummary(string CompanyCode, string GroupPyramid, string Division, string Level, string EmpStatus)
        {

            string SQL = "SELECT [Comp_Name],[GroupName],[Dept],[Level_Emp],[EmpType],COUNT([EmpNum]) as 'EmpQty' ";
            SQL += " FROM [dbo].[VW_Pyramid_EmpMain] ";
            SQL += " where (Company  like '%" + CompanyCode + "%' or '%" + CompanyCode + "%' = '%%') ";
            SQL += " and (GroupPyramid  like '%" + GroupPyramid + "%' or '%" + GroupPyramid + "%' = '%%') ";
            SQL += " and (Division like '%" + Division + "%' or '%" + Division + "%' = '%%') ";       
            SQL += " and (Level_Emp like '%" + Level + "%' or '%" + Level + "%' = '%%')";
            SQL += " and (EmpType like '%" + EmpStatus + "%' or '%" + EmpStatus + "%' = '%%')";
            SQL += " GROUP BY[Comp_Name],[GroupName],[Dept],[Level_Emp],[EmpType],[EmpLevel_Hir],[EmpType_Hir] ";
            SQL += " ORDER BY[Comp_Name],[GroupName],[Dept],[EmpLevel_Hir],[EmpType_Hir] " ;


            return ExecuteReader(SQL);
    }


        public List<List<ArrayList>> GetExport_SummaryDetail(String CompanyCode, String GroupPyramid, String Division, String Costcerter, String Location, String Level, String EmpStatus)
        {
            DataTable DTData = new DataTable();
           
            DTData = SeacrhSummaryDetail(CompanyCode, GroupPyramid, Division, Costcerter, Location, Level, EmpStatus);

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




        public DataTable LoadPyramid_Myteam(string EmpNum, String Site_ref, string Type, string ChkRoleID)
        {
            //string company = "";
            //string substr = Site_ref.Substring(4);

            //EmpNum = "47046";
            //EmpNum = "57363";
            string SQL = "";

            //company = 'C' + substr;

            if (Type == "Main")
            {
                SQL = " select * from [dbo].[VW_Pyramid_Line] ";
                SQL += " where EmpNum_Line = '" + EmpNum + "'and  Acting_Line = 0 and site_ref = '" + Site_ref + "'";
            }
            else if (Type == "Acting")
            {

                SQL = " select * from [dbo].[VW_Pyramid_Line] ";
                SQL += " where RoleID_Line = '" + ChkRoleID + "' and site_ref = '" + Site_ref + "'";
            }


            return ExecuteReader(SQL);
        }




        public DataTable LoadRefRole(string RoleID, string RefRoleID)
        {

            string SQL = " select * from [dbo].[VW_Pyramid_Line] ";
            SQL += " where  RoleID_Line ='" + RoleID + "' or   RefRoleID_Line = '" + RoleID + "' or RoleID_Line = '" + RefRoleID + "'";
            return ExecuteReader(SQL);

        }



        public DataTable LoadHeaderMyteam(string EmpNum, String Site_ref)
        {
            //string company = "";
            //string substr = Site_ref.Substring(4);

            //EmpNum = "47046";
            //EmpNum = "57363";

            //company = 'C' + substr;
            string SQL = " select * from [dbo].[VW_Pyramid_Line] ";
            SQL += " where EmpNum_Line = '" + EmpNum + "'and site_ref = '" + Site_ref + "' and Stat = 'Active'";
            return ExecuteReader(SQL);
        }

        public void UpdateEmpHRPortal(string TypeUpdate, int Pyramid_ID, string EmpNum)
        {
            string SQL = "exec  [dbo].[SP_UpdateEmpInfoFromPyramid] '" + TypeUpdate + "'," + Pyramid_ID + ", '" + EmpNum + "'";
            ExecuteReader(SQL);
        }

        public DataTable LoadCostcenter(String Site_ref, String StrQuickSearch)
        {
            string SQL = " select Costcenter as code,CostcenterDesc as name from VW_Dept_AllSite ";
            SQL += " where Costcenter <> '0000' and CostcenterDesc is not null ";
            SQL += " and (site_ref = '" + Site_ref + "' or '" + Site_ref + "' = '') ";
            SQL += " and (Costcenter Like '%" + StrQuickSearch + "%' or CostcenterDesc Like '%" + StrQuickSearch + "%') ";
            return ExecuteReader(SQL);
        }

        public DataTable CheckPermission(string Username)
        {

            string SQL = " SELECT [username] FROM [dbo].[TB_Permission] WHERE [page] = 'Pyramid' AND [username] = '" + Username.Trim() + "'";
            //DT = ExecuteReader(SQL);
            return ExecuteReader(SQL);
            //return DT.Rows[0]["emp_num"].ToString();
        }


    }




}