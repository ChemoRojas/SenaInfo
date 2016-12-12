using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de IAlertas
/// </summary>
public interface IAlertas
{
    bool ActualizarAlerta(Alerta alerta);
    int getTipoAlerta();
}