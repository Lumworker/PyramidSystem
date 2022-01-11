<%@ Page Title="Maintain Pyramid Type" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintainPyramid_Type.aspx.cs" Inherits="PyramidSystem.Projects.MaintainPyramid_Type" %>
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

        .nav-tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
        }.table-responsive {
            overflow-x: hidden !important; 
        }
        .center{
            text-align: center;
        }
    </style>
        <div class="page-header">
        <div class="row">
            <div class="col-md-4 col-sm-4 col-xs-4" style="text-align: left;">
            <h2>Maintain Pyramid Type</h2>
            </div>

            <div class="col-md-8 col-sm-8 col-xs-8" style="text-align: right">
                <button id="btnModalNew" class="btn btn-success Pos_Worker" type="button" data-toggle="modal" style="float: right">New </button>
            </div>
        </div>
    </div>

<!----End Header---->

    
    <div class="panel-group">
        <!--panel-default-->
        <div class="panel panel-default" style="margin-top: 1em;" id="divDataTable">
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table class="table table-hover table-bordered table-responsive" style="width: 100%" id="table_Type">
                                <thead>
                                    <tr>
                                        <th>Type Code</th>
                                        <th>Type Name</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody id="List_Type">
                                    <tr>
                                        <td>0</td>
                                        <td>Skip</td>

                                        <td>
                                            <button class="btn btn-warning  btnModalEdit" data-id="' + ID + '" type="button">Edit</button></td>
                                    </tr>
                                    <tr>
                                        <td>S0001</td>
                                        <td>Subcontractor</td>

                                        <td>
                                            <button class="btn btn-warning  btnModalEdit" data-id="' + ID + '" type="button">Edit</button></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <!--panel-body-->
        </div>
        <!--panel-default-->
    </div>
    <!--Panel-Group -->


    
    <div class="modal fade" id="Modal_Type" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; ">
                        <div class="col-md-7 col-sm-12">
                            <h4 class="modal-title"><span id="TitleModal_Type"></span> : Pyramid Type</h4>
                        </div>
                        <div class="col-md-5 col-sm-12" style="text-align: right;">
                            <button type="button" class="btn btn-success" id="Save_Type" >Save</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                    </div>
                </div>
                <div class="modal-body" style="max-height: 28em; max-width: 100%;">
                    
                    <div class="row">
                   <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <label class="control-label" style="font-size: 13px">Type Code :</label>
                            </div>
                            <div class="col-md-9 col-sm-9 col-xs-12"> 
                                <input type="text" id="text_TypeCode" class="form-control " style="min-width: 100%" autocomplete="off"  />
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <label class="control-label" style="font-size: 13px">Type Name :</label>
                            </div>
                            <div class="col-md-9 col-sm-9 col-xs-12"> 
                                <input type="text" id="text_TypeName" class="form-control " style="min-width: 100%" autocomplete="off" />
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
    <%--Browse New/Edit--%>

    
    
    <div class="modal fade" id="modalBrowseSearch" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-xs" id="modalSize">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em;">
                        <div class="col-md-9 col-lg-9 col-sm-12">
                            <h4 id="Titlebrowse" class="modal-title">Text</h4>
                        </div>
                        <div class="col-md-3 col-lg-3 col-sm-12" style="text-align: right;">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12">
                        <div class="form-group col-md-12 col-lg-12 col-sm-12">
                            <div id="search_box">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: auto; max-height: 28em; max-width: 100%;">
                    <table id="TbListBrowse" class="table table-striped table-bordered table-responsive">
                        <thead>
                            <tr class="header" id="TBheaderBrowse">
                                <%-- <th>Column</th>
                                <th>Name</th>
                                <th></th>--%>
                            </tr>
                        </thead>
                        <tbody id='TBbodyBrowse'></tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <%--modalBrowseSearch--%>
     <script>
        $(document).ready(function () {
            var table_Type = $("#table_Type").DataTable({
                searching: true,
                responsive: true,
                "order": []
            });

            GetTable();
            
            $(document).on("click", "#btnModalNew", function () {
                $("#text_TypeCode").val('');
                $("#text_TypeName").val('');
                $("#TitleModal_Type").text("New");
                $("#text_TypeCode").prop('disabled',false);
                $("#Save_Type").attr("data-action","Insert");
                $("#Modal_Type").modal("show");
            });

            $(document).on("click", ".btnModalEdit", function () {
                var TypeCode = $(this).closest("tr").find("td:nth-child(1)").text();
                var TypeName = $(this).closest("tr").find("td:nth-child(2)").text();
                $("#text_TypeCode").val(TypeCode);
                $("#text_TypeName").val(TypeName);
                $("#TitleModal_Type").text("Edit");
                $("#text_TypeCode").prop('disabled',true);
                $("#Save_Type").attr("data-action","Edit");
                $("#Modal_Type").modal("show");
            });

            $(document).on("click", "#Save_Type", function () {
                let Action = $(this).attr("data-action");
                Save_Type(Action);
            });
            
           function Save_Type(Action) {
                var TypeCode = $("#text_TypeCode").val();
                var TypeName = $("#text_TypeName").val();
                if (  TypeCode != "" && TypeName != "") {
                    $.ajax({
                        type: "post",
                        async: false,
                        url: "<%= ResolveUrl("Default.aspx/SP_Pyramid_Employee") %>",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({
                            Emp_Num: TypeCode,  Emp_Name: TypeName ,Action:Action
                        }),
                        success: function (response) {
                             var Msg = response.d;
                            if (Msg == 'Already have Type Code') {
                                swal('Already have Already have Type Code', 'มี Type Code นี้ในระบบแล้ว', 'error');
                            } else {
                                swal('Complete', '', 'success');
                                GetTable();
                                $("#Modal_Type").modal("hide");
                            }
                            console.log(Msg);
                        }
                    });
                } else {
                      swal('Error', 'กรุณากรอกข้อมูลให้ครบถ้วน', 'error');
                }
            }

            function GetTable() {
                $("#IMGUpload").modal("show");
                table_Type.clear().draw();
                $.ajax({
                    type: "post",
                    async: false,
                    url: "<%= ResolveUrl("Default.aspx/TB_Pyramid_Employee") %>",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({  }),
                    success: function (response) {
                        if (response.d.length > 0) {
                            $.each(response.d, function (index, val) {
                                var MainType = val[0];
                                var Emp_Name = val[1];
                                    table_Type.row.add([
                                        MainType,
                                        Emp_Name,
                                        '<td><button class="btn btn-warning  btnModalEdit" type="button" >Edit</button></td> ',
                                    ]).draw(false);
                                
                            });
                        }
                         $("#IMGUpload").modal("hide");
                    }

                });
            }
            //End Document Ready
         });


     </script>
</asp:Content>
