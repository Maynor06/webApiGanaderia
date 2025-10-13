using System;
using System.Collections.Generic;

namespace WebapiProyect.Models;

public partial class Usuario
{
    public long IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Rol { get; set; }

    public string? ContrasenaHash { get; set; }

    public string? PermisosJson { get; set; }
}
