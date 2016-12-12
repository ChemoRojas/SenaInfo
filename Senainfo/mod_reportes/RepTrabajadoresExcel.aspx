<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="RepTrabajadoresExcel.aspx.cs" Inherits="mod_reportes_RepTrabajadoresExcel" %>

<!DOCTYPE html>
<html lang="es">

<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Excel Trabajadores :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/jquery-2.1.4.js"></script>

    <script src="../js/bootstrap3.3.4.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>

</head>
<script language="JavaScript" type="text/javascript">	
    function revisarDigito( dvr )
{	
	dv = dvr + ""	
	if ( dv != '0' && dv != '1' && dv != '2' && dv != '3' && dv != '4' && dv != '5' && dv != '6' && dv != '7' && dv != '8' && dv != '9' && dv != 'k'  && dv != 'K')	
	{		
		alert("Debe ingresar un digito verificador valido");		
		//window.document.form1.rut.focus();		
		//window.document.form1.rut.select();		
		return false;	
	}	
	    return true;
}

function revisarDigito2( crut )
{	
	largo = crut.length;	
	if ( largo < 2 )	
	{		
		alert("Debe ingresar el rut completo")		
		//window.document.form1.rut.focus();		
		//window.document.form1.rut.select();		
		return false;	
	}	
	if ( largo > 2 )		
		rut = crut.substring(0, largo - 1);	
	else		
		rut = crut.charAt(0);	
	dv = crut.charAt(largo-1);	
	revisarDigito( dv );	

	if ( rut == null || dv == null )
		return 0	

	var dvr = '0'	
	suma = 0	
	mul  = 2	

	for (i= rut.length -1 ; i >= 0; i--)	
	{	
		suma = suma + rut.charAt(i) * mul		
		if (mul == 7)			
			mul = 2		
		else    			
			mul++	
	}	
	res = suma % 11	
	if (res==1)		
		dvr = 'k'	
	else if (res==0)		
		dvr = '0'	
	else	
	{		
		dvi = 11-res		
		dvr = dvi + ""	
	}
	if ( dvr != dv.toLowerCase() )	
	{		
		alert("EL rut es incorrecto")				
		return false	
	}

	return true
}

