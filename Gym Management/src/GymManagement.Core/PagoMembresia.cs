using System;
using System.ComponentModel.DataAnnotations;

namespace GymManagement.Core;

public class PagoMembresia
{
    public int Id_Mensualidad { get; set; }
    public int Id_Usuario { get; set; }
    public string TipoMembresia { get; set; }

    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un número positivo")]
    public decimal Monto { get; set; }
    public DateTime FechaPago { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaVencimiento { get; set; }

    public Cliente Cliente { get; set; }
}
