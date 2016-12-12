<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_modalPopUp.ascx.cs" Inherits="SenainfoSdk.UI.C_modalPopUp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="C_msgAlerta.ascx" TagPrefix="uc1" TagName="C_msgAlerta" %>

<asp:Button ID="btn_ejecutar" runat="server" Text="" Style="Display: none" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server" Style="Display: none">
            <div class="popupConfirmation">
                <div class="modal-header header-modal" scrollbars="None">
                    <h4 ID="tituloPopup" runat="server" class="modal-title" />
                </div>
                <uc1:C_msgAlerta runat="server" ID="C_msgAlerta" />
                <div class="botonera pull-right">
                    <asp:LinkButton ID="link_tres" runat="server" OnClick="btn_tres_Click">
                        <span id="link_tres_icon" runat="server"></span>&nbsp;<span id="link_tres_text" runat="server"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="link_dos" runat="server" OnClick="btn_dos_Click">
                        <span id="link_dos_icon" runat="server"></span>&nbsp;<span id="link_dos_text" runat="server"></span>
                    </asp:LinkButton>
                    <asp:LinkButton ID="link_uno" runat="server" OnClick="btn_uno_Click">
                        <span id="link_uno_icon" runat="server"></span>&nbsp;<span id="link_uno_text" runat="server"></span>
                    </asp:LinkButton>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground"
    DropShadow="true"
    TargetControlID="btn_ejecutar">
</cc1:ModalPopupExtender>
