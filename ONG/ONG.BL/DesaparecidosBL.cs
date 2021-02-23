using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class DesaparecidosBL
    {
        public List<Desaparecido> ObtenerDesaparecidos()
        {
            var desaparecido1 = new Desaparecido();
            desaparecido1.Id = 1;
            desaparecido1.Primer_Nombre = "Juan";
            desaparecido1.Segundo_Apellido = "Lopez";

            var desaparecido2 = new Desaparecido();
            desaparecido2.Id = 2;
            desaparecido2.Primer_Nombre = "Juan Lopez";
            desaparecido2.Segundo_Apellido = "Lopez";

            var desaparecido3 = new Desaparecido();
            desaparecido3.Id = 3;
            desaparecido3.Primer_Nombre = "Juan Lopez";
            desaparecido3.Segundo_Apellido = "Lopez";

            var listadeDesaparecidos = new List<Desaparecido>();
            listadeDesaparecidos.Add(desaparecido1);
            listadeDesaparecidos.Add(desaparecido2);
            listadeDesaparecidos.Add(desaparecido3);

            return listadeDesaparecidos;
        }
    }
}
