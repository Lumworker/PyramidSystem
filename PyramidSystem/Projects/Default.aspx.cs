using MobileTask.AppCode;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PyramidSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<ArrayList> TB_Pyramid_SpecialGroup()
        {
            return new ClassBrowseNew().TB_Pyramid_SpecialGroup();
        }
        [WebMethod]
        public static List<ArrayList> TB_Pyramid_Employee()
        {
            return new ClassBrowseNew().TB_Pyramid_Employee();
        }
        [WebMethod]
        public static List<ArrayList> TB_Pyramid_Company(string search)
        {
            return new ClassBrowseNew().TB_Pyramid_Company(search);
        }
        [WebMethod]
        public static List<ArrayList> TB_Pyramid_Group(string site_ref, string Comp_Code, string search)
        {
            return new ClassBrowseNew().TB_Pyramid_Group(site_ref, Comp_Code, search);
        }
        [WebMethod]
        public static List<ArrayList> TB_Pyramid_Dept(string site_ref, string CompCode, string GroupID, string search)
        {
            return new ClassBrowseNew().TB_Pyramid_Dept(site_ref, CompCode, GroupID, search);
        }
        [WebMethod]
        public static string SP_Pyramid_SpecialGroup(string Spc_Code, string PicName, string Action)
        {
            return new ClassBrowseNew().SP_Pyramid_SpecialGroup(Spc_Code, PicName, Action);
        }
        [WebMethod]
        public static string SP_Pyramid_Employee(string Emp_Num, string Emp_Name, string Action)
        {
            return new ClassBrowseNew().SP_Pyramid_Employee(Emp_Num, Emp_Name, Action);
        }
        [WebMethod]
        public static string SP_Pyramid_Company(string Comp_Code, string Comp_Name, string site_ref, string Action)
        {
            return new ClassBrowseNew().SP_Pyramid_Company(Comp_Code, Comp_Name, site_ref, Action);
        }
        [WebMethod]
        public static string SP_Pyramid_Group(string Group_ID, string GroupName, string Comp_Code, string site_ref, string Action)
        {
            return new ClassBrowseNew().SP_Pyramid_Group(Group_ID, GroupName, Comp_Code, site_ref, Action);
        }
        [WebMethod]
        public static string SP_Pyramid_Dept(int DeptID, string DeptCode, string DeptName, string site_ref, string CompCode, string GroupID, string Action)
        {
            return new ClassBrowseNew().SP_Pyramid_Dept(DeptID, DeptCode, DeptName, site_ref, CompCode, GroupID, Action);
        }
    }
}