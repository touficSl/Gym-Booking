<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/RegisterCTR.aspx.cs" Inherits="View_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REGISTER</title>
    <style>
        @font-face{
              src:url(http://lab.web-gate.fr/fonts/proxima-nova/ProximaNova-Light.ttf);
              font-family:calibri;
            }
            * {
                box-sizing: border-box;
                -webkit-font-smoothing: antialiased;
                font-family: "proximaNova", helvetica Neue;
                font-weight: 600;
                -webkit-appearance: none;
                border-radius: 0;
            }
            body {
                background:#FF5335;
                color: red;
                font-size: 12px;
            }
            #card {
                width: 450px;
                margin: auto;
                margin-top: 120px;
            }
            #card h2 {
                text-shadow: 0 1px 0 red;
                font-size: 1.62em;
                color: red;
                display: block;
                width: 100%;
                padding-bottom: .4em;
                margin-bottom: .6em;
                border-bottom: 2px solid red;
                /*box-shadow*/
                -webkit-box-shadow: 0 1px 0 red;
                -moz-box-shadow: 0 1px 0 red;
                box-shadow: 0 1px 0 red;
            }
            #card a { color: red }
            #card label {
                font-size: 10px;
                display: block;
                float: right;
                clear: left;
                line-height: 2.4;
                margin: -30px 0 0;
                padding: 0;
                width: 190px;
                height: 20px;
            }
            input[type="text"],
            input[type="submit"] {
                clear: both;
                float: left;
                display: block;
                border: 1px solid #ccc;
                background: #ffd5ce;
                margin: 6px 0;
                padding: 4px 10px;
                width: 100%;
                height: 34px;
                outline: 0;
                color: #34495e;
                font-size: 14px;
                -webkit-border-radius: 5px 5px 0 0;
                -moz-border-radius: 5px 5px 0 0; 
                border-radius: 5px 5px 5px 5px;
            }
            input[type=submit] {
                background: red;
                color: #ecf0f1;
                border: 0; 
                margin: 10px 0 0;
            } 
            input[type=text]:not([value*=" "]):active,
            input[type=text]:not([value*=" "]):focus {
                /*box-shadow*/
                -webkit-box-shadow: inset 8px 0px 0  red;
                -moz-box-shadow: inset 8px 0px 0  red;
                box-shadow: inset 8px 0px 0  red; 
            }
            input[type=submit]:active,
            input[type=submit]:focus {
                background: #red;
                color: #ecf0f1;
                border: 0;
                position: relative;
                top: 1px;
                border-bottom: 1px solid;
            }  
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <div id="card">
          <h2>REGISTER  </h2>
          <input runat="server" type="text" id="name" name="name" placeholder="Name.."/>
          <input runat="server" type="text" id="mail" name="mail" placeholder="Mail.." />
          <input runat="server" type="text" id="password" name="password"  placeholder="Password.." /> 
          <input runat="server" type="text" id="Address" name="address"  placeholder="Address.." /> 
          <input runat="server" type="text" id="tel" name="tel"  placeholder="Tel.." /> 

          <asp:Button runat="server" id="submit" Text="Register" onclick="Register_Click"/> 
        </div> 
    </form>
</body>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<script>
    $(document).ready(function () {
        setInterval(function () {
            $("input[type=text]").each(function () {
                var element = $(this);
                if (element.val() !== "") {
                    $(this).css({
                        boxShadow: 'inset 8px 0px 0  red',
                        paddingLeft: '12px'
                    })
                }
                var element = $(this);
                if (element.val() == "") {
                    $(this).css('border-left', '1px solid #ccc')
                }
            });
        }, 200);
    });
</script>
</html>