function Rut()
{	
	var tmpstr = "";
	var texto = document.getElementById("txt_newRut").value;
	for ( i=0; i < texto.length ; i++ )		
		if ( texto.charAt(i) != ' ' && texto.charAt(i) != '.' && texto.charAt(i) != '-' )
			tmpstr = tmpstr + texto.charAt(i);	
	texto = tmpstr;	
	largo = texto.length;	

	if ( largo < 2 )	
	{		
		alert("Debe ingresar el rut completo")			
		return false;	
	}	

	for (i=0; i < largo ; i++ )	
	{			
		if ( texto.charAt(i) !="0" && texto.charAt(i) != "1" && texto.charAt(i) !="2" && texto.charAt(i) != "3" && texto.charAt(i) != "4" && texto.charAt(i) !="5" && texto.charAt(i) != "6" && texto.charAt(i) != "7" && texto.charAt(i) !="8" && texto.charAt(i) != "9" && texto.charAt(i) !="k" && texto.charAt(i) != "K" )
 		{			
			alert("El valor ingresado no corresponde a un R.U.T valido");		
			return false;		
		}	
	}	

	var invertido = "";	
	for ( i=(largo-1),j=0; i>=0; i--,j++ )		
		invertido = invertido + texto.charAt(i);	
	var dtexto = "";	
	dtexto = dtexto + invertido.charAt(0);	
	dtexto = dtexto + '-';	
	cnt = 0;	

	for ( i=1,j=2; i<largo; i++,j++ )	
	{			
		if ( cnt == 3 )		
		{			
			dtexto = dtexto + '.';			
			j++;			
			dtexto = dtexto + invertido.charAt(i);			
			cnt = 1;		
		}		
		else		
		{				
			dtexto = dtexto + invertido.charAt(i);			
			cnt++;		
		}	
	}	

	invertido = "";	
	for ( i=(dtexto.length-1),j=0; i>=0; i--,j++ )		
		invertido = invertido + dtexto.charAt(i);	

	//window.document.form1.rut.value = invertido.toUpperCase()		
    document.getElementById("txt_newRut").value = invertido;
	if ( revisarDigito2(texto) )			
		return true;	

	return false;	
} 
function Validate() 
{    
    if (confirm("¿Esta seguro que quiere caducar a este trabajador?") == true) 
    {    
        document.getElementById('btn_invisibleEvent').click();
        return true;   
    } 
    else 
    {
        return false;
    }
    
}
</script>
<body class="body-form">
    <form id="form1" runat="server">
    <div class="container" style="margin-left:10px">
        <div class="row">

        <asp:Panel ID="Panel_DataGrid" runat="server">
    
    
       
                <h4 class="subtitulo-form">
                    Reporte Trabajadores</h4>
           
                    <asp:GridView ID="grd001" runat="server" CssClass="table table-bordered table-hover"  AutoGenerateColumns="False" OnRowCommand="grd001_RowCommand">
                        <Columns>
                        <%--    <asp:BoundField DataField="ICodTrabajadoresInhabilidades" HeaderText="ICodTrabajadoresInhabilidades">
                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="40px" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="Region" HeaderText="Region">
                            </asp:BoundField>
                            <asp:BoundField DataField="Nemotecnico" HeaderText="Nemotecnico">
                            </asp:BoundField>
                            <asp:BoundField DataField="CodInstitucion" HeaderText="CodInstitucion">
                            </asp:BoundField>
                            <asp:BoundField DataField="Institucion" HeaderText="Institucion" />
                            <asp:BoundField DataField="CodProyecto" HeaderText="CodProyecto">
                            </asp:BoundField>
                            <asp:BoundField DataField="Proyecto" HeaderText="Proyecto">
                            </asp:BoundField>
                            <asp:BoundField DataField="RUT" HeaderText="RUT">
                            </asp:BoundField>
                            <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno">
                            </asp:BoundField>
                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno">
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                            </asp:BoundField>
                            <asp:BoundField DataField="Profesion" HeaderText="Profesion">
                            </asp:BoundField>
                            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                            <asp:BoundField DataField="OtraProfesionOficio" HeaderText="Otra Profesion Oficio">
                            </asp:BoundField>
                         <%--   <asp:BoundField DataField="IndVigencia" HeaderText="Vigencia" />--%>
                            <asp:ButtonField Text="Modificar" CommandName="Modificar" HeaderText="Modificar" />
                            <asp:ButtonField CommandName="Caducar" Text="Caducar" HeaderText="Caducar" />
                        </Columns>
                        <HeaderStyle CssClass="table-borderless titulo-tabla"  />
                        <RowStyle CssClass="table-bordered caja-tabla" />
                    </asp:GridView>
                
                <div class="botonera" >
                    <asp:LinkButton ID="imgbtn_Excel" runat="server" CssClass="btn btn-sm btn-success fixed-width-button" Text="Excel" OnClick="imgbtn_Excel_Click" >
                        <span class="glyphicon glyphicon-floppy-save"></span>&nbsp Exportar
                    </asp:LinkButton>
                    <asp:LinkButton ID="imgbtn_Cerrar" runat="server" CssClass="btn btn-sm btn-info fixed-width-button" Text="Cerrar" OnClick="imgbtn_Cerrar_Click"  >
                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp Cerrar
                    </asp:LinkButton>
                </div>
            </asp:Panel>
    
        <asp:Panel ID="Panel_Nuevo" runat="server" Visible="False">
                                    <asp:Label ID="Label1" runat="server" Text="Ingrese rut del nuevo trabajador"></asp:Label>
<table class="table table-bordered table-condensed" >
                
                <tr>
                    <th class="titulo-tabla" >
            <asp:Label ID="lbl_Rut" runat="server" Text="Rut"></asp:Label></th>
                    <td >
                        <asp:TextBox ID="txt_newRut" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt_newRut" ValidationGroup="agregar" runat="server" ErrorMessage="Rut Inv&aacute;lido" CssClass="help-block" Display="Dynamic" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
                    <div class="pull-right">
                        <asp:LinkButton ID="imgbtn_addNew" runat="server" CssClass="btn btn-sm btn-info fixed-width-button" Text="Agregar" OnClick="imgbtn_addNew_Click" OnClientClick="return Rut()" ValidationGroup="agregar" >     
                           <span class="glyphicon glyphicon-plus"></span>&nbsp; Agregar
