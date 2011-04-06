<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ContentSecurityPolicy.Net.WebTest.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        img { width: 100px; }
        table { border: 1px solid #444; margin-top: 10px;}
        td { border: 1px solid #444; padding: 5px 20px 5px 20px; } 
        td.hide { color: #fff; }   
        iframe { width: 100px; height: 3em; }
    </style>
    <link rel="Stylesheet" type="text/css" href="http://erlend.oftedal.no/csp-test/shouldWork.css" />
    <link rel="Stylesheet" type="text/css" href="http://www.oftedal.no/~erlend/csp-test/shouldNotWork.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="Content" runat="server" />

        <table>
            <tr>
                <th>Element</th><th>Should work</th><th>Should not work</th>
            </tr>
            <tr>
                <td>Image</td><td><img src="https://d3nwyuy0nl342s.cloudfront.net/images/modules/header/logov3-hover.png" /></td><td><img src="http://www.google.com/images/logos/ps_logo2.png" /></td>
            </tr>
            <tr>
                <td>Script</td><td id="jsYes">- no result -</td><td id="jsNo">- no result -</td>
            </tr>
            <tr>
                <td>Style</td><td class="hide" id="cssYes">Worked</td><td class="hide" id="cssNo">Worked</td>
            </tr>
            <tr>
                <td>Iframe</td><td><iframe src="http://erlend.oftedal.no/csp-test/shouldWork.html"></iframe></td>
                <td><iframe src="http://www.oftedal.no/~erlend/csp-test/shouldNotWork.html"></iframe></td>
            </tr>
        </table>
    </div>
    </form>

    <script src="http://erlend.oftedal.no/csp-test/shouldWork.js"></script>
    <script src="http://www.oftedal.no/~erlend/csp-test/shouldNotWork.js"></script>

</body>
</html>
