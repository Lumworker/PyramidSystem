<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreviewPyramid.aspx.cs" Inherits="PyramidSystem.Projects.PreviewPyramid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- <script src="js-orgChart-master/js-orgchart.js"></script>
    <link href="js-orgChart-master/js-orgchart.css" type="text/css" rel="stylesheet" />--%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <%--    <script src="../js-orgChart-master/js-orgchart.js"></script>
    <link href="../js-orgChart-master/js-orgchart.css" rel="stylesheet" />--%>


   <%--  <div class="loading" id="loading" style=" text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 999; background-color: #ffffff; opacity: 0.1;">
        <img src="../img/Spin.gif" style="position: absolute; left: 50%; top: 10%; bottom: 0; margin: auto; width: 70px; height: 70px;" />
    </div>--%>

     <div class="loading" id="loading">
        <img src="../img/Spin.gif" style="position: absolute; left: 50%; top: 10%; bottom: 0; margin: auto; width: 70px; height: 70px;" />
    </div>

    <div class="container">
        <div class="col-md-12">
            <div class='page-header'>
                <div class='btn-toolbar pull-right'>
                    <div class="btn-group">
                        <button type="button" class="btn btn-primary" id="btnBrowse" style="width: 90px">Search <i class="fa fa-search" aria-hidden="true"></i></button>
                    </div>
                </div>
                <h3>Organization Chart (Pyramid) <i class="fa fa-sitemap" aria-hidden="true"></i></h3>
            </div>
        </div>
        <br>

        <div class="row">
            <div class="col-md-12">
                <div class="col-md-6">
                    <span id="lblPyramidID" style="display: none"></span>
                    <div class="form-group">
                        <label class="col-lg-4 control-label">Company  :</label>
                        <div class="col-lg-8">
                            <span id="lblCompanyCode" style="display: none"></span>
                            <span id="lblCompany"></span>
                        </div>
                    </div>
                    <hr class="gradient_line" />

                    <div style="clear: both; height: 1px"></div>
                    <div class="form-group">
                        <label class="col-lg-4 control-label">Department :</label>
                        <div class="col-lg-8">
                            <span id="lblDeptID" style="display: none"></span>
                            <span id="lblDept"></span>
                        </div>
                    </div>
                    <hr class="gradient_line" />
                    <div style="clear: both; height: 1px"></div>

                    <%-- <div class="form-group">
                        <label class="col-lg-4 control-label">Effect Date :</label>
                        <div class="col-lg-8">
                            <span id="lblEffectDate"></span>
                        </div>
                    </div>

                    <hr class="gradient_line" />
                    <div style="clear: both; height: 1px"></div>--%>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-lg-4 control-label">Group :</label>
                        <div class="col-lg-8">
                            <span id="lblGroupID" style="display: none"></span>
                            <span id="lblGroup"></span>
                        </div>
                    </div>
                    <hr class="gradient_line" />
                    <div style="clear: both; height: 1px"></div>
                    <div class="form-group">
                        <label class="col-lg-4 control-label">Effect Date :</label>
                        <div class="col-lg-8">
                            <span id="lblEffectDate"></span>
                        </div>
                    </div>

                    <hr class="gradient_line" />
                    <div style="clear: both; height: 1px"></div>


                    <%--    <div class="form-group">
                        <label class="col-lg-4 control-label">Status :</label>
                        <div class="col-lg-8">
                            <span id="lblStatus"></span>
                        </div>
                    </div>

                    <hr class="gradient_line" />
                    <div style="clear: both; height: 1px"></div>--%>
                </div>
            </div>
        </div>


        <div id="PanelOrgChart" style="display: none">
            <div class="row">
                <div class="col-md-12">
                   <%-- <div style="background-color: #a3a3a3; height: 20px; width: 20px; float: right; margin-top: 18px"></div>
                    &nbsp;&nbsp;<h5 style="margin-top: 20px; float: right">&nbsp;&nbsp;&nbsp;Skip&nbsp;&nbsp;</h5>--%>

                    <div style="background-color: #dd5695; height: 20px; width: 20px; float: right; margin-top: 18px"></div>
                    <h5 style="margin-top: 20px; float: right">&nbsp;&nbsp;&nbsp;Subcontractor&nbsp;&nbsp;</h5>

                    <div style="background-color: #eea236; height: 20px; width: 20px; float: right; margin-top: 18px"></div>
                    &nbsp;&nbsp;<h5 style="margin-top: 20px; float: right">&nbsp;&nbsp;&nbsp;Acting&nbsp;&nbsp;</h5>

                    <div style="background-color: #36add1; height: 20px; width: 20px; float: right; margin-top: 18px"></div>
                    <h5 style="margin-top: 20px; float: right">Active&nbsp;&nbsp;</h5>

                </div>
            </div>

            <br />

            <div class="row">
                <div class="chart" style="padding:20px 20px 20px 20px">
                    <div id="chart_div" style="width:500px">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="ModalPyramid" class="modal modal-wide fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Pyramid : Search Data &nbsp;<i class="fa fa-folder-open" aria-hidden="true"></i></h4>
                </div>
                <div class="modal-body" style="overflow-y: auto; max-height: calc(100vh - 230px);">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-xs-4">
                                                <p>Company</p>
                                            </div>
                                            <div class="col-md-9 col-xs-8">
                                                <select id="SelectCompany_S" class="form-control" style="max-width: 500px;">
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-xs-4">
                                                <p>Group</p>
                                            </div>
                                            <div class="col-md-9 col-xs-8">
                                                <div class="input-group">
                                                    <span style="display: none" id="lblGroup_S"></span>
                                                    <input type="text" id="txtGroup_S" class="form-control" style="max-width: 100%" placeholder="Search">
                                                    <div class="input-group-btn">
                                                        <button class="btn btn-default" id="btnGroup_S" type="button" data-toggle="modal" data-target="#ModalSearchGroup" data-backdrop="false">
                                                            <i class="glyphicon glyphicon-search"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-xs-4">
                                                <p>Department </p>
                                            </div>
                                            <div class="col-md-9 col-xs-8">

                                                <span id="lblDept_S" style="display: none"></span>
                                                <div class="input-group">
                                                    <input type="text" id="txtDept_S" class="form-control" style="max-width: 100%" placeholder="Search">
                                                    <div class="input-group-btn">
                                                        <button class="btn btn-default" id="btnDept_S" type="button">
                                                            <i class="glyphicon glyphicon-search"></i>
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <%-- <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-xs-4">
                                                <p>Revision </p>
                                            </div>
                                            <div class="col-md-9 col-xs-8">
                                                <input type="text" id="txtRevision_S" onkeypress="return isNumberKey(event)" class="form-control" style="max-width: 100%" placeholder="Please insert number">
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                        <%-- <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-xs-4">
                                                <p>Status</p>
                                            </div>

                                            <div class="col-md-9 col-xs-8">
                                                <select class="form-control" id="SelectStatus_S" style="max-width: 100%">
                                                    <option value="">-- All --</option>
                                                    <option value="Draft">Draft</option>
                                                    <option value="Active">Active</option>
                                                    <option value="InActive">InActive</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                        </div>--%>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-xs-4">
                                            </div>
                                            <div class="col-md-9 col-xs-8">
                                                <button type="button" class="btn btn-primary" id="btnSearch_S" style="width: 180px;">Search&nbsp;<i class="fa fa-search" aria-hidden="true"></i></button></center>            
                                                  <button type="button" class="btn btn-warning" id="btnClear_S" style="width: 180px;">Clear</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                        </div>


                        <br>
                        <div class="row">
                            <div class="col-md-12">
                                <center>
                        <table class="table table-bordered table-striped table-hover" id="TableSearchPyramid" >
                            <thead>
                                <tr>
                                    <th>Company</th>
                                    <th>Group</th>
                                    <th>Dept</th>     
                                   <%-- <th>Revision</th>--%>
                                    <th>Effect Date</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody id="bodyTableSearchPyramid">         
                            </tbody>
                        </table></center>
                            </div>
                        </div>
                        <br>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalSearchGroup" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Group Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchGroup" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchGroup" class="table table-bordered table-responsive">
                        <thead id="Thead9" runat="server">
                            <tr>

                                <th>Code</th>
                                <th>Name </th>

                            </tr>
                        </thead>
                        <tbody id='Group_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalSearchDept_S" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Department Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchDept_S" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchDept_S" class="table table-bordered table-responsive">
                        <thead id="Thead3" runat="server">
                            <tr>

                                <th>Code</th>
                                <th>Name </th>

                            </tr>
                        </thead>
                        <tbody id='Dept_insertRowText_S'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


   


    <script type="text/javascript">
        $(document).ready(function () {
            //$('.loading').hide();

            google.charts.load('current', { packages: ["orgchart"] });
            google.charts.setOnLoadCallback(OrgChart);


            loadcompany();



            function loadcompany() {

                inputsearchText(
                    "<%= ResolveUrl("MaintainPyramid.aspx/LoadCompany") %>",
                    { data: "" },
                    function (response) {
                        var column = "";
                        if (response.d.length > 0) {
                            $.each(response.d, function (index, val) {
                                column += "<option value='" + val.Code.trim() + "'>" + val.Name + "</option>";
                            });
                        }


                        $("#SelectCompany_S").append(column);

                        $("select#SelectCompany_S")[0].selectedIndex = 1;

                    });

            }





            function inputsearchText(url, data, text) {
                $.ajax({
                    type: "POST",
                    async: true,
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(data),
                    success: text
                });
            }





            $('#btnBrowse').on('click', function () {

                ClearSearchHeader()
                $('#ModalPyramid').modal('show');

            });


            function ClearSearchHeader() {

                $('#bodyTableSearchPyramid').empty();

                $("#SelectCompany_S").val("CPK");
                //$('#txtRevision_S').val("");
                $('#txtGroup_S').val("");
                $('#txtDept_S').val("");
                $('#txtEffectDate_S').val("");
            }



            $("#btnGroup_S").on('click', function () {


                browseGroup();

            });

            function browseGroup() {

                var Comp_Code = $('#SelectCompany_S option:selected').val();

                var data = { Comp_Code: Comp_Code, Search: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadGroup") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchGroup,
                });

                function ModalSearchGroup(response) {
                    $("#Group_insertRowText").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {
                            var Code = val.Code;
                            var Name = val.Name;

                            fragment += '<tr>';
                            fragment += '<td class="Code"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + Code + '</a></td>';
                            fragment += '<td class="Name"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Name + '</a></td>';
                            fragment += '</tr>';
                            number = number + 1;
                        });
                    } else {
                        fragment = '<tr>';
                        fragment += '<td> Not Data </td>';
                        fragment += '<td> Not Data </td>';
                        fragment += '</tr>';
                    }
                    $("#Group_insertRowText").append(fragment);
                }

                $('#Group_insertRowText').on('click', '.clickSearch', function () {

                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#Group_insertRowText tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#Group_insertRowText tr:eq(' + numindex + ') .Name a').html()


                    $('#lblGroup_S').text(Code);
                    $('#txtGroup_S').val(Name);



                });

                $("#txtsearchGroup").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Group_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });

            }




            $("#btnDept_S").on('click', function () {

                if ($('#txtGroup_S').val() == "") {

                    $.alert({
                        title: 'Alert!',
                        content: "Please insert Group !! ",
                        type: 'red',
                    });

                } else {


                    $('#ModalSearchDept_S').modal();
                    browseDept_S();
                }

            });



            function browseDept_S() {


                var GroupID = $('#lblGroup_S').text();

                var data = { GroupID: GroupID, Search: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadDept") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchCostCenter,
                });

                function ModalSearchCostCenter(response) {
                    $("#Dept_insertRowText_S").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {
                            var Code = val.Code;
                            var Name = val.Name;
                            var DeptCode = val.DeptCode;

                            fragment += '<tr>';
                            fragment += '<td class="Code"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + DeptCode + '</a></td>';
                            fragment += '<td class="Name"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Name + '</a></td>';
                            fragment += '</tr>';
                            number = number + 1;
                        });
                    } else {
                        fragment = '<tr>';
                        fragment += '<td> Not Data </td>';
                        fragment += '<td> Not Data </td>';
                        fragment += '</tr>';
                    }
                    $("#Dept_insertRowText_S").append(fragment);
                }

                $('#Dept_insertRowText_S').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#Dept_insertRowText_S tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#Dept_insertRowText_S tr:eq(' + numindex + ') .Name a').html()

                    $('#txtDept_S').val(Name);
                    $('#lblDept_S').text(Code);
                    $('#ModalSearchDept_S').modal('hide');

                });

                $("#txtsearchDept_S").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Dept_insertRowText_S tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });
            }


            $("#btnClear_S").on('click', function () {
                ClearSearchHeader();
            });
            function ClearSearchHeader() {

                $('#bodyTableSearchPyramid').empty();

                $("#SelectCompany_S").val("CPK");
                //$('#txtRevision_S').val("");
                $('#txtGroup_S').val("");
                $('#txtDept_S').val("");
                $('#txtEffectDate_S').val("");
            }





            $("#btnSearch_S").on('click', function () {

                //var txtRevision_S = $('#txtRevision_S').val();
                var txtGroup_S = $('#lblGroup_S').text();
                var Dept_S = $('#lblDept_S').text();
                //var txtEffectDate_S = $('#txtEffectDate_S').val();
                var company = $('#SelectCompany_S option:selected').val();
                var Status = 'Active';

                var data = {
                    Company: company,
                    GroupPyramid: txtGroup_S,
                    Dept: Dept_S,
                    Revision: '',
                    EffectDate: '',
                    Status: Status
                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/SearchPyramid") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: showsearch
                });


                function showsearch(response) {
                    $("#bodyTableSearchPyramid").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {

                            var CompanyCode = val.Company;
                            var GroupID = val.GroupPyramid;
                            var deptCode = val.Dept;
                            //var revision = val.Revision;
                            var EffectDate = val.EffectDate;
                            var PyramidID = val.PyramidID;
                            var Comp_Name = val.Comp_Name;
                            var GroupName = val.GroupName;
                            var DeptName = val.DeptName;
                            var Status = val.Status;

                            fragment += '<tr>';
                            fragment += '<td class="company"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + Comp_Name + '</a></td>';
                            fragment += '<td class="Group"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + GroupName + '</a></td>';
                            fragment += '<td class="dept"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + DeptName + '</a></td>';
                            //fragment += '<td class="revision"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + revision + '</a></td>';
                            fragment += '<td class="EffectDate"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + EffectDate + '</a></td>';
                            fragment += '<td class="Status"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Status + '</a></td>';
                            fragment += '<td style="display:none" class="PyramidID"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + PyramidID + '</a></td>';
                            fragment += '<td style="display:none" class="CompanyCode"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + CompanyCode + '</a></td>';
                            fragment += '<td style="display:none" class="GroupID"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + GroupID + '</a></td>';
                            fragment += '<td style="display:none" class="deptCode"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + deptCode + '</a></td>';
                            fragment += '</tr>';
                            number = number + 1;
                        });
                    } else {
                        fragment = '<tr>';
                        fragment += '<td> Not Data </td>';
                        fragment += '<td> Not Data </td>';
                        //fragment += '<td> Not Data </td>';
                        fragment += '<td> Not Data </td>';
                        fragment += '<td> Not Data </td>';
                        fragment += '<td> Not Data </td>';
                        fragment += '</tr>';
                    }
                    $("#bodyTableSearchPyramid").append(fragment);
                }


                $('#bodyTableSearchPyramid').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var DataCompany = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .company a').html(),
                        GroupPyramid = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .Group a').html(),
                        Dept = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .dept a').html(),
                        //Revision = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .revision a').html(),
                        EffectDate = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .EffectDate a').html(),
                        PyramidID = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .PyramidID a').html(),
                        CompanyCode = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .CompanyCode a').html(),
                        GroupID = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .GroupID a').html(),
                        deptCode = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .deptCode a').html(),
                        Status = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .Status a').html()


                    //yam



                    $('#lblCompany').text(DataCompany);
                    $('#lblGroup').text(GroupPyramid);
                    $('#lblDept').text(Dept);
                    //$('#lblRevision').text(Revision);
                    $('#lblEffectDate').text(EffectDate);
                    $('#lblPyramidID').text(PyramidID);

                    $('#lblCompanyCode').text(CompanyCode);
                    $('#lblGroupID').text(GroupID);
                    $('#lblDeptID').text(deptCode);
                    $('#lblStatus').text(Status);

                    OrgChart();
                    //ShowPyramidLine();
                    //LoadCountPerson();


                    //visible_ButtonEditHeader();

                });
            });







            var ChkRefRoleID = '0';
            var ChkRoleID = '0';



            function OrgChart() {

                var PyramidID = $('#lblPyramidID').text();

                 //$('.loading').show();
                var data = { PyramidID: PyramidID };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("PreviewPyramid.aspx/LoadPyramid") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowPyramid,
                });

                function ShowPyramid(response) {

                    var DT = new google.visualization.DataTable();
                    DT.addColumn('string', 'Name');
                    DT.addColumn('string', 'Manager');
                    DT.addColumn('string', 'ToolTip');

                    if (response.d.length > 0) {


                        $('#PanelOrgChart').show();

                        $.each(response.d, function (index, val) {

                            var RoleID = val.RoleID_Line;
                            var RefRoleID_Line = val.RefRoleID_Line;
                            var EmpNum = val.EmpNum_Line;
                            var Acting = val.Acting_Line;


                            $('#lblDept').text(val.Dept)



                            if (val.EmpName_Line != 'Skip') {


                                SetBox(val.Path, val.EmpName_Line, val.Level_Emp_Line, val.Dept_Line, val.Position_Line, val.ActingType_Line, Acting, EmpNum, RoleID, RefRoleID_Line);
                                CreatChart(Acting);
                            }


                        });
                    } else {

                        $('#PageUnder').show();
                        $('#Pyramid').hide();

                    }



                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    function SetBox(Path, EmpName, Level_Emp, Dept, Position, ActingType, Acting, EmpNum, RoleID, RefRoleID_Line) {

                        var content = '';

                        //content += '<div style="width:200px;height:100px">'

                        //content += '<hr style="color:#36add1">'
                        content += '<div style="width:160px;"></div>'

                        if (Path != "") {
                            content += '<img style="width: 27px; max-height: 27px;"  src="' + Path + '" />&nbsp;&nbsp;'
                        }

                        if (Level_Emp != "") { 
                        content += '<span style="white-space: nowrap;color:#fff;font-size:14px;font-weight:bold;">(' + Level_Emp + ')</span></br>'
                        }else {
                            content += '<br>'
                        }

                        if (EmpName != "") {
                            content += '<span style="white-space: nowrap;color:#fff;font-size:14px;font-weight:bold;">' + EmpName + '</span></br>'
                        }else {
                            content += '<br>'
                        }

                        if (Dept != "") {

                            content += '<span style="white-space: nowrap;color:#fff;font-size:12px;">' + Dept + '</span></br>'
                        }
                        else {
                            content += '<br>'
                        }

                        if (Position != "") {

                            content += '<span style="color:#fff;font-size:12px;">' + Position + '</span></br>'
                        } else {
                            content += '<br>'
                        }

                        if (ActingType != "") {

                            content += '<span style="color:#fff;font-size:12px;font-style:italic;font-weight:bold;">- Acting : ' + ActingType + ' -</span></br>'
                            content += '<br>';
                        } else {

                            content += '<br>'
                        }

                       

                            //content += EmpName;
                        //content += '<span>' + Position + '</span>'
                        //content += '</div>'
                        //content += '<span>เจนจิรา ตนะสุข</span>'



                        if (RefRoleID_Line == '0') {

                            RefRoleID_Line = '';
                        }
                        //content += '<div style="max-width:200px;height:auto;padding: 20px 20px 20px 20px;">'

                        //if (Path != '') {
                        //    content += '<img style="margin-right:3px;height:20px;width20px;"  src="' + Path + '" />'
                        //}

                        ////content += '</center><div style="width:200px;height:auto;">'
                       

                        //content += '<span style="color:#fff;font-weight: bold;font-size:14px">' + EmpName + '</span>';


                        //if (Level_Emp != "") {

                        // content += '<span style="color:#fff;font-weight: bold; font-style:italic;font-size:12px">( ' + Level_Emp + ' )</span>';
                        //}
                        //content += '<span style="color:#fff;font-weight: bold;font-size:11px">' + Dept + '<br></span>';
                        //content += '<span style="color:#fff;font-size:11px">' + Position + '<br></span>';


                        //if (ActingType != '') {

                        //    content += '<span style="color:#fff;font-weight: bold; font-style:italic;font-size:12px">- Acting : ' + ActingType + ' - </span>';

                        //} else {
                        //    content += '</br>';
                        //}

                        //content += '</div>'

                        var rowIndex = DT.addRows([
                            [{ v: RoleID, f: content },
                                RefRoleID_Line, 'EmpNum : ' + EmpNum],
                        ]);


                        SetColor(Acting, rowIndex, EmpNum);

                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    function SetColor(Acting, rowIndex, EmpNum) {

                        var colorBlue = '';
                        var colorOrange = '';
                        var colorGray = '';
                        var colorPink = '';

                        colorOrange += 'text-align: center;'
                        colorOrange += 'vertical-align: middle;'
                        colorOrange += 'font-family: arial, helvetica;'
                        colorOrange += 'cursor: default;'
                        colorOrange += 'border: 1px hidden #ffffff;border-radius: 5px;'
                        colorOrange += '-webkit-border-radius: 5px;'
                        colorOrange += '-webkit-box-shadow: rgba(0, 0, 0, 0.5) 0px 0px 0px;'
                        colorOrange += '-moz-box-shadow: rgba(0, 0, 0, 0.5) 0px 0px 0px;'
                        colorOrange += 'background-color: #eea236;'
                        colorOrange += 'background: -webkit-gradient(linear, left top, left bottom, from(#eea236), to(#eea236));'
                        //colorOrange += 'width: 150px;height: 100px'



                        colorBlue += 'text-align: center;'
                        colorBlue += 'vertical-align: middle;'
                        colorBlue += 'font-family: arial, helvetica;'
                        colorBlue += 'cursor: default;'
                        colorBlue += 'border: 1px hidden #ffffff;border-radius: 5px;'
                        colorBlue += '-webkit-border-radius: 5px;'
                        colorBlue += '-webkit-box-shadow: rgba(0, 0, 0, 0.5) 0px 0px 0px;'
                        colorBlue += '-moz-box-shadow: rgba(0, 0, 0, 0.5) 0px 0px 0px;'
                        colorBlue += 'background-color: #36add1;'
                        colorBlue += 'background: -webkit-gradient(linear, left top, left bottom, from(#36add1), to(#36add1));'
                        //colorBlue += 'size:medium;'
                        //colorBlue += 'width: 150px;height: 100px'


                        colorGray += 'text-align: center;'
                        colorGray += 'vertical-align: middle;'
                        colorGray += 'font-family: arial, helvetica;'
                        colorGray += 'cursor: default;'
                        colorGray += ' border: 1px hidden #ffffff;border-radius: 5px;'
                        colorGray += '-webkit-border-radius: 5px;'
                        colorGray += '-webkit-box-shadow: rgba(0, 0, 0, 0.5) 0px 0px 0px;'
                        colorGray += '-moz-box-shadow: rgba(0, 0, 0, 0.5) 0px 0px 0px;'
                        colorGray += 'background-color:#a3a3a3;'
                        colorGray += 'background: -webkit-gradient(linear, left top, left bottom, from(#a3a3a3), to(#a3a3a3));'
                        //colorGray += 'width: 150px;height: 100px'



                        colorPink += 'text-align: center;'
                        colorPink += 'vertical-align: middle;'
                        colorPink += 'font-family: arial, helvetica;'
                        colorPink += 'cursor: default;'
                        colorPink += 'border: 1px hidden #ffffff;border-radius: 5px;'
                        colorPink += '-webkit-border-radius: 5px;'
                        colorPink += '-webkit-box-shadow: rgba(0, 0, 0, 0.5) 0px 0px 0px;'
                        colorPink += '-moz-box-shadow: rgba(0, 0, 0, 0.5) 0px 0px 0px;'
                        colorPink += 'background-color:#dd5695;'
                        colorPink += ' background: -webkit-gradient(linear, left top, left bottom, from(#dd5695), to(#dd5695));'
                        //colorPink += 'width: 150px;height: 100px';


                        if (Acting == '1') {

                            DT.setRowProperty(rowIndex, 'style', colorOrange);
                        }
                        else if (Acting == '0') {

                            DT.setRowProperty(rowIndex, 'style', colorBlue);
                        }


                        if (EmpNum == 'S0001') { //Sub

                            DT.setRowProperty(rowIndex, 'style', colorPink);
                        }


                        if (EmpNum == '1') { //New

                            DT.setRowProperty(rowIndex, 'style', colorOrange);
                        }

                        if (EmpNum == '2') { // Replace

                            DT.setRowProperty(rowIndex, 'style', colorOrange);
                        }

                        if (EmpNum == '0') {//Skip

                            DT.setRowProperty(rowIndex, 'style', colorGray);
                        }







                    }

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    function CreatChart(Acting) {
                        var color = "";

                        if (Acting == '0') {

                            color = "Orange";


                        } else if (Acting == '1') {

                            color = "Blue";
                        }



                        var options = {
                            explorer: {
                                maxZoomOut: 2,
                                keepInBounds: true
                            },

                            //nodeClass: color,
                            selectedNodeClass: 'mySelectedNodeClass',
                            //color: '#7dc673',
                            allowHtml: true,

                            //size: 'small',


                        };

                        // Create the chart.
                        var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));
                        // Draw the chart, setting the allowHtml option to true for the tooltips.
                        chart.draw(DT, options);

                        //$('.loading').hide();
                    }//ปิดCreateChart

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                } //ปิด

            } // ปิดfn orgChart



        }); //ปิด doc



        $(document).ready(function () {
            var $loading = $('.loading').hide();
            $(document)
                .ajaxStart(function () {
                    $loading.show();
                })
                .ajaxStop(function () {
                    $loading.hide();
                });
        });

    </script>


    <style>
        .gradient_line {
            display: block;
            border: none;
            height: 1px;
            background: #CBCBCB;
        }

        .container {
            width: 97%
        }

        .modal.modal-wide .modal-dialog {
            width: 90%;
        }

        .modal-wide .modal-body {
            overflow-y: auto;
        }

        /* irrelevant styling */
        #tallModal .modal-body p {
            margin-bottom: 700px
        }

        .google-visualization-orgchart-table * {
            margin: 0;
            padding: 2px;
            vertical-align: middle;
            width: 30px;
            /*height:26px*/
        }



        .chart {
            border: solid 1px #c1c1c1;
            width: 100%;
            height: 560px;
            background: #fafafa;
            overflow: auto;
        }


        /*.maman {
            color: green;
            width: 100px;
            border: 1px solid #fff;
            text-align: center;
        }*/

        .google-visualization-orgchart-lineleft {
            border-left: 1px solid #16a1cc !important;
        }

        .google-visualization-orgchart-linebottom {
            border-bottom: 1px solid #16a1cc !important;
        }

        .google-visualization-orgchart-lineright {
            border-right: 1px solid #16a1cc !important;
        }

        .maman img {
            clear: both;
            display: block;
            margin: auto;
        }


       



        /*.Orange {
            text-align: center;
            vertical-align: middle;
            font-family: arial,helvetica;
            cursor: default;
            border: 2px solid #b5d9ea;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -webkit-box-shadow: rgba(0, 0, 0, 0.5) 3px 3px 3px;
            -moz-box-shadow: rgba(0, 0, 0, 0.5) 3px 3px 3px;
            background-color: #eea236;
            background: -webkit-gradient(linear, left top, left bottom, from(#eea236), to(#eea236));
        }*/


        /*.Blue {
            text-align: center;
            vertical-align: middle;
            font-family: arial,helvetica;
            cursor: default;
            border: 2px solid #b5d9ea;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -webkit-box-shadow: rgba(0, 0, 0, 0.5) 3px 3px 3px;
            -moz-box-shadow: rgba(0, 0, 0, 0.5) 3px 3px 3px;
            background-color: #35c6ea;
            background: -webkit-gradient(linear, left top, left bottom, from(#35c6ea), to(#35c6ea));
        }*/



        /*.myNodeClass {
            text-align: center;
            vertical-align: middle;
            font-family: arial,helvetica;
            cursor: default;
            border: 2px solid #b5d9ea;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -webkit-box-shadow: rgba(0, 0, 0, 0.5) 3px 3px 3px;
            -moz-box-shadow: rgba(0, 0, 0, 0.5) 3px 3px 3px;
            background-color: #ef0e42;
            background: -webkit-gradient(linear, left top, left bottom, from(#ef0e42), to(#ef0e42));
        }*/


        .mySelectedNodeClass {
            border: 2px solid #e38493;
            background-color: #eeb0d7;
            background: -webkit-gradient(linear, left top, left bottom, from(#ffb0d7), to(#eeb0d7));
        }

        .google-visualization-orgchart-node-small {
            font-size:14px;
        }
    </style>


</asp:Content>

