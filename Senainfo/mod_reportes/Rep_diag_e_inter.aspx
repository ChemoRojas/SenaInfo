 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_diag_e_inter.aspx.cs" Inherits="Reportes_rep_Diag_e_inter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../Script/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.fancybox-1.3.4.js"></script>

    <script language="javascript" type="text/javascript">
        

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="titulo_form">Reporte de Diagn&oacute;sticos e Intervenciones </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="1000" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td width="225" class="texto_form">Regi&oacute;n</td>
                                                    <td colspan="3" class="linea_inferior">

                                                        <asp:DropDownList ID="ddregion" runat="server" Font-Size="11px" Width="550px" EnableViewState="true" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddinstitucion_SelectedIndexChanged"></asp:DropDownList>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="texto_form">Instituci&oacute;n</td>
                                                    <td colspan="3" class="linea_inferior">

                                                        <asp:DropDownList ID="ddinstitucion" runat="server" Font-Size="11px" Width="550px" AutoPostBack="True" OnSelectedIndexChanged="ddproyecto_SelectedIndexChanged"></asp:DropDownList>
                                                        <a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_reportes/Rep_diag_e_inter.aspx">
                                                            <asp:ImageButton ID="btnBuscaInstitucion" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="btnBuscaInstitucion_Click" /></a>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="texto_form">Proyecto</td>
                                                    <td colspan="3" class="linea_inferior">

                                                        <asp:DropDownList ID="ddproyecto" runat="server" Font-Size="11px" Width="550px"></asp:DropDownList>
                                                        <a id="A2" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_reportes/Rep_diag_e_inter.aspx">
                                                            <asp:ImageButton ID="btnBuscaProyecto" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="btnBuscaProyecto_Click" /></a>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="texto_form">Fecha de B&uacute;squeda </td>
                                                </tr>
                                                <tr>
                                                    <td class="texto_form">Inicio</td>
                                                    <td class="linea_inferior">
                                                        <calendarlayout daynameformat="FirstLetter" firstdayofweek="Monday" footerformat=""
                                                            maxdate="" showfooter="False" shownextprevmonth="False" showtitle="False">
</calendarlayout>

                                                        <asp:TextBox ID="cal_inicio" runat="server" Width="150px" EDITABLE="False" />
                                                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1320" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Fecha Requerida" ControlToValidate="cal_inicio" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="cal_inicio" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />

                                                        <selecteddaystyle backcolor="#0054E3" />
                                                        <daystyle backcolor="White" font-names="Arial" font-size="10px" />
                                                        <othermonthdaystyle forecolor="White" />
                                                        <dayheaderstyle backcolor="#7A96DF" forecolor="White" />
                                                        <titlestyle backcolor="White" />
                                                        <todaydaystyle backcolor="#FFFFC0" />
                                                        <weekenddaystyle forecolor="Red" />
                                                        <calendarstyle backcolor="#EFF6F8" bordercolor="Gray" borderstyle="Solid" borderwidth="1px"
                                                            font-names="Arial" font-size="11px" forecolor="#404050">
</calendarstyle>
                                                    </td>
                                                    <td width="150" class="texto_form">T&eacute;rmino</td>
                                                    <td class="linea_inferior">
                                                        <calendarlayout daynameformat="FirstLetter" firstdayofweek="Monday" footerformat=""
                                                            maxdate="" showfooter="False" shownextprevmonth="False" showtitle="False">
</calendarlayout>

                                                        <asp:TextBox ID="cal_termino" runat="server" Width="150px" EDITABLE="False" />
                                                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1337" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_termino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Fecha Requerida" ControlToValidate="cal_termino" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true"  ControlToValidate="cal_termino" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />

                                                        <selecteddaystyle backcolor="#0054E3" />
                                                        <daystyle backcolor="White" font-names="Arial" font-size="10px" />
                                                        <othermonthdaystyle forecolor="White" />
                                                        <dayheaderstyle backcolor="#7A96DF" forecolor="White" />
                                                        <titlestyle backcolor="White" />
                                                        <todaydaystyle backcolor="#FFFFC0" />
                                                        <weekenddaystyle forecolor="Red" />
                                                        <calendarstyle backcolor="#EFF6F8" bordercolor="Gray" borderstyle="Solid" borderwidth="1px"
                                                            font-names="Arial" font-size="11px" forecolor="#404050">
