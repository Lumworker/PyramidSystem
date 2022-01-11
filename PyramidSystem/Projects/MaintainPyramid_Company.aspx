<%@ Page Title="Maintain Pyramid Company" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintainPyramid_Company.aspx.cs" Inherits="PyramidSystem.Projects.MaintainPyramid_Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <style>
        .max-wide {
            max-width: 100%;
        }

        .datepicker {
            background: #333;
            border: 1px solid #555;
            color: #EEE;
        }

        .bg-color-white {
            background: #fff !important;
            border: 1px solid #555;
        }

        .nav-tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #fff;
        }

        .ui-datepicker {
            z-index: 2 !important;
        }

        .form-control {
            min-width: 100%;
        }

        .row-eq-height {
            display: -webkit-box;
            display: -webkit-flex;
            display: -ms-flexbox;
            display: flex;
        }

        input[type=checkbox] {
            -ms-transform: scale(2);
            -moz-transform: scale(2);
            -webkit-transform: scale(2);
            -o-transform: scale(2);
            transform: scale(2);
            padding: 10px;
        }

        .checkboxtext {
            font-size: 110%;
            display: inline;
        }

        @media only screen and (max-width: 990px) {
            .row-eq-height {
                display: -webkit-box;
                display: grid;
            }
        }

        .SelectLine, .SelectLine:focus {
            color: #f0ad4e;
            font-weight: bold;
        }

        .panel-body {
            padding: 8px;
        }
    </style>
    <div class="page-header">
        <h2>Maintain Pyramid Company</h2>
    </div>
    <div class="row">
        <div class="row-eq-height">
            <div class="col-md-6 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-9">
                                <h4>
                                    <strong>Main Company</strong>
                                </h4>
                            </div>
                            <div class="col-md-3 text-right">
                                <button type="button" class="btn btn-success btnComp Pos_Viewer" data-type="Insert">Add</button>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12" style="margin-left: 1px; margin-top: 20px; margin-bottom: 10px;">
                            <div class="col-md-3">
                                <span style="font-size: 15px">Search Company</span>
                            </div>
                            <div class="col-md-6">
                                <input type="text" id="SearchComp_Step1" class="form-control max-wide" placeholder="Search Comp" autocomplete="off">
                                <input type="text" id="SelectComp_Step1" class="form-control max-wide" placeholder="Search Comp" autocomplete="off" style="display:none" disabled>
                                <input type="text" id="Selectsite_ref_Step1" class="form-control max-wide" placeholder="Search Comp" autocomplete="off" style="display:none" disabled>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <table class="table table-hover" id="TableComp">
                                                    <thead>
                                                        <tr>
                                                            <th>site ref</th>
                                                            <th>Comp Code</th>
                                                            <th>Comp Name</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="ListComp">
                                                        <tr>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">ERP_HA</a></td>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">CHA</a></td>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">HEATAWAY COMPANY LIMITED</a></td>
                                                            <td>
                                                                <button type="button" class="btn btn-warning btnComp" data-type="Edit">Edit</button></td>
                                                        </tr>
                                                        <tr>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">ERP_ID</a></td>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">CID</a></td>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">PT. INDONESIA PATKOL SERVICE</a></td>
                                                            <td>
                                                                <button type="button" class="btn btn-warning btnComp" data-type="Edit">Edit</button></td>
                                                        </tr>
                                                        <tr>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">ERP_MM</a></td>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">CMM</a></td>
                                                            <td><a class="ClickComp_SelectStep1" href="javascript:void(0)">PATKOL MYANMAR CO., LTD.</a></td>
                                                            <td>
                                                                <button type="button" class="btn btn-warning btnComp" data-type="Edit">Edit</button></td>
                                                        </tr>
                                                        <%----- Mock Up Data -----%>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--END row-->
                    </div>
                </div>
            </div>
            <!--End  Comp-->
            <div class="col-md-6 col-xs-12" id="divMainGroup_Step2"  style="display:none" >
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-9">
                                <h4>
                                    <strong>Main Group : <span id="Title_TextHeaderMainGroup">CHA</span></strong>
                                </h4>
                            </div>
                            <div class="col-md-3 text-right">
                                <button Type="button" class="btn btn-success btnModalGroup Pos_Viewer" data-Type="Insert">Add</button>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12" style="margin-left: 1px; margin-top: 20px; margin-bottom: 10px;">
                            <div class="col-md-3">
                                <span style="font-size: 15px">Search Group</span>
                            </div>
                            <div class="col-md-6">
                                <input Type="text" id="SearchGroup_Step2" class="form-control max-wide" placeholder="Search Group" autocomplete="off">
                                <input Type="text" id="SelectGroup_Step2" class="form-control max-wide" placeholder="Search Group" autocomplete="off" style="display:none" disabled>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="table-responsive">
                                                        <table class="table table-hover" id="TableGroup">
                                                            <thead>
                                                                <tr>
                                                                    <th>Group ID</th>
                                                                    <th>Group Name</th>
                                                                    <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody id="ListGroup_Active">
                                                                <tr>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">GAG</a></td>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">Administrative Group</a></td>
                                                                    <td>
                                                                        <button type="button" class="btn btn-warning btnModalGroup" data-type="Edit">Edit</button></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">GEG</a></td>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">Executive Group</a></td>
                                                                    <td>
                                                                        <button type="button" class="btn btn-warning btnModalGroup" data-type="Edit">Edit</button></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">GHA</a></td>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">HEATAWAY</a></td>
                                                                    <td>
                                                                        <button type="button" class="btn btn-warning btnModalGroup" data-type="Edit">Edit</button></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">GMG</a></td>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">MANUFACTURING GROUP</a></td>
                                                                    <td>
                                                                        <button type="button" class="btn btn-warning btnModalGroup" data-type="Edit">Edit</button></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">GSG</a></td>
                                                                    <td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">Strategy Group</a></td>
                                                                    <td>
                                                                        <button type="button" class="btn btn-warning btnModalGroup" data-type="Edit">Edit</button></td>
                                                                </tr>

                                                                <%----- Mock Up Data -----%>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                        <!--END row-->
                    </div>
                </div>
            </div>
            <!--End Group-->
        </div>
        <!--row-eq-height-->
        <div class="row-eq-height">
            <div class="col-md-6 col-xs-12" id="divMaindept_Step3"  style="display:none">
                 <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-9">
                                <h4>
                                    <strong>Main Department : <span id="Title_TextHeaderMainDept">GAG</span></strong>
                                </h4>
                            </div>
                            <div class="col-md-3 text-right">
                                <button Type="button" class="btn btn-success btnModalDept Pos_Viewer" data-Type="Insert">Add</button>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12" style="margin-left: 1px; margin-top: 20px; margin-bottom: 10px;">
                            <div class="col-md-3">
                                <span style="font-size: 15px">Search Dept</span>
                            </div>
                            <div class="col-md-6">
                                <input Type="text" id="SearchDept_Step3" class="form-control max-wide" placeholder="Search Dept" autocomplete="off">
                                <input Type="text" id="SelectDept_Step3" class="form-control max-wide" placeholder="Search Dept" autocomplete="off" style="display:none" disabled>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="table-responsive">
                                                        <table class="table table-hover" id="TableDept">
                                                            <thead>
                                                                <tr>
                                                                    <th>Dept Code</th>
                                                                    <th>Dept Name</th>
                                                                    <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody id="ListDept">
                                                                <tr>
                                                                    <td><a href="javascript:void(0)">AF</a></td>
                                                                    <td><a href="javascript:void(0)">Accounting & Finance</a></td>
                                                                    <td><button Type="button" class="btn btn-warning btnModalDept" data-id="1" data-Type="Edit">Edit</button></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><a href="javascript:void(0)">HR</a></td>
                                                                    <td><a href="javascript:void(0)">Human Resource Management</a></td>
                                                                    <td><button Type="button" class="btn btn-warning btnModalDept" data-id="1" data-Type="Edit">Edit</button></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><a href="javascript:void(0)">IT</a></td>
                                                                    <td><a href="javascript:void(0)">Information Technology</a></td>
                                                                    <td><button Type="button" class="btn btn-warning btnModalDept" data-id="1" data-Type="Edit">Edit</button></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><a href="javascript:void(0)">LA</a></td>
                                                                    <td><a href="javascript:void(0)">Lagel</a></td>
                                                                    <td><button Type="button" class="btn btn-warning btnModalDept" data-id="1" data-Type="Edit">Edit</button></td>
                                                                </tr>
                                                                <tr>
                                                                    <td><a href="javascript:void(0)">SC</a></td>
                                                                    <td><a href="javascript:void(0)">Supply Chain</a></td>
                                                                    <td><button Type="button" class="btn btn-warning btnModalDept" data-id="1" data-Type="Edit">Edit</button></td>
                                                                </tr>

                                                                <%----- Mock Up Data -----%>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                        <!--END row-->
                    </div>
                </div>
            </div>
            <!--End Main size-->
        </div>
        <!--row-eq-height-->
    </div>
    <%--End Page 3step Panal--%>

    <div class="modal fade" id="ModalComp" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em;">
                            <div class="col-md-7 col-sm-12">
                                <h4 class="modal-title"><span id="textModalComp"> </span>Comp</h4>
                            </div>
                            <div class="col-md-5 col-sm-12" style="text-align: right;">
                                <button type="button" class="btn btn-success Pos_Viewer" id="btnSaveComp" data-action="">Save</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: auto; max-height: 28em; max-width: 100%;">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            
                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;" >
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <label class="control-label" style="font-size: 13px">Site Ref :</label>
                                </div>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <input type="text" id="textCompSiteref" class="form-control " style="min-width: 100%" autocomplete="off" />
                                </div>
                            </div>
                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <label class="control-label" style="font-size: 13px">Comp Code:</label>
                                </div>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <input type="text" id="textCompCode" class="form-control max-wide" autocomplete="off">
                                </div>
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <label class="control-label" style="font-size: 13px">Comp Name :</label>
                                </div>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <input type="text" id="textCompName" class="form-control " style="min-width: 100%" autocomplete="off" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <%--Browse Comp Insert/Edit--%>

    <div class="modal fade" id="ModalGroup" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em;">
                            <div class="col-md-7 col-sm-12">
                                <h4 class="modal-title"><span id="textModalGroup"> </span>Group</h4>
                            </div>
                            <div class="col-md-5 col-sm-12" style="text-align: right;">
                                <button Type="button" class="btn btn-success Pos_Viewer" id="btnSaveGroup" data-action="">Save</button>
                                <button Type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: auto; max-height: 28em; max-width: 100%;">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <label class="control-label" style="font-size: 13px">Group Code:</label>
                                </div>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <input Type="text" id="textGroupCode" class="form-control max-wide" autocomplete="off" />
                                </div>
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <label class="control-label" style="font-size: 13px">Group Name :</label>
                                </div>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <input Type="text" id="textGroupName" class="form-control max-wide" autocomplete="off" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <%--Browse Group Insert/Edit--%>

    <div class="modal fade" id="ModalDept" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em;">
                            <div class="col-md-7 col-sm-12">
                                <h4 class="modal-title"><span id="textModalDept"> </span>Dept</h4>
                            </div>
                            <div class="col-md-5 col-sm-12" style="text-align: right;">
                                <button type="button" class="btn btn-success Pos_Viewer" id="btnSaveDept" data-action="">Save</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: auto; max-height: 28em; max-width: 100%;">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <label class="control-label" style="font-size: 13px">Dept Code:</label>
                                </div>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <input type="text" id="textDeptCode" class="form-control max-wide" autocomplete="off"  >
                                </div>
                            </div>

                            <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                                <div class="col-md-3 col-sm-3 col-xs-12">
                                    <label class="control-label" style="font-size: 13px">Dept Name :</label>
                                </div>
                                <div class="col-md-9 col-sm-9 col-xs-12">
                                    <input type="text" id="textDeptName" class="form-control max-wide"  autocomplete="off" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <%--Browse Dept Insert/Edit--%>





    <script type="text/javascript">
        $(document).ready(function () {
            
            var TableComp = $("#TableComp").DataTable({
                searching: false,
                "bInfo": true,
                "paging": true,
                "info": false,
            });

            var TableGroup = $("#TableGroup").DataTable({
                searching: false,
                "bInfo": true,
                "paging": true,
                "info": false
            });

            var TableDept = $("#TableDept").DataTable({
                searching: false,
                "bInfo": true,
                "paging": true,
                "info": false
            });
            Get_TableComp('');


            $(document).on('change', '#SearchComp_Step1', function () {
                var search = $(this).val();
                Get_TableComp(search);
            });


            $(document).on('change', '#SearchGroup_Step2', function () {
                var search = $(this).val();
                var Comp_Code = $("#SelectComp_Step1").val();
                var site_ref = $("#Selectsite_ref_Step1").val();
                console.log(Comp_Code);
                console.log(site_ref);
                GET_TableGroup(site_ref,Comp_Code,search) ;
            });
 
            $(document).on('change', '#SearchDept_Step3', function () {
                var search = $(this).val();
                var site_ref = $("#Selectsite_ref_Step1").val();
                var CompCode = $("#SelectComp_Step1").val();
                var GroupID = $("#SelectGroup_Step2").val();

                Get_TableDept(site_ref, CompCode, GroupID, search)
            });
        

            $(document).on('click', '.ClickComp_SelectStep1', function () {
                $("#ListComp").find("tr").find("td").find("a").removeClass("SelectLine");
                var row = $(this).closest("tr");
                var site_ref = row.find("td:nth-child(1)").text();
                var Comp_Code = row.find("td:nth-child(2)").text();
                $("#Title_TextHeaderMainGroup").text( site_ref + " / " + Comp_Code);
                row.find("td").find("a").addClass("SelectLine");
                $("#SelectComp_Step1").val(Comp_Code);
                $("#Selectsite_ref_Step1").val(site_ref);
                $("#SelectGroup_Step2").val('');
                //Set Value
                $('.nav-tabs a[href="#Type_Active"]').tab('show');
                //Set Default Tab1 
                GET_TableGroup(site_ref,Comp_Code,'')
                $("#divMainGroup_Step2").show();
                $("#divMaindept_Step3").hide();
                //LoadData
            });

            $(document).on('click', '.ClickGroup_SelectStep2', function () {
                var row = $(this).closest("tr");
                row.find("td").find("a").addClass("SelectLine");
                var row = $(this).closest("tr");
                var site_ref = $("#Selectsite_ref_Step1").val();
                var CompCode = $("#SelectComp_Step1").val();
                var GroupID = row.find("td:nth-child(1)").text();
                
                $("#Title_TextHeaderMainDept").text( site_ref + " / " + CompCode +" / "+GroupID);
                $("#SelectGroup_Step2").val(GroupID);
                //Set Default Tab1 
                Get_TableDept(site_ref, CompCode, GroupID, '')
                $("#divMaindept_Step3").show();
                //LoadData
            });

           
            $(document).on('click', '.btnComp', function () {
                var type = $(this).attr("data-type");
                if (type == "Insert") {
                    $("#textCompCode").val('');
                    $("#textCompName").val('');
                    $("#textCompSiteref").val('');
                    $("#textCompCode").prop("disabled", false);
                    $("#textCompSiteref").prop("disabled", false);
                } else if (type == "Edit") {
                    var row = $(this).closest("tr");
                    var siteRef = row.find("td:nth-child(1)").text();
                    var CompCode = row.find("td:nth-child(2)").text();
                    var CompName = row.find("td:nth-child(3)").text();
                    $("#textCompCode").val(CompCode);
                    $("#textCompName").val(CompName);
                    $("#textCompSiteref").val(siteRef);
                    $("#textCompCode").prop("disabled", true);
                    $("#textCompSiteref").prop("disabled", true);
                }
                $("#btnSaveComp").attr("data-action", type);
                $("#textModalComp").text(type)
                $("#ModalComp").modal("show");
            });

            $(document).on('click', '.btnModalGroup', function () {
                var type = $(this).attr("data-type");
                if (type == "Insert") {
                    $("#textGroupCode").prop('disabled', false)
                    $("#textGroupCode").val('');
                    $("#textGroupName").val('');
                } else if (type == "Edit") {
                    var row = $(this).closest("tr");
                    var textTypeCode = row.find("td:nth-child(1)").text();
                    var textTypeName = row.find("td:nth-child(2)").text();
                    $("#textGroupCode").val(textTypeCode);
                    $("#textGroupName").val(textTypeName);
                    $("#btnSaveGroup").attr("data-action", type);
                    $("#textGroupCode").prop('disabled', true)
                }
                $("#btnSaveGroup").attr("data-action", type);
                $("#textModalGroup").text(type)
                $("#ModalGroup").modal("show");
            });

            $(document).on('click', '.btnModalDept', function () {
                var type = $(this).attr("data-type");
                if (type == "Insert") {
                    $("#textDeptCode").val('');
                    $("#textDeptName").val('');
                    $("#textDeptCode").prop("disabled",false)
                    $("#SelectDept_Step3").val(0);
                } else if (type == "Edit") {
                    var ID = $(this).attr("data-id");
                    var row = $(this).closest("tr");
                    var textDeptCode = row.find("td:nth-child(1)").text();
                    var textDeptName = row.find("td:nth-child(2)").text();
                    $("#textDeptCode").val(textDeptCode);
                    $("#textDeptName").val(textDeptName);
                    $("#textDeptCode").prop("disabled",true)
                    console.log('Edit');
                    $("#SelectDept_Step3").val(ID);
                }
                $("#btnSaveDept").attr("data-action", type);
                $("#textModalDept").text(type);
                $("#ModalDept").modal("show");
            });



            $(document).on('click', '#btnSaveComp', function () {
                var Comp_Code = $("#textCompCode").val();
                var Comp_Name = $("#textCompName").val();
                //var Comp_Name = $('#textCompSiteref option:selected').attr("data-compname");
                var site_ref = $("#textCompSiteref").val();
                var Action = $(this).attr("data-action");
                console.log(Comp_Code)
                console.log(Comp_Name)
                console.log(site_ref)
                console.log(Action)
                if (site_ref != "" && Comp_Code != "" && site_ref != "" && Comp_Name != ""&& Action != "") {
                     SaveComp(Comp_Code, Comp_Name, site_ref, Action)
                } else {
                    swal('Error', 'กรุณากรอกข้อมูลให้ครบถ้วน', 'error');
                }
            });
            
            $(document).on('click', '#btnSaveGroup', function () {
                var Group_ID = $("#textGroupCode").val();
                var GroupName = $("#textGroupName").val();
                var Comp_Code = $("#SelectComp_Step1").val();
                var site_ref = $("#Selectsite_ref_Step1").val();
                var Action = $(this).attr("data-action");
                console.log(Group_ID)
                console.log(GroupName)
                console.log(Comp_Code)
                console.log(site_ref)
                console.log(Action)
                if (Group_ID != "" && GroupName != "" && Comp_Code != ""  && site_ref != "" && Action != "") {
                    SaveGroup(Group_ID, GroupName, Comp_Code, site_ref, Action);
                } else {
                    swal('Error', 'กรุณากรอกข้อมูลให้ครบถ้วน', 'error');
                }
            });

            
           
            $(document).on('click', '#btnSaveDept', function () {
                var DeptID = $("#SelectDept_Step3").val();
                var DeptCode = $("#textDeptCode").val();
                var DeptName = $("#textDeptName").val();
                var site_ref = $("#Selectsite_ref_Step1").val();
                var CompCode = $("#SelectComp_Step1").val();
                var GroupID = $("#SelectGroup_Step2").val();
                var Action = $(this).attr("data-action");
                console.log(DeptID)
                console.log(DeptCode)
                console.log(DeptName)
                console.log(site_ref)
                console.log(CompCode)
                console.log(GroupID)
                console.log(Action)
                if (site_ref != "" && CompCode != "" && GroupID != "" && DeptID !="" && DeptCode != "" && DeptName != "" ) {
                    SaveDept( DeptID,  DeptCode,  DeptName,  site_ref,  CompCode,  GroupID,  Action) 
                } else {
                    swal('Error', 'กรุณากรอกข้อมูลให้ครบถ้วน', 'error');
                }
            });
        

            function SaveComp(Comp_Code, Comp_Name, site_ref, Action) {
                $.ajax({
                    type: "post",
                    async: false,
                    url: "<%= ResolveUrl("Default.aspx/SP_Pyramid_Company") %>",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({ Comp_Code: Comp_Code, Comp_Name: Comp_Name, site_ref: site_ref, Action: Action }),
                    success: function (response) {
                        let Msg = response.d;
                        if (Msg == "Already have Company Code or Site ref") {
                            swal('Error', Msg, 'error');
                        } else {
                          swal('Complete', '', 'success');
                       $("#ModalComp").modal("hide");
                        }
                        Get_TableComp('');
                    }
                });
            }
            
            
            function SaveGroup(Group_ID, GroupName,Comp_Code, site_ref, Action) {
                $.ajax({
                    type: "post",
                    async: false,
                    url: "<%=ResolveUrl("Default.aspx/SP_Pyramid_Group")%>",
                    contentType: "application/json; charset = utf-8",
                    dataType: "json",
                    data: JSON.stringify({ Group_ID: Group_ID, GroupName: GroupName, Comp_Code: Comp_Code, site_ref: site_ref,Action:Action }),
                    success: function (response) {
                        let Msg = response.d;
                         if (Msg == "Already have Group ID") {
                            swal('Error', Msg, 'error');
                        } else {
                          swal('Complete', '', 'success');
                         $("#ModalGroup").modal("hide");
                        }
                         GET_TableGroup(site_ref,Comp_Code,'');
                    }
                });
            }

            function SaveDept( DeptID,  DeptCode,  DeptName,  site_ref, CompCode,  GroupID,  Action) {

                $.ajax({
                    type: "post",
                    async: false,
                    url: "<%=ResolveUrl("Default.aspx/SP_Pyramid_Dept")%>",
                    contentType: "application/json; charset = utf-8",
                    dataType: "json",
                    data: JSON.stringify({ DeptID:DeptID,  DeptCode:DeptCode,  DeptName:DeptName,  site_ref:site_ref,  CompCode:CompCode,  GroupID:GroupID,  Action:Action}),
                    success: function (response) {
                        let Msg = response.d;
                         if (Msg == "Already have Department ID") {
                            swal('Error', Msg, 'error');
                        } else {
                          swal('Complete', '', 'success');
                          $("#ModalDept").modal("hide");
                        }
                        Get_TableDept(site_ref, CompCode, GroupID, '');
                    }
                });
            }
        

            function Get_TableComp(search) {
                TableComp.clear().draw();
                var selected = $("#SelectComp_Step1").val()
                $.ajax({
                    type: "post",
                    async: false,
                    url: "<%= ResolveUrl("Default.aspx/TB_Pyramid_Company") %>",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({}),
                    data: JSON.stringify({ search: search }),
                    success: function (response) {
                        if (response.d.length > 0) {
                            $.each(response.d, function (index, val) {
                                //[Comp_Code],[Comp_Name],[site_ref] 
                                var CompCode = val[0];
                                var CompName = val[1];
                                var siteref = val[2];
                                var column_CompCode = "";
                                var column_CompName = "";
                                if (CompCode == selected) {
                                     column_siteref = '<td><a class="ClickComp_SelectStep1 SelectLine" href="javascript:void(0)">' + siteref + '</a></td>'
                                     column_CompCode = '<td><a class="ClickComp_SelectStep1 SelectLine" href="javascript:void(0)">' + CompCode + '</a></td>'
                                     column_CompName = '<td><a class="ClickComp_SelectStep1 SelectLine" href="javascript:void(0)">' + CompName + '</a></td>'
                                } else {
                                     column_siteref = '<td><a class="ClickComp_SelectStep1" href="javascript:void(0)">' + siteref + '</a></td>'
                                     column_CompCode = '<td><a class="ClickComp_SelectStep1 " href="javascript:void(0)">' + CompCode + '</a></td>'
                                     column_CompName = '<td><a class="ClickComp_SelectStep1 " href="javascript:void(0)">' + CompName + '</a></td>'
                                }
                                    TableComp.row.add([
                                        column_siteref,
                                        column_CompCode,
                                        column_CompName,
                                        '<td> <button type="button" class="btn btn-warning btnComp Pos_Viewer" data-type="Edit">Edit</button></td>',
                                        '<td><button type="button" class="btn btn-danger btndeleteComp Pos_Viewer">Delete</button></td>',
                                    ]).draw(false);
                            });
                        }
                        $("#IMGUpload").modal("hide");
                        //Pos_Viewer();
                    }
                });
            }
        
            function GET_TableGroup(site_ref,Comp_Code,search) {
                TableGroup.clear().draw();
                var selected = $("#SelectGroup_Step2").val();
                $.ajax({
                    type: "post",
                    async: false,
                    url: "<%= ResolveUrl("Default.aspx/TB_Pyramid_Group") %>",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({site_ref:site_ref, Comp_Code: Comp_Code ,search:search}),
                    success: function (response) {
                        if (response.d.length > 0) {
                            $.each(response.d, function (index, val) {
                                //[site_ref],[Comp_Code],[Group_ID],[GroupName] 
                                var site_ref = val[0];
                                var Comp_Code = val[1];
                                var Group_ID = val[2];
                                var GroupName = val[3];
                                
                                var column_Group_ID = "";
                                var column_GroupName = "";
                                //Set Icon Calibration
                                if (Group_ID == selected) {
                                     column_Group_ID = '<td><a class="ClickGroup_SelectStep2 SelectLine"   href="javascript:void(0)">' + Group_ID + '</a></td>'
                                     column_GroupName = '<td><a class="ClickGroup_SelectStep2 SelectLine"   href="javascript:void(0)">' + GroupName + '</a></td>'
                                } else {
                                     column_Group_ID = '<td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">' + Group_ID + '</a></td>'
                                     column_GroupName = '<td><a class="ClickGroup_SelectStep2" href="javascript:void(0)">' + GroupName + '</a></td>'
                                }
                                //Set ColumnName
                                    TableGroup.row.add([
                                        column_Group_ID,
                                        column_GroupName,
                                        '<td> <button type="button" class="btn btn-warning btnModalGroup Pos_Viewer" data-type="Edit">Edit</button></td>',
                                        '<td><button type="button" class="btn btn-danger btndeleteGroup Pos_Viewer" >Delete</button></td>',
                                    ]).draw(false);
                                
                                //Add To Table
                            });
                        }
                        $("#IMGUpload").modal("hide");
                        //Pos_Viewer();
                    }
                });
            }
            
            
            function Get_TableDept(site_ref,CompCode,GroupID,search) {
                TableDept.clear().draw();
                $.ajax({
                    type: "post",
                    async: false,
                    url: "<%= ResolveUrl("Default.aspx/TB_Pyramid_Dept") %>",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({ site_ref:site_ref,CompCode:CompCode,GroupID:GroupID,search:search }),
                    success: function (response) {
                        if (response.d.length > 0) {
                            $.each(response.d, function (index, val) {
                                // [DeptID],[DeptCode],[DeptName],[site_ref],[CompCode],[GroupID]
                                var DeptID = val[0];
                                var DeptCode = val[1];
                                var DeptName = val[2];
                                var site_ref = val[3];
                                var CompCode = val[4];
                                var GroupID = val[5];
                                    TableDept.row.add([
                                        DeptCode,
                                        DeptName,
                                        '<td><button type="button" class="btn btn-warning btnModalDept Pos_Viewer" data-id="' + DeptID + '" data-type="Edit">Edit</button></td>',
                                        '<td><button type="button" class="btn btn-danger btndeleteDept Pos_Viewer" >Delete</button></td>',
                                    ]).draw(false);
                                
                            });
                        }
                        $("#IMGUpload").modal("hide");
                        //Pos_Viewer();
                    }
                });
            }


 <%--  
            function Pos_Viewer() {
                var CheckPage = CheckPermission('Maintain Master');
                if (CheckPage == "") {
                    $(".Pos_Viewer").hide();
                    swal({
                        title: 'Error',
                        text: "ไม่มีสิทธิ ในการใช้งาน",
                        icon: 'error',
                        buttons: {
                            confirm: true,
                        },
                    }).then(function () {
                        window.location.href = "http://portalapp01/PersonalWorkspace/";
                    })
                } else if (CheckPage == "Viewer")  {
                    $(".Pos_Viewer").hide();
                }
            }

            --%>
        });

        
        

    </script>
</asp:Content>
