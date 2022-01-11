using System;
using System.Collections.Generic;
using System.Web.Services;
using MobileTask.AppCode;
using Workflow_Application;
using System.Data;
using System.Collections;
using PyramidSystem.ModelData;

namespace PyramidSystem.Projects
{
    public partial class PreviewPyramid : System.Web.UI.Page
    {
        string Username ,Dept = "",emp_num;
        ClassHRPortal DBConnHRDB = new ClassHRPortal();
        protected void Page_Load(object sender, EventArgs e)
        {
            fn_All fn = new fn_All();
            Username = fn.GetUser();
            //emp_num = DBConnHRDB.CheckPermission(Username);
            if (string.IsNullOrEmpty(emp_num))
            {
                
            }
            Dept = fn.getLogonCost_Center();
            string subDept = Dept.Substring(1, 2);
            lblCostCenter.Text = subDept;
        }

        [WebMethod]
        public static List<PyramidLine_JoinDotLineCommand> LoadPyramid(string PyramidID)
        {

            List<PyramidLine_JoinDotLineCommand> ListData = new List<PyramidLine_JoinDotLineCommand>();

            ClassHRPortal DBConn = new ClassHRPortal();


            DataTable DTData = new DataTable();
           
            DTData = DBConn.LoadPyramid(PyramidID);

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow r in DTData.Rows)
                {

                    string RoleID_Line = r["RoleID_Line"].ToString();
                    string RefRoleID_Line = r["RefRoleID_Line"].ToString();
                    string Role_Line = r["Role_Line"].ToString();
                    string EmpNum_Line = r["EmpNum_Line"].ToString();
                    string EmpName_Line = r["EmpName_Line"].ToString();
                    string Dept_Line = r["Dept_Line"].ToString();
                    //string Level_Emp = r["Level_Emp"].ToString();
                    //string Level_acting = r["Level_acting"].ToString();
                    string Level_Emp = r["Level_Emp_Line"].ToString();

                    string Position_Line = r["Position_Line"].ToString();
                    string Acting_Line = r["Acting_Line"].ToString();
                    string ActingType_Line = r["ActingType_Line"].ToString();
                    string SpecialGroup_Line = r["SpecialGroup_Line"].ToString();
                    string Remark_Line = r["Remark_Line"].ToString();
                    string CreateBy_Line = r["CreateBy_Line"].ToString();
                    string CreateDate_Line = r["CreateDate_Line"].ToString();
                    string Pyramid_ID_Line = r["Pyramid_ID_Line"].ToString();
                    string Path = r["PicName"].ToString();
                    string Dept = r["Dept"].ToString();



                    string strPorsition = Position_Line.Replace("และ", " และ");



                    //if (EmpNum_Line == "57363")
                    //{
                    //    String a = "EmpNum_Line";
                    //}
                    //string ChkRefRoleID = DBConn.checkRefSkip(RefRoleID_Line); // Check RefRoleSkip
                    string Level_Main = "";

                    if (Acting_Line == "1") {

                        Level_Main = DBConn.getLevel(EmpNum_Line);
                    }
                  



                    ListData.Add(new PyramidLine_JoinDotLineCommand
                    {
                        RoleID_Line = RoleID_Line,
                        RefRoleID_Line = RefRoleID_Line,
                        Role_Line = Role_Line,
                        EmpNum_Line = EmpNum_Line.Trim(),
                        EmpName_Line = EmpName_Line,
                        Dept_Line = Dept_Line,
                        Level_Emp = Level_Emp,
                        Level_acting = Level_Main,
                        Position_Line = strPorsition,
                        Acting_Line = Acting_Line,
                        ActingType_Line = ActingType_Line,
                        SpecialGroup_Line = SpecialGroup_Line,
                        Remark_Line = Remark_Line,
                        CreateBy_Line = CreateBy_Line,
                        CreateDate_Line = CreateDate_Line,
                        Pyramid_ID_Line = Pyramid_ID_Line,
                        Path = Path,
                        Dept = Dept

                    });

                }


            }


            return ListData;


        }

        [WebMethod]
        public static List<CheckPermission> CheckPermission()
        {
            ClassHRPortal DBConn = new ClassHRPortal();
            fn_All fn = new fn_All();
            DataTable DTData = new DataTable();
            List<CheckPermission> ListData = new List<CheckPermission>();
            DTData = DBConn.CheckPermission(fn.GetUser());
            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow r in DTData.Rows)
                {

                    string Emp_num = r["username"].ToString();


                    ListData.Add(new CheckPermission
                    {

                        Emp_num = Emp_num,

                    });
                }
                
            }
            else
            {
                ListData.Add(new CheckPermission
                {

                    Emp_num = "",

                });
            }

            return ListData;
        }
    }
}