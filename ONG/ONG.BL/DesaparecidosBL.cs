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

        public List<Desaparecidos> listaDesaparecidos { get; set; }

    public DesaparecidosBL()
        {
            _contexto = new Contexto();
            listaDesaparecidos = new List<Desaparecidos>();
        }
      
        public List<Desaparecidos> ObtenerDesaparecidos()
        {
            listaDesaparecidos = _contexto.Desaparecido
                .Include("Categorias")
                .ToList();
          

            return listaDesaparecidos;
          }


        public void GuardarDesaparecido(Desaparecidos Desaparecidos)
        {
            if (Desaparecidos.Id == 0)
            { 
            _contexto.Desaparecido.Add(Desaparecidos);
          
            }else
            {
                var DesaparecidoExistente = _contexto.Desaparecido.Find(Desaparecidos.Id);
                DesaparecidoExistente.PNombre = Desaparecidos.PNombre;
                DesaparecidoExistente.SNombre = Desaparecidos.SNombre;
                DesaparecidoExistente.PApellido = Desaparecidos.PApellido;
                DesaparecidoExistente.SApellido = Desaparecidos.SApellido;
                DesaparecidoExistente.Residencia = Desaparecidos.Residencia;
                DesaparecidoExistente.Edad = Desaparecidos.Edad;
                DesaparecidoExistente.Genero = Desaparecidos.Genero;
                DesaparecidoExistente.Activo = Desaparecidos.Activo;

            }

            _contexto.SaveChanges();
        }

        public Desaparecidos ObtenerDesaparecidos( int id)
        {
            var Desaparecido = _contexto.Desaparecido
                .Include("Categorias").FirstOrDefault(p => p.Id == id);

            return Desaparecido;
        }


        public void EliminarDesaparecido(int id)
        {
            var Desaparecido = _contexto.Desaparecido.Find(id);

            _contexto.Desaparecido.Remove(Desaparecido);
            _contexto.SaveChanges();
        }
    }
}
