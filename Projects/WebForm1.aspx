<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PyramidSystem.Projects.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {packages:["orgchart"]});
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Name');
        data.addColumn('string', 'Manager');
        data.addColumn('string', 'ToolTip');

        // For each orgchart box, provide the name, manager, and tooltip to show.
        data.addRows([
          [{v:'Mike', f:'Mike<div style="color:red; font-style:italic">President</div>'},
           '', 'The President'],
          [{v:'Jim', f:'Jim<div style="color:red; font-style:italic">Vice President</div>'},
           'Mike', 'VP'],
          ['Alice', 'Mike', ''],
          ['Bob', 'Jim', 'Bob Sponge'],
          ['Carol', 'Bob', '']
        ]);

        // Create the chart.
        var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));
        // Draw the chart, setting the allowHtml option to true for the tooltips.
        chart.draw(data, {allowHtml:true});
      }
   </script>
   
    <div id="chart_div"></div>
     <style>
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