</asp:LinkButton>
                        
                    </div>
                
        </asp:Panel>
        <asp:Panel ID="Panel_Cambios" runat="server"  >
             <h4 class="subtitulo-form"><asp:Label ID="lbl_text1" runat="server" Text="Id Usuario:"></asp:Label>
            <asp:Label ID="lbl_CodEncuesta" runat="server" Text="Label"></asp:Label></h4>

            <table class="table table-bordered table-condensed" >
               
                <tr>
                    <th class="titulo-tabla col-md-1" >
            <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label></th>
                    <td class="col-md-4">
            <asp:TextBox ID="txt_name" CssClass="form-control input-sm" runat="server"></asp:TextBox></td>
                    <th class="titulo-tabla col-md-1">
            <asp:Label ID="Label4" runat="server" Text="Apellido Paterno"></asp:Label></th>
                    <td >
                        <asp:TextBox ID="txt_ApellidoP" CssClass="form-control input-sm" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <th class="titulo-tabla">
            <asp:Label ID="Label5" runat="server" Text="Apellido Materno"></asp:Label></th>
                    <td>
            <asp:TextBox ID="txt_ApellidoM" CssClass="form-control input-sm" runat="server"></asp:TextBox></td>
                    <th class="titulo-tabla">
            <asp:Label ID="Label6" runat="server" Text="Rut"></asp:Label></th>
                    <td >
            <asp:TextBox ID="txt_rut" CssClass="form-control input-sm" runat="server"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_rut" runat="server" ValidationGroup="agregar2" ErrorMessage="Rut Inv&aacute;lido" CssClass="help-block" Display="Dynamic" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)"></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <th class="titulo-tabla" >
            <asp:Label ID="Label7" runat="server" Text="Profesion"></asp:Label></th>
                    <td >
                        <asp:DropDownList CssClass="form-control input-sm" ID="ddl_profesion" runat="server" AutoPostBack="True">
                        </asp:DropDownList></td>
                    <th class="titulo-tabla" >
            <asp:Label ID="Label8" runat="server" Text="Cargo"></asp:Label></th>
                    <td >
                        <asp:DropDownList  CssClass="form-control input-sm" ID="ddl_cargo" runat="server" AutoPostBack="True">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th class="titulo-tabla" >
                        <asp:Label ID="Label9" runat="server" Text="OtraProfesionOficio"></asp:Label></th>
                    <td colspan="3">
                        <asp:TextBox ID="txt_OtraProfesion" CssClass="form-control input-sm" runat="server"></asp:TextBox></td>
                </tr></table>
                <div class="pull-right">
                       
                        <asp:LinkButton ID="btn_Add" runat="server" CssClass="btn btn-sm btn-info fixed-width-button" Text="" Visible="False" OnClick="btn_Add_Click" ValidationGroup="agregar2" >
                                                    <span class="glyphicon glyphicon-plus"></span>&nbsp; Agregar

                        </asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="btn_close" runat="server" Text="" CssClass="btn btn-sm btn-info fixed-width-button" Visible="False" OnClick="btn_close_Click"  >
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar
                        </asp:LinkButton>
                        
                        <asp:LinkButton ID="imgbtn_guardar" runat="server" Text="" CssClass="btn btn-sm btn-danger fixed-width-button" OnClick="imgbtn_guardar_Click" ValidationGroup="agregar2" >
                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                        </asp:LinkButton>
                        
                        <asp:LinkButton ID="imgbtn_volver" runat="server" Text="" CssClass="btn btn-sm btn-info fixed-width-button" OnClick="imgbtn_volver_Click" >
                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Volver
                        </asp:LinkButton>

                </div>
        </asp:Panel>
        <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="btn_invisibleEvent" runat="server" Height="0px" OnClick="btn_invisibleEvent_Click" Text="btn_invisibleEvent" Width="0px" Visible="false" />
                </div>

            </div>
        </div>
            
    </form>
</body>
</html>
