<%@ Page Title="Summary - " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="PyramidSystem.Projects.Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/dt/dt-1.10.18/datatables.min.css" />

    <link href="https://cdnjs.cloudflare.com/ajax/libs/TableExport/4.0.11/css/tableexport.css" rel="stylesheet">

    <style>
        .container {
            width: 90%
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
    </style>
    <div class="col-md-12">
        <div class='page-header'>
            <div class='btn-toolbar pull-right'>
                <div class="btn-group">
                    <button type="button" class="btn btn-primary" id="btnfilter" style="width: 70px"><i class="fa fa-filter" aria-hidden="true"></i></button>
                    <button type="button" class="btn btn-primary" id="btnExport"  style="width: 70px;display:none">Export </button>

                </div>
            </div>
            <h3>Summary <i class="fa fa-sitemap" aria-hidden="true"></i></h3>
        </div>
    </div>
    <%--/////////////////////////////////////--%>
    <div class="row"  >
        <div class="col-md-12">
            <center>
                        <table class="table table-bordered table-striped table-hover" id="TableSummary" >
                            <thead style="background-color: #e8e8e8">
                                <tr>
                                    <th>Company</th>
                                    <th>Group</th>
                                    <th>Dept</th>     
                                    <th>Level</th>
                                    <th>Emp Status</th>
                                    <th>Man Power</th>
                                </tr>
                            </thead>
                            <tbody id="bodySummary">   
                                   <tr>
                                    <td>Not Data</td>
                                    <td>Not Data</td>
                                    <td>Not Data</td>
                                    <td>Not Data</td>
                                    <td>Not Data</td>
                                    <td>Not Data</td>
                                    
                                   
                                    </tr>
                            </tbody>
                        </table></center>
        </div>
    </div>




    <%--////////////////////////////////--%>
    <div id="ModalPyramid" class="modal modal-wide fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Search Data &nbsp;<i class="fa fa-folder-open" aria-hidden="true"></i></h4>
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
                                                <p>Level </p>
                                            </div>
                                            <div class="col-md-9 col-xs-8">
                                                <input type="text" id="txtLevel" class="form-control" style="max-width: 100%">
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
                                                <p>Emp Status</p>
                                            </div>

                                            <div class="col-md-9 col-xs-8">
                                                <select class="form-control" id="SelectStatus_S" style="max-width: 100%">
                                                    <option value="">-- All --</option>
                                                    <option value="Active">Active</option>
                                                    <option value="Acting">Acting</option>
                                                    <option value="New">New</option>
                                                    <option value="Replace">Replace</option>
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
                                            <div class="col-md-3 col-xs-8">
                                                <button type="button" class="btn btn-primary" id="btnSearch_S" style="width: 100px;">Search&nbsp;<i class="fa fa-search" aria-hidden="true"></i></button></center>            
                                                 
                                            </div>
                                            <div class="col-md-3 col-xs-8">

                                                <button type="button" class="btn btn-warning" id="btnClear_S" style="width: 100px;">Clear</button>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                        </div>
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
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.11.10/xlsx.core.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/blob-polyfill/1.0.20150320/Blob.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/FileSaver.js/1.3.3/FileSaver.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/TableExport/4.0.11/js/tableexport.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/v/dt/dt-1.10.18/datatables.min.js"></script>
    <script>
        $(document).ready(function () {

            CheckPermission();
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

                        //$("#SelectCompany_N").append(column);
                        //$("#SelectCompany_E").append(column);
                        $("#SelectCompany_S").append(column);

                        //$("select#SelectCompany_N").val('0'); 

                        $("select#SelectCompany_S")[0].selectedIndex = 5;
                        //$("select#SelectCompany_E")[0].selectedIndex = 1;
                        //$("select#SelectCompany_N")[0].selectedIndex = 1;


                        //$("#SelectCompany_N").val("PK");
                        //$("#SelectCompany_S").val("CHA");
                        //$("#SelectCompany_E").val("PK");


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

            $('#btnfilter').on('click', function () {

                //ClearSearchHeader()
                $('#ModalPyramid').modal('show');

            });


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

            function ClearSearchHeader() {

                $('#bodyTableSearchPyramid').empty();

                $("#SelectCompany_S").val("CPK");
                $('#txtRevision_S').val("");
                $('#txtGroup_S').val("");
                $('#txtDept_S').val("");
                $('#txtEffectDate_S').val("");
                $("select#SelectStatus_S")[0].selectedIndex = 0;

                $('#lblGroup_S').text("");
                $('#lblDept_S').text("");
                $('#txtLevel').val("");


                ////$('#SelectStatus_S').text("-- All --");

            }


            ///////////////////////////////////////////////////////
            $("#btnSearch_S").on('click', function () {

                $("#bodySummary").empty();
                var data = {
                    CompanyCode: $('#SelectCompany_S option:selected').val(),
                    GroupPyramid: $('#lblGroup_S').text(),
                    Division: $('#lblDept_S').text(),
                    Level: $('#txtLevel').val(),
                    EmpStatus: $('#SelectStatus_S option:selected').val(),


                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("Summary.aspx/LoadSummary") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchSpcGroup,
                });

                function ModalSearchSpcGroup(response) {

                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {

                            //table.row.add([
                            //    val.CompanyCode,
                            //    val.GroupPyramid,
                            //    val.Division,
                            //    val.Costcerter,
                            //    val.Level,
                            //    val.Location,
                            //    val.EmpStatus,
                            //    val.ManPower,
                            //]).draw()



                            fragment += '<tr>';
                            fragment += '<td>' + val.CompanyCode + '</td>'
                            fragment += '<td>' + val.GroupPyramid + '</td>'
                            fragment += '<td>' + val.Costcerter + '</td>'
                            fragment += '<td>' + val.Level + '</td>'
                            fragment += '<td>' + val.EmpStatus + '</td>'
                            fragment += '<td>' + val.ManPower + '</td>'
                        
                            fragment += '</tr>';
                            number = number + 1;
                        });
                    } else {

                        fragment += '<tr>';
                        fragment += '<td>Not Data</td>'
                        fragment += '<td>Not Data</td>'
                        fragment += '<td>Not Data</td>'
                        fragment += '<td>Not Data</td>'
                        fragment += '<td>Not Data</td>'
                        fragment += '<td>Not Data</td>'
                        fragment += '</tr>';
                    }
                    $("#bodySummary").append(fragment);

                    var table = TableExport(document.getElementById('TableSummary'), {
                        //headers: true,                              // (Boolean), display table headers (th or td elements) in the <thead>, (default: true)
                        //footers: true,                              // (Boolean), display table footers (th or td elements) in the <tfoot>, (default: false)
                        formats: ['xlsx'],             // (String[]), filetype(s) for the export, (default: ['xls', 'csv', 'txt'])
                        filename: 'id',                             // (id, String), filename for the downloaded file, (default: 'id')
                        bootstrap: true,                           // (Boolean), style buttons using bootstrap, (default: true)
                        exportButtons: true,                        // (Boolean), automatically generate the built-in export buttons for each of the specified formats (default: true)
                        position: 'top',                         // (top, bottom), position of the caption element relative to table, (default: 'bottom')
                        //ignoreRows: null,                           // (Number, Number[]), row indices to exclude from the exported file(s) (default: null)
                        //ignoreCols: null,                           // (Number, Number[]), column indices to exclude from the exported file(s) (default: null)
                        //trimWhitespace: false                        // (Boolean), remove all leading/trailing newlines, spaces, and tabs from cell text in the exported file(s) (default: false)
                    });

                    table.reset();
                    $("#ModalPyramid").modal('hide');

                }


            });
        });
    </script>
</asp:Content>
