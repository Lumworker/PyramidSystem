namespace PyramidSystem.Projects
{
    public class Department
    {
    }

    public class Browse
    {
        public string Code;
        public string Name;
        public string Uf_Jobtitle;
        public string Path;
        public string DeptCode;
    }
    public class Employee
    {
        public string SiteRef;
        public string EmpCode;
        public string Fullname;
        public string FullnameEN;
        public string JobTitle;
        public string Emp_StatusDesc;
        public string Gender;
        public string Birth_Date;
        public string Location;
        public string OfficePhone;
        public string Extension;
        public string Mobile;
        public string eMail;
        public string Division;
        public string costcenter;
        public string Level;
        public string ManagerName;
        public string ManagerID;
        public string Startdate;
        public string Enddate;
        public string address;
        public string zip;
        public string state;
        public string County;
        public string PhotoEmp;
        public string Uf_JobTitleEN;
        public string job_id;
    }

    public class alert
    {
        public string msg;
    }

    public class CountPerson
    {
        public string CountNormal;
        public string CountActing;
        public string CountSub;
        public string CountSkip;
        public string CountNew;
        public string CountReplace;
    }

    public class HeaderPyramid
    {

        public string PyramidID;
        public string Company;
        public string GroupPyramid;
        public string Dept;
        public string Revision;
        public string EffectDate;
        public string CreateBy;
        public string CreateDate;
        public string Comp_Name;
        public string GroupName;
        public string DeptName;
        public string Status;
        public string msg;



    }




    public class PyramidLine
    {
        public string RefRoleID;
        public string RoleID;
        public string Role;
        public string EmpNum;
        public string EmpName;
        public string Dept;
        public string Level_Emp;
        public string Position;
        public string Acting;
        public string ActingType;
        public string SpecialGroup;
        public string Remark;
        public string CreateBy;
        public string Pyramid_ID;
        public string MsgReturn;
        public string Path;
        public string CheckColumn;
        public string ActingMain;

    }

    public class PyramidLine_JoinDotLineCommand
    {
        public string RoleID_Line;
        public string RefRoleID_Line;
        public string Role_Line;
        public string EmpNum_Line;
        public string EmpName_Line;
        public string Dept_Line;
        public string Level_Emp_Line;
        public string Position_Line;
        public string Acting_Line;
        public string ActingMain_Line;
        public string ActingType_Line;
        public string SpecialGroup_Line;
        public string Remark_Line;
        public string CreateBy_Line;
        public string CreateDate_Line;
        public string Pyramid_ID_Line;
        public string CheckColumn_Line;
        public string Position_Code_Line;

        public string RoleID_Command;
        public string RefRoleID_Command;
        public string Role_Command;
        public string EmpNum_Command;
        public string EmpName_Command;
        public string Dept_Command;
        public string Level_Emp_Command;
        public string Position_Command;
        public string SpecialGroup_Command;
        public string Remark_Command;
        public string CreateBy_Command;
        public string CreateDate_Command;
        public string Pyramid_ID_Command;
        public string Position_Code_Command;

        public string PicName;
        public string Path;
        public string Dept;

        public string Level_Emp;
        public string Level_acting;

        public string Company;

        public string Dept_Real;
        public string Level_Emp_Real;
        public string Position_Real;
        public string PositionEN_Real;
    }



    public class SummaryData {

        public string CompanyCode;
        public string GroupPyramid;
        public string Division;
        public string Costcerter;
        public  string Location;
        public  string Level;
        public  string EmpStatus;
        public string ManPower;

    }



   


}