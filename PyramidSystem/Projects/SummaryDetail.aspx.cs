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
    public partial class SummaryDetail : System.Web.UI.Page
    {
        string Username, Dept = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            fn_All fn = new fn_All();
            Username = fn.GetUser();
            Dept = fn.getLogonCost_Center();
            //string subDept = Dept.Substring(1, 2);
            //lblCostCenter.Text = subDept;
        }


        [WebMethod]
        public static List<SummaryData> LoadSummaryDetail(string CompanyCode, string GroupPyramid, string Division, string Costcerter, string Location, string Level, string EmpStatus)
        {

            List<SummaryData> ListData = new List<SummaryData>();

            ClassHRPortal DBConn = new ClassHRPortal();


            DataTable DTData = new DataTable();

            DTData = DBConn.SeacrhSummaryDetail(CompanyCode.Trim(), GroupPyramid.Trim(), Division.Trim(), Costcerter.Trim(), Location.Trim(), Level.Trim(), EmpStatus.Trim());

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow r in DTData.Rows)
                {

                    string CompanyCode_ = r["Comp_Name"].ToString();
                    string GroupPyramid_ = r["GroupName"].ToString();
                    string Division_ = r["Division"].ToString();
                    string Costcerter_ = r["Dept"].ToString();
                    string Location_ = r["Location"].ToString();
                    string Level_ = r["Level_Emp"].ToString();
                    string EmpStatus_ = r["EmpType"].ToString();
                    string ManPower_ = r["EmpQty"].ToString();





                    ListData.Add(new SummaryData
                    {
                        CompanyCode = CompanyCode_,
                        GroupPyramid = GroupPyramid_,
                        Division = Division_,
                        Costcerter = Costcerter_,
                        Location = Location_,
                        Level = Level_,
                        EmpStatus = EmpStatus_,
                        ManPower = ManPower_

                    });

                }


            }


            return ListData;


        }




        [WebMethod]
        public static List<List<ArrayList>> GetExport(String CompanyCode, String GroupPyramid, String Division, String Costcerter, String Location, String Level, String EmpStatus)
        {
            return new ClassHRPortal().GetExport_SummaryDetail(CompanyCode, GroupPyramid, Division, Costcerter, Location, Level, EmpStatus);
        }




    }
}