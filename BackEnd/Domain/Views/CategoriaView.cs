using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views
{
    public class CategoriaView
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public CategoriaView(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