</calendarstyle>
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td width="150" align="center">
                                            <roundedcorners heightofbottomedge="0" hoverimageurl="ig_butMac2.gif" imageurl="ig_butMac1.gif"
                                                maxheight="23" maxwidth="300" pressedimageurl="ig_butMac4.gif" renderingtype="FileImages"
                                                widthofrightedge="13">
</roundedcorners>
                                            <roundedcorners heightofbottomedge="0" hoverimageurl="ig_butMac2.gif" imageurl="ig_butMac1.gif"
                                                maxheight="23" maxwidth="300" pressedimageurl="ig_butMac4.gif" renderingtype="FileImages"
                                                widthofrightedge="13">
</roundedcorners>
                                            <roundedcorners heightofbottomedge="0" hoverimageurl="ig_butMac2.gif" imageurl="ig_butMac1.gif"
                                                maxheight="23" maxwidth="300" pressedimageurl="ig_butMac4.gif" renderingtype="FileImages"
                                                widthofrightedge="13">
</roundedcorners>

                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_buscar" runat="server" Text="Buscar" Width="100px" OnClick="btn_buscar_Click" />


                                            <br />

                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_limpiar" runat="server" Text="Limpiar" Width="100px" OnClick="btn_limpiar_Click" />


                                            <br />

                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" OnClick="btn_volver_Click" Text="Volver" Width="100px" />


                                            <br />
                                            <asp:ImageButton ID="btn_excel" runat="server" ImageUrl="../images/Excel1.bmp" OnClick="btn_excel_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_error" runat="server" Font-Size="11px" ForeColor="Red" Visible="False">No se han encontrado registros coincidentes.</asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" Width="100%">
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="codinstitucion" HeaderText="CodInst" Visible="False" />
                                                <asp:BoundField DataField="nombinst" HeaderText="nombinst" Visible="False" />
                                                <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nombproy" HeaderText="Nombre Proyecto">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CodRegion" HeaderText="CodRegion" Visible="False" />
                                                <asp:BoundField DataField="comuna" HeaderText="comuna" Visible="False" />
                                                <asp:BoundField DataField="codnino" HeaderText="Cod. Ni&#241;o">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="apellido_paterno" HeaderText="Ap. Paterno">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="apellido_materno" HeaderText="Ap. Materno">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nombres" HeaderText="Nombres">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fechanacimiento" HeaderText="F. Nacto.">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="rut" HeaderText="Rut" Visible="False" />
                                                <asp:BoundField DataField="fechaingreso" HeaderText="F. Ingreso">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fechaegreso" HeaderText="F. Egreso">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="permanencia" HeaderText="Permanencia">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="intervenciones" HeaderText="Num. Interv.">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="diligencias_sol" HeaderText="Dilig. Sol.">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="diligencias_rea" HeaderText="Dilig. Rea.">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="maltrato" HeaderText="Diag. Maltrato">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="escolar" HeaderText="Diag. Escolar">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="droga" HeaderText="Diag. Drogas">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sicologica" HeaderText="Diag. Psicol&#243;gico">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="social" HeaderText="Diag. Social">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="capacitacion" HeaderText="Diag. Capacitaci&#243;n">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="laboral" HeaderText="Diag. Laboral">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="pfti" HeaderText="Diag. PFTI">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vigencia" HeaderText="Vigente a hoy">
                                                    <ItemStyle Font-Size="11px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ICodIE" HeaderText="ICodIE" Visible="False" />
                                                <asp:BoundField DataField="desde" HeaderText="desde" Visible="False" />
                                                <asp:BoundField DataField="hasta" HeaderText="hasta" Visible="False" />
                                                <asp:BoundField DataField="reporte" HeaderText="reporte" Visible="False" />
                                            </Columns>
                                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
