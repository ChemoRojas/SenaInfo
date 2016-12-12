<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_Egreso_Direccion.aspx.cs" Inherits="mod_ninos_Egreso_Direccion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>
<html lang="es">

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Untitled Page</title>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery.blockUI.js"></script>   
    <!-- gfontbrevis agrega senainfotools con herramientas como fijador de headers de tablas -->
    <script src="../js/senainfoTools.js"></script>
    <%-- <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/ventanas-modales.js"></script>--%>
    <%--<script src="../js/bootstrap.min.js"></script>--%>
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>
    <link href="../css/ventanas-modales.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
        function CerrarFancybox() {
            parent.$.fancybox.close();
        };

    </script>
</head>
<body class="body-form">
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
            <asp:PostBackTrigger ControlID="btn_guardar" />
                           
            </Triggers>
            <ContentTemplate>
            <div>
                     
                <br />
                <div class="row">
                    <div class="col-md-10">
                        <div>
                          <asp:Panel ID="pnl003" runat="server" Visible="False">
                              <div id="tableHeader" class="fixed-header"></div>
                         <div class="fixed-header-table-container">
                            <asp:GridView CssClass="table table table-bordered table-hover caja-tabla" ID="grd002" runat="server" AllowPaging="True" AutoGenerateColumns="False" Visible="False" OnRowCommand="grd002_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="FechaIngresoDireccion" HeaderText="Ingreso Direccion" DataFormatString="{0:d}" HtmlEncode="False">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Telefono" HeaderText="Telefono">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TelefonoRecado" HeaderText="Telefono Recado">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Mail" HeaderText="Mail">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fax" HeaderText="Fax">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CodigoPostal" HeaderText="CodigoPostal">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha Actualizacion" DataFormatString="{0:d}" HtmlEncode="False">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Comuna">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CodComuna" HeaderText="Cod. Comuna">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ICodDireccion" HeaderText="C&#243;digo Direcci&#243;n">
                                    </asp:BoundField>
                                    <asp:ButtonField CommandName="Ver" Text="Ver">
                                    </asp:ButtonField>
                                </Columns>
                                <HeaderStyle CssClass="titulo-tabla" />
                                <PagerStyle CssClass="titulo-tabla" ForeColor="White" />   
                            </asp:GridView>
                              </div>
                        <div >
                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button pull-right" ID="WebImageButton1" AutoPostback="true" runat="server" OnClick="WebImageButton1_Click" Text="Agregar Nueva"  >
                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Nueva
                    </asp:LinkButton>
                </div> 
                                               
                        </asp:Panel>
                            

                         </div>
                        <asp:Panel ID="pnl002" runat="server" Visible="False">
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fecha Ingreso *</th>

                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl001" runat="server" Visible="False"></asp:Label><br />
                                                    <asp:TextBox ID="cal001" runat="server" CssClass="form-control form-control-fecha input-sm" MaxLength="10" placeholder="dd-mm-aaaa"/>
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende856" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal001" ValidChars="0123456789-/" />
                                                </td>
                                                <td>
                                                    <asp:RangeValidator ID="RangeValidator903" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="cal001" Type="Date" OnInit="rv_fecha_Init" /><br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="cal001" ForeColor="Red" ErrorMessage="Fecha Requerida">
                                                </asp:RequiredFieldValidator>
                                                </td>                                            
                                            </tr>                                            
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                     <th class="titulo-tabla" scope="row">Dirección *</th>
                                     <td>
                                        <asp:TextBox ID="txt007" runat="server" MaxLength="100" CssClass="form-control input-sm" TextMode="MultiLine"/>
                                     </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Región *</th>     
                                    <td>
                                        <asp:DropDownList ID="ddown006" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddown006_SelectedIndexChanged1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Comuna *</th>
                                    <td>
                                        <asp:DropDownList ID="ddown004" runat="server" CssClass="form-control input-sm" >
                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">fono</th>
                                    <td>
                                        <div class="input-group"> 
                                            <asp:Label ID="Label_fono" CssClass="input-group-addon-telefono btn btn-sm" runat="server" Text="+56"></asp:Label>
                                            <asp:TextBox ID="txt002" runat="server" MaxLength="30" CssClass="form-control input-sm" placeholder="Cod.Área + 2 + Número" />
                                        </div>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt002" ValidChars="0123456789" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Teléfono Recado</th>
                                    <td>
                                        <div class="input-group">
                                            <asp:Label ID="Label_tel_recado" CssClass="input-group-addon-telefono btn btn-sm" runat="server" Text="+56"></asp:Label> 
                                            <asp:TextBox ID="txt003" runat="server" MaxLength="30" CssClass="form-control input-sm" placeholder="Cod.Área + 2 + Número" />
                                        </div>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt003" ValidChars="0123456789" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">e-Mail</th>
                                    <td>
                                        <asp:TextBox ID="txt004" runat="server" MaxLength="30" CssClass="form-control input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fax</th>
                                    <td>
                                        <div class="input-group"> 
                                            <asp:Label ID="Label_fax" CssClass="input-group-addon-telefono btn btn-sm" runat="server" Text="+56"></asp:Label> 
                                            <asp:TextBox ID="txt005" runat="server" MaxLength="30" CssClass="form-control input-sm" placeholder="Cod.Área + 2 + Número" />
                                        </div>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt005" ValidChars="0123456789" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Código Postal</th>
                                    <td>
                                        <asp:TextBox ID="txt006" runat="server" MaxLength="8" CssClass="form-control input-sm"/>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt006" ValidChars="0123456789" />
                                    </td>
                                </tr>
                            </table>

                        <div class="pull-right">
                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click" CausesValidation="true" >
                                <span class="glyphicon glyphicon-refresh"></span>&nbsp;Actualizar
                            </asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_guardar" runat="server" Text="Guardar" Visible="False" OnClick="btn_guardar_Click" CausesValidation="true">
                                <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp;Guardar
                            </asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn_limpiar" runat="server" Text="Limpiar" OnClick="btn_limpiar_Click" CausesValidation="false">
                                <span class="glyphicon glyphicon-remove-circle"></span>&nbsp;Limpiar
                            </asp:LinkButton>                           
                        </div>
                        </asp:Panel>
                    </div>
                  </div>
                </div>
            </ContentTemplate>
         </asp:UpdatePanel>
    </form>
</body>
</html>
