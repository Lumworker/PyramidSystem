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
    public partial class Summary : System.Web.UI.Page
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
        public static List<SummaryData> LoadSummary(string CompanyCode, string GroupPyramid, string Division,  string Level, string EmpStatus)
        {

            List<SummaryData> ListData = new List<SummaryData>();

            ClassHRPortal DBConn = new ClassHRPortal();


            DataTable DTData = new DataTable();

            DTData = DBConn.SeacrhSummary(CompanyCode.Trim(), GroupPyramid.Trim(), Division.Trim() ,Level.Trim(), EmpStatus.Trim());

            if (DTData.Rows.Count > 0)
            {
                foreach (DataRow r in DTData.Rows)
                {
                    

                    string CompanyCode_ = r["Comp_Name"].ToString();
                    string GroupPyramid_ = r["GroupName"].ToString(); 
                    string Costcerter_ = r["Dept"].ToString(); 
                    string Level_ = r["Level_Emp"].ToString();
                    string EmpStatus_ = r["EmpType"].ToString();
                    string ManPower_ = r["EmpQty"].ToString();


                    ListData.Add(new SummaryData
                    {
                        CompanyCode = CompanyCode_,
                        GroupPyramid = GroupPyramid_,
                        Costcerter = Costcerter_,
                        Level = Level_,
                        EmpStatus = EmpStatus_,
                        ManPower = ManPower_

                    });

                }


            }


            return ListData;


        }



    }
}