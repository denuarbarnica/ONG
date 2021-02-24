using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class Desaparecido
    {
        public Desaparecido()
        {
            Activo = true;
        }

        public int Id { get; set; }
        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Residencia { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public bool Activo { get; set; }

    }
}
