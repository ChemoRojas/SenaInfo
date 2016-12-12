<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PII_MSJ.aspx.cs" Inherits="mod_ninos_PII_MSJ" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Buscador Instituciones</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="1" cellspacing="1">
                <tr>
                    <td class="titulo_form" style="height: 20px">&nbsp;Resumen Plan Intervención<br />
                        &nbsp;<asp:Label ID="Label1" runat="server" CssClass="texto_rojo_peque" Visible="False"></asp:Label></td>
                </tr>

                <tr>
                    <td style="height: 14px">
                        <span style="font-size: 11px">Ha Ingresado los Siguientes Planes de Intervencion </span></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">

                            <tr>
                                <td>
                                    <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="CodPlanIntervencion" HeaderText="COD. PLAN INTERV.">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ICodIE" HeaderText="ICodIE">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodProyecto" HeaderText="NI&#209;O">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodNino" HeaderText="COD. NI&#209;O">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodGrupo" HeaderText="COD. GRUPO">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                        <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" style="height: 44px">
                                    <br />
                                    &nbsp; &nbsp; &nbsp;
                        
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb003" runat="server" Text="Cerrar" OnClick="imb003_Click"  />


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
