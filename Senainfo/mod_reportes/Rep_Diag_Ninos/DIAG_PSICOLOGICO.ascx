<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Excel1.bmp"
    OnClick="ImageButton1_Click" /><br />
<br />
<asp:GridView id="grd001" runat="server" AutoGenerateColumns="False" CellPadding="2" GridLines="None" AllowPaging="True" PageSize="20" ForeColor="#333333" Width="100%" OnPageIndexChanging="grd001_PageIndexChanging">
                  <Columns>
                      <asp:BoundField DataField="CodNino" HeaderText="Cod. Ni&#241;o" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="ICodIE" HeaderText="Icodie" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="Apellido_Paterno" HeaderText="Ap. Paterno" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="Apellido_Materno" HeaderText="Ap. Materno" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="NombresNino" HeaderText="Nombres" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="Rut" HeaderText="Rut" >
                          <ItemStyle Font-Size="11px" Width="60px" Wrap="True"  />
                          <HeaderStyle Wrap="False"  />
                          <FooterStyle Wrap="False"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="Sexo" HeaderText="Sexo" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="FechaNacimiento" HeaderText="F. Nacim." DataFormatString="{0:d}" HtmlEncode="False" >
                          <ItemStyle Font-Size="11px" Width="60px" Wrap="True"  />
                          <HeaderStyle Wrap="True"  />
                          <FooterStyle Wrap="True"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="FechaIngreso" HeaderText="F. Ingreso" DataFormatString="{0:d}" >
                          <ItemStyle Font-Size="11px" HorizontalAlign="Center"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="FechaEgreso" HeaderText="F. Egreso" DataFormatString="{0:d}" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="ICodPsicologico" HeaderText="Cod. Psicologico" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="CodDiagnostico" HeaderText="Cod. Diagnostico" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="FechaDiagnostico" HeaderText="F. Diagnostico" />
                      <asp:BoundField DataField="InstrumentosDiagnostico" HeaderText="Instrumentos Diagnostico" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="MedicionesDiagnosticas" HeaderText="Mediciones Diagnosticas" />
                      <asp:BoundField DataField="Tecnico" HeaderText="Tecnico" HtmlEncode="False" >
                          <ItemStyle Font-Size="11px" Width="60px"  />
                      </asp:BoundField>
                      <asp:BoundField DataField="FechaActualizacion" HeaderText="F. Actualizacion" DataFormatString="{0:d}" >
                          <ItemStyle Font-Size="11px"  />
                      </asp:BoundField>
                  </Columns>
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left"  />
                        <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px"  />
                        <EditRowStyle BackColor="#2461BF" Font-Size="11px"  />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Arial" Font-Size="11px"  />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"  />
                        <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px"  />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
              </asp:GridView><%@ Control Language="C#" AutoEventWireup="true" CodeFile="DIAG_PSICOLOGICO.ascx.cs" Inherits="mod_reportes_Rep_Diag_Ninos_DIAG_PSICOLOGICO" %>
