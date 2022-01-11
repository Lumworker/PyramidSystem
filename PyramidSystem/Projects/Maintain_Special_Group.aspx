<%@ Page Title="Maintain Special Group" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintain_Special_Group.aspx.cs" Inherits="PyramidSystem.Projects.Maintain_Special_Group" %>
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
            <h2>Maintain Special Group</h2>
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
                            <table class="table table-hover table-bordered table-responsive" style="width: 100%" id="tableSPG">
                                <thead>
                                    <tr>
                                        <%--<th>Owner</th>--%>
                                        <th>Special Code</th>
                                        <th>Picture</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody id="ListSPG">
                                   <%-- <tr>
                                        <td>IND</td>
                                        <td>//PORTALAPP01/ImgSpecialGroup/Indonesia.png</td>
                                        <td>
                                            <button class="btn btn-warning  btnModalEdit" data-id="' + ID + '" type="button">Edit</button></td>
                                    </tr>
                                    <tr>
                                        <td>THA</td>
                                        <td>//PORTALAPP01/ImgSpecialGroup/Thailand.png</td>
                                        <td>
                                            <button class="btn btn-warning  btnModalEdit" data-id="' + ID + '" type="button">Edit</button></td>
                                    </tr>
                                    <tr>
                                        <td>PKT</td>
                                        <td>//PORTALAPP01/ImgSpecialGroup/PKT.png</td>
                                        <td>
                                            <button class="btn btn-warning  btnModalEdit" data-id="' + ID + '" type="button">Edit</button></td>
                                    </tr>--%>
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


    
    <div class="modal fade" id="ModalSPG" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; ">
                        <div class="col-md-7 col-sm-12">
                            <h4 class="modal-title"><span id="TitleModalSPG"></span> : Special Group</h4>
                        </div>
                        <div class="col-md-5 col-sm-12" style="text-align: right;">
                            <button type="button" class="btn btn-success" id="SaveSPG" >Save</button>
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
                                <label class="control-label" style="font-size: 13px">Special Code :</label>
                            </div>
                            <div class="col-md-9 col-sm-9 col-xs-12"> 
                                <input type="text" id="text_Spc_Code" class="form-control " maxlength="4"  style="min-width: 100%" autocomplete="off"  />
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;" id="div_PicName">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <label class="control-label" style="font-size: 13px">Picture Name :</label>
                            </div>
                            <div class="col-md-9 col-sm-9 col-xs-12"> 
                                <input type="text" id="text_PicName" class="form-control " style="min-width: 100%" autocomplete="off" disabled />
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12" style="margin-bottom: 1em;">
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <label class="control-label" style="font-size: 13px">Picture  :</label>
                            </div>
                            <div class="col-md-9 col-sm-9 col-xs-12">
                                <input type="file" id="addAttach" class="form-control max-wide EmpImg inputFile att-margin" style="display: none">
                                <div id="imageShow">
                                                    <img id="previewHolder" style="border: 1px solid #ddd; line-height: 1.42857143;" class="center" width="150" height="100" src=""
                                                         onerror="this.src='../img/Upload.png'" 
                                                        onclick="document.getElementById('addAttach').click();" alt="Placeholder">
                                </div>
                                

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


            var tableSPG = $("#tableSPG").DataTable({
                searching: true,
                responsive: true,
                "order": []
            });

            GetTable();
            //-------ImagePreview (Only Image)  ------
            $(document).on("change", "#addAttach", function () {


                readURL(this);
            });
            
            $(document).on("click", "#btnModalNew", function () {
                $('#previewHolder').attr('src','../images/Upload.png');
                $("#text_Spc_Code").val('');
                $("#text_PicName").val('');
                $("#div_PicName").hide();
                $("#text_Spc_Code").prop('disabled',false);
                $("#TitleModalSPG").text("New");
                $("#SaveSPG").attr("data-action","Insert");
                $("#ModalSPG").modal("show");
            });

            $(document).on("click", ".btnModalEdit", function () {
                var Spc_Code = $(this).closest("tr").find("td:nth-child(1)").text();
                var PicName = $(this).closest("tr").find("td:nth-child(2)").find("div").attr("data-picname");
                console.log(PicName)
                $("#text_Spc_Code").val(Spc_Code);
                $("#text_PicName").val(PicName);
                $("#div_PicName").show();
                $("#text_Spc_Code").prop('disabled',true);
                $("#TitleModalSPG").text("Edit");
                $('#previewHolder').attr('src',PicName);
                $("#SaveSPG").attr("data-action","Edit");
                $("#ModalSPG").modal("show");
            });

            $(document).on("click", "#SaveSPG", function () {
                var Action = $(this).attr("data-action");
                //console.log(Action);
                 SaveSPG(Action);
            });
            
            function SaveSPG(Action) {
                var Spc_Code = $("#text_Spc_Code").val();
                var PicName = "//PORTALAPP01/ImgSpecialGroup/" + Spc_Code+".PNG";
                if (  Spc_Code != "" && Action !="" ) {
                    $.ajax({
                        type: "post",
                        async: false,
                        url: "<%= ResolveUrl("Default.aspx/SP_Pyramid_SpecialGroup") %>",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({
                            Spc_Code: Spc_Code,  PicName: PicName, Action: Action
                        }),
                        success: function (response) {
                            var Msg = response.d;
                            if (Msg == 'Already have Spc Code') {
                                swal('Already have Spc Code', 'มี SpcCode นี้ในระบบแล้ว', 'error');
                            } else {
                                swal('Complete', '', 'success');
                                CheckAttach(Spc_Code)
                                GetTable();
                                $("#ModalSPG").modal("hide");
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
                tableSPG.clear().draw();
                $.ajax({
                    type: "post",
                    async: false,
                    url: "<%= ResolveUrl("Default.aspx/TB_Pyramid_SpecialGroup") %>",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({  }),
                    success: function (response) {
                        if (response.d.length > 0) {
                            $.each(response.d, function (index, val) {
                                // [Spc_Code],[PicName]
                                var Spc_Code = val[0];
                                var PicName = val[1];
                                    tableSPG.row.add([
                                        Spc_Code,
                                        `<div data-picname="`+PicName+`">
                                            <img  style="border: 1px solid #ddd; line-height: 1.42857143;" class="center" width="150" height="100" src="`+ PicName +`"
                                            onerror="this.src='../images/Upload.png'" alt="Placeholder">
                                        </div>`,
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
               function readURL(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    //console.log(imagenum);
                    reader.onload = function (e) {
                        $('#previewHolder').attr('src', e.target.result);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }
            //แสดงภาพตัวอย่าง

          function CheckAttach(Spc_Code) {
                if ($("#addAttach").val() != "") {
                    var data = $("#addAttach")[0].files[0];
                    var name = Spc_Code;
                    var type = 'PNG';
                    insertFile(data, name,  type);
                }
            }

            function insertFile(data, name,  type) {
                var formData = new FormData();
                formData.append('file', data);
                formData.append('name', name);
                formData.append('type', type);
                $.ajax({
                    type: 'post',
                    url: '../Uploadfile_SpecialGroup.ashx',
                    //ต้องสร้างใหม่เป็นของ PATAG
                    data: formData,
                    async: false,
                    success: function (status) {
                        //alert("Upload Complete");
                    },
                    processData: false,
                    contentType: false,
                    error: function () {
                        alert("Whoops something went wrong!");
                    }
                });
            }

     </script>
</asp:Content>
