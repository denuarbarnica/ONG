using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class Desaparecidos
    {

        public  Desaparecidos()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="ICampo Obligatorio")]
        [MinLength(3, ErrorMessage ="Ingrese Maximo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string PNombre { get; set; }

        public string SNombre { get; set; }

        [Required(ErrorMessage = "ICampo Obligatorio")]
        [MinLength(3, ErrorMessage = "Ingrese Maximo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string PApellido { get; set; }

        public string SApellido { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [MinLength(3, ErrorMessage = "Ingrese Maximo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string Residencia { get; set; }

        [Required(ErrorMessage ="Ingrese la Edad")]
        [Range(1, 500, ErrorMessage ="Ingresa una edad Correcta")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [MinLength(3, ErrorMessage = "Ingrese Maximo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese Maximo 20 caracteres")]
        public string Genero { get; set; }

        public int CategoriaId { get; set; }
        public Categorias Categorias { get; set; }
        public bool Activo { get; set; }

    }
}
