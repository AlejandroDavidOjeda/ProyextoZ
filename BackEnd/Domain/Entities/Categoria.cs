using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Categoria
    {
        public Categoria(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Descripcion { get; set; }
    }
}
