<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_seleccionIcodie.ascx.cs" Inherits="SenainfoSdk.UI.C_seleccionIcodie" %>
<%@ Register Src="I_Institucion.ascx" TagPrefix="uc1" TagName="I_Institucion" %>
<%@ Register Src="I_Proyecto.ascx" TagPrefix="uc1" TagName="I_Proyecto" %>
<%@ Register Src="I_ICodIE.ascx" TagPrefix="uc1" TagName="I_ICodIE" %>


<% if (this.UsarTabla) { %>
<div class="row">
    <div class="col-md-12">
        <table class="table table-bordered table-condensed">
<% } %>
            <tr>
                <th class="titulo-tabla col-md-1">Institución *</th>
                <td>
                    <uc1:I_Institucion runat="server" id="I_Institucion" UsarAllInOne="True" />
                </td>
            </tr>
            <tr>
                <th class="titulo-tabla col-md-1">Proyecto *</th>
                <td>
                    <uc1:I_Proyecto runat="server" id="I_Proyecto" UsarAllInOne="True" InstitucionControlID="I_Institucion" />
                </td>
            </tr>
            <tr>
                <th class="titulo-tabla col-md-1">IcodIE o Nombre del Niño *</th>
                <td>
                    <uc1:I_ICodIE runat="server" id="I_ICodIE" UsarAllInOne="False" ProyectoControlID="I_Proyecto" OnICodIECambio="I_ICodIE_ICodIECambio" />
                </td>
            </tr>
<% if (this.UsarTabla) { %>
        </table>
    </div>
</div>
<% } %>

