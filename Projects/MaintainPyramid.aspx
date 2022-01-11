<%@ Page Title="Maintain - " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintainPyramid.aspx.cs" Inherits="PyramidSystem.Projects.MaintainPyramid" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />

    <div class="container">
        <div class="col-md-12">
            <%--<button type="button" class="btn btn-primary" id="test">Primary</button>--%>
            <div class='page-header'>

                <div class='btn-toolbar pull-right'>


                    <div class="btn-group">
                        <button type="button" class="btn btn-primary" id="btnBrowse" style="width: 90px">Search <i class="fa fa-search" aria-hidden="true"></i></button>
                        <button type="button" class="btn btn-primary" id="btnNewHead" style="width: 90px">NEW&nbsp;<i class="fa fa-plus" aria-hidden="true"></i></button>
                        <button type="button" class="btn btn-primary" id="btnEdit" style="width: 90px">EDIT <i class="fa fa-pencil-square-o" aria-hidden="true"></i></button>
                        <button type="button" class="btn btn-primary" id="btnClone" style="width: 90px">Clone <i class="fa fa-copy" aria-hidden="true"></i></button>
                    </div>


                    <%--                    <div class='btn-group'>
                        <button type="button" class="btn btn-primary" id="btnBrowse" style="width: 90px" data-toggle="modal" data-target="#ModalPyramid">Search <i class="fa fa-folder-open" aria-hidden="true"></i></button>
                    </div>
                    <div class='btn-group'>
                        <button type="button" class="btn btn-success" id="btnNewHead" style="width: 90px">NEW&nbsp;<i class="fa fa-plus" aria-hidden="true"></i></button>
                    </div>
                    <div class='btn-group'>
                        <button type="button" class="btn btn-warning" id="btnEdit" style="width: 90px">EDIT <i class="fa fa-pencil-square-o" aria-hidden="true"></i></button>
                    </div>--%>

                </div>
                <h2>Maintain Pyramid <i class="fa fa-sitemap" aria-hidden="true"></i>&nbsp;&nbsp;
                         
                    <asp:Label ID="lblUserLogin" runat="server" Text="Label"></asp:Label>
                </h2>
            </div>
        </div>

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

        <div class="row" style ="float:right">
           <div class="col-md-12"></div>
       
          <%--  <center>--%>
            <i class="fa fa-user" aria-hidden="true" style="color:deepskyblue;font-size:16px"></i> <span style="color:deepskyblue;"> Active : </span> <span id="lblUserNormal"></span>


            <i class="fa fa-user" aria-hidden="true" style="color:orangered;font-size:16px;margin-left:25px"> </i> <span style="color:orangered;">  Acting : </span><span id="lblUserActing"></span>

                 <i class="fa fa-user" aria-hidden="true" style="color:orangered;font-size:16px;margin-left:25px"> </i> <span style="color:orangered;">  New : </span><span id="lblUserNew"></span>

                 <i class="fa fa-user" aria-hidden="true" style="color:orangered;font-size:16px;margin-left:25px"> </i> <span style="color:orangered;">  Replace : </span><span id="lblUserReplace"></span>
                  
                <i class="fa fa-user" aria-hidden="true" style="color:deeppink;font-size:16px;margin-left:25px"> </i> <span style="color:deeppink;"> Subcontractor : </span><span id="lblUserSub"></span>
                
                <i class="fa fa-user" aria-hidden="true" style="color:dimgray;font-size:16px;margin-left:25px">  </i> <span style="color:dimgray;"> Skip : </span><span id="lblUserSkip"></span>
              
                <%-- </center>--%>
           
        </div>

        <div style="clear: both; height: 30px"></div>
        <div class="row" id="PanelTablePyramid">
            <div class="col-md-12">
                <table class="table table-bordered" id="TablePyramid">
                    <thead id="TheadPyramid">
                        <tr>
                            <th><span style="margin-top: 20px;">E17</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddE17" style="float: right;"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">E16</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddE16" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">E15</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddE15" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">M14</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddM14" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">M13-M12</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddM13_M12" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">S11-S9</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddS11_S9" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">G8-G5</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddG8_G5" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">O4</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddO4" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">O3-O2</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddO3" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>
                            <th><span style="margin-top: 20px;">D2-D1</span>
                                <button type="button" class="btn btn-link btn-xs" id="btnAddD2_D1" style="float: right; display: none"><i class="fa fa-plus-square" aria-hidden="true" style="font-size: 20px; color: forestgreen;"></i></button>
                            </th>

                        </tr>
                    </thead>
                    <tbody id="Pyramid_insertRowText">
                        <tr>
                            <td style="width: 130px" id="col1"></td>
                            <td style="width: 130px" id="col2"></td>
                            <td style="width: 130px" id="col3"></td>
                            <td style="width: 130px" id="col4"></td>
                            <td style="width: 130px" id="col5"></td>
                            <td style="width: 130px" id="col6"></td>
                            <td style="width: 130px" id="col7"></td>
                            <td style="width: 130px" id="col8"></td>
                            <td style="width: 130px" id="col9"></td>
                            <td style="width: 130px" id="col10"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>



        <br>
    </div>

    <div id="ModalNewBox" class="modal modal-wide fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Information Form : <span id="lblRoleID_Modal" style="display: none"></span></h4>
                    <span id="lblheadCol" style="display: none"></span>
                    <span id="lblRefRoleID_Modal" style="display: none"></span>
                </div>
                <div class="modal-body" style="overflow-y: auto; max-height: calc(100vh - 230px);">
                    <div class="container">
                        <table class="table table-bordered">
                            <thead style="background-color: #efeded">
                                <tr>
                                    <th style="width: 50%">New Box <i class="fa fa-cube"></i></th>
                                    <th style="width: 50%">Dot Line Command <i class="fa fa-user-circle-o"></i></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Employee :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <div class="input-group">
                                                                <input type="text" id="txtEmp_Newbox" class="form-control" style="max-width: 100%" placeholder="Search" disabled>
                                                                <div class="input-group-btn">
                                                                    <button class="btn btn-default" id="btnEmp_Newbox" type="button" data-toggle="modal" data-target="#ModalSearchEmp" data-backdrop="false">
                                                                        <i class="glyphicon glyphicon-search"></i>
                                                                    </button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Name :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblName_Newbox"></span>
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Position :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblPosition_Newbox"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Level :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblLevel_Newbox"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">CostCenter :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblDept_Newbox"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Group :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblGroup_Newbox"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="panel panel-default" style="margin-top: 5px">
                                            <div class="panel-heading" style="background-color: #efeded"><span style="font-weight: bold;">Pyramid Box</span></div>
                                            <div class="panel-body" style="background-color: #f9f9f9">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>CostCenter :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <div class="input-group">
                                                                        <input type="text" id="txtDept_PyramidBox" class="form-control" style="max-width: 100%" placeholder="Search">
                                                                        <div class="input-group-btn">
                                                                            <button class="btn btn-default" id="btnDept_PyramidBox" type="button" data-toggle="modal" data-backdrop="false" data-target="#ModalSearchDeptPyramid">
                                                                                <i class="glyphicon glyphicon-search"></i>
                                                                            </button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>Level :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <input type="text" class="form-control" id="txtLevel_Newbox" style="max-width: 100%" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>Position :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <div class="input-group">
                                                                        <span id="lblJobCode" style="display:none"></span>
                                                                        <input type="text" id="txtPosition_Newbox" class="form-control" style="max-width: 100%" placeholder="Search">
                                                                        <div class="input-group-btn">
                                                                            <button class="btn btn-default" id="btnPosition_PyramidBox" type="button" data-backdrop="false">
                                                                                <i class="glyphicon glyphicon-search"></i>
                                                                            </button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row" id="PanelActing">
                                                                <div class="col-md-2 col-xs-4">
                                                                    <label class="checkbox-inline">
                                                                        <input type="checkbox" id="CB_Acting" name="CB_Acting" value="Acting">Acting</label>
                                                                </div>
                                                                 <div class="col-md-2 col-xs-4">
                                                                    <label class="checkbox-inline">
                                                                        <input type="checkbox" id="CB_ActingMain" name="CB_ActingMain" value="1">Main</label>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row" id="PanelActingType" >
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-12 col-xs-12">
                                                                    <label class="radio-inline">
                                                                        <input type="radio" name="optradio" value="Future" class="radio_typePyramid" id="radio_Fu">Future</label>
                                                                    <label class="radio-inline">
                                                                        <input type="radio" name="optradio" value="New" class="radio_typePyramid" id="radio_In">New</label>
                                                                    <label class="radio-inline">
                                                                        <input type="radio" name="optradio" value="Replace" class="radio_typePyramid" id="radio_Ex">Replace</label>
                                                                    <label class="radio-inline">
                                                                        <input type="radio" name="optradio" value="None" class="radio_typePyramid" id="radio_None">None</label>
                                                                    <label class="radio-inline" style="display:none">
                                                                        <input type="radio" name="optradio" value="Main" class="radio_typePyramid" id="radio_Main">Main</label>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>Special Group :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <div class="input-group">
                                                                        <input type="text" id="txtSpecialGroup_Newbox" class="form-control" style="max-width: 100%" placeholder="Search">
                                                                        <div class="input-group-btn">
                                                                            <button class="btn btn-default" id="btnSpecialGroup_PyramidBox" type="button" data-toggle="modal" data-backdrop="false" data-target="#ModalSearchSpcGroup">
                                                                                <i class="glyphicon glyphicon-search"></i>
                                                                            </button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>Remark :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <textarea class="form-control" rows="4" id="TB_RemarkNewbox" style="max-width: 100%"></textarea>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                    </td>

                                    <td>
                                        <div class="row" style="display: none">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <%-- <p style="/*margin-left: 10px*/">Role :</p>--%>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <div class="input-group" style="display: none">
                                                                <input type="text" id="txtRole_Command" class="form-control" style="max-width: 100%" placeholder="Search">
                                                                <div class="input-group-btn">
                                                                    <button class="btn btn-default" id="btnRole_Command" type="button" data-toggle="modal" data-backdrop="false" data-target="#ModalSearchDeptPyramid">
                                                                        <i class="glyphicon glyphicon-search"></i>
                                                                    </button>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Employee :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <div class="input-group">
                                                                <input type="text" id="txtEmpCommand" class="form-control" style="max-width: 100%" placeholder="Search" disabled>
                                                                <div class="input-group-btn">
                                                                    <button class="btn btn-default" id="btnEmpCommand" type="button" data-toggle="modal" data-backdrop="false" data-target="#ModalSearchEmpCommand">
                                                                        <i class="glyphicon glyphicon-search"></i>
                                                                    </button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Name :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblName_Command"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Position :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblPosition_Command"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">Level :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblLevel_Command"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-3 col-xs-4">
                                                            <p style="margin-left: 10px">CostCenter :</p>
                                                        </div>
                                                        <div class="col-md-9 col-xs-8">
                                                            <span id="lblDept_Command"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div style="clear: both; height: 50px"></div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading" style="background-color: #efeded"><span style="font-weight: bold">Pyramid Box</span></div>
                                            <div class="panel-body" style="background-color: #f9f9f9">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>CostCenter :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <div class="input-group">
                                                                        <input type="text" id="txtDept_Command" class="form-control" style="max-width: 100%" placeholder="Search">
                                                                        <div class="input-group-btn">
                                                                            <button class="btn btn-default" id="btnDept_Command" type="button" data-toggle="modal" data-backdrop="false" data-target="#ModalSearchDeptCommand">
                                                                                <i class="glyphicon glyphicon-search"></i>
                                                                            </button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>Level :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <input type="text" class="form-control" id="txtLevel_Command" style="max-width: 100%" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>Position :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <div class="input-group">
                                                                        <span id="lblJobCode_Command" style="display:none"></span>
                                                                        <input type="text" id="txtPosition_Command" class="form-control" style="max-width: 100%" placeholder="Search">
                                                                        <div class="input-group-btn">
                                                                            <button class="btn btn-default" id="btnPosition_Command" type="button" data-backdrop="false">
                                                                                <i class="glyphicon glyphicon-search"></i>
                                                                            </button>
                                                                        </div>
                                                                    </div>
                                                                    <%--  <textarea class="form-control" rows="2" id="txtPosition_Command"></textarea>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>Special Group :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <div class="input-group">
                                                                        <input type="text" id="txtSpecialGroup_Command" class="form-control" style="max-width: 100%" placeholder="Search">
                                                                        <div class="input-group-btn">
                                                                            <button class="btn btn-default" id="btnSpecialGroup_Command" type="button" data-toggle="modal" data-backdrop="false" data-target="#ModalSearchSpcGroup_Commmand">
                                                                                <i class="glyphicon glyphicon-search"></i>
                                                                            </button>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-3 col-xs-4">
                                                                    <p>Remark :</p>
                                                                </div>
                                                                <div class="col-md-9 col-xs-8">
                                                                    <textarea class="form-control" rows="4" id="TB_Remark_Command" style="max-width: 100%"> </textarea>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div style="clear: both; height: 50px"></div>
                                            </div>

                                        </div>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" style="display: none" id="btnDelBox">Delete Box&nbsp;<i class="fa fa-trash" aria-hidden="true"></i></button>

                    <button type="button" class="btn btn-primary" id="btnSaveBox" style="width: 100px">Save&nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalSearchEmp" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Employee Search</h4>
                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchEmp" placeholder="Search Code Or Name" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableEmp" class="table table-bordered table-responsive">
                        <thead id="Emp_theadtable" runat="server">
                            <tr>
                                <th>Code</th>
                                <th>Name</th>
                                <th>Position</th>
                                <th>Level</th>
                                <th>CostCenter</th>
                            </tr>
                        </thead>
                        <tbody id='Emp_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ModalSearchEmpCommand" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Employee Search</h4>
                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchEmpCommand" placeholder="Search Code Or Name" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableEmpCommand" class="table table-bordered table-responsive">
                        <thead id="Thead2" runat="server">
                            <tr>
                                <th>Code</th>
                                <th>Name</th>
                                <th>Position</th>
                                <th>Level</th>
                                <th>CostCenter</th>
                            </tr>
                        </thead>
                        <tbody id='EmpCommand_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>



    <div class="modal fade" id="ModalSearchDeptPyramid" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Department Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchDeptPyramid" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchDeptPyramid" class="table table-bordered table-responsive">
                        <thead id="Thead1" runat="server">
                            <tr>

                                <th>Code</th>
                                <th>Name </th>

                            </tr>
                        </thead>
                        <tbody id='DeptPyramid_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


    <div id="ModalNewHead" class="modal modal-wide fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">New Pyramid</h4>
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
                                                <select id="SelectCompany_N" class="form-control" style="max-width: 500px;">
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
                                                    <span id="lblGroup_N" style="display: none"></span>
                                                    <input type="text" id="txtGroup_N" class="form-control" style="max-width: 100%" placeholder="Search">
                                                    <div class="input-group-btn">
                                                        <button class="btn btn-default" id="btnGroup_N" type="button" data-toggle="modal" data-target="#ModalSearchGroup" data-backdrop="false">
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
                                                <div class="input-group">
                                                    <span id="lblDept_N" style="display: none"></span>
                                                    <input type="text" id="txtDept_N" class="form-control" style="max-width: 100%" placeholder="Search">
                                                    <div class="input-group-btn">
                                                        <button class="btn btn-default" id="btnDept_N" type="button" data-backdrop="false">
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
                                                <%--<p>Revision </p>--%>
                                                <p>Effect Date</p>
                                            </div>
                                            <div class="col-md-9 col-xs-8">
                                                <input id="txtEffectDate_N" type="text" class="form-control" style="max-width: 100%" placeholder="dd/mm/yyyy">
                                                <input type="text" id="txtRevision_N" onkeypress="return isNumberKey(event)" class="form-control" style="max-width: 100%; display: none" placeholder="Please insert number">
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
                                                <select class="form-control" id="SelectStatus_N" style="max-width: 100%">
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
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close&nbsp;&times;</button>
                    <button type="button" class="btn btn-primary" id="btnSaveHead" style="width: 100px">Save&nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade" id="ModalSearchDept_N" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Department Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchDept" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchDept" class="table table-bordered table-responsive">
                        <thead id="Thead4" runat="server">
                            <tr>

                                <th>Code</th>
                                <th>Name </th>

                            </tr>
                        </thead>
                        <tbody id='Dept_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>



    <div id="ModalEditHead" class="modal modal-wide fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Pyramid : Edit <i class="fa fa-pencil-square-o" aria-hidden="true"></i></h4>
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
                                                <select id="SelectCompany_E" class="form-control" style="max-width: 500px;">
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
                                                <span id="lblGroup_E" style="display: none"></span>
                                                <div class="input-group">
                                                    <input type="text" id="txtGroup_E" class="form-control" style="max-width: 100%" placeholder="Search">
                                                    <div class="input-group-btn">
                                                        <button class="btn btn-default" id="btnGroup_E" type="button" data-toggle="modal" data-target="#ModalSearchGroup" data-backdrop="false">
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
                                                <span id="lblDept_E" style="display: none"></span>
                                                <div class="input-group">

                                                    <input type="text" id="txtDept_E" class="form-control" style="max-width: 100%" placeholder="Search">
                                                    <div class="input-group-btn">
                                                        <button class="btn btn-default" id="btnDept_E" type="button" data-backdrop="false">
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
                                                <input type="text" id="txtRevision_E" onkeypress="return isNumberKey(event)" class="form-control" disabled style="max-width: 100%;" placeholder="Please insert number">
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
                                                <p>Effect Date</p>
                                            </div>
                                            <div class="col-md-9 col-xs-8">
                                                <input id="txtEffectDate_E" type="text" class="form-control" style="max-width: 100%" placeholder="dd/mm/yyyy">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-3 col-xs-4">
                                                <p>Status</p>
                                            </div>

                                            <div class="col-md-9 col-xs-8">
                                                <select class="form-control" id="SelectStatus_E" style="max-width: 100%">
                                                    <option value="Draft">Draft</option>
                                                    <option value="Active">Active</option>
                                                    <option value="InActive">InActive</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close&nbsp;&times;</button>
                    <button type="button" class="btn btn-primary" id="btnSaveHead_E" style="width: 100px">Save&nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
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

    <div class="modal fade" id="ModalSearchDept_E" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Department Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchDept_E" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchDept_E" class="table table-bordered table-responsive">
                        <thead id="Thead5" runat="server">
                            <tr>

                                <th>Code</th>
                                <th>Name </th>

                            </tr>
                        </thead>
                        <tbody id='Dept_insertRowText_E'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ModalSearchDeptCommand" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Department Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchDeptCommand" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchDeptCommand" class="table table-bordered table-responsive">
                        <thead id="Thead6" runat="server">
                            <tr>

                                <th>Code</th>
                                <th>Name </th>

                            </tr>
                        </thead>
                        <tbody id='DeptCommand_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalSearchPosition" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Position Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchPosition" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchPosition" class="table table-bordered table-responsive">
                        <thead id="Thead7" runat="server">
                            <tr>
                                <th>Position</th>
                            </tr>
                        </thead>
                        <tbody id='Position_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ModalSearchPosition_Command" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Position Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchPosition_Command" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchPosition_Command" class="table table-bordered table-responsive">
                        <thead id="Thead8" runat="server">
                            <tr>
                                <th>Position</th>
                            </tr>
                        </thead>
                        <tbody id='Position_insertRowText_Command'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
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

    <div class="modal fade" id="ModalSearchSpcGroup" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Special Group Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchSpcGroup" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchSpcGroup" class="table table-bordered table-responsive">
                        <thead id="Thead10" runat="server">
                            <tr>

                                <th>Code</th>
                                <th>Picture </th>

                            </tr>
                        </thead>
                        <tbody id='SpcGroup_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalSearchSpcGroup_Commmand" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <div class="col-md-12 col-lg-12 col-sm-12" style="margin-bottom: 1em; padding-left: 0.5em;">
                        <button type="button" class="close" data-dismiss="modal" style="font-size: 2.5em;">&times;</button>
                        <h4 class="modal-title">Special Group Search &nbsp;&nbsp;</h4>

                    </div>
                    <div class="col-md-12 col-lg-12 col-sm-12" style="padding-left: 5px;">
                        <input type="text" class="form-control" id="txtsearchSpcGroup_Commmand" placeholder="Search data" autocomplete="off" />
                    </div>
                </div>
                <div class="modal-body" style="overflow-y: scroll; max-height: 28em;">
                    <table id="TableSearchSpcGroup_Commmand" class="table table-bordered table-responsive">
                        <thead id="Thead11" runat="server">
                            <tr>

                                <th>Code</th>
                                <th>Picture </th>

                            </tr>
                        </thead>
                        <tbody id='SpcGroup_Command_insertRowText'>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            //var table = $('#TableSearchPyramid').DataTable({ searching: false });
            $('#txtEffectDate_N').datepicker({ format: 'dd/mm/yyyy' });
            $('#txtEffectDate_E').datepicker({ format: 'dd/mm/yyyy' });

            var Username = $("#MainContent_lblUserLogin").html();

            $("#MainContent_lblUserLogin").hide();

            $('.loading').hide();

            var CheckShow = '';

            loadcompany();

            visible_ButtonEditHeader();



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

                        $("#SelectCompany_N").append(column);
                        $("#SelectCompany_E").append(column);
                        $("#SelectCompany_S").append(column);

                        //$("select#SelectCompany_N").val('0'); 

                        $("select#SelectCompany_S")[0].selectedIndex = 1;
                        $("select#SelectCompany_E")[0].selectedIndex = 1;
                        $("select#SelectCompany_N")[0].selectedIndex = 1;


                        //$("#SelectCompany_N").val("PK");
                        //$("#SelectCompany_S").val("CHA");
                        //$("#SelectCompany_E").val("PK");


                    });

            }

            //visible_ButtonEditHeader();

            function visible_ButtonEditHeader() {

                var Company = $('#lblCompany').text();
                if (Company == '') {
                    $('#btnEdit').hide();
                    $('#btnClone').hide();

                } else {
                    $('#btnEdit').show();
                    $('#btnClone').show();
                }

            }



            $('#btnNewHead').on('click', function () {

                ClearNewHeader();
                $('#ModalNewHead').modal('show');

            });


            $('#btnBrowse').on('click', function () {

                ClearSearchHeader()
                $('#ModalPyramid').modal('show');

            });





            $('#btnEdit').on('click', function () {

                $('#ModalEditHead').modal('show');

                var txtRevision = $('#lblRevision').text();
                var txtGroup = $('#lblGroup').text();
                var txtDept = $('#lblDept').text();
                var txtEffectDate = $('#lblEffectDate').text();
                var company = $('#lblCompany').text();
                var CompanyCode = $('#lblCompanyCode').text();
                var GroupID = $('#lblGroupID').text();
                var DeptID = $('#lblDeptID').text();
                var Status = $('#lblStatus').text();

                $('#txtRevision_E').val(txtRevision);
                $('#txtGroup_E').val(txtGroup);
                $('#txtDept_E').val(txtDept);
                $('#txtEffectDate_E').val(txtEffectDate);
                $('#SelectCompany_E').val(CompanyCode);
                $('#SelectStatus_E').val(Status);


                $('#lblGroup_E').text(GroupID);
                $('#lblDept_E').text(DeptID);


            });

            $("#btnEmp_Newbox").on('click', function () {
                browseEmp();
            });


            ///////////////////////////////////////
            $("#btnEmpCommand").on('click', function () {
                browseEmpCommand();
            });

            /////////////////////////////////////////



            function browseEmp() {

                $("#txtsearchEmp").val("");
                $("#Emp_insertRowText").empty();
                var data = { Site_ref: "", Search: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadEmp") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchEmp,
                });

                function ModalSearchEmp(response) {
                    //$("#Emp_insertRowText").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {
                            var Code = val.EmpCode;
                            var Name = val.Fullname;
                            var Position = val.JobTitle;
                            var Level = val.Level;
                            var costcenter = val.costcenter;
                            var job_id = val.job_id;

                            fragment += '<tr>';
                            fragment += '<td class="Code"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + Code + '</a></td>';
                            fragment += '<td class="Name"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Name + '</a></td>';
                            fragment += '<td class="Position"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Position + '</a></td>';
                            fragment += '<td class="Level"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Level + '</a></td>';
                            fragment += '<td class="costcenter"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + costcenter + '</a></td>';
                            fragment += '<td class="job_id" style="display:none"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + job_id + '</a></td>';
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
                        fragment += '</tr>';
                    }
                    $("#Emp_insertRowText").append(fragment);
                }

                $('#Emp_insertRowText').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#Emp_insertRowText tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#Emp_insertRowText tr:eq(' + numindex + ') .Name a').html(),
                        Position = $('#Emp_insertRowText tr:eq(' + numindex + ') .Position a').html(),
                        Level = $('#Emp_insertRowText tr:eq(' + numindex + ') .Level a').html(),
                        costcenter = $('#Emp_insertRowText tr:eq(' + numindex + ') .costcenter a').html()
                        job_id = $('#Emp_insertRowText tr:eq(' + numindex + ') .job_id a').html()


                     var ReplaceName = Name.replace("&nbsp;", " ");


                    $('#txtEmp_Newbox').val(Code.trim());
                    $('#lblName_Newbox').text(ReplaceName);
                    $('#lblPosition_Newbox').text(Position);
                    $('#lblLevel_Newbox').text(Level);
                    $('#lblDept_Newbox').text(costcenter);


                    $('#txtDept_PyramidBox').val(costcenter);
                    $('#txtLevel_Newbox').val(Level);
                    $('#txtPosition_Newbox').val(Position);

                    
                    $('#lblJobCode').text(job_id);

                  //  DisplayActing(Code.trim());


                });

                $("#txtsearchEmp").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Emp_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });



               <%-- $("#txtsearchEmp").on("change", function () {

                    $("#txtsearchEmp").empty();
                    var value = $(this).val();

                    //alert(value);
                    var data = { Site_ref: "", Search: value };

                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadEmp") %>",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: ModalSearchEmp,
                    });
                });--%>



            }
            ///////////////////////////////////
            function browseEmpCommand() {

                $("#txtsearchEmpCommand").val("");
                $("#EmpCommand_insertRowText").empty();
                var data = { Site_ref: "ERP_PK", Search: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadEmp") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchEmpCommand,
                });

                function ModalSearchEmpCommand(response) {
                    $("#EmpCommand_insertRowText").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {
                            var Code = val.EmpCode;
                            var Name = val.Fullname;
                            var Position = val.JobTitle;
                            var Level = val.Level;
                            var costcenter = val.costcenter;
                            var job_id = val.job_id;

                            fragment += '<tr>';
                            fragment += '<td class="Code"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + Code + '</a></td>';
                            fragment += '<td class="Name"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Name + '</a></td>';
                            fragment += '<td class="Position"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Position + '</a></td>';
                            fragment += '<td class="Level"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Level + '</a></td>';
                            fragment += '<td class="costcenter"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + costcenter + '</a></td>';
                            fragment += '<td class="job_id" style="display:none"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + job_id + '</a></td>';
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
                        fragment += '</tr>';
                    }
                    $("#EmpCommand_insertRowText").append(fragment);
                }

                $('#EmpCommand_insertRowText').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#EmpCommand_insertRowText tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#EmpCommand_insertRowText tr:eq(' + numindex + ') .Name a').html(),
                        Position = $('#EmpCommand_insertRowText tr:eq(' + numindex + ') .Position a').html(),
                        Level = $('#EmpCommand_insertRowText tr:eq(' + numindex + ') .Level a').html(),
                        costcenter = $('#EmpCommand_insertRowText tr:eq(' + numindex + ') .costcenter a').html()
                        job_id = $('#EmpCommand_insertRowText tr:eq(' + numindex + ') .job_id a').html()



                    var ReplaceName = Name.replace("&nbsp;", " ");

                    $('#txtEmpCommand').val(Code.trim());
                    $('#lblName_Command').text(ReplaceName);
                    $('#lblDept_Command').text(costcenter);
                    $('#lblLevel_Command').text(Level);
                    $('#lblPosition_Command').text(Position);

                    $('#txtDept_Command').val(costcenter);
                    $('#txtLevel_Command').val(Level);
                    $('#txtPosition_Command').val(Position);
                    $('#lblJobCode_Command').text(job_id);

                });


               <%-- $("#txtsearchEmpCommand").on("change", function () {

                    $("#txtsearchEmpCommand").empty();
                    var value = $(this).val();


                    var data = { Site_ref: "", Search: value };

                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadEmp") %>",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        dataType: "json",
                        success: ModalSearchEmpCommand,
                    });
                });--%>



                $("#txtsearchEmpCommand").on("keyup", function () {

                    var value = $(this).val().toLowerCase();
                    $("#EmpCommand_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });

                });
            }
            //////////////////////////////////////


            $("#btnDept_PyramidBox").on('click', function () {

                browseDeptPyramid();
            });



            function browseDept() {

                var GroupID = $('#lblGroup_N').text();
                var CompCode = $('#SelectCompany_N option:selected').val();


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
                    $("#Dept_insertRowText").empty();
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
                    $("#Dept_insertRowText").append(fragment);
                }

                $('#Dept_insertRowText').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#Dept_insertRowText tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#Dept_insertRowText tr:eq(' + numindex + ') .Name a').html()

                    //var dept = Code.substring(1, 3);

                         var ReplaceName = Name.replace("amp;", "");

                    $('#txtDept_N').val(ReplaceName);
                    $('#lblDept_N').text(Code);

                });

                $("#txtsearchDept").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Dept_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });
            }


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



            function browseDept_E() {

                var GroupID = $('#lblGroup_E').text();
                var CompCode = $('#SelectCompany_E option:selected').val();


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
                    $("#Dept_insertRowText_E").empty();
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
                    $("#Dept_insertRowText_E").append(fragment);
                }

                $('#Dept_insertRowText_E').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#Dept_insertRowText_E tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#Dept_insertRowText_E tr:eq(' + numindex + ') .Name a').html()


                    var ReplaceName = Name.replace("amp;", "");
                    $('#txtDept_E').val(ReplaceName);
                    $('#lblDept_E').text(Code);

                });

                $("#txtsearchDept_E").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Dept_insertRowText_E tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });
            }


            function browseDeptPyramid() {

                var data = { Site_ref: "ERP_PK", Search: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadCostCenter") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchCostCenter,
                });

                function ModalSearchCostCenter(response) {
                    $("#DeptPyramid_insertRowText").empty();
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
                    $("#DeptPyramid_insertRowText").append(fragment);
                }

                $('#DeptPyramid_insertRowText').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#DeptPyramid_insertRowText tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#DeptPyramid_insertRowText tr:eq(' + numindex + ') .Name a').html()

                    //var DeptPyramid = Code.substring(1, 3);

                    $('#txtDept_PyramidBox').val(Code);

                });

                $("#txtsearchDeptPyramid").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#DeptPyramid_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });
            }

            function browseDept_Command() {

                var data = { Site_ref: "ERP_PK", Search: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadCostCenter") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchCostCenter,
                });

                function ModalSearchCostCenter(response) {
                    $("#DeptCommand_insertRowText").empty();
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
                    $("#DeptCommand_insertRowText").append(fragment);
                }

                $('#DeptCommand_insertRowText').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#DeptCommand_insertRowText tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#DeptCommand_insertRowText tr:eq(' + numindex + ') .Name a').html()

                    //var DeptPyramid = Code.substring(1, 3);

                    $('#txtDept_Command').val(Code);

                });

                $("#txtsearchDeptCommand").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#DeptCommand_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
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

            $('#btnAddBox').on('click', function () {

                $('#ModalNewBox').modal('show');


            });

            $('#btnSaveBox').on('click', function () {

                var RoleID = $('#lblRoleID_Modal').text();

                var EmpNum = $('#txtEmp_Newbox').val();
                var Dept = $('#txtDept_PyramidBox').val();
                var Level = $('#txtLevel_Newbox').val();
                var Postion = $('#txtPosition_Newbox').val();
                var SpcGroup = $('#txtSpecialGroup_Newbox').val();

                var msg = "";

                if ($('#CB_Acting').is(':checked')) {

                    ActingType = $("input[name='optradio']:checked").val();

                    if (ActingType == null) {
                        msg += "Acting Type, "
                    }

                }


                if (EmpNum == "") {
                    msg += "Emp Num, ";
                }
                //if (Dept == "") {
                //    msg += "Department, ";
                //}
                //if (Level == "") {
                //    msg += "Level, ";
                //}
                //if (Postion == "") {
                //    msg += "Postion, ";
                //}

                //if (SpcGroup == "") {
                //    msg += "Special Group";
                //}
                if (msg != "") {

                    $.alert({

                        title: 'Alert',
                        content: 'Please insert !! ' + msg,
                        type: 'red'

                    });


                } else {

                    if (RoleID != "") {

                        SaveBox("Update", RoleID);

                    } else {

                        SaveBox("Insert", RoleID);
                    }



                    $('#ModalNewBox').modal('hide');

                }

            });


            function SaveBox(Action, RoleID) {


                var Acting = 0;
                var ActingType = '';
                var ActingMain = 0;

                if ($('#CB_Acting').is(':checked')) {

                    Acting = 1;
                }
                else {

                    Acting = 0;
                }


                if ($('#CB_ActingMain').is(':checked')) {

                    ActingMain = 1;
                }
                else {

                    ActingMain = 0;
                }




                if ($('.radio_typePyramid').is(':checked')) {

                    ActingType = $("input[name='optradio']:checked").val();
                }





                var data = {
                    Pyramid_ID: $('#lblPyramidID').text(),
                    RoleID: RoleID,
                    RefRoleID: $('#lblRefRoleID_Modal').text(),
                    Role: $('#lblheadCol').text(),
                    RoleCode: $('#lblDeptID').text(),
                    EmpNum: $('#txtEmp_Newbox').val(),
                    EmpName: $('#lblName_Newbox').text(),
                    Dept: $('#txtDept_PyramidBox').val(),
                    Level_Emp: $('#txtLevel_Newbox').val(),
                    Position: $('#txtPosition_Newbox').val(),
                    Acting: Acting,
                    ActingMain: ActingMain,
                    ActingType: ActingType,
                    SpecialGroup: $('#txtSpecialGroup_Newbox').val(),
                    Remark: $('#TB_RemarkNewbox').val(),
                    CreateBy: Username,
                    Action: Action,
                    Position_Code: $('#lblJobCode').text(),


                    //////////DotLineCommand/////////
                    ID: '',
                    Role_Command: $('#txtRole_Command').val(),
                    Emp_Command: $('#txtEmpCommand').val(),
                    EmpName_Command: $('#lblName_Command').text(),
                    Dept_Command: $('#txtDept_Command').val(),
                    Level_Command: $('#txtLevel_Command').val(),
                    Position_Command: $('#txtPosition_Command').val(),
                    Remark_Command: $('#TB_Remark_Command').val(),
                    SpecialGroup_Command: $('#txtSpecialGroup_Command').val(),
                    Status: $('#lblStatus').text(), //27/06/2019
                    Position_Code_Command : $('#lblJobCode_Command').text(),

                };


                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/InsertPyramidLine") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowAlert
                });


                function ShowAlert(response) {
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {

                            var headCol = $('#lblheadCol').text();

                            var EmpNum = val.EmpNum;
                            var EmpName = val.EmpName;
                            var Level_Emp = val.Level_Emp;
                            var Position = val.Position;
                            var Dept = val.Dept;
                            var Acting = val.Acting;
                            var ActingMain = val.ActingMain;

                            var RoleID = val.RoleID;
                            var RefRoleID = val.RefRoleID;
                            var SpecialGroup = val.SpecialGroup;
                            var MsgReturn = val.MsgReturn;
                            var Path = val.Path;
                            var headCol = val.CheckColumn;
                            

                            var ActingType = '';

                            if (val.ActingType != "") {

                                ActingType = "Acting : " + val.ActingType
                            }


                            $.alert({

                                title: 'Alert',
                                content: MsgReturn,
                                type: 'green'

                            })

                            LoadCountPerson();

                            SetBox(headCol, RoleID, RefRoleID, EmpNum, EmpName, Level_Emp, Position, Dept, Acting, SpecialGroup, RefRoleID, Action, ActingType, Path,ActingMain);






                        });


                    } else {

                        $.alert({

                            title: 'Alert',
                            content: 'You have already that User Account in Pyramid !!!',
                            type: 'red'

                        })

                    }



                }


            }




            function SetBox(headCol, RoleID, RefRoleID, EmpNum, EmpName, Level_Emp, Position, Dept, Acting, SpecialGroup, RefRoleID, Action, ActingType, Path,ActingMain) {


                var HeadPanelColor = "";
                var BodyPanelColor = "";
                var row = "";

                if (Acting == 1) { //สีส้ม

                    HeadPanelColor += "background-image: linear-gradient(#f0ad4e, #f0ad4e 50%, #eea236);"
                    HeadPanelColor += "background-repeat: no-repeat;"
                    HeadPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);"
                    HeadPanelColor += "border: 0px solid #eea236;height:40px;"
                    HeadPanelColor += "border-radius: 0px;height:40px;"
                    //BodyPanelColor += "background-image: linear-gradient(#f0ad4e, #f0ad4e 50%, #eea236);"
                    //BodyPanelColor += "ackground-repeat: no-repeat;"
                    BodyPanelColor += "border: 1px solid #eea236;"
                    BodyPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);height:138px;"
                    //BodyPanelColor += "border-radius: 3px;"


                } else {

                    if (EmpNum == "0") //สีเทา
                    {


                        HeadPanelColor += "background-image: linear-gradient(#afafaf, #afafaf 60%, #a8a8a8);"
                        HeadPanelColor += "background-repeat: no-repeat;"
                        HeadPanelColor += "border: 0px solid #a8a8a8;"
                        HeadPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);"
                        HeadPanelColor += "border-radius: 0px;height:40px;"

                        //BodyPanelColor += "background-image: linear-gradient(#afafaf, #afafaf 60%, #a8a8a8);"
                        //BodyPanelColor += "ackground-repeat: no-repeat;"
                        BodyPanelColor += "border: 1px solid #a8a8a8;"
                        BodyPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);height:138px;"
                        //BodyPanelColor += "border-radius: 0px;"


                    }
                    else if (EmpNum == "S0001")  //สีบานเย็น
                    {
                        HeadPanelColor += "background-image: linear-gradient(#e06ba5, #e06ba5 60%, #e25fa0);"
                        HeadPanelColor += "background-repeat: no-repeat;"
                        HeadPanelColor += "border: 0px solid #e06ba5;"
                        HeadPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);height:40px;"
                        HeadPanelColor += "border-radius: 0px;"


                        BodyPanelColor += "border: 1px solid #e06ba5;"

                        //BodyPanelColor += "background-image: linear-gradient(#e06ba5, #e06ba5 60%, #e25fa0);"
                        //BodyPanelColor += "ackground-repeat: no-repeat;"
                        //BodyPanelColor += "border-bottom: 1px solid #e25fa0;"
                        BodyPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);height:138px;"
                        //BodyPanelColor += "border-radius: 0px;"

                    }
                    else if (EmpNum == "1" || EmpNum == "2")  //สีส้ม
                    {
                        HeadPanelColor += "background-image: linear-gradient(#f0ad4e, #f0ad4e 50%, #eea236);"
                        HeadPanelColor += "background-repeat: no-repeat;"
                        HeadPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);"
                        HeadPanelColor += "border: 0px solid #eea236;height:40px;"
                        HeadPanelColor += "border-radius: 0px;height:40px;"
                        //BodyPanelColor += "background-image: linear-gradient(#f0ad4e, #f0ad4e 50%, #eea236);"
                        //BodyPanelColor += "ackground-repeat: no-repeat;"
                        BodyPanelColor += "border: 1px solid #eea236;"
                        BodyPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);height:138px;"
                        //BodyPanelColor += "border-radius: 3px;"

                    }
                    else {

                        HeadPanelColor += "background-image: linear-gradient(#37bdef, #37bdef 60%, #2db9ed);"
                        HeadPanelColor += "background-repeat: no-repeat;"
                        HeadPanelColor += "border: 0px solid #37bdef;"
                        HeadPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);height:40px;"
                        HeadPanelColor += "border - radius: 0px;"

                        BodyPanelColor += "border: 1px solid #37bdef;"

                        //BodyPanelColor += "background-image: linear-gradient(#37bdef, #37bdef 60%, #2db9ed);"
                        //BodyPanelColor += "ackground-repeat: no-repeat;"
                        //BodyPanelColor += "border-bottom: px solid #2db9ed;"
                        BodyPanelColor += "box-shadow: 0px 1px 10px rgba(0, 0, 0, 0.1);height:138px;"
                        //BodyPanelColor += "border-radius: 3px;"
                    }
                }


                var Col = $('#lblheadCol').text();
                //yam
                //alert(Col)

                if (Action == 'Insert') {

                    row += '<div class="Content' + RoleID + '">'
                    row += '<div class="Box panel panel-default" style="width:145px;" id="PanalBox' + RoleID + '" >'
                    row += '<div class="panel-heading" style="' + HeadPanelColor + ';"  id="headingBox' + RoleID + '">'
                    row += '<span id = "lblCol' + RoleID + '" style = "display:none" > >' + Col + '</span >'
                    row += '<span id = "lblRoleID' + RoleID + '" style = "display:none" >' + RoleID + '</span >'
                    row += '<span id = "lblRefRoleID' + RefRoleID + '"  style = "display:none" >' + RefRoleID + '</span >'

                    row += '<span id = "lblCheckColumn' + RoleID + '"  style = "display:none">' + headCol + '</span >'




                    if (Path != "") {
                        row += '<img id="PathSpcGroup' + RoleID + '" style="margin-right:3px;height:13px;width13px;"  src="' + Path + '" />'
                    }
                    row += '<span id = "lblLevelH' + RoleID + '" style = "color:#ffffff;font-weight: bold" >' + Level_Emp + '</span > '
                    //row += '< img style="height:16px;width15px;float:right"" src = "../img/300px-Flag_of_the_Philippines.svg.png" />'



                    row += '<button type = "button" class="btnNextbox' + RoleID + ' btn btn-link btn-xs" style = "float:right" id="btnNextbox" value="' + RoleID + '"> <i class="fa fa-arrow-circle-right" aria-hidden="true" style="font-size:17px;color:#2f5284"></i></button > '
                    row += '<button type = "button" class="btnEditBox' + RoleID + ' btn btn-link btn-xs" style = "float:right" id="btnEditBox" value="' + RoleID + '"> <i class="fa fa-cog" aria-hidden="true" style="font-size:17px;color:#4e5456"></i></button > </div >'
                    row += '<div class="panel-body" style="' + BodyPanelColor + '"  id="BodyBox' + RoleID + '">'


                    row += '<span id="lblEmpNum' + RoleID + '" style="color:black;font-size:12px">' + EmpNum + '</span></br>'
                    row += '<span id="lblname' + RoleID + '" style="color:black;font-size:12px">' + EmpName + '</span></br>'
                    row += '<span id="lbldept' + RoleID + '" style="color:black;font-size:12px">' + Dept + '</span></br>'

                    row += '<span id="lblActingType' + RoleID + '" style="color:#ea9215;font-size:12px">' + ActingType + '</span></br>'


                    //row += '<span id="lblLevel' + RoleID + '" style="color:black>' + Level_Emp + '</span></br>'
                    row += '</div >'
                    row += '</div>'
                    row += '</div>'

                    if (headCol == "E17") {
                        $("#col1").append(row);

                    } else if (headCol == "E16") {
                        $("#col2").append(row);
                    }
                    else if (headCol == "E15") {
                        $("#col3").append(row);
                    }
                    if (headCol == "M14") {
                        $("#col4").append(row);
                    }
                    if (headCol == "M13-M12") {
                        $("#col5").append(row);
                    }
                    if (headCol == "S11-S9") {
                        $("#col6").append(row);
                    }
                    if (headCol == "G8-G5") {
                        $("#col7").append(row);
                    }
                    if (headCol == "O4") {
                        $("#col8").append(row);
                    }
                    if (headCol == "O3-O2") {
                        $("#col9").append(row);
                    }
                    if (headCol == "D2-D1") {
                        $("#col10").append(row);
                    }


                } else if (Action == 'Update') {

                    $('#headingBox' + RoleID).empty();

                    var row = "";
                    row += '<span id = "lblCol' + RoleID + '" style="display:none">' + Col + '</span >'
                    row += '<span id = "lblRoleID' + RoleID + '" style = "display:none" >' + RoleID + '</span >'
                    row += '<span id = "lblRefRoleID' + RefRoleID + '" style = "display:none" >' + RefRoleID + '</span >'
                    row += '<span id = "lblCheckColumn' + RoleID + '" style = "display:none" >' + headCol + '</span >'
                    if (Path != "") {
                        row += '<img id="PathSpcGroup' + RoleID + '" style="margin-right:3px;height:15px;width15px;"  src="' + Path + '" />'
                    }
                    row += '<span id = "lblLevelH' + RoleID + '" style = "color:#ffffff;font-weight: bold" >' + Level_Emp + '</span >'
                    row += '<button type = "button" class="btnNextbox' + RoleID + ' btn btn-link btn-xs" style = "float:right" id="btnNextbox"  value="' + RoleID + '"> <i class="fa fa-arrow-circle-right" aria-hidden="true" style="font-size:18px;color:#2f5284"></i></button > '
                    row += '<button type = "button" class="btnEditBox' + RoleID + ' btn btn-link btn-xs" style = "float:right" id="btnEditBox" value="' + RoleID + '"> <i class="fa fa-cog" aria-hidden="true" style="font-size:18px;color:#4e5456"></i></button ></div>'

                    //if (Acting == 1) {

                    //      row += '<span id="lblActingType' + RoleID + '" style="color:black;font-size:12px">' + ActingType + '</span></br>'
                    //}

                    $('#headingBox' + RoleID).attr("style", HeadPanelColor);
                    $('#BodyBox' + RoleID).attr("style", BodyPanelColor);
                    $('#headingBox' + RoleID).append(row);
                    //$('#lblLevelH' + RoleID).text(Level_Emp);
                    $('#lbldept' + RoleID).text(Dept);
                    $('#lblLevel' + RoleID).text(Level_Emp);
                    $('#lblEmpNum' + RoleID).text(EmpNum);
                    $('#lblname' + RoleID).text(EmpName);
                    $('#lblRoleID' + RoleID).text(RoleID);

                    //$('#lblCheckColumn' + RoleID).text(headCol);

                    $('#PathSpcGroup' + RoleID).text(Path);

                    if (Acting == 1) {

                        $('#lblActingType' + RoleID).text(ActingType);
                    } else {

                        $('#lblActingType' + RoleID).text("");
                    }


                } else if (Action == 'Delete') {


                    $('.Content' + RoleID).empty();

                    //if ($('#PanalBox' + RoleID + ':visible').length == 0) {

                    //    $('.Content' + RoleID).empty();

                    //} else {


                    //}


                }




            }

            ////////////////////////////////////////////////////////////////////////

            $(document).on('click', '#btnEditBox', function () {

                var RoleID = $(this).val();
                var Col = $('#lblCol' + RoleID).text();
                $('#lblheadCol').text(Col);
                $('#btnDelBox').show();


                $('#btnDelBox').attr('value', RoleID);

                LoadPersonEdit(RoleID);

            });

            function LoadPersonEdit(RoleID) {

                var data = {
                    RoleID: RoleID,
                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadPersonEdit") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowData
                });


                function ShowData(response) {
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {

                            var Acting_Line = val.Acting_Line;
                            var ActingType = val.ActingType_Line;
                            var ActingMain = val.ActingMain_Line;

                            $('#lblRoleID_Modal').text(RoleID);
                            $('#lblName_Newbox').text(val.EmpName_Line);
                            $('#lblLevel_Newbox').text(val.Level_Emp_Real);
                            $('#lblDept_Newbox').text(val.Dept_Real);
                            $('#lblPosition_Newbox').text(val.Position_Real);
                            $('#txtEmp_Newbox').val(val.EmpNum_Line);
                            $('#TB_RemarkNewbox').val(val.Remark_Line);
                            $('#lblRefRoleID_Modal').text(val.RefRoleID_Line);

                            //yam

                            //$('#PanelActingType').show();
                            // $('#PanelActing').show();

                            if (Acting_Line == '1') {

                                $("#CB_Acting").prop('checked', true);

                                //$('#PanelActingType').show();

                            } else {

                                $("#CB_Acting").prop('checked', false);

                                $("#radio_None").prop('checked', false);
                                $("#radio_Fu").prop('checked', false);
                                $("#radio_In").prop('checked', false);
                                $("#radio_Ex").prop('checked', false);
                                 $("#radio_Main").prop('checked', false);
                            }


                            if (ActingMain == '1') {

                                $("#CB_ActingMain").prop('checked', true);
                            } else {
                                $("#CB_ActingMain").prop('checked', false);
                            }




                            if (ActingType == 'None') {

                                $("#radio_None").prop('checked', true);

                            }
                            
                            else if (ActingType == 'Future') {

                                $("#radio_Fu").prop('checked', true);
                            }
                            else if (ActingType == 'New') {

                                $("#radio_In").prop('checked', true);
                            }
                            else if (ActingType == 'Replace') {

                                $("#radio_Ex").prop('checked', true);
                            }

                            else if (ActingType == 'Main') {

                                $("#radio_Main").prop('checked', true);
                            }



                            $("input[name='optradio']:checked").val(val.ActingType_Line);

                            $('#txtDept_PyramidBox').val(val.Dept_Line);
                            $('#txtLevel_Newbox').val(val.Level_Emp_Line);
                            $('#txtPosition_Newbox').val(val.Position_Line);
                            $('#TB_RemarkNewbox').val(val.Remark_Line);

                            $('#lblJobCode').text(val.Position_Code_Line);

                            



                            ///////////////////////////////////DotLine Command///////////////////////////////////////////////////////
                            $('#txtRole_Command').val(val.Role_Command);
                            $('#txtEmpCommand').val(val.EmpNum_Command);
                            $('#lblName_Command').text(val.EmpName_Command);
                            $('#lblPosition_Command').text(val.Position_Command);
                            $('#lblLevel_Command').text(val.Level_Emp_Command);
                            $('#lblDept_Command').text(val.Dept_Command);

                            $('#txtDept_Command').val(val.Dept_Command);
                            $('#txtLevel_Command').val(val.Level_Emp_Command);
                            $('#txtPosition_Command').val(val.Position_Command);
                            $('#TB_Remark_Command').val(val.Remark_Command);
                            $('#txtSpecialGroup_Newbox').val(val.SpecialGroup_Line);
                            $('#lblJobCode_Command').text(val.Position_Code_Command);


                            $('#ModalNewBox').modal('show');

                        });

                    }
                }

            }


            function CheckRefRoleID(RoleID) {  // ดึงคนที่เป็นลูกน้องออกมาโชว์

                var data = {
                    RoleID: RoleID,
                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/CheckRefRoleID") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: SetRefRow
                });


                function SetRefRow(response) {
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {


                            //SetComponent(RoleID);
                            var headCol = val.CheckColumn;
                            SetBox(headCol, val.RoleID, val.RefRoleID, val.EmpNum, val.EmpName, val.Level_Emp, val.Position, val.Dept, val.Acting, val.SpecialGroup, val.RefRoleID, "Insert", val.ActingType, val.Path);

                        });

                    } else {

                        //SetComponent(RoleID);

                    }
                }



            }



            function SetComponent(RoleID) {

                //var CheckCol = $('#lblCol' + RoleID).text();

                var CheckCol = $('#lblCheckColumn' + RoleID).text();

                //alert(CheckCol);

                if (CheckCol == 'E17') {

                    if ($("#col2").text() != "") {

                        $("#col2").empty();
                        $("#col3").empty();
                        $("#col4").empty();
                        $("#col5").empty();
                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddE15').hide();
                        $('#btnAddM14').hide();
                        $('#btnAddM13_M12').hide();
                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();


                        $('#btnAddE16').attr('value', RoleID);
                        $('#btnAddE16').show();
                    } else {

                        $('#btnAddE16').attr('value', RoleID);
                        $('#btnAddE16').show();
                    }



                }
                else if (CheckCol == "E16") {


                    if ($("#col3").text() != "") {

                        $("#col3").empty();
                        $("#col4").empty();
                        $("#col5").empty();
                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddM14').hide();
                        $('#btnAddM13_M12').hide();
                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();


                        $('#btnAddE15').attr('value', RoleID);
                        $('#btnAddE15').show();

                    } else {

                        $('#btnAddE15').attr('value', RoleID);
                        $('#btnAddE15').show();
                    }

                }
                else if (CheckCol == "E15") {


                    if ($("#col4").text() != "") {

                        $("#col4").empty();
                        $("#col5").empty();
                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddM13_M12').hide();
                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();



                        $('#btnAddM14').attr('value', RoleID);
                        $('#btnAddM14').show();

                    } else {

                        $('#btnAddM14').attr('value', RoleID);
                        $('#btnAddM14').show();
                    }


                }
                else if (CheckCol == "M14") {

                    if ($("#col5").text() != "") {

                        $("#col5").empty();
                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();


                        $('#btnAddM13_M12').attr('value', RoleID);
                        $('#btnAddM13_M12').show();

                    } else {

                        $('#btnAddM13_M12').attr('value', RoleID);
                        $('#btnAddM13_M12').show();
                    }

                }
                else if (CheckCol == "M13-M12") {

                    if ($("#col6").text() != "") {

                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();


                        $('#btnAddS11_S9').attr('value', RoleID);
                        $('#btnAddS11_S9').show();

                    } else {



                        $('#btnAddS11_S9').attr('value', RoleID);
                        $('#btnAddS11_S9').show();
                    }




                }
                else if (CheckCol == "S11-S9") {


                    if ($("#col7").text() != "") {

                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();


                        $('#btnAddG8_G5').attr('value', RoleID);
                        $('#btnAddG8_G5').show();

                    } else {
                        $('#btnAddG8_G5').attr('value', RoleID);
                        $('#btnAddG8_G5').show();
                    }

                }
                else if (CheckCol == "G8-G5") {


                    if ($("#col8").text() != "") {

                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddD2_D1').hide();

                        $('#btnAddO4').attr('value', RoleID);
                        $('#btnAddO4').show();

                    } else {
                        $('#btnAddO4').attr('value', RoleID);
                        $('#btnAddO4').show();
                    }

                }

                else if (CheckCol == "O4") {


                    if ($("#col9").text() != "") {

                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddO3').attr('value', RoleID);
                        $('#btnAddO3').show();

                    } else {

                        $('#btnAddO3').attr('value', RoleID);
                        $('#btnAddO3').show();
                    }
                }


                else if (CheckCol == "O3-O2") {


                    if ($("#col10").text() != "") {

                        $("#col10").empty();


                        $('#btnAddD2_D1').attr('value', RoleID);
                        $('#btnAddD2_D1').show();

                    } else {

                        $('#btnAddD2_D1').attr('value', RoleID);
                        $('#btnAddD2_D1').show();
                    }

                    //var tbody = $("#col9").text();
                    //alert(tbody);
                }

            }


            //////////////////////////////////////

            function SetComponent_Del(RoleID) {

                //var CheckCol = $('#lblCol' + RoleID).text();

                var CheckCol = $('#lblCheckColumn' + RoleID).text();

                //alert(CheckCol);

                if (CheckCol == 'E17') {

                    if ($("#col2").text() != "") {

                        $("#col2").empty();
                        $("#col3").empty();
                        $("#col4").empty();
                        $("#col5").empty();
                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();


                        $('#btnAddE16').hide();
                        $('#btnAddE15').hide();
                        $('#btnAddM14').hide();
                        $('#btnAddM13_M12').hide();
                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();


                    }


                    if ($("#col1").text() == "") {

                        $('#btnAddE16').hide();
                    }



                }
                else if (CheckCol == "E16") {


                    if ($("#col3").text() != "") {

                        $("#col3").empty();
                        $("#col4").empty();
                        $("#col5").empty();
                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();


                        $('#btnAddE15').hide();
                        $('#btnAddM14').hide();
                        $('#btnAddM13_M12').hide();
                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();

                    }


                    if ($("#col2").text() == "") {

                        $('#btnAddE15').hide();
                    }

                }
                else if (CheckCol == "E15") {


                    if ($("#col4").text() != "") {

                        $("#col4").empty();
                        $("#col5").empty();
                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();


                        $('#btnAddM14').hide();
                        $('#btnAddM13_M12').hide();
                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();


                    }


                    if ($("#col3").text() == "") {

                        $('#btnAddM14').hide();
                    }


                }
                else if (CheckCol == "M14") {

                    if ($("#col5").text() != "") {

                        $("#col5").empty();
                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddM13_M12').hide();
                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();





                    }

                    if ($("#col4").text() == "") {

                        $('#btnAddM13_M12').hide();
                    }

                }
                else if (CheckCol == "M13-M12") {

                    if ($("#col6").text() != "") {



                        $("#col6").empty();
                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();


                        $('#btnAddS11_S9').hide();
                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();





                    }


                    if ($("#col5").text() == "") {

                        $('#btnAddS11_S9').hide();
                    }




                }
                else if (CheckCol == "S11-S9") {


                    if ($("#col7").text() != "") {


                        $("#col7").empty();
                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();



                        $('#btnAddG8_G5').hide();
                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();





                    }


                    if ($("#col6").text() == "") {

                        $('#btnAddG8_G5').hide();
                    }




                }
                else if (CheckCol == "G8-G5") {


                    if ($("#col8").text() != "") {


                        $("#col8").empty();
                        $("#col9").empty();
                        $("#col10").empty();




                        $('#btnAddO4').hide();
                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();



                    }

                    if ($("#col7").text() == "") {

                        $('#btnAddO4').hide();
                    }

                }

                else if (CheckCol == "O4") {


                    if ($("#col9").text() != "") {


                        $("#col9").empty();
                        $("#col10").empty();

                        $('#btnAddO3').hide();
                        $('#btnAddD2_D1').hide();

                    }

                    if ($("#col8").text() == "") {

                        $('#btnAddO3').hide();
                    }
                }


                else if (CheckCol == "O3-O2") {


                    if ($("#col10").text() != "") {


                        $("#col10").empty();

                        $('#btnAddD2_D1').hide();

                    }


                    if ($("#col9").text() == "") {

                        $('#btnAddD2_D1').hide();
                    }

                    //var tbody = $("#col9").text();
                    //alert(tbody);
                }

            }


            ///////////////////////////////////////////////////////////////////////////////////////

            //function check(RoleID) {

            //   $('#lblRefRoleID' + RoleID).text() + "," + $('#lblRefRoleID_Modal').text();
            //    alert(check)
            //}

            function SetHighLightBox(RoleID) {

                //$('.Box').removeAttr("style")
                //$('.Box').attr("style","width:145px;")

                //CheckShow = RoleID

                var CheckShow = $('#lblCheckColumn' + RoleID).text();


                if (CheckShow == 'E17') {
                    //alert(CheckShow);


                    $("#col1").find('.Box').removeAttr("style");
                    $("#col1").find('.Box').attr("style", "width:150px;")

                    //$("#col1").find('.panel-body').attr("style", "height:134px")


                }
                else if (CheckShow == 'E16') {
                    //alert(CheckShow);

                    $("#col2").find('.Box').removeAttr("style");
                    $("#col2").find('.Box').attr("style", "width:150px;")

                    //$("#col2").find('.panel-body').attr("style", "height:134px")
                }
                else if (CheckShow == 'E15') {
                    //alert(CheckShow);

                    $("#col3").find('.Box').removeAttr("style");
                    $("#col3").find('.Box').attr("style", "width:150px;")

                    //$("#col3").find('.panel-body').attr("style", "height:134px")
                }
                else if (CheckShow == 'M14') {
                    //alert(CheckShow);

                    $("#col4").find('.Box').removeAttr("style");
                    $("#col4").find('.Box').attr("style", "width:150px;")

                    //$("#col4").find('.panel-body').attr("style", "height:134px")
                }
                else if (CheckShow == 'M13-M12') {
                    //alert(CheckShow);

                    $("#col5").find('.Box').removeAttr("style");
                    $("#col5").find('.Box').attr("style", "width:150px;")

                    //$("#col5").find('.panel-body').attr("style", "height:134px")
                }
                else if (CheckShow == 'S11-S9') {
                    //alert(CheckShow);

                    $("#col6").find('.Box').removeAttr("style");
                    $("#col6").find('.Box').attr("style", "width:150px;")

                    //$("#col6").find('.panel-body').attr("style", "height:134px")
                }
                else if (CheckShow == 'G8-G5') {
                    //alert(CheckShow);

                    $("#col7").find('.Box').removeAttr("style");
                    $("#col7").find('.Box').attr("style", "width:150px;")

                    //$("#col7").find('.panel-body').attr("style", "height:134px")
                }
                else if (CheckShow == 'O4') {
                    //alert(CheckShow);

                    $("#col8").find('.Box').removeAttr("style");
                    $("#col8").find('.Box').attr("style", "width:150px;")
                    //$("#col8").find('.panel-body').attr("style", "height:134px")
                }
                else if (CheckShow == 'O3-O2') {
                    //alert(CheckShow);

                    $("#col9").find('.Box').removeAttr("style");
                    $("#col9").find('.Box').attr("style", "width:150px;")

                    //$("#col9").find('.panel-body').attr("style", "height:134px")
                }
                else if (CheckShow == 'D2-D1') {
                    //alert(CheckShow);

                    $("#col10").find('.Box').removeAttr("style");
                    $("#col10").find('.Box').attr("style", "width:150px;")

                    //$("#col10").find('.panel-body').attr("style", "height:134px")
                }



                var PanelColor = "";

                PanelColor += "border: 5px solid #29a329; border-radius: 0.5rem;width:150px;";
                //HeadPanelColor += "box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.1);width:145px;";
                PanelColor += "box-shadow: 0 0 4px hsla(100,50%,50%,1);width:150px;"

                //HeadPanelColor += "box-shadow: inset 1px 1px 150px #000;";

                //HeadPanelColor += "box-shadow: inset 0 0 0 10px #10b7ec, inset 0 0 0 14px #fff;"

                $('#PanalBox' + RoleID).attr("style", PanelColor);



            }


            $(document).on('click', '#btnNextbox', function () {

                var RoleID = $(this).val();



                SetComponent(RoleID);

                SetHighLightBox(RoleID);

                CheckRefRoleID(RoleID);


            });
            ///////////////////////////////////////////////////////////////////////////

            $(document).on('click', '#btnAddE17', function () {

                var company = $('#lblCompany').text();

                $('#lblRoleID_Modal').text("");

                if (company == '') {

                    $.alert({
                        title: 'Alert!',
                        content: "Please Select Pyramid ID !!!",
                        type: 'red',
                    });

                } else {

                    $('#lblRefRoleID_Modal').text("0")
                    $('#ModalNewBox').modal('show');
                    $('#lblheadCol').text("E17")
                    clearNewBox();
                }


            });

            $(document).on('click', '#btnAddE16', function () {

                var RefRowID = $(this).val();

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("E16");
                $('#lblRefRoleID_Modal').text(RefRowID);
                //yam

                clearNewBox();

            });

            $(document).on('click', '#btnAddE15', function () {

                var RefRowID = $(this).val();
                $('#lblRefRoleID_Modal').text(RefRowID);

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("E15");
                clearNewBox();

            });

            $(document).on('click', '#btnAddM14', function () {
                var RefRowID = $(this).val();
                $('#lblRefRoleID_Modal').text(RefRowID);

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("M14");
                clearNewBox();

            });

            $(document).on('click', '#btnAddM13_M12', function () {
                var RefRowID = $(this).val();
                $('#lblRefRoleID_Modal').text(RefRowID);

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("M13-M12");
                clearNewBox();

            });
            $(document).on('click', '#btnAddS11_S9', function () {
                var RefRowID = $(this).val();
                $('#lblRefRoleID_Modal').text(RefRowID);

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("S11-S9");
                clearNewBox();

            });

            $(document).on('click', '#btnAddG8_G5', function () {
                var RefRowID = $(this).val();
                $('#lblRefRoleID_Modal').text(RefRowID);

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("G8-G5");
                clearNewBox();
            });

            $(document).on('click', '#btnAddO4', function () {
                var RefRowID = $(this).val();
                $('#lblRefRoleID_Modal').text(RefRowID);

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("O4");
                clearNewBox();

            });

            $(document).on('click', '#btnAddO3', function () {
                var RefRowID = $(this).val();
                $('#lblRefRoleID_Modal').text(RefRowID);

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("O3-O2");
                clearNewBox();

            });

            $(document).on('click', '#btnAddD2_D1', function () {
                var RefRowID = $(this).val();
                $('#lblRefRoleID_Modal').text(RefRowID);

                $('#lblRoleID_Modal').text("");
                $('#ModalNewBox').modal('show');
                $('#lblheadCol').text("D2-D1");
                clearNewBox();

            });


            function clearNewBox() {

                $('#lblName_Newbox').text("");
                $('#lblLevel_Newbox').text("");
                $('#lblDept_Newbox').text("");
                $('#lblPosition_Newbox').text("");
                $('#txtEmp_Newbox').val("")
                $("#CB_Acting").prop('checked', false);
                $("#CB_ActingMain").prop('checked', false);
                $(".radio_typePyramid").prop('checked', false);
                $('#TB_RemarkNewbox').val("")

                $('#txtDept_PyramidBox').val("");
                $('#txtLevel_Newbox').val("");
                $('#txtPosition_Newbox').val("");
                $('#TB_RemarkNewbox').val("");

                $('#txtRole_Command').val("");
                $('#txtEmpCommand').val("");
                $('#lblName_Command').text("");
                $('#lblPosition_Command').text("");
                $('#lblLevel_Command').text("");
                $('#lblDept_Command').text("");

                $('#txtDept_Command').val("");
                $('#txtLevel_Command').val("");
                $('#txtPosition_Command').val("");
                $('#TB_Remark_Command').val("");

                $('#lblJobCode_Command').text("");
                $('#lblJobCode').text("");
               
            }



            $("#btnDept_N").on('click', function () {

                if ($('#txtGroup_N').val() == "") {

                    $.alert({
                        title: 'Alert!',
                        content: "Please insert Group !! ",
                        type: 'red',
                    });

                } else {

                    $('#ModalSearchDept_N').modal('show');
                    browseDept();
                }

            });

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

            $("#btnDept_E").on('click', function () {

                if ($('#txtGroup_E').val() == "") {

                    $.alert({
                        title: 'Alert!',
                        content: "Please insert Group !! ",
                        type: 'red',
                    });

                } else {

                    $('#ModalSearchDept_E').modal('show');
                    browseDept_E();
                }
            });

            $("#btnDept_Command").on('click', function () {
                browseDept_Command();
            });



            $("#btnSaveHead").on('click', function () {



                var txtRevision_N = $('#txtRevision_N').val();
                var txtGroup_N = $('#txtGroup_N').val();
                var txtDept_N = $('#txtDept_N').val();
                var txtEffectDate_N = $('#txtEffectDate_N').val();

                var msg = '';

                if (txtGroup_N == '') {

                    msg += "Group, ";
                }


                if (txtDept_N == '') {

                    msg += "Department, ";
                }

                //if (txtRevision_N == '') {

                //    msg += "Revision, ";
                //}


                if (txtEffectDate_N == '') {

                    msg += "EffectDate, ";
                }

                if (msg != '') {
                    $.alert({
                        title: 'Alert!',
                        content: "Please insert !! " + msg,
                        type: 'red',
                    });

                }
                else {

                    clearPyramidLine();
                    clearCountUser();
                    HideButtonAddCol();

                    $('#ModalNewHead').modal('hide');

                    insertHeadder();

                }

            });


            function insertHeadder() {

                var Revision_N = $('#txtRevision_N').val();
                var Group_N = $('#lblGroup_N').text();
                var Dept_N = $('#lblDept_N').text();
                var EffectDate_N = $('#txtEffectDate_N').val();
                var company = $('#SelectCompany_N option:selected').val();
                var Status = $('#SelectStatus_N option:selected').val();

                var data = {

                    PyramidID: '',
                    Company: company,
                    GroupPyramid: Group_N,
                    Dept: Dept_N,
                    Revision: Revision_N,
                    EffectDate: EffectDate_N,
                    Action: 'Insert',
                    Createby: Username,
                    Status: Status
                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/InsertPyramidHerder") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowHeader
                });

                function ShowHeader(response) {
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {


                            $('#lblCompany').text(val.Comp_Name);
                            $('#lblGroup').text(val.GroupName);
                            $('#lblDept').text(val.DeptName);
                            $('#lblRevision').text(val.Revision);
                            $('#lblEffectDate').text(val.EffectDate);
                            $('#lblPyramidID').text(val.PyramidID);


                            $('#lblCompanyCode').text(val.Company);
                            $('#lblDeptID').text(val.Dept);
                            $('#lblGroupID').text(val.GroupPyramid);
                            $('#lblStatus').text(val.Status);


                            var MsgReturn = val.msg

                            $.alert({

                                title: 'Alert',
                                content: MsgReturn,
                                type: 'green'

                            })

                        });

                        //ClearNewHeader();
                        //LoadHeader();
                    }
                }
            }



            function ClearNewHeader() {

                $("#SelectCompany_N").val("CPK");
                $('#txtRevision_N').val("");
                $('#txtGroup_N').val("");
                $('#txtDept_N').val("");
                $('#txtEffectDate_N').val("");
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////
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


                ////$('#SelectStatus_S').text("-- All --");

            }

            ///////////////////////////////////////////EditHead/////////////////////////////////////////////////////////

            $("#btnSaveHead_E").on('click', function () {


                var txtRevision_E = $('#txtRevision_E').val();
                var txtGroup_E = $('#txtGroup_E').val();
                var txtDept_E = $('#txtDept_E').val();
                var txtEffectDate_E = $('#txtEffectDate_E').val();

                var msg = '';

                if (txtGroup_E == '') {

                    msg += "Group, ";
                }


                if (txtDept_E == '') {

                    msg += "Department, ";
                }

                if (txtRevision_E == '') {

                    msg += "Revision, ";
                }


                if (txtEffectDate_E == '') {

                    msg += "EffectDate, ";
                }

                if (msg != '') {
                    $.alert({
                        title: 'Alert!',
                        content: "Please insert !! " + msg,
                        type: 'red',
                    });

                }
                else {

                    $('#ModalEditHead').modal('hide');

                    EditHeadder();

                }

            });




            function EditHeadder() {

                var Revision_E = $('#txtRevision_E').val();
                var Group_E = $('#lblGroup_E').text();
                var Dept_E = $('#lblDept_E').text();
                var EffectDate_E = $('#txtEffectDate_E').val();
                var company = $('#SelectCompany_E option:selected').val();
                var PyramidID = $('#lblPyramidID').text();
                var Status = $('#SelectStatus_E option:selected').val();

                var data = {
                    PyramidID: PyramidID,
                    Company: company,
                    GroupPyramid: Group_E,
                    Dept: Dept_E,
                    Revision: Revision_E,
                    EffectDate: EffectDate_E,
                    Action: 'Update',
                    Createby: Username,
                    Status: Status
                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/InsertPyramidHerder") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowEditHeader
                });

                function ShowEditHeader(response) {
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {

                            $('#lblCompany').text(val.Comp_Name);
                            $('#lblGroup').text(val.GroupName);
                            $('#lblDept').text(val.DeptName);
                            $('#lblRevision').text(val.Revision);
                            $('#lblEffectDate').text(val.EffectDate);
                            $('#lblPyramidID').text(val.PyramidID);
                            $('#lblCompanyCode').text(val.Company);
                            $('#lblDeptID').text(val.Dept);
                            $('#lblGroupID').text(val.GroupPyramid);

                            $('#lblStatus').text(val.Status);

                            //visible_ButtonEditHeader();
                            var MsgReturn = val.msg

                            $.alert({

                                title: 'Alert',
                                content: MsgReturn,
                                type: 'green'

                            })

                        });

                        //ClearNewHeader();
                        //LoadHeader();
                    }
                }
            }


           

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


                    ShowPyramidLine();
                    LoadCountPerson();
                    visible_ButtonEditHeader();

                    //visible_ButtonEditHeader();

                });


            });


            /////////////////////////////////////////////////////////////////////////////////
            function ShowPyramidLine() {

                var data = {
                    PyramidID: $('#lblPyramidID').text()

                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/ShowPyramidLine") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowData
                });


                function ShowData(response) {
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {

                            clearPyramidLine();


                            var RoleID = val.RoleID_Line;
                            var RefRoleID = val.RefRoleID_Line;
                            var Role = val.Role_Line;
                            var EmpNum = val.EmpNum_Line;
                            var EmpName = val.EmpName_Line;
                            var Dept = val.Dept_Line;
                            var Level_Emp = val.Level_Emp_Line;
                            var Position = val.Position_Line;
                            var Acting = val.Acting_Line;
                            var ActingMain = val.ActingMain;
                            var ActingType = val.ActingType_Line;
                            var SpecialGroup = val.SpecialGroup_Line;
                            var Remark = val.Remark_Line;
                            var CreateBy = val.CreateBy_Line;
                            var CreateDate = val.CreateDate_Line;
                            var Pyramid_ID = val.Pyramid_ID_Line;
                            var headCol = val.CheckColumn_Line;
                            var Path = val.PicName

                            SetBox(headCol, RoleID, RefRoleID, EmpNum, EmpName, Level_Emp, Position, Dept, Acting, SpecialGroup, RefRoleID, 'Insert', ActingType, Path,ActingMain);


                        });

                    } else {

                        clearPyramidLine();
                        clearCountUser();


                    }




                }







            }


            //////////////////////////////////////////////////////////////////
            $("#btnPosition_Command").on('click', function () {


                var Level = $('#txtLevel_Command').val();

                if (Level != "") {

                    $('#ModalSearchPosition_Command').modal('show')
                    browsePosition_Command();

                } else {

                    $.alert({

                        title: 'Alert',
                        content: 'Please insert Level !!!',
                        type: 'red'

                    });
                }


            });

            ///////////////////////////////////////////////////////////////////////////

            $("#btnPosition_PyramidBox").on('click', function () {


                var Level = $('#txtLevel_Newbox').val();

                if (Level != "") {

                    $('#ModalSearchPosition').modal('show')
                    browsePosition();

                } else {

                    $.alert({

                        title: 'Alert',
                        content: 'Please insert Level !!!',
                        type: 'red'

                    });
                }



            });

            function browsePosition_Command() {

                var data = {
                    Site_ref: "ERP_PK",
                    Dept: $('#lblDeptID').text(),
                    Level: $('#txtLevel_Command').val()
                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadPosition") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchPosition,
                });

                function ModalSearchPosition(response) {
                    $("#Position_insertRowText_Command").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {
                            var Uf_Jobtitle = val[0];
                            var Code = val[1];

                            fragment += '<tr>';
                            fragment += '<td class="Code" style="display:none"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + Code + '</a></td>';
                            fragment += '<td class="Uf_Jobtitle"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Uf_Jobtitle + '</a></td>';
                            fragment += '</tr>';
                            number = number + 1;
                        });
                    } else {
                        fragment = '<tr>';
                        fragment += '<td> Not Data </td>';
                        fragment += '</tr>';
                    }
                    $("#Position_insertRowText_Command").append(fragment);
                }

                $('#Position_insertRowText_Command').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Uf_Jobtitle = $('#Position_insertRowText_Command tr:eq(' + numindex + ') .Uf_Jobtitle a').html();
                    var Code = $('#Position_insertRowText_Command tr:eq(' + numindex + ') .Code a').html();

                    $('#lblJobCode_Command').text(Code);
                    $('#txtPosition_Command').val(Uf_Jobtitle);
                    $('#ModalSearchPosition_Command').modal('hide');

                });

                $("#txtsearchPosition_Command").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Position_insertRowText_Command tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });
            }



            function browsePosition() {

                var data = {
                    Site_ref: "ERP_PK",
                    Dept: $('#lblDeptID').text(),
                    Level: $('#txtLevel_Newbox').val()
                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadPosition") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchPosition,
                });

                function ModalSearchPosition(response) {
                    $("#Position_insertRowText").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {
                            var Uf_Jobtitle = val[0];
                            var JobCode = val[1];
                            

                            fragment += '<tr>';
                            fragment += '<td class="Code" style="display:none"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + JobCode + '</a></td>';
                            fragment += '<td class="Uf_Jobtitle"><a class="clickSearch" href="javascript:void(0)" data-dismiss="modal"  data-indexrows=' + number + '>' + Uf_Jobtitle + '</a></td>';
                            fragment += '</tr>';
                            number = number + 1;
                        });
                    } else {
                        fragment = '<tr>';
                        fragment += '<td> Not Data </td>';
                        fragment += '</tr>';
                    }
                    $("#Position_insertRowText").append(fragment);
                }

                $('#Position_insertRowText').on('click', '.clickSearch', function () {
                    var numindex = ($(this).data("indexrows"));
                    var Uf_Jobtitle = $('#Position_insertRowText tr:eq(' + numindex + ') .Uf_Jobtitle a').html();
                    var Code = $('#Position_insertRowText tr:eq(' + numindex + ') .Code a').html();


                    $('#lblJobCode').text(Code);
                    
                    $('#txtPosition_Newbox').val(Uf_Jobtitle);
                    $('#ModalSearchPosition').modal('hide');

                });

                $("#txtsearchPosition").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Position_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });
            }


            /////////////////////////////////////////////////////////////////////////////////////////
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

            ////////////////////////////////////////////////////////////////////////////////////////

            $("#btnGroup_N").on('click', function () {


                browseGroup_N();

            });


            function browseGroup_N() {



                var Comp_Code = $('#SelectCompany_N option:selected').val();

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

                    $('#lblGroup_N').text(Code);
                    $('#txtGroup_N').val(ReplaceName);



                });

                $("#txtsearchGroup").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Group_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });

            }

            //////////////////////////////////////////////////////////////////////////////////////
            $("#btnGroup_E").on('click', function () {


                browseGroup_E();

            });


            function browseGroup_E() {



                var Comp_Code = $('#SelectCompany_E option:selected').val();

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


                    $('#lblGroup_E').text(Code);
                    $('#txtGroup_E').val(ReplaceName);



                });

                $("#txtsearchGroup").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#Group_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });

            }
            /////////////////////////////////////////////////////////////////////////////////////
            $("#btnClear_S").on('click', function () {
                ClearSearchHeader();
            });


            $(document).on('change', '#CB_Acting', function () {

                if (this.checked) {

                    //$('#PanelActingType').show();
                }
                else {
                    //$('#PanelActingType').hide();
                    //$(".radio_typePyramid").prop('checked', false);
                }


            });

            function browseSpcGroup_Command() {

                var data = { Search: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadSpcGroup") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchSpcGroup,
                });

                function ModalSearchSpcGroup(response) {
                    $("#SpcGroup_Command_insertRowText").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {
                            var Code = val.Code;
                            var Path = val.Path;

                            fragment += '<tr>';
                            fragment += '<td class="Code"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + Code + '</a></td>';
                            fragment += '<td class="Name"><img style="width:50px ;height:30px; " src="' + Path + '" /></td>';
                            fragment += '</tr>';
                            number = number + 1;
                        });
                    } else {
                        fragment = '<tr>';
                        fragment += '<td> Not Data </td>';
                        fragment += '<td> Not Data </td>';
                        fragment += '</tr>';
                    }
                    $("#SpcGroup_Command_insertRowText").append(fragment);
                }

                $('#SpcGroup_Command_insertRowText').on('click', '.clickSearch', function () {

                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#SpcGroup_Command_insertRowText tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#SpcGroup_Command_insertRowText tr:eq(' + numindex + ') .Name a').html()


                    $('#txtSpecialGroup_Command').val(Code);

                });

                $("#txtsearchSpcGroup_Commmand").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#SpcGroup_Command_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });
            }




            function browseSpcGroup() {

                var data = { Search: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadSpcGroup") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ModalSearchSpcGroup,
                });

                function ModalSearchSpcGroup(response) {
                    $("#SpcGroup_insertRowText").empty();
                    var number = 0;
                    var fragment = '';
                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {
                            var Code = val.Code;
                            var Path = val.Path;

                            fragment += '<tr>';
                            fragment += '<td class="Code"><a class="clickSearch"  href="javascript:void(0)" data-dismiss="modal" data-indexrows=' + number + '>' + Code + '</a></td>';
                            fragment += '<td class="Name"><img style="width:50px ;height:30px; " src="' + Path + '" /></td>';
                            fragment += '</tr>';
                            number = number + 1;
                        });
                    } else {
                        fragment = '<tr>';
                        fragment += '<td> Not Data </td>';
                        fragment += '<td> Not Data </td>';
                        fragment += '</tr>';
                    }
                    $("#SpcGroup_insertRowText").append(fragment);
                }

                $('#SpcGroup_insertRowText').on('click', '.clickSearch', function () {

                    var numindex = ($(this).data("indexrows"));
                    var Code = $('#SpcGroup_insertRowText tr:eq(' + numindex + ') .Code a').html(),
                        Name = $('#SpcGroup_insertRowText tr:eq(' + numindex + ') .Name a').html()


                    $('#txtSpecialGroup_Newbox').val(Code);

                });

                $("#txtsearchSpcGroup").on("keyup", function () {
                    var value = $(this).val().toLowerCase();
                    $("#SpcGroup_insertRowText tr").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                    });
                });
            }



            ////////////////////////////////////////////////////////////////////////////////////
            $("#btnSpecialGroup_PyramidBox").on('click', function () {
                browseSpcGroup();
            });


            $("#btnSpecialGroup_Command").on('click', function () {
                browseSpcGroup_Command();
            });


            //$("#test").on('click', function () {
            //    $("#col3").show();
            //            $("#col4").show();
            //            $("#col5").show();
            //            $("#col6").show();
            //            $("#col7").show();
            //            $("#col8").show();
            //            $("#col9").show();
            //});

            $("#btnDelBox").on('click', function () {
                var RoleID = $(this).val();

                $.confirm({
                    title: 'Confirm!',
                    content: 'Are you sure you want to delete this box',
                    buttons: {
                        confirm: function () {

                            SaveBox("Delete", RoleID)
                            SetComponent_Del(RoleID);

                            $('#ModalNewBox').modal('hide');
                        },
                        cancel: function () {

                        },

                    }
                });

            });
            ///////////////////////////////////////////////////////////////////////

            function LoadCountPerson() {

                var data = { PyramidID: $('#lblPyramidID').text() };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/LoadCountPerson") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowLoadCountPerson,
                });

                function ShowLoadCountPerson(response) {


                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {

                            $('#lblUserNormal').text(val.CountNormal);
                            $('#lblUserActing').text(val.CountActing);
                            $('#lblUserSub').text(val.CountSub);
                            $('#lblUserSkip').text(val.CountSkip);
                            $('#lblUserNew').text(val.CountNew);
                            $('#lblUserReplace').text(val.CountReplace);

                        });
                    } else {

                    }

                }

            }



            function clearPyramidLine() {

                $("#col1").empty();
                $("#col2").empty();
                $("#col3").empty();
                $("#col4").empty();
                $("#col5").empty();
                $("#col6").empty();
                $("#col7").empty();
                $("#col8").empty();
                $("#col9").empty();
                $("#col10").empty();

            }

            function clearCountUser() {

                $('#lblUserNormal').text("");
                $('#lblUserActing').text("");
                $('#lblUserSub').text("");
                $('#lblUserSkip').text("");

            }


            function HideButtonAddCol() {


                $('#btnAddE16').hide();
                $('#btnAddE15').hide();
                $('#btnAddM14').hide();
                $('#btnAddM13_M12').hide();
                $('#btnAddS11_S9').hide();
                $('#btnAddG8_G5').hide();
                $('#btnAddO4').hide();
                $('#btnAddO3').hide();
                $('#btnAddD2_D1').hide();

            }


            function DisplayActing(EmpNum) {

                if (EmpNum == '0' || EmpNum == '1' || EmpNum == '2' || EmpNum == 'S0001') {
                    $('#PanelActing').hide();
                    $('#PanelActingType').hide();
                } else {
                    $('#PanelActing').show();
                    $('#PanelActingType').show();

                }


            }


            function Clone() {

                var data = {
                    PyramidID: $('#lblPyramidID').text(),
                    CompanyCode: $('#lblCompanyCode').text(),
                    Dept: $('#lblDeptID').text(),
                    CreateBy: Username
                };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MaintainPyramid.aspx/ClonePyramid") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowLoadCountPerson,
                });

                function ShowLoadCountPerson(response) {

                    if (response.d.length > 0) {
                        $.each(response.d, function (index, val) {

                            $('#lblCompany').text(val.Comp_Name);
                            $('#lblGroup').text(val.GroupName);
                            $('#lblDept').text(val.DeptName);
                            $('#lblRevision').text(val.Revision);
                            $('#lblEffectDate').text(val.EffectDate);
                            $('#lblPyramidID').text(val.PyramidID);


                            $('#lblCompanyCode').text(val.Company);
                            $('#lblDeptID').text(val.Dept);
                            $('#lblGroupID').text(val.GroupPyramid);
                            $('#lblStatus').text(val.Status);


                            var MsgReturn = val.msg

                            $.alert({

                                title: 'Alert',
                                content: MsgReturn,
                                type: 'green'

                            })

                        });
                    } else {

                    }

                }
            }



            $("#btnClone").on('click', function () {

                $.confirm({
                    title: 'Confirm!',
                    content: 'Are you sure you want to Clone this Pyramid',
                    buttons: {
                        confirm: function () {

                            Clone();
                            ShowPyramidLine();
                            LoadCountPerson();

                        },
                        cancel: function () {

                        },

                    }
                });


            });



       




        }); //close Doc

        $(document).on('click', '.browse', function () {
            var file = $(this).parent().parent().parent().find('.file');
            file.trigger('click');

            //var output = file.substr(0, file.lastIndexOf('.')) || file;
            //$('#TB_FileName').val(output);
        });
        $(document).on('change', '.file', function () {
            $(this).parent().find('.form-control').val($(this).val().replace(/C:\\fakepath\\/i, ''));
        });

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

    </script>

    <style>
        .file {
            visibility: hidden;
            position: absolute;
        }

        .gradient_line {
            /*margin: 0 0 50px 0;*/
            display: block;
            border: none;
            height: 1px;
            background: #CBCBCB;
            /*background: linear-gradient(to right, white, #0071B9, #26ABFF, #0071B9, white);*/
            /*width: 300px;*/
        }

        .container {
            width: 97%
        }
        /*.panel-body {
background:#FFCCFF;}*/

        /*.panel-heading.active {
  background-color: #ffd051;
}*/

        .gradient_line {
            display: block;
            border: none;
            height: 1px;
            background: #CBCBCB;
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

        .google-visualization-orgchart-node {
            text-align: center;
            vertical-align: middle;
            font-family: arial,helvetica;
            cursor: default;
            border: 2px solid #b5d9ea;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -webkit-box-shadow: rgba(0, 0, 0, 0.5) 3px 3px 3px;
            -moz-box-shadow: rgba(0, 0, 0, 0.5) 3px 3px 3px;
            background-color: #db0a0a;
            background: -webkit-gradient(linear, left top, left bottom, from(#db0a0a), to(#db0a0a));
        }
       



    </style>
</asp:Content>
