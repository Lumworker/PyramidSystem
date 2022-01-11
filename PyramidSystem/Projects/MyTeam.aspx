<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMyteam.Master" AutoEventWireup="true" CodeBehind="MyTeam.aspx.cs" Inherits="PyramidSystem.Projects.MyTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <script src="http://portalapp01/PyramidSystem/js/latest/orgchart.js"></script>
    <style>
        .Acting rect {
            stroke: #eea236;
            fill: #eea236;
            /*width:270px;*/
            /*height:180px;*/
            /*height: 155px;*/
        }

        .Active rect {
            stroke: #36add1;
            fill: #36add1;
            /*width:266px;*/
            /*height: 155px;*/
        }

        .Subcon rect {
            stroke: #dd5695;
            fill: #dd5695;
            /*width:290px; 
           height:180px;*/
            /*height: 155px;*/
        }

        .New rect {
            stroke: #eea236;
            fill: #eea236;
            /*width:290px; 
           height:180px;*/
            /*height: 155px;*/
        }

        .Replace rect {
            stroke: #eea236;
            fill: #eea236;
            /*width:290px; 
           height:180px;*/
            /*height: 155px;*/
        }

        .Skip rect {
            stroke: #a3a3a3;
            fill: #a3a3a3;
            /*width:290px; 
           height:180px;*/
            /*height: 155px;*/
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

         .field_0 a:visited, .field_0 a {
            fill: #ffffff;
        }

            .field_0 a:hover {
                fill: black !important;
            }

    </style>

    <br>
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-12 col-sm-12">
                <h4>Organization Chart (MyTeam) <i class="fa fa-sitemap" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;<span style="font-size:14px;font-weight:bold;color:#0099bf" id="lblName"></span></h4>
            </div>
            <div class="col-md-7 col-sm-12">

                <%-- <div style="background-color: #dd5695; height: 25px; width: 25px; float: right; margin-top: 18px"></div>
                <h5 style="margin-top: 20px; float: right">&nbsp;&nbsp;&nbsp;Subcontractor&nbsp;&nbsp;</h5>

                <div style="background-color: #eea236; height: 25px; width: 25px; float: right; margin-top: 18px"></div>
                &nbsp;&nbsp;<h5 style="margin-top: 20px; float: right">&nbsp;&nbsp;&nbsp;Acting&nbsp;&nbsp;</h5>

                <div style="background-color: #36add1; height: 25px; width: 25px; float: right; margin-top: 18px"></div>
                <h5 style="margin-top: 20px; float: right">Active&nbsp;&nbsp;</h5>--%>
            </div>
        </div>
    </div>
    <br>

    <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblEmpNum" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblCostCenter" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblLevel" runat="server" Text="Label"></asp:Label>

    <div id="exTab2" class="container">
        <ul class="nav nav-tabs" id="tabOrg">
        </ul>
        <div class="tab-content" id="tabBody" style="height: 700px">
        </div>
    </div>


    <script type="text/javascript">
        $(document).ready(function () {


            var EmpNum = $("#MainContent_lblEmpNum").html();
            var CostCenter = $("#MainContent_lblCostCenter").html();
            var Level = $("#MainContent_lblLevel").html();;
            var site_ref = getUrlVars()["site_ref"];
            var GetEmpNum = getUrlVars()["EmpNum"];


           //var GetEmpNum = '61055';

            $("#MainContent_lblUser").hide();
            $("#MainContent_lblEmpNum").hide();
            $("#MainContent_lblCostCenter").hide();
            $("#MainContent_lblLevel").hide();




            LoadHeaderTab();

            /////////////////////////////////////
            function LoadHeaderTab() {


                var data = { EmpNum: GetEmpNum, Site_ref: site_ref };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MyTeam.aspx/LoadHeaderMyteam") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowHeader,
                });


                function ShowHeader(response) {

                    var contentH = '';

                    var num = 0;

                    $('#tabOrg').empty();
                    $('#tabBody').empty();

                    if (response.d.length > 0) {

                        $.each(response.d, function (index, val) {

                            if (val.Acting_Line == '0') {

                                contentH = '<li class="active"><a href="#' + val.RoleID_Line + '" data-toggle="tab"><span style="font-weight:bold;">Main<span/></a></li>'

                                var Name = 'User : ' + val.EmpName_Line;

                                $('#lblName').text(Name);
                                $('#tabOrg').append(contentH);

                                LoadOrgMain(val.RoleID_Line);


                            } else {

                                var title = 'Acting : ' + val.Company + " - " + val.Level_Emp_Line + " - " + val.Dept_Line;

                                num = num + 1;
                                contentH = '<li><a  class="btnActing" at="' + val.RoleID_Line + '"   href="#' + val.RoleID_Line + '" data-toggle="tab"><span style="font-weight:bold;">' + title + '  <span/></a><li>'
                                $('#tabOrg').append(contentH);
                                
                                var Name = 'User : ' + val.EmpName_Line;
                                $('#lblName').text(Name);
                                LoadOrgActing(val.RoleID_Line);
                            }

                        });


                    }

                }//ปิด function
            }




            //////////////////////////////////////////////
            function LoadOrgMain(RoleID) {

                var contentBody = "";

                contentBody += '<div class="tab-pane active chart" id="' + RoleID + '" ><br/>'
                contentBody += '<center><div id="tree" style="height: 480px; width: 100%"></div></center>'
                contentBody += '</div>'

                $('#tabBody').append(contentBody);

                ShowChartMain();

            }

            //////////////////////////////////////////////
            function LoadOrgActing(RoleID) {

                var contentBody = "";

                contentBody += '<div class="tab-pane" id="' + RoleID + '" ><br/>'
                contentBody += '<center><div id="tree_Acting" style="height: 480px; width: 100%"></div></center>'
                contentBody += '</div>'

                $('#tabBody').append(contentBody);

                //ShowChartActing(RoleID);

            }
            //////////////////////////
            function ShowChartActing(RoleID) {

                var data = { EmpNum: GetEmpNum, Site_ref: site_ref, Costcenter: CostCenter, Type: "Acting", ChkRoleID: RoleID };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MyTeam.aspx/LoadPyramid_Myteam") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowPyramid,
                });

                function ShowPyramid(response) {



                    if (response.d.length > 0) {

                       
                        OrgChart.templates.ana.size = [250, 130];

                        OrgChart.templates.ana.field_0 =
                            '<text class="field_0" style="font-size: 16px;" fill="#ffffff" x="125" y="25" text-anchor="middle">{val}</text>';


                        OrgChart.templates.ana.field_1 =
                            '<text class="field_1" style="font-size: 14px;font-weight:bold;" fill="#ffffff"  x="125" y="50" text-anchor="middle">( {val} )</text>';

                        OrgChart.templates.ana.field_2 =
                            '<text class="field_2" style="font-size: 12px;" fill="#ffffff" x="125" y="70" text-anchor="middle">CostCenter : {val}</text>';


                        OrgChart.templates.ana.field_3 =
                            '<text class="field_3 word-wrap" style="font-size: 10.5px;" width="200px" text-overflow="multiline" fill="#ffffff" x="125" y="90" text-anchor="middle">{val}</text>';

                        //OrgChart.templates.ana.html = '<foreignobject class="node" x="20" y="80"  style="font-size: 14px;"  text-anchor="middle" width="200" height="100">{val}</foreignobject>';



                        OrgChart.templates.ana.img_0 =
                            '<image preserveAspectRatio="xMidYMid slice" xlink:href="{val}" x="10" y="5" width="30" height="20"></image>';
                        var chart_Acting = new OrgChart(document.getElementById("tree_Acting"), {
                            scaleInitial: BALKANGraph.match.boundary,
                            nodeMouseClick: BALKANGraph.action.none,
                            //showXScroll: BALKANGraph.scroll.visible,
                            //showYScroll: BALKANGraph.scroll.visible,
                            collapse: {
                                level: 3,
                                allChildren: true
                            },
                            mouseScrool: BALKANGraph.action.zoom,
                            template: "ana",
                            enableSearch: false,


                            nodeBinding: {
                              
                               field_0: function (sender, node) {
                                    var data = sender.get(node.id);
                                    var name = data["Name"];
                                    var link = data["link"];
                                    return '<a target="_blank" style="color: #ffffff;hover: #ffffff" href="' + link + '">' + name + '</a>'
                                },
                                field_1: "Level",
                                field_2: "CostCenter",
                                field_3: "Position",
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
                             toolbar: {
                                layout: true,
                                zoom: true,
                                fit: true,
                                expandAll: false
                            },
                            //menu: {
                            //    //pdfPreview: {
                            //    //    text: "PDF Preview",
                            //    //    icon: OrgChart.icon.pdf(24, 24, '#7A7A7A'),
                            //    //    onClick: preview
                            //    //},
                            //    pdf: { text: "Export PDF" },
                            //    png: { text: "Export PNG" },
                            //    svg: { text: "Export SVG" },
                            //    csv: { text: "Export CSV" }
                            //},
                        });



                        $.each(response.d, function (index, val) {

                            var RoleID = val.RoleID_Line;
                            var RefRoleID = val.RefRoleID_Line;
                            var EmpNum = val.EmpNum_Line;
                            var EmpName = val.EmpName_Line;
                            var Position = val.Position_Line;
                            var Acting = val.Acting_Line;
                            var CostCenter = val.Dept_Line;
                            var Level = val.Level_Emp_Line;
                            var Path = val.Path;
                            

                            var Template = ''


                            if (Acting == '1') {

                                Template = 'Acting';
                            }
                            else if (Acting == '0') {

                                Template = 'Active';
                            }


                            if (EmpNum == 'S0001') {

                                Template = 'Subcon';
                            }
                            else if (EmpNum == '1') {

                                Template = 'Acting';
                            }
                            else if (EmpNum == '2') {

                                Template = 'Acting';
                            }
                            else if (EmpNum == '0') {

                                Template = 'Skip';
                            }

                            var link = "MyTeam.aspx?site_ref=" + site_ref + "&EmpNum=" + EmpNum;
                            if (val.EmpName_Line != 'Skip') {

                                chart_Acting.add({
                              
                                    id: RoleID,
                                    pid: RefRoleID,
                                    Name: EmpName,
                                    img: Path,
                                    Level: Level,
                                    CostCenter: CostCenter,
                                    Position: Position,
                                    Acting: Acting,
                                    tags: [Template],
                                    //html: "<div class='word-wrap' style='color:#ffffff;text-align: center;'>" + Position + "</div>",
                                    link: link,
                                });
                            }


                        });


                        chart_Acting.draw(OrgChart.action.init);

                       
                        //function preview() {
                        //    OrgChart.pdfPrevUI.show(chart, {
                        //        format: 'A4'
                        //    });
                        //}

                      


                    } else {


                    }

                }
            }


            ////////////////////////////

            function ShowChartMain() {

                var data = { EmpNum: GetEmpNum, Site_ref: site_ref, Costcenter: CostCenter, Type: "Main", ChkRoleID: "" };

                $.ajax({
                    type: "POST",
                    async: true,
                    url: "<%= ResolveUrl("MyTeam.aspx/LoadPyramid_Myteam") %>",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "json",
                    success: ShowPyramid,
                });

                function ShowPyramid(response) {



                    if (response.d.length > 0) {

                        OrgChart.templates.ana.size = [250, 130];

                        OrgChart.templates.ana.field_0 =
                            '<text class="field_0" style="font-size: 16px;" fill="#ffffff" x="125" y="25" text-anchor="middle">{val}</text>';


                        OrgChart.templates.ana.field_1 =
                            '<text class="field_1" style="font-size: 14px;font-weight:bold;" fill="#ffffff"  x="125" y="50" text-anchor="middle">( {val} )</text>';

                        OrgChart.templates.ana.field_2 =
                            '<text class="field_2" style="font-size: 12px;" fill="#ffffff" x="125" y="70" text-anchor="middle">CostCenter : {val}</text>';


                        OrgChart.templates.ana.field_3 =
                            '<text class="field_3 word-wrap" style="font-size: 10.5px;" width="200px" text-overflow="multiline" fill="#ffffff" x="125" y="90" text-anchor="middle">{val}</text>';

                        OrgChart.templates.ana.html = '<foreignobject class="node" x="20" y="80"  style="font-size: 14px;"  text-anchor="middle" width="200" height="100">{val}</foreignobject>';



                        OrgChart.templates.ana.img_0 =
                            '<image preserveAspectRatio="xMidYMid slice" xlink:href="{val}" x="10" y="5" width="30" height="20"></image>';

                        var chart = new OrgChart(document.getElementById("tree"), {
                            nodeMouseClick: BALKANGraph.action.none,
                            scaleInitial: BALKANGraph.match.boundary,
                            //showXScroll: BALKANGraph.scroll.visible,
                            //showYScroll: BALKANGraph.scroll.visible,
                            collapse: {
                                level: 3,
                                allChildren: true
                            },
                            mouseScrool: BALKANGraph.action.zoom,
                            template: "ana",
                            enableSearch: false,

                            nodeMouseClickBehaviour: BALKANGraph.action.none,
                            nodeBinding: {
                                field_0: function (sender, node) {
                                    var data = sender.get(node.id);
                                    var name = data["Name"];
                                    var link = data["link"];
                                    return '<a target="_blank" style="color: #ffffff;hover: #ffffff" href="' + link + '">' + name + '</a>'
                                },

                            
                                field_1: "Level",
                                field_2: "CostCenter",
                                field_3: "Position",
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
                            //menu: {
                            //    //pdfPreview: {
                            //    //    text: "PDF Preview",
                            //    //    icon: OrgChart.icon.pdf(24, 24, '#7A7A7A'),
                            //    //    onClick: preview
                            //    //},
                            //    pdf: { text: "Export PDF" },
                            //    png: { text: "Export PNG" },
                            //    svg: { text: "Export SVG" },
                            //    csv: { text: "Export CSV" }
                            //},
                             toolbar: {
                                layout: true,
                                zoom: true,
                                fit: true,
                                expandAll: false
                            },
                        });



                        $.each(response.d, function (index, val) {

                            var RoleID = val.RoleID_Line;
                            var RefRoleID = val.RefRoleID_Line;
                            var EmpNum = val.EmpNum_Line;
                            var EmpName = val.EmpName_Line;
                            var Position = val.Position_Line;
                            var Acting = val.Acting_Line;
                            var CostCenter = val.Dept_Line;
                            var Level = val.Level_Emp_Line;
                            var Path = val.Path;

                            var Template = ''


                            if (Acting == '1') {

                                Template = 'Acting';
                            }
                            else if (Acting == '0') {

                                Template = 'Active';
                            }


                            if (EmpNum == 'S0001') {
                                Template = 'Subcon';
                            }
                            else if (EmpNum == '1') {
                                Template = 'Acting';
                            }
                            else if (EmpNum == '2') {

                                Template = 'Acting';
                            }
                            else if (EmpNum == '0') {
                                Template = 'Skip';
                            }


                            var link = "MyTeam.aspx?site_ref=" + site_ref + "&EmpNum=" + EmpNum;

                            if (val.EmpName_Line != 'Skip') {
                                chart.add({
                                    id: RoleID,
                                    pid: RefRoleID,
                                    Name: EmpName,
                                    img : Path,
                                    Position: Position,
                                    Level: Level,
                                    CostCenter: CostCenter,
                                    Acting: Acting,
                                    tags: [Template],
                                    link: link,
                                    //html: "<div class='word-wrap' style='color:#ffffff;text-align: center;'>" + Position + "</div>"
                                });
                            }


                        });


                        chart.draw(OrgChart.action.init);

                        function preview() {
                            OrgChart.pdfPrevUI.show(chart, {
                                format: 'A4'
                            });
                        }




                    } else {


                    }

                }
            }


            //////////////////
            $(document).on('click', '.btnActing', function () {

                var ChkRoleID = $(this).attr('at');



                ShowChartActing(ChkRoleID);
                //google.charts.load('current', { packages: ["orgchart"] });
                //google.charts.setOnLoadCallback(CreateChartActing);


            });

            function getUrlVars() {
                var vars = [], hash;
                var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < hashes.length; i++) {
                    hash = hashes[i].split('=');
                    vars.push(hash[0]);
                    vars[hash[0]] = hash[1];
                }
                return vars;
            }
        });//closedoc

    </script>


</asp:Content>
