using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBaseBE.Models;
[Table("fiestas")]
public class Fiestas
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Column("nombre")]

    public string Nombre { get; set; }
    [Column("invitados")]

    public decimal Invitados { get; set; }
    [Column("comida")]

    public string Comida { get; set; }
    [Column("decoracion")]

    public string Decoracion { get; set; }
    [Column("fecha")]

    public DateTime Fecha { get; set; } 
}