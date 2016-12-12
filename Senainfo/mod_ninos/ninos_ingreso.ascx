<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ninos_ingreso.ascx.cs" Inherits="mod_ninos_ninos_ingreso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>


<link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

         
<table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
    <tr>
        <td>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="middle" class="titulo_form" valign="top">
                        Ingresos</td>
                </tr>
                <tr>
                    <td bgcolor="#e0f1fe" valign="top">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr valign="top">
                                <td class="texto_form" width="30%" >
                                    Fecha Ingreso
                                </td>
                                <td bgcolor="#ffffff" width="70%">
                                                    <asp:TextBox ID="ddown001" RUNAT="server" WIDTH="250px" /><ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1669" runat="server"  Enabled="true" Format="dd-MM-yyyy" TargetControlID="ddown001" ValidateRequestMode="Enabled" ViewStateMode="Enabled"/><asp:RangeValidator ID="RangeValidator1669" runat="server" Text="Fecha Invalida" ControlToValidate="ddown001" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01"/>
                                    </td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Inmueble</td>
                                <td bgcolor="#ffffff">
                                    <span class="texto_rojo_peque">
                                        <asp:DropDownList ID="ddown002" runat="server" Width="450px" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList></span></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Tipo Atención</td>
                                <td bgcolor="#ffffff">
                                    <span class="texto_rojo_peque">
                                        <asp:DropDownList ID="ddown003" runat="server" Width="449px" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList></span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="middle" class="titulo_form" valign="top">
                        Datos del Ingreso</td>
                </tr>
                <tr>
                    <td bgcolor="#e0f1fe" valign="top">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr valign="top">
                                <td class="texto_form" width="30%" style="height: 24px">
                                    Calidad Jurídica</td>
                                <td bgcolor="#ffffff" width="70%" style="height: 24px">
                                    <span class="texto_rojo_peque"><asp:DropDownList ID="ddown004" runat="server" Width="250px" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                    </asp:DropDownList></span></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form" style="height: 22px">
                                    Identidad Confirmada en el ingreso</td>
                                <td bgcolor="#ffffff" style="height: 22px">
                                    <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form" style="height: 15px">
                                    <span id="lblEdad">Edad</span></td>
                                <td bgcolor="#ffffff" style="height: 15px">
                                    <asp:TextBox ID="txt001" RUNAT="server" WIDTH="50px" /><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender132" runat="server" FilterType="Numbers" TargetControlID="txt001"/><asp:RangeValidator ID="RangeValidator132" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txt001" Type="Integer" MaximumValue="999999999" MinimumValue="0"/>
                                                &nbsp;Años&nbsp;<asp:TextBox ID="txt002" RUNAT="server" WIDTH="49px" /><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender134" runat="server" FilterType="Numbers" TargetControlID="txt002"/><asp:RangeValidator ID="RangeValidator134" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txt002" Type="Integer" MaximumValue="999999999" MinimumValue="0"/>
                                                &nbsp;Meses</td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form" style="height: 27px">
                                    Escolaridad</td>
                                <td bgcolor="#ffffff" style="height: 27px">
                                    <asp:DropDownList ID="ddown005" runat="server" Width="250px" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form" style="height: 24px">
                                    Año último Curso</td>
                                <td bgcolor="#ffffff" style="height: 24px">
                                    <input name="textfield" size="15" /></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form" style="height: 45px">
                                    Tipo Asistencia Escolar</td>
                                <td bgcolor="#ffffff" style="height: 45px">
                                    <asp:DropDownList ID="ddown006" runat="server" Width="250px" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form" style="height: 76px">
                                    Domicilio</td>
                                <td bgcolor="#ffffff" style="height: 76px">
                                    <textarea cols="45" name="textfield" style="height: 74px"></textarea></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form" style="height: 27px">
                                    Comuna</td>
                                <td bgcolor="#ffffff" style="height: 27px"><asp:DropDownList ID="ddown007a" runat="server" Width="250px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown007a_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                </asp:DropDownList>
                                    <asp:DropDownList ID="ddown007" runat="server" Width="250px" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Tipo Relación con Quien Vive</td>
                                <td bgcolor="#ffffff"><asp:DropDownList ID="ddown008" runat="server" Width="250px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Persona Contacto</td>
                                <td bgcolor="#ffffff">
                                    <asp:TextBox ID="txt003" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Teléfono Contacto</td>
                                <td bgcolor="#ffffff">
                                    <asp:TextBox ID="txt004" RUNAT="server" /><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender136" runat="server" FilterType="Numbers" TargetControlID="txt004"/><asp:RangeValidator ID="RangeValidator136" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txt004" Type="Integer" MaximumValue="999999999" MinimumValue="0"/>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Tipo Relación Contacto</td>
                                <td bgcolor="#ffffff"><asp:DropDownList ID="ddown009" runat="server" Width="250px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Entrevistador</td>
                                <td bgcolor="#ffffff"><asp:DropDownList ID="ddown010" runat="server" Width="250px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Revisor</td>
                                <td bgcolor="#ffffff"><asp:DropDownList ID="ddown011" runat="server" Width="250px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Ingreso Comunicado Familia u Otro</td>
                                <td bgcolor="#ffffff">
                                    <asp:CheckBox ID="CheckBox2" runat="server" /></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Tipo Solicitante Ingreso</td>
                                <td bgcolor="#ffffff"><asp:DropDownList ID="ddown012" runat="server" Width="250px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td class="texto_form">
                                    Solicitante Ingreso</td>
                                <td bgcolor="#ffffff"><asp:DropDownList ID="ddown013" runat="server" Width="250px" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="middle" class="titulo_form" valign="top" style="height: 25px">
                        Ordenes del Tribunal</td>
                </tr>
                <tr>
                    <td bgcolor="#e0f1fe" valign="top">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr valign="top">
                                <td class="texto_form" width="30%">
                                    Tiene Orden de Tribunal</td>
                                <td bgcolor="#ffffff" width="70%">
                                    <span>
                                        <asp:RadioButton ID="rdo001" runat="server" AutoPostBack="True" GroupName="rdoorden"
                                            OnCheckedChanged="rdo001_CheckedChanged" Text="SI" />&nbsp;
                                        <asp:RadioButton ID="rdo002" runat="server" AutoPostBack="True" GroupName="rdoorden"
                                            OnCheckedChanged="rdo002_CheckedChanged" Text="EN TRAMITE" />&nbsp;
                                        <asp:RadioButton ID="rdo003" runat="server" AutoPostBack="True" GroupName="rdoorden"
                                            OnCheckedChanged="rdo003_CheckedChanged" Text="NO" />
                                        &nbsp;&nbsp; </span>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td bgcolor="#ffffff" colspan="2">
                                    <asp:Panel ID="pnl001" runat="server" Visible="False" Width="100%">
                                        <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                            <tr bgcolor="#eeeeee">
                                                <td bgcolor="#eeeeee" colspan="4" style="height: 22px">
                                                    <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd001_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="CodTribunal" Visible="False" />
                                                            <asp:BoundField HeaderText="Tribunal" DataField="Descripcion" />
                                                            <asp:BoundField HeaderText="Fecha Orden" DataField="Fecha" />
                                                            <asp:BoundField HeaderText="Expediente" DataField="expediente" />
                                                            <asp:ButtonField Text="Quitar" />
                                                        </Columns>
                                                        <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#eeeeee">
                                                <td bgcolor="#eeeeee" style="height: 22px; width: 87px;" class="texto_form">
                                                    Region</td>
                                                <td style="height: 22px">
                                                    <asp:DropDownList ID="ddown014" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddown014_SelectedIndexChanged" AppendDataBoundItems="True">
                                                        <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="height: 22px" class="texto_form">
                                                    Tipo de Tribunal</td>
                                                <td style="height: 22px">
                                                    <asp:DropDownList ID="ddown015" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddown015_SelectedIndexChanged" AppendDataBoundItems="True">
                                                        <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr bgcolor="#eeeeee">
                                                <td style="height: 22px; width: 87px;" class="texto_form">
                                                    <span>Tribunal</span></td>
                                                <td style="height: 22px">
                                                    <span class="texto_rojo_peque">
                                                        <asp:DropDownList ID="ddown016" runat="server" Width="250px" AutoPostBack="True" AppendDataBoundItems="True">
                                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                        </asp:DropDownList></span></td>
                                                <td style="height: 22px" class="texto_form">
                                                    Expediente</td>
                                                <td style="height: 22px">
                                                    <span class="texto_rojo_peque">
                                                        <asp:TextBox ID="txt005" RUNAT="server" WIDTH="250px" /><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender138" runat="server" FilterType="Numbers" TargetControlID="txt005"/><asp:RangeValidator ID="RangeValidator138" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txt005" Type="Integer" MaximumValue="999999999" MinimumValue="0"/>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr bgcolor="#eeeeee">
                                                <td style="height: 22px; width: 87px;" class="texto_form">
                                                    Fecha</td>
                                                <td style="height: 22px" valign="middle">
                                                    <asp:TextBox ID="ddown017" RUNAT="server" WIDTH="250px" /><ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1679" runat="server"  Enabled="true" Format="dd-MM-yyyy" TargetControlID="ddown017" ValidateRequestMode="Enabled" ViewStateMode="Enabled"/><asp:RangeValidator ID="RangeValidator1679" runat="server" Text="Fecha Invalida" ControlToValidate="ddown017" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01"/>
                                                </td>
                                                <td style="height: 22px; text-align: center;">
                                                    <asp:Button ID="btn001" runat="server" Text="AGREGAR" OnClick="btn001_Click" CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" /></td>
                                                <td style="height: 22px">
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    </td>
                            </tr>
                        </table>
                       </td>
                </tr>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="middle" class="titulo_form" valign="top">
                        Causales del Ingreso
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#e0f1fe" valign="top">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr bgcolor="#ffffff" valign="top">
                                <td>
                                    <span style="text-align: center"><span id="rvCausalesIngreso" class="TextoError"
                                        controltovalidate="txtNroCausalesIngreso" errormessage="Debe ingresar Causales de Ingreso(1 hasta 3)"
                                        isvalid="false" maximumvalue="3" minimumvalue="1" style="color: red">Debe ingresar
                                        Causales de Ingreso(1 hasta 3)</span></span>
                                    <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                        <tr bgcolor="#eeeeee">
                                            <td bgcolor="#eeeeee" colspan="4">
                                                <asp:GridView ID="grd002" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd002_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="CodTipoCausalIngreso" Visible="False" />
                                                        <asp:BoundField HeaderText="CodCausalIngreso" DataField="CodCausalIngreso" Visible="False" />
                                                        <asp:BoundField HeaderText="Tipo Causal de Ingreso" DataField="DescripcionTipo" />
                                                        <asp:BoundField HeaderText="Causal de Ingreso" DataField="Descripcion" />
                                                        <asp:BoundField DataField="entidad" HeaderText="Entidad que Asigna" />
                                                        <asp:ButtonField Text="Quitar" />
                                                    </Columns>
                                                    <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#eeeeee">
                                            <td bgcolor="#eeeeee" class="texto_form" style="width: 77px">
                                                Tipo Causal de Ingreso</td>
                                            <td style="width: 142px"><asp:DropDownList ID="ddown018" runat="server" Width="320px" AutoPostBack="True" OnSelectedIndexChanged="ddown018_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar </asp:ListItem>
                                            </asp:DropDownList></td>
                                            <td style="width: 108px" class="texto_form">
                                                Causal de 
                                                <br />
                                                Ingreso</td>
                                            <td><asp:DropDownList ID="ddown019" runat="server" Width="281px" AutoPostBack="True" OnSelectedIndexChanged="ddown014_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar </asp:ListItem>
                                            </asp:DropDownList></td>
                                        </tr>
                                        <tr bgcolor="#eeeeee">
                                            <td style="height: 22px; width: 77px;" class="texto_form">
                                                <span>&nbsp;Prioridad</span></td>
                                            <td style="height: 22px; width: 142px;">
                                                <span class="texto_rojo_peque"><asp:TextBox ID="txt006" RUNAT="server" WIDTH="40px" /><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender140" runat="server" FilterType="Numbers" TargetControlID="txt006"/><asp:RangeValidator ID="RangeValidator140" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txt006" Type="Integer" MaximumValue="999999999" MinimumValue="0"/>
                                                </span>
                                            </td>
                                            <td style="height: 22px; width: 108px;" class="texto_form">
                                                Entidad que 
                                                <br />
                                                Asigna</td>
                                            <td style="height: 22px">
                                                <span class="texto_rojo_peque"><asp:DropDownList ID="ddown020" runat="server" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="ddown014_SelectedIndexChanged" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                    <asp:ListItem Value="1">ESTABLECIMIENTO</asp:ListItem>
                                                    <asp:ListItem Value="2">POLICIA</asp:ListItem>
                                                    <asp:ListItem Value="3">TRIBUNAL</asp:ListItem>
                                                </asp:DropDownList></span></td>
                                        </tr>
                                        <tr bgcolor="#eeeeee">
                                            <td style="height: 22px; width: 77px;">
                                            </td>
                                            <td style="width: 142px; height: 22px">
                                            </td>
                                            <td style="width: 108px; height: 22px; text-align: center">
                                                <asp:Button ID="btn002" runat="server" Text="AGREGAR" OnClick="btn002_Click" CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul"/></td>
                                            <td style="height: 22px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="middle" class="titulo_form" valign="top">
                        Detalle de Lesiones al Ingreso</td>
                </tr>
                <tr>
                    <td bgcolor="#e0f1fe" valign="top">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr valign="top">
                                <td class="texto_form" style="width: 30%; height: 22px">
                                    Presenta Lesiones</td>
                                <td bgcolor="#ffffff" width="70%" style="height: 22px">
                                    <span><asp:RadioButton ID="rdo004" runat="server" AutoPostBack="True" GroupName="rdolesiones"
                                            OnCheckedChanged="rdo004_CheckedChanged" Text="SI" />
                                        <asp:RadioButton ID="rdo005" runat="server" AutoPostBack="True" GroupName="rdolesiones"
                                            OnCheckedChanged="rdo005_CheckedChanged" Text="NO" /></span></td>
                            </tr>
                            <tr valign="top">
                                <td bgcolor="#ffffff" colspan="2"><asp:Panel ID="pnl002" runat="server" Visible="False" Width="100%">
                                    <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                        <tr bgcolor="#eeeeee">
                                            <td bgcolor="#eeeeee" colspan="4" style="height: 22px">
                                                <asp:GridView ID="grd003" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd003_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="TipoLesiones" Visible="False" />
                                                        <asp:BoundField DataField="CodQuienOcasionaLesion" HeaderText="CodQuienOcasionaLesion"
                                                            Visible="False" />
                                                        <asp:BoundField DataField="descripciontipo" HeaderText="Tipo de Lesion" />
                                                        <asp:BoundField HeaderText="Lesion" DataField="descripcion" />
                                                        <asp:BoundField HeaderText="Observaciones" DataField="observaciones" />
                                                        <asp:ButtonField Text="Quitar" />
                                                    </Columns>
                                                    <RowStyle BackColor="White" BorderColor="SteelBlue" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#eeeeee">
                                            <td bgcolor="#eeeeee" style="height: 22px; width: 117px;" class="texto_form">
                                                Tipo de Lesion</td>
                                            <td style="height: 22px">
                                                <asp:DropDownList ID="ddown021" runat="server" Width="280px" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td class="texto_form" rowspan="2">
                                                Observaciones</td>
                                            <td rowspan="2">
                                                <span class="texto_rojo_peque">&nbsp;<asp:TextBox ID="txt007" runat="server" Height="55px"
                                                    TextMode="MultiLine" Width="284px"></asp:TextBox></span></td>
                                        </tr>
                                        <tr bgcolor="#eeeeee">
                                            <td style="height: 22px; width: 117px;" class="texto_form">
                                                <span><span style="background-color: #066cb7">Quien ocaciono<br />
                                                </span><span style="background-color: #066cb7">la Lesión</span></span></td>
                                            <td style="height: 22px">
                                                <span class="texto_rojo_peque">
                                                    <asp:DropDownList ID="ddown022" runat="server" Width="280px" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="0">Seleccionar </asp:ListItem>
                                                    </asp:DropDownList></span></td>
                                        </tr>
                                        <tr bgcolor="#eeeeee">
                                            <td style="height: 22px; width: 117px;">
                                            </td>
                                            <td style="height: 22px" valign="middle">
                                                &nbsp;</td>
                                            <td style="height: 22px; text-align: center;">
                                                <asp:Button ID="btn003" runat="server" Text="AGREGAR" OnClick="btn003_Click" CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" /></td>
                                            <td style="height: 22px">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <table align="center" border="0" cellpadding="0" cellspacing="3" width="50%">
                <tr align="middle">
                    <td>
                        </td>
                    <td>
                        </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top">
            &nbsp;</td>
    </tr>
</table>
            </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div style="position: absolute; top: 40%; left: 45%; right: 0; bottom: 0;">
                    <img alt="Cargando" height="70" src="../images/Cursors/ajax-loader.gif" width="70" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>