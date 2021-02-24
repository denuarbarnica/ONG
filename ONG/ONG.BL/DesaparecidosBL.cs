using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONG.BL
{
    public class DesaparecidosBL
    {
        Contexto _contexto;
        public List<Desaparecido> ListadeDesaparecidos { get; set; }

        public DesaparecidosBL()
        {
            _contexto = new Contexto();
            ListadeDesaparecidos = new List<Desaparecido>();

        }

        public List<Desaparecido> ObtenerDesaparecidos()
        {
            ListadeDesaparecidos = _contexto.Desaparecidos.ToList();

            return ListadeDesaparecidos;
        }
    }
}
