<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="QuienTraslada.aspx.cs" Inherits="QuienTraslada" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Página sin título</title>
    <link href="css/sename_aplica.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />

    <script type="text/javascript" src="Script/jquery.min.js"></script>
    <script type="text/javascript" src="Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="Script/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="Script/jquery.fancybox-1.3.4.js"></script>

    <script type="text/javascript">
    
        function pageLoad() {
            $(".ifancybox").fancybox({
                'width': '75%',
                'height': '75%',
                'autoScale': false,
                'transitionIn': 'none',
                'transitionOut': 'none',
                'type': 'iframe'
            });
        };

    function funcionsuma()
    {
            if(trim(document.getElementById("txt003").value) == "")
            {
                document.getElementById("txt003").value = "0";
            }
            if(trim(document.getElementById("txt004").value) == "")
            {
                document.getElementById("txt004").value = "0";
            }
            if(trim(document.getElementById("txt005").value) == "")
            {
                document.getElementById("txt005").value = "0";
            }
            if(trim(document.getElementById("txt006").value) == "")
            {
                document.getElementById("txt006").value = "0";
            }
          
            var textoprop = parseInt(trim(document.getElementById("txt003").value))+
                            parseInt(trim(document.getElementById("txt004").value))+
                            parseInt(trim(document.getElementById("txt005").value))+
                            parseInt(trim(document.getElementById("txt006").value));
            //alert(textoprop);
            document.getElementById("txt002").value = textoprop.toString();
        
    }
    function trim(str) 
    {
        str = str.toString();
        while (1) 
        {
        if (str.substring(0, 1) != " ")
        {
        break;
        }
        str = str.substring(1, str.length);
        }
        while (1) 
        {
        if (str.substring(str.length - 1,str.length) != " ")
        {
        break;
        }
        str = str.substring(0, str.length - 1);
        }
        return str;
    }

    function AcceptNum(evt)
    { 
        var nav4 = window.Event ? true : false;
        var key = nav4 ? evt.which : evt.keyCode; 
        return (key <= 13 || (key >= 48 && key <= 57) || key == 44);
    }
    function f_SoloNumeros()
    {
        var key=window.event.keyCode;
        if (key < 48 || key > 57)
        {
            window.event.keyCode=0;
        }
    }

  

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div>
            <br />
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td class="titulo_form" style="height: 20px">
                        &nbsp;Registro de Quien Traslada NNA<table align="right" border="0" cellpadding="1"
                            cellspacing="1" width="120">
                            <tr>
                                <td>
                          
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" Text="Buscar" OnClick="WebImageButton1_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <asp:Label ID="lbl001" runat="server" ForeColor="Red" Text="No puede registrar evento en mes cerrado"
                            Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top" bgcolor="E1EDFF">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td class="texto_form">
                                    Institución</td>
                                <td bgcolor="#ffffff">
                                    <span class="texto_rojo_peque">
                                        <asp:DropDownList ID="ddlInstitucion" runat="server" Width="700px" OnSelectedIndexChanged="ddown001_SelectedIndexChanged"
                                            AutoPostBack="True" Font-Size="11px" Font-Names="Arial">
                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    <a id="A2" runat="server" class="ifancybox" href="mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=reg_eventosproy.aspx"> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton1_Click" /></a>
                                        </span>


                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form">
                                    Proyecto</td>
                                <td bgcolor="#ffffff">
                                    <span class="texto_rojo_peque">
                                        <asp:DropDownList ID="ddlProyecto" runat="server" Width="700px" AutoPostBack="True"
                                            Font-Size="11px" Font-Names="Arial" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                      <a id="A1" runat="server" class="ifancybox" href="mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=reg_eventosproy.aspx">  <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton2_Click" /></a>   &nbsp;&nbsp;
                                       
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 222px">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="width: 30px; border-style: none">
                                </td>
                                <td bgcolor="#ffffff" style="height: 15px; text-align: center">
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp;<br />
                                    <br />
                                    <asp:GridView ID="grdQuienTraslada" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        Font-Size="11px" ForeColor="#333333" GridLines="None" Width="70%">
                                        <RowStyle BackColor="#EFF3FB" />
                                        <Columns>
                                            <asp:BoundField DataField="ICodIE" HeaderText="ICodIE">
                                                <ItemStyle Font-Size="11px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodNino" HeaderText="CodNino">
                                                <ItemStyle Font-Size="1px" ForeColor="White" Width="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" />
                                            <asp:BoundField DataField="FechaEgreso" HeaderText="Fecha Egreso" />
                                           
                                            <asp:TemplateField HeaderText="Tipo de Traslado">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ListaTiposTraslados" runat="server">
                                                        <asp:ListItem Text="SIN INFORMACION" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="CARABINEROS" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="ETD RESIDENCIA" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="FAMILIA" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="FUNCIONARIO SENAME" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="OTROS" Value="5"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle Font-Size="11px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFFF" style="height: 15px; text-align: center" colspan="2">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                  
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb001" runat="server" Text="Guardar" Visible="False" OnClick="imb001_Click" />
                                    &nbsp;&nbsp;
                                  
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton4" runat="server" Text="Ejecutar Consulta" OnClick="WebImageButton4_Click" />
                                    &nbsp; &nbsp;&nbsp;
                                   
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton3" runat="server" Text="Volver" OnClick="WebImageButton3_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
