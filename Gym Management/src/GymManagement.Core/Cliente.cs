using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymManagement.Core;

public class Cliente
{
    public int Id_Usuario { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener exactamente 10 dígitos (solo números)")]
    public string Telefono { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }

    public ICollection<PagoMembresia> PagosMembresias { get; set; } = new List<PagoMembresia>();
}
