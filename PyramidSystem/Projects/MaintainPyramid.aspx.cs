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
    public partial class MaintainPyramid : System.Web.UI.Page
    {
        string Username = "";
        string Dept = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            fn_All fn = new fn_All();
            Username = fn.GetUser();
            lblUserLogin.Text = Username;
            Dept = fn.getLogonCost_Center();

        }


        [WebMethod]
        public static List<String[]> GetNameEmployee(string search, string site_ref)
        {
            return new ClassBrowseNew().GetNameEmployee(search, site_ref);
        }

        [WebMethod]
        public static List<String[]> LoadPosition(String Site_ref, String Dept, string Level)
        {
            return new ClassBrowseNew().LoadPosition(Site_ref, Dept, Level);
        }

        [WebMethod]
        public static List<Browse> LoadCostCenter(String Site_ref, String Search)
        {
            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadCostcenter(Site_ref, Search.Trim());

            List<Browse> ListData = new List<Browse>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string Code = row["code"].ToString();
                    string Name = row["name"].ToString();

                    ListData.Add(new Browse
                    {
                        Code = Code,
                        Name = Name,
                    });
                }
            }
            return ListData;
        }

        [WebMethod]
        public static List<ArrayList> GetSite_ref(string data)
        {
            return new ClassBrowseNew().GetSite_ref();
        }

        [WebMethod]
        public static List<Employee> LoadEmp(String Site_ref, String Search)
        {
            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadEmployee_SearchModal(Site_ref.Trim(), Search.Trim());
            List<Employee> ListData = new List<Employee>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string empCode = row["Emp_Num"].ToString();
                    string fullName = row["Emp_Name"].ToString();
                    string JobTitle = row["Position"].ToString();
                    string Costcenter = row["CostCenter"].ToString();
                    string JobLevel = row["Emp_Level"].ToString();
                    string job_id = row["job_id"].ToString();

                    ListData.Add(new Employee
                    {
                        EmpCode = empCode,
                        Fullname = fullName,
                        JobTitle = JobTitle,
                        costcenter = Costcenter,
                        Level = JobLevel,
                        job_id = job_id,

                    });
                }
            }
            return ListData;
        }


        [WebMethod]
        public static List<HeaderPyramid> InsertPyramidHerder(string PyramidID, string Company, string GroupPyramid, string Dept, string Revision, string EffectDate, string Action, string Createby, string Status)
        {

            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            string msg = "";
            ClassHRPortal DBConn = new ClassHRPortal();

            List<HeaderPyramid> ListData = new List<HeaderPyramid>();

            DTData = DBConn.InsertPyramid_Header(PyramidID, Company, GroupPyramid, Dept, Revision, EffectDate, Action, Createby, Status);


            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string DataPyramidID = row["PyramidID"].ToString();
                    string DataCompany = row["Company"].ToString();
                    string DataGroupPyramid = row["GroupPyramid"].ToString();
                    string DataDept = row["Dept"].ToString();
                    string DataRevision = row["Revision"].ToString();
                    string DataEffectDate = fn_.fn_ConvertDate(row["EffectDate"].ToString());

                    string Comp_Name = row["Comp_Name"].ToString();
                    string GroupName = row["GroupName"].ToString();
                    string DeptName = row["DeptName"].ToString();
                    string Stat = row["stat"].ToString();

                    if (Action == "Insert")
                    {
                        msg = "Insert Complete";
                    }
                    else if (Action == "Update")
                    {
                        msg = "Update Complete";
                    }




                    ListData.Add(new HeaderPyramid
                    {
                        PyramidID = DataPyramidID,
                        Company = DataCompany,
                        GroupPyramid = DataGroupPyramid,
                        Dept = DataDept,
                        Revision = DataRevision,
                        EffectDate = DataEffectDate,
                        Comp_Name = Comp_Name,
                        GroupName = GroupName,
                        DeptName = DeptName,
                        Status = Stat,
                        msg = msg
                    });
                }
            }



            return ListData;
        }



        [WebMethod]
        public static List<HeaderPyramid> SearchPyramid(string Company, string GroupPyramid, string Dept, string Revision, string EffectDate, string Status)
        {

            DataTable DTData = new DataTable();
            DataTable DTGet = new DataTable();
            fn_All fn_ = new fn_All();

            ClassHRPortal DBConn = new ClassHRPortal();

            List<HeaderPyramid> ListData = new List<HeaderPyramid>();

            DTData = DBConn.SeacrhPyramid(Company, GroupPyramid, Dept, Revision, EffectDate, Status);

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string DataPyramidID = row["PyramidID"].ToString();
                    string DataCompany = row["Company"].ToString();
                    string DataGroupPyramid = row["GroupPyramid"].ToString();
                    string DataDept = row["Dept"].ToString();
                    string DataRevision = row["Revision"].ToString();
                    string DataEffectDate = fn_.fn_ConvertDate(row["EffectDate"].ToString());
                    string Comp_Name = row["Comp_Name"].ToString();
                    string GroupName = row["GroupName"].ToString();
                    string DeptName = row["DeptName"].ToString();
                    string Stat = row["Stat"].ToString();
                    string SiteRef = row["site_ref"].ToString();

                    ListData.Add(new HeaderPyramid
                    {
                        PyramidID = DataPyramidID,
                        Company = DataCompany,
                        GroupPyramid = DataGroupPyramid,
                        Dept = DataDept,
                        Revision = DataRevision,
                        EffectDate = DataEffectDate,
                        Comp_Name = Comp_Name,
                        GroupName = GroupName,
                        DeptName = DeptName,
                        Status = Stat,
                        SiteRef = SiteRef
                    });
                }
            }



            return ListData;
        }



        [WebMethod]
        public static List<PyramidLine> InsertPyramidLine(string Pyramid_ID, string RoleID, string RefRoleID, string Role, string RoleCode, string EmpNum, string EmpName, string Dept,
        string Level_Emp, string Position, string Acting, string ActingMain, string ActingType, string SpecialGroup, string Remark, string CreateBy, string Action, string Position_Code,
        string ID, string Role_Command, string Emp_Command, string EmpName_Command, string Dept_Command, string Level_Command, string Position_Command, string Remark_Command,
        string SpecialGroup_Command, string Status, string Position_Code_Command)
        {
            //CreateBy = "apidtha.ch";

            DataTable DTData = new DataTable();
            DataTable DTPath = new DataTable();
            fn_All fn_ = new fn_All();
            string msg = "";
            ClassHRPortal DBConn = new ClassHRPortal();

            List<PyramidLine> ListData = new List<PyramidLine>();

            DTData = DBConn.insert_PyramidLine(Pyramid_ID, RoleID, RefRoleID, Role, RoleCode, EmpNum, EmpName, Dept,
            Level_Emp, Position, Acting, ActingMain, ActingType, SpecialGroup, Remark, CreateBy, Action, Status, Position_Code);
            string Path = "";


            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {

                    string DataPyramid_ID = row["Pyramid_ID"].ToString();
                    string DataRoleID = row["RoleID"].ToString();
                    string DataRefRoleID = row["RefRoleID"].ToString();
                    string DataRole = row["Role"].ToString();
                    string DataEmpNum = row["EmpNum"].ToString();
                    string DataEmpName = row["EmpName"].ToString();
                    string DataDept = row["Dept"].ToString();
                    string DataLevel_Emp = row["Level_Emp"].ToString();
                    string DataPosition = row["Position"].ToString();
                    string DataActing = row["Acting"].ToString();
                    string DataActingMain = row["ActingMain"].ToString();
                    string DataActingType = row["ActingType"].ToString();
                    string DataSpecialGroup = row["SpecialGroup"].ToString();
                    string DataRemark = row["Remark"].ToString();
                    string DataCreateBy = row["CreateBy"].ToString();
                    string DataCheckColumn = row["CheckColume"].ToString();

                    if (Emp_Command != "")
                    {
                        DBConn.insert_Pyramid_DotLineCommand(ID, Pyramid_ID, DataRoleID, DataRefRoleID, Role_Command, Emp_Command,
                        EmpName_Command, Dept_Command, Level_Command, Position_Command, SpecialGroup_Command, Remark_Command, Action, CreateBy, Position_Code_Command);
                    }


                    if (DataSpecialGroup != "")
                    {
                        DTPath = DBConn.getPathSpcGroup(DataSpecialGroup);

                        foreach (DataRow r in DTPath.Rows)
                        {
                            Path = r["PicName"].ToString();
                        }
                    }



                    if (Action == "Insert")
                    {
                        msg = "Insert Complete !!";
                    }
                    else if (Action == "Update")
                    {
                        msg = "Update Complete !!";
                    }
                    else if (Action == "Delete")
                    {
                        msg = "Delete Complete !!";
                    }


                    ListData.Add(new PyramidLine
                    {
                        RefRoleID = DataRefRoleID,
                        RoleID = DataRoleID,
                        Role = DataRole,
                        EmpNum = DataEmpNum,
                        EmpName = DataEmpName,
                        Dept = DataDept,
                        Level_Emp = DataLevel_Emp,
                        Position = DataPosition,
                        Acting = DataActing,
                        ActingMain = DataActingMain,
                        ActingType = DataActingType,
                        SpecialGroup = DataSpecialGroup,
                        Remark = DataRemark,
                        CreateBy = DataCreateBy,
                        Pyramid_ID = DataPyramid_ID,
                        MsgReturn = msg,
                        Path = Path,
                        CheckColumn = DataCheckColumn
                    });

                }
            }



            return ListData;
        }


        [WebMethod]
        public static List<PyramidLine_JoinDotLineCommand> LoadPersonEdit(string RoleID)
        {

            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            string msg = "";
            ClassHRPortal DBConn = new ClassHRPortal();

            List<PyramidLine_JoinDotLineCommand> ListData = new List<PyramidLine_JoinDotLineCommand>();

            DTData = DBConn.LoadPersonEdit_Pyramid(RoleID);

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string RoleID_Line = row["RoleID_Line"].ToString();
                    string RefRoleID_Line = row["RefRoleID_Line"].ToString();
                    string Role_Line = row["Role_Line"].ToString();
                    string EmpNum_Line = row["EmpNum_Line"].ToString();
                    string EmpName_Line = row["EmpName_Line"].ToString();
                    string Dept_Line = row["Dept_Line"].ToString();
                    string Level_Emp_Line = row["Level_Emp_Line"].ToString();
                    string Position_Line = row["Position_Line"].ToString();
                    string Acting_Line = row["Acting_Line"].ToString();
                    string ActingMain_Line = row["ActingMain_Line"].ToString();
                    string ActingType_Line = row["ActingType_Line"].ToString();
                    string SpecialGroup_Line = row["SpecialGroup_Line"].ToString();
                    string Remark_Line = row["Remark_Line"].ToString();
                    string CreateBy_Line = row["CreateBy_Line"].ToString();
                    string CreateDate_Line = row["CreateDate_Line"].ToString();
                    string Pyramid_ID_Line = row["Pyramid_ID_Line"].ToString();
                    string CheckColumn_Line = row["CheckColumn_Line"].ToString();
                    string Position_Code_Line = row["Position_Code_Line"].ToString(); //02/08/2019



                    /////////////////DotLine Command/////////////////////////////////////////////////////////////////////////////////
                    string RoleID_Command = row["RoleID_Command"].ToString();
                    string RefRoleID_Command = row["RefRoleID_Command"].ToString();
                    string Role_Command = row["Role_Command"].ToString();
                    string EmpNum_Command = row["EmpNum_Command"].ToString();
                    string EmpName_Command = row["EmpName_Command"].ToString();
                    string Dept_Command = row["Dept_Command"].ToString();
                    string Level_Emp_Command = row["Level_Emp_Command"].ToString();
                    string Position_Command = row["Position_Command"].ToString();
                    string SpecialGroup_Command = row["SpecialGroup_Command"].ToString();
                    string Remark_Command = row["Remark_Command"].ToString();
                    string CreateBy_Command = row["CreateBy_Command"].ToString();
                    string CreateDate_Command = row["CreateDate_Command"].ToString();
                    string Pyramid_ID_Command = row["Pyramid_ID_Command"].ToString();
                    string Position_Code_Command = row["Position_Code_Command"].ToString(); //02/08/2019

                    /////////////////Real/////////////////////////////////////////////////////////////////////////////////
                    string Dept_Real = row["real_costcenter"].ToString();
                    string Level_Emp_Real = row["real_Level"].ToString();
                    string Position_Real = row["real_JobTitle"].ToString();
                    string PositionEN_Real = row["real_JobTitle_EN"].ToString();

                    ListData.Add(new PyramidLine_JoinDotLineCommand
                    {
                        RoleID_Line = RoleID_Line,
                        RefRoleID_Line = RefRoleID_Line,
                        Role_Line = Role_Line,
                        EmpNum_Line = EmpNum_Line,
                        EmpName_Line = EmpName_Line,
                        Dept_Line = Dept_Line,
                        Level_Emp_Line = Level_Emp_Line,
                        Position_Line = Position_Line,
                        Acting_Line = Acting_Line,
                        ActingMain_Line = ActingMain_Line,
                        ActingType_Line = ActingType_Line,
                        SpecialGroup_Line = SpecialGroup_Line,
                        Remark_Line = Remark_Line,
                        CreateBy_Line = CreateBy_Line,
                        CreateDate_Line = CreateDate_Line,
                        Pyramid_ID_Line = Pyramid_ID_Line,
                        CheckColumn_Line = CheckColumn_Line,
                        Position_Code_Line = Position_Code_Line,

                        //////////////////////////DotLine Command////////////////////////////////////////////////////////////////////////
                        RoleID_Command = RoleID_Command,
                        RefRoleID_Command = RefRoleID_Command,
                        Role_Command = Role_Command,
                        EmpNum_Command = EmpNum_Command,
                        EmpName_Command = EmpName_Command,
                        Dept_Command = Dept_Command,
                        Level_Emp_Command = Level_Emp_Command,
                        Position_Command = Position_Command,
                        SpecialGroup_Command = SpecialGroup_Command,
                        Remark_Command = Remark_Command,
                        CreateBy_Command = CreateBy_Command,
                        CreateDate_Command = CreateDate_Command,
                        Pyramid_ID_Command = Pyramid_ID_Command,
                        Position_Code_Command = Position_Code_Command,

                        /////////////////Real///////////////////////////////////////////////////////

                        Dept_Real = Dept_Real,
                        Level_Emp_Real = Level_Emp_Real,
                        Position_Real = Position_Real,
                        PositionEN_Real = PositionEN_Real,

                    });

                }
            }



            return ListData;
        }




        [WebMethod]
        public static List<Browse> LoadGroup(string Comp_Code, String Search)
        {

            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadGroup(Comp_Code.Trim(), Search);



            List<Browse> ListData = new List<Browse>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string Group_ID = row["Group_ID"].ToString();
                    string GroupName = row["GroupName"].ToString();

                    ListData.Add(new Browse
                    {
                        Code = Group_ID,
                        Name = GroupName,
                    });
                }
            }
            return ListData;
        }




        [WebMethod]
        public static List<Browse> LoadCompany(string data)
        {

            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadCompany();



            List<Browse> ListData = new List<Browse>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string Comp_Code = row["Comp_Code"].ToString();
                    string Comp_Name = row["Comp_Name"].ToString();

                    ListData.Add(new Browse
                    {
                        Code = Comp_Code,
                        Name = Comp_Name,
                    });
                }
            }
            return ListData;
        }


        [WebMethod]
        public static List<Browse> LoadDept(string GroupID, String Search, string CompCode)
        {

            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadDept(GroupID.Trim(), Search, CompCode);



            List<Browse> ListData = new List<Browse>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string DeptID = row["DeptID"].ToString();
                    string DeptName = row["DeptName"].ToString();
                    string DeptCode = row["DeptCode"].ToString();

                    ListData.Add(new Browse
                    {
                        Code = DeptID,
                        Name = DeptName,
                        DeptCode = DeptCode,
                    });
                }
            }
            return ListData;
        }


        [WebMethod]
        public static List<PyramidLine> CheckRefRoleID(string RoleID)
        {

            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.CheckRefRoleID(RoleID);

            DataTable DTPath = new DataTable();

            string Path = "";
            List<PyramidLine> ListData = new List<PyramidLine>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {

                    string DataPyramid_ID = row["Pyramid_ID"].ToString();
                    string DataRoleID = row["RoleID"].ToString();
                    string DataRefRoleID = row["RefRoleID"].ToString();
                    string DataRole = row["Role"].ToString();
                    string DataEmpNum = row["EmpNum"].ToString();
                    string DataEmpName = row["EmpName"].ToString();
                    string DataDept = row["Dept"].ToString();
                    string DataLevel_Emp = row["Level_Emp"].ToString();
                    string DataPosition = row["Position"].ToString();
                    string DataActing = row["Acting"].ToString();
                    string DataActingType = row["ActingType"].ToString();
                    string DataSpecialGroup = row["SpecialGroup"].ToString();
                    string DataRemark = row["Remark"].ToString();
                    string DataCreateBy = row["CreateBy"].ToString();
                    string DataCheckColumn = row["CheckColume"].ToString();


                    if (DataSpecialGroup != "")
                    {
                        DTPath = DBConn.getPathSpcGroup(DataSpecialGroup);

                        foreach (DataRow r in DTPath.Rows)
                        {
                            Path = r["PicName"].ToString();
                        }
                    }


                    ListData.Add(new PyramidLine
                    {
                        RefRoleID = DataRefRoleID,
                        RoleID = DataRoleID,
                        Role = DataRole,
                        EmpNum = DataEmpNum,
                        EmpName = DataEmpName,
                        Dept = DataDept,
                        Level_Emp = DataLevel_Emp,
                        Position = DataPosition,
                        Acting = DataActing,
                        ActingType = DataActingType,
                        SpecialGroup = DataSpecialGroup,
                        Remark = DataRemark,
                        CreateBy = DataCreateBy,
                        Pyramid_ID = DataPyramid_ID,
                        Path = Path,
                        CheckColumn = DataCheckColumn

                    });

                }
            }



            return ListData;

        }


        [WebMethod]
        public static List<Browse> LoadSpcGroup(String Search)
        {

            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadSpcGroup(Search);

            List<Browse> ListData = new List<Browse>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string Code = row["Spc_Code"].ToString();
                    string path = row["PicName"].ToString();

                    ListData.Add(new Browse
                    {
                        Code = Code,
                        Path = path,
                    });
                }
            }
            return ListData;
        }


        [WebMethod]
        public static List<Browse> LoadRefRole(String RoleID)
        {

            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadSpcGroup(RoleID);

            List<Browse> ListData = new List<Browse>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    //string Code = row["Spc_Code"].ToString();
                    //string path = row["PicName"].ToString();

                    ListData.Add(new Browse
                    {
                        //    Code = Code,
                        //    Path = path,
                    });
                }
            }
            return ListData;
        }



        [WebMethod]
        public static List<PyramidLine_JoinDotLineCommand> ShowPyramidLine(String PyramidID)
        {

            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            DTData = DBConn.LoadPyramidLine(PyramidID);

            List<PyramidLine_JoinDotLineCommand> ListData = new List<PyramidLine_JoinDotLineCommand>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string RoleID_Line = row["RoleID_Line"].ToString();
                    string RefRoleID_Line = row["RefRoleID_Line"].ToString();
                    string Role_Line = row["Role_Line"].ToString();
                    string EmpNum_Line = row["EmpNum_Line"].ToString();
                    string EmpName_Line = row["EmpName_Line"].ToString();
                    string Dept_Line = row["Dept_Line"].ToString();
                    string Level_Emp_Line = row["Level_Emp_Line"].ToString();
                    string Position_Line = row["Position_Line"].ToString();
                    string Acting_Line = row["Acting_Line"].ToString();
                    string ActingMain_Line = row["ActingMain_Line"].ToString();
                    string ActingType_Line = row["ActingType_Line"].ToString();
                    string SpecialGroup_Line = row["SpecialGroup_Line"].ToString();
                    string Remark_Line = row["Remark_Line"].ToString();
                    string CreateBy_Line = row["CreateBy_Line"].ToString();
                    string CreateDate_Line = row["CreateDate_Line"].ToString();
                    string Pyramid_ID_Line = row["Pyramid_ID_Line"].ToString();
                    string CheckColumn_Line = row["CheckColumn_Line"].ToString();
                    /////////////////DotLine Command/////////////////////////////////////////////////////////////////////////////////
                    string RoleID_Command = row["RoleID_Command"].ToString();
                    string RefRoleID_Command = row["RefRoleID_Command"].ToString();
                    string Role_Command = row["Role_Command"].ToString();
                    string EmpNum_Command = row["EmpNum_Command"].ToString();
                    string EmpName_Command = row["EmpName_Command"].ToString();
                    string Dept_Command = row["Dept_Command"].ToString();
                    string Level_Emp_Command = row["Level_Emp_Command"].ToString();
                    string Position_Command = row["Position_Command"].ToString();
                    string SpecialGroup_Command = row["SpecialGroup_Command"].ToString();
                    string Remark_Command = row["Remark_Command"].ToString();
                    string CreateBy_Command = row["CreateBy_Command"].ToString();
                    string CreateDate_Command = row["CreateDate_Command"].ToString();
                    string Pyramid_ID_Command = row["Pyramid_ID_Command"].ToString();
                    string PicName = row["PicName"].ToString();



                    ListData.Add(new PyramidLine_JoinDotLineCommand
                    {
                        RoleID_Line = RoleID_Line,
                        RefRoleID_Line = RefRoleID_Line,
                        Role_Line = Role_Line,
                        EmpNum_Line = EmpNum_Line,
                        EmpName_Line = EmpName_Line,
                        Dept_Line = Dept_Line,
                        Level_Emp_Line = Level_Emp_Line,
                        Position_Line = Position_Line,
                        Acting_Line = Acting_Line,
                        ActingMain_Line = ActingMain_Line,
                        ActingType_Line = ActingType_Line,
                        SpecialGroup_Line = SpecialGroup_Line,
                        Remark_Line = Remark_Line,
                        CreateBy_Line = CreateBy_Line,
                        CreateDate_Line = CreateDate_Line,
                        Pyramid_ID_Line = Pyramid_ID_Line,
                        CheckColumn_Line = CheckColumn_Line,


                        //////////////////////////DotLine Command////////////////////////////////////////////////////////////////////////
                        RoleID_Command = RoleID_Command,
                        RefRoleID_Command = RefRoleID_Command,
                        Role_Command = Role_Command,
                        EmpNum_Command = EmpNum_Command,
                        EmpName_Command = EmpName_Command,
                        Dept_Command = Dept_Command,
                        Level_Emp_Command = Level_Emp_Command,
                        Position_Command = Position_Command,
                        SpecialGroup_Command = SpecialGroup_Command,
                        Remark_Command = Remark_Command,
                        CreateBy_Command = CreateBy_Command,
                        CreateDate_Command = CreateDate_Command,
                        Pyramid_ID_Command = Pyramid_ID_Command,

                        PicName = PicName

                    });

                }
            }



            return ListData;
        }

        [WebMethod]
        public static List<CountPerson> LoadCountPerson(String PyramidID)
        {

            List<CountPerson> ListData = new List<CountPerson>();
            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();
            string CountNormal = DBConn.getCountNormal(PyramidID);
            string CountActing = DBConn.getCountActing(PyramidID);
            string CountSub = DBConn.getCountSub(PyramidID);
            string CountSkip = DBConn.getCountSkip(PyramidID);
            string CountNew = DBConn.getCountNew(PyramidID);
            string CountReplace = DBConn.getCountReplace(PyramidID);

            ListData.Add(new CountPerson
            {
                CountNormal = CountNormal,
                CountActing = CountActing,
                CountSub = CountSub,
                CountSkip = CountSkip,
                CountNew = CountNew,
                CountReplace = CountReplace

            });




            return ListData;

        }






        [WebMethod]
        public static List<HeaderPyramid> ClonePyramid(String PyramidID, String CompanyCode, String Dept, String CreateBy)
        {

            List<HeaderPyramid> ListData = new List<HeaderPyramid>();
            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();

            DTData = DBConn.ClonePyramid(PyramidID, CompanyCode, Dept, CreateBy);


            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string DataPyramidID = row["PyramidID"].ToString();
                    string DataCompany = row["Company"].ToString();
                    string DataGroupPyramid = row["GroupPyramid"].ToString();
                    string DataDept = row["Dept"].ToString();
                    string DataRevision = row["Revision"].ToString();
                    string DataEffectDate = fn_.fn_ConvertDate(row["EffectDate"].ToString());

                    string Comp_Name = row["Comp_Name"].ToString();
                    string GroupName = row["GroupName"].ToString();
                    string DeptName = row["DeptName"].ToString();
                    string Stat = row["stat"].ToString();



                    ListData.Add(new HeaderPyramid
                    {
                        PyramidID = DataPyramidID,
                        Company = DataCompany,
                        GroupPyramid = DataGroupPyramid,
                        Dept = DataDept,
                        Revision = DataRevision,
                        EffectDate = DataEffectDate,
                        Comp_Name = Comp_Name,
                        GroupName = GroupName,
                        DeptName = DeptName,
                        Status = Stat,
                        msg = "Clone completed successfully !!"
                    });
                }
            }




            return ListData;

        }


        [WebMethod]
        public static List<Browse> LoadLocation(String Search)
        {
            ClassHRPortal DBConn = new ClassHRPortal();
            DataTable DTData = new DataTable();
            fn_All fn_ = new fn_All();

            DTData = DBConn.LoadLocation(Search.Trim());

            List<Browse> ListData = new List<Browse>();

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow row in DTData.Rows)
                {
                    string Code = row["Location"].ToString();
                    string Name = row["Desc_Location"].ToString();

                    ListData.Add(new Browse
                    {
                        Code = Code,
                        Name = Name,
                    });
                }
            }
            return ListData;
        }

        [WebMethod]
        public static void UpdateEmpHRPortalWithEmp(string emp_num)
        {
            ClassHRPortal DBConn = new ClassHRPortal();
            DBConn.UpdateEmpHRPortal("Employee",0,emp_num);

        }

        [WebMethod]
        public static void UpdateEmpHRPortalWithPyramid(string PyramidID)
        {
            ClassHRPortal DBConn = new ClassHRPortal();
            int PyramidID_INT = Int16.Parse(PyramidID);
            DBConn.UpdateEmpHRPortal("Pyramid", PyramidID_INT, "");

        }




    }
}