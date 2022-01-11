using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using MobileTask.AppCode;
using System.Data;
using Workflow_Application;
using PyramidSystem.ModelData;

namespace PyramidSystem.Projects
{
    public partial class MyTeam : System.Web.UI.Page
    {
        string Username, EmpNum, Dept, Level;
        fn_All fn_ = new fn_All();
        protected void Page_Load(object sender, EventArgs e)
        {
            Username = fn_.GetUser();
            EmpNum = fn_.getLogonEmp_Num();
            Dept = fn_.getLogonCost_Center();
            Level = fn_.getLogonEmp_Level();

            lblUser.Text = Username;
            lblEmpNum.Text = EmpNum;

            //lblEmpNum.Text = "43106";
            lblCostCenter.Text = Dept;
            lblLevel.Text = Level;
            //lblLevel.Text = "E16";
        }



        [WebMethod]
        public static List<PyramidLine_JoinDotLineCommand> LoadPyramid_Myteam(String EmpNum, String Site_ref, String Costcenter, string Type, string ChkRoleID)
        {


            List<PyramidLine_JoinDotLineCommand> ListData = new List<PyramidLine_JoinDotLineCommand>();

            ClassHRPortal DBConn = new ClassHRPortal();


            DataTable DTData = new DataTable();

            DataTable DTRoleID = new DataTable();

            string RoleID = "";
            string RefRoleID = "";

            string ChkRefRoleID = "";
            string RefRoleNonSkip = "";



            DTData = DBConn.LoadPyramid_Myteam(EmpNum.Trim(), Site_ref, Type, ChkRoleID);


            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    RoleID = row["RoleID_Line"].ToString();
                    RefRoleID = row["RefRoleID_Line"].ToString();

                    ChkRefRoleID = DBConn.checkRefSkip(RefRoleID); // Check RefRoleSkip

                }
            }


            //////////////////////////////////////////////////////////////////////////////////////////////


            DTRoleID = DBConn.LoadRefRole(RoleID, ChkRefRoleID);

            if (DTRoleID.Rows.Count > 0)
            {
                foreach (DataRow r in DTRoleID.Rows)
                {

                    string RoleID_Line = r["RoleID_Line"].ToString();
                    string RefRoleID_Line = r["RefRoleID_Line"].ToString();
                    string Role_Line = r["Role_Line"].ToString();
                    string EmpNum_Line = r["EmpNum_Line"].ToString();
                    string EmpName_Line = r["EmpName_Line"].ToString();
                    string Dept_Line = r["Dept_Line"].ToString();
                    string Level_Emp_Line = r["Level_Emp_Line"].ToString();
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


                    if (RoleID == RoleID_Line)
                    {

                        RefRoleID_Line = ChkRefRoleID;
                    }

                    if (RoleID_Line == ChkRefRoleID)
                    {

                        RefRoleID_Line = "";
                    }


                    ListData.Add(new PyramidLine_JoinDotLineCommand
                    {
                        RoleID_Line = RoleID_Line,
                        RefRoleID_Line = RefRoleID_Line,
                        Role_Line = Role_Line,
                        EmpNum_Line = EmpNum_Line.Trim(),
                        EmpName_Line = EmpName_Line,
                        Dept_Line = Dept_Line,
                        Level_Emp_Line = Level_Emp_Line,
                        Position_Line = Position_Line,
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

        public static List<PyramidLine_JoinDotLineCommand> LoadHeaderMyteam(String EmpNum, String Site_ref)
        {

            //EmpNum = "47046";

            ClassHRPortal DBConn = new ClassHRPortal();
            List<PyramidLine_JoinDotLineCommand> ListData = new List<PyramidLine_JoinDotLineCommand>();
            DataTable DTData = new DataTable();

            DTData = DBConn.LoadHeaderMyteam(EmpNum.Trim(), Site_ref);


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
                    string Level_Emp_Line = r["Level_Emp_Line"].ToString();
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
                    string Company = r["Company"].ToString();



                    ListData.Add(new PyramidLine_JoinDotLineCommand
                    {
                        RoleID_Line = RoleID_Line,
                        RefRoleID_Line = RefRoleID_Line,
                        Role_Line = Role_Line,
                        EmpNum_Line = EmpNum_Line.Trim(),
                        EmpName_Line = EmpName_Line,
                        Dept_Line = Dept_Line,
                        Level_Emp_Line = Level_Emp_Line,
                        Position_Line = Position_Line,
                        Acting_Line = Acting_Line,
                        ActingType_Line = ActingType_Line,
                        SpecialGroup_Line = SpecialGroup_Line,
                        Remark_Line = Remark_Line,
                        CreateBy_Line = CreateBy_Line,
                        CreateDate_Line = CreateDate_Line,
                        Pyramid_ID_Line = Pyramid_ID_Line,
                        Company = Company


                    });

                }


            }


            return ListData;
        }

    }


}