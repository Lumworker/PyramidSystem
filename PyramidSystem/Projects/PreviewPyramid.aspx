<%@ Page Title="Preview - " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreviewPyramid.aspx.cs" Inherits="PyramidSystem.Projects.PreviewPyramid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script src="../OrgChartJS%20(1)/orgchart.js"></script>--%>

    <script src="http://portalapp01/PyramidSystem/js/latest/orgchart.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.5/jspdf.min.js"></script>


    <%--  <div class="loading" id="loading" style=" text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 999; background-color: #ffffff; opacity: 0.1;">
        <img src="../img/Spin.gif" style="position: absolute; left: 50%; top: 10%; bottom: 0; margin: auto; width: 70px; height: 70px;" />
    </div>--%>

    <div class="loading" id="loading">
        <img src="../img/Spin.gif" style="position: absolute; left: 50%; top: 2%; bottom: 0; margin: auto; width: 70px; height: 70px;" />
    </div>

    <style>
        .gradient_line {
            display: block;
            border: none;
            height: 1px;
            background: #CBCBCB;
        }

        .container {
            width: 99%
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
            font-size: 14px;
        }


        .Acting rect {
            stroke: #eea236;
            fill: #eea236;
            /*width:270px;*/
            /*height:180px;*/
            /*height: 153px;*/
        }

        .Active rect {
            stroke: #36add1;
            fill: #36add1;
            /*width:266px;*/
            /*height: 153px;*/
        }

        .Subcon rect {
            stroke: #dd5695;
            fill: #dd5695;
            /*width:290px; 
           height:180px;*/
            /*height: 153px;*/
        }

        .New rect {
            stroke: #eea236;
            fill: #eea236;
            /*width:290px; 
           height:180px;*/
            /*height: 153px;*/
        }

        .Replace rect {
            stroke: #eea236;
            fill: #eea236;
            /*width:290px; 
           height:180px;*/
            /*height: 153px;*/
        }

        .Skip rect {
            stroke: #a3a3a3;
            fill: #a3a3a3;
            /*width:290px; 
           height:180px;*/
            /*height: 153px;*/
        }


        /*สีเส้น*/
        [link-id] path {
            stroke: #6e6e6e;
        }



        .field_0 a:visited, .field_0 a {
            fill: #ffffff;
        }

            .field_0 a:hover {
                fill: black !important;
            }

        [control-expcoll-id] circle {
            stroke: #6e6e6e;
        }

        /*[control-expcoll-id] circle {
            fill: #de6c1b
        }*/

        .check-box {
            width: 20px;
            height: 20px;
        }

        #tree {
            width: 100%;
            height: 100%;
        }
    </style>
    <asp:Label ID="lblCostCenter" runat="server" Text="Label"></asp:Label>
    <div class="container">
        <div class="col-md-12">
            <div class='page-header'>
                <div class='btn-toolbar pull-right'>
                    <div class="btn-group">
                        <button type="button" class="btn btn-primary" id="btnBrowse" style="width: 90px">Search <i class="fa fa-search" aria-hidden="true"></i></button>

                        <button type="button" class="btn btn-primary" id="btnSearchPerson" style="width: 150px; display: none">Special Search <i class="fa fa-user" aria-hidden="true"></i></button>

                        <button type="button" class="btn btn-primary" id="btnRefresh" style="width: 90px;">Refresh <i class="fa fa-refresh" aria-hidden="true"></i></button>
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

                    <div class="form-group">
                        <label class="col-lg-4 control-label">Effect Date :</label>
                        <div class="col-lg-8">
                            <span id="lblEffectDate"></span>
                        </div>
                    </div>

                    <hr class="gradient_line" />
                    <div style="clear: both; height: 1px"></div>

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
                        <label class="col-lg-4 control-label">Revision :</label>
                        <div class="col-lg-8">
                            <span id="lblRevision"></span>
                        </div>
                    </div>

                    <hr class="gradient_line" />
                    <div style="clear: both; height: 1px"></div>


                    <div class="form-group">
                        <label class="col-lg-4 control-label">Status :</label>
                        <div class="col-lg-8">
                            <span id="lblStatus"></span>
                        </div>
                    </div>

                    <hr class="gradient_line" />
                    <div style="clear: both; height: 1px"></div>

                </div>
            </div>
        </div>

        <%--    <input id="save-pdf" type="button" value="Save as PDF" />--%>
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

            <div class="chart">
                <div id="tree" style="height: 100%; width: 100%">
                </div>
                <%--<div class="row">
                <div class="chart" style="padding: 20px 20px 20px 20px">
                  
                    </div>
                </div>--%>
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
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-xs-4">
                                                <p>Revision </p>
                                            </div>
                                            <div class="col-md-9 col-xs-8">
                                                <input type="text" id="txtRevision_S" onkeypress="return isNumberKey(event)" class="form-control" style="max-width: 100%" placeholder="Please insert number">
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
                        </div>

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
                                    <th>Revision</th>
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




            var CostCenter = $("#MainContent_lblCostCenter").html();

            $("#MainContent_lblCostCenter").hide();
            CheckPermission();
            loadcompany();

            $('.loading').hide();

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

            function CheckPermission() {

                inputsearchText(
                    "<%= ResolveUrl("PreviewPyramid.aspx/CheckPermission") %>",
                    { data: "" },
                    function (response) {
                        var emp_num = "";
                        if (response.d.length > 0) {
                            $.each(response.d, function (index, val) {
                                emp_num = val.Emp_num.trim();

                            });
                        }

                        if (emp_num == "") {
                            $.confirm({
                                title: "Alert!",
                                content: "You don't have permission.",
                                type: 'red',
                                buttons: {
                                    ok: function () {
                                        window.open('','_parent','');
                                        window.close();
                                    }
                                }
                            });
                        }

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


            $('#btnRefresh').on('click', function () {

                ShowOrg();

            });



            $('#btnSearchPerson').on('click', function () {


                $('#ModalSpcSearch').modal('show');

            });





            function ClearSearchHeader() {

                $('#bodyTableSearchPyramid').empty();

                $("#SelectCompany_S").val("CPK");
                //$('#txtRevision_S').val("");
                $('#txtGroup_S').val("");
                $('#txtDept_S').val("");
                $('#txtEffectDate_S').val("");
                $("select#SelectStatus_S")[0].selectedIndex = 0;
                $('#lblGroup_S').text("");
                $('#lblDept_S').text("");
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
                    var Code = $('#Group_insertRowText tr:eq(' + numindex + ') .Code a').html()
                    var Name = $('#Group_insertRowText tr:eq(' + numindex + ') .Name a').html()

                    var ReplaceName = Name.replace("amp;", "");



                    $('#lblGroup_S').text(Code);
                    $('#txtGroup_S').val(ReplaceName);



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
                var CompCode = $('#SelectCompany_S option:selected').val();

                var data = { GroupID: GroupID, Search: "", CompCode: CompCode };

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


                    var ReplaceName = Name.replace("amp;", "");

                    $('#txtDept_S').val(ReplaceName);
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
            //function ClearSearchHeader() {

            //    $('#bodyTableSearchPyramid').empty();

            //    $("#SelectCompany_S").val("CPK");
            //    //$('#txtRevision_S').val("");
            //    $('#txtGroup_S').val("");
            //    $('#txtDept_S').val("");
            //    $('#txtEffectDate_S').val("");
            //}





            $("#btnSearch_S").on('click', function () {

                var txtRevision_S = $('#txtRevision_S').val();
                var txtGroup_S = $('#lblGroup_S').text();
                var Dept_S = $('#lblDept_S').text();
                //var txtEffectDate_S = $('#txtEffectDate_S').val();
                var company = $('#SelectCompany_S option:selected').val();


                var Status = $('#SelectStatus_S option:selected').val();


                var data = {
                    Company: company,
                    GroupPyramid: txtGroup_S,
                    Dept: Dept_S,
                    Revision: txtRevision_S,
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
                            var revision = val.Revision;
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
                            fragment += '<td class="revision"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + revision + '</a></td>';
                            fragment += '<td class="EffectDate"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + EffectDate + '</a></td>';

                            if (Status == "Active") {

                                fragment += '<td class="Status"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '><span class="label label-success">' + Status + '</span></a></td>';

                            } else if (Status == "InActive") {

                                fragment += '<td class="Status"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '><span class="label label-danger">' + Status + '</span></a></td>';
                            }
                            else if (Status == "Draft") {

                                fragment += '<td class="Status"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '><span class="label label-warning">' + Status + '</span></a></td>';
                            }



                            fragment += '<td style="display:none" class="StatusShow"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Status + '</a></td>';
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
                        fragment += '<td> Not Data </td>';
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
                        Revision = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .revision a').html(),
                        EffectDate = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .EffectDate a').html(),
                        PyramidID = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .PyramidID a').html(),
                        CompanyCode = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .CompanyCode a').html(),
                        GroupID = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .GroupID a').html(),
                        deptCode = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .deptCode a').html(),
                        Status = $('#bodyTableSearchPyramid tr:eq(' + numindex + ') .StatusShow a').html()


                    //yam

                    var ReplaceGroupPyramid = GroupPyramid.replace("amp;", "");
                    var ReplaceDept = Dept.replace("amp;", "");



                    $('#lblCompany').text(DataCompany);
                    $('#lblGroup').text(ReplaceGroupPyramid);
                    $('#lblDept').text(ReplaceDept);
                    $('#lblRevision').text(Revision);
                    $('#lblEffectDate').text(EffectDate);
                    $('#lblPyramidID').text(PyramidID);

                    $('#lblCompanyCode').text(CompanyCode);
                    $('#lblGroupID').text(GroupID);
                    $('#lblDeptID').text(deptCode);
                    $('#lblStatus').text(Status);


                    //google.charts.load('current', { packages: ["orgchart"] });
                    //google.charts.setOnLoadCallback(OrgChart);


                    ShowOrg();




                });
            });

            ///////////////////////อันใหม่/////////////////////
            function ShowOrg() {

                var PyramidID = $('#lblPyramidID').text();
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


                    if (response.d.length > 0) {


                        $('#PanelOrgChart').show();

                        OrgChart.templates.ana.size = [374, 180];

                        OrgChart.templates.ana.node = '<rect x="0" y="0" height="180" width="374" fill="#36add1" stroke-width="4" stroke="#36add1" rx="10" ry="10"></rect>';


                        OrgChart.templates.ana.field_0 =
                            '<text width="320" text-overflow="multiline" style="font-size: 16px;" fill="#ffffff" x="187" y="55" text-anchor="middle">{val}</text>';


                        //OrgChart.templates.ana.field_0 =
                        //    '<text class="field_0  word-wrap" style="font-size: 12px;" text-overflow="multiline" fill="#ffffff" x="125" y="25" text-anchor="middle">{val}</text>';


                        OrgChart.templates.ana.field_1 =
                            '<text class="field_1" style="font-size: 20px;font-weight:bold;" fill="#ffffff"  x="187" y="98" text-anchor="middle">- {val} -</text>';

                        OrgChart.templates.ana.field_2 =
                            '<text class="field_2" style="font-size: 17px;font-weight:bold;" fill="#ffffff" x="187" y="125" text-anchor="middle">{val}</text>';


                        OrgChart.templates.ana.field_3 =
                            '<text class="field_3 " style="font-size: 17px;" width="200px"  fill="#ffffff" x="187" y="149" text-anchor="middle">{val}</text>';

                        //OrgChart.templates.ana.html = '<foreignobject class="node" x="20" y="10" width="200" height="100">{val}</foreignobject>';



                        OrgChart.templates.ana.img_0 =
                            '<image preserveAspectRatio="xMidYMid slice" xlink:href="{val}" x="295" y="10" width="48" height="25"></image>';


                        OrgChart.templates.empty = Object.assign({}, OrgChart.templates.base);
                        OrgChart.templates.empty.size = [0, 0];
                        OrgChart.templates.empty.node = '';
                        OrgChart.templates.empty.plus = '';
                        OrgChart.templates.empty.minus = '';



                        var chart = new OrgChart(document.getElementById("tree"), {
                            layout: BALKANGraph.normal,
                            scaleInitial: BALKANGraph.match.boundary,
                            nodeMouseClick: BALKANGraph.action.none,
                            //showXScroll: BALKANGraph.scroll.visible,
                            //showYScroll: BALKANGraph.scroll.visible,
                            // collapse: {
                            //level: 3,
                            //allChildren: true
                            //},
                            mouseScrool: BALKANGraph.action.zoom,
                            template: "ana",
                            //enableSearch: false,


                            nodeBinding: {

                                field_0: "Position",
                                field_1: "Name",
                                field_2: "Level",
                                field_3: "CostCenter",

                                img_0: "img",
                                //html: "html"
                            },
                            tags: {
                                empty: { template: 'empty' }
                            },
                            //tags: {
                            //    "hide": {
                            //        state: BALKANGraph.COLLAPSE
                            //    }
                            //},

                            mouseScrool: OrgChart.action.zoom,
                            menu: {
                                pdfPreview: {
                                    text: "PDF Preview",
                                    icon: OrgChart.icon.pdf(24, 24, '#7A7A7A'),
                                    onClick: preview
                                },
                                pdf: { text: "Export PDF" },
                                png: { text: "Export PNG" },
                                svg: { text: "Export SVG" },
                                csv: { text: "Export CSV" }
                            },
                            toolbar: {
                                layout: true,
                                zoom: true,
                                fit: true,
                                expandAll: false
                            },
                        });

                        function preview() {
                            OrgChart.pdfPrevUI.show(chart, {
                                format: 'A4'
                            });
                        }


                        $.each(response.d, function (index, val) {

                            var RoleID = val.RoleID_Line;
                            var RefRoleID = val.RefRoleID_Line;
                            var EmpNum = val.EmpNum_Line;
                            var EmpName = val.EmpName_Line;




                            var Position = val.Position_Line;

                            var Acting = val.Acting_Line;
                            var CostCenter = val.Dept_Line;
                            var Level = val.Level_Emp;
                            var Level_Acting = val.Level_acting;
                            var Path = val.Path;


                            var Template = 'Active'

                            var contentLevel = '';




                            if (Acting == '1') {

                                contentLevel += '( ' + Level_Acting + ' Acting : ' + Level + ' )</br>';
                                //Template = 'Acting';
                            }
                            else if (Acting == '0') {
                                contentLevel += '( ' + Level + ' )</br>';
                                //Template = 'Active';
                            }

                            //content +=  CostCenter 

                            //if (EmpNum == 'S0001') {

                            //    Template = 'Subcon';

                            //}
                            //else if (EmpNum == '1') {

                            //    Template = 'Acting';

                            //}
                            //else if (EmpNum == '2') {

                            //    Template = 'Acting';

                            //}
                            //else


                            if (EmpNum == '0') {

                                Template = 'empty';
                            }

                            var ActingType = val.ActingType_Line
                            //var content = "";

                            //if (ActingType != "") {

                            //    content = "CostCenter : " + CostCenter + "  , Acting : " + val.ActingType_Line

                            //} else {

                            //      content = "CostCenter : " + CostCenter 
                            //}



                            if (val.EmpName_Line != 'Skip') {

                                chart.add({
                                    id: RoleID,
                                    pid: RefRoleID,
                                    Name: EmpName,
                                    img: Path,
                                    Level: contentLevel,
                                    CostCenter: CostCenter,
                                    Position: Position,
                                    Acting: Acting,
                                    tags: ['Active'],
                                    EmpNum: EmpNum,

                                    //html: "<div  style='color:#ffffff;text-align: center;'>" + content + "</div>"
                                });
                            }
                            else if (val.EmpName_Line = 'Skip') {
                                chart.add({
                                    id: RoleID,
                                    pid: RefRoleID,
                                    Name: EmpName,
                                    img: Path,
                                    Level: contentLevel,
                                    CostCenter: CostCenter,
                                    Position: Position,
                                    Acting: Acting,
                                    tags: ['empty'],
                                    EmpNum: EmpNum,

                                    //html: "<div class='word-wrap' style='color:#ffffff;text-align: center;'>" + Position + "</div>"
                                });

                            }


                        });


                        chart.draw(OrgChart.action.init);




                    } else {
                        //$('#PanelOrgChart').show();
                        $('#PanelOrgChart').hide();
                        //alert("Not Data !!")
                        //    $.alert({

                        //    title: 'Alert',
                        //    content: 'Not Data !!!',
                        //    type: 'red'

                        //});

                    }

                }
            }





















            ///////////////////////////////////////อันเก่า///////////////////////////////////////////////



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





</asp:Content>





