using Microsoft.EntityFrameworkCore;
using RegistroPrioridadesDoNet8.DAL;
using RegistroPrioridadesDoNet8.Models;
using System.Linq.Expressions;

namespace RegistroPrioridadesDoNet8.BLL
{
    public class PrioridadesBLL
    {
        private readonly Context _contexto;

        public PrioridadesBLL(Context contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int PrioridadId)
        {
            return _contexto.Prioridades.Any(p => p.PrioridadId == PrioridadId);
        }

        public bool Insertar(Prioridades Prioridades)
        {
            _contexto.Prioridades.Add(Prioridades);
            return _contexto.SaveChanges() > 0;
        }

        public bool Modificar(Prioridades Prioridades)
        {
            var p = _contexto.Prioridades.Find(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Guardar(Prioridades Prioridades)
        {
            if (!Existe(Prioridades.PrioridadId))
                return this.Insertar(Prioridades);
            else
                return this.Modificar(Prioridades);
        }
        public bool Eliminar(Prioridades Prioridades)
        {
            var p = _contexto.Prioridades.Find(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }

        public Prioridades? Buscar(int PrioridadId)
        {
            return _contexto.Prioridades
                    .AsNoTracking()
                    .SingleOrDefault(a => a.PrioridadId == PrioridadId);
        }
        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridades
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
