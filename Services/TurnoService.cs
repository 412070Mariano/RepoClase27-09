using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TurnoApi.Models;
using TurnoApi.Repositorios;

namespace TurnoApi.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;
        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }
        public async Task<bool> Delete(int id,string motivo)
        {
            return await _turnoRepository.Delete(id,motivo);
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _turnoRepository.GetAll();
        }



        public async Task<bool> Save(TTurno turno)
        {
            return await _turnoRepository.Save(turno);
        }

        public async  Task<bool> Update(TTurno turno, int id)
        {
            return await _turnoRepository.Update(turno,id);
        }

        public async Task<bool> ValidarTurnos(string cliente, DateTime fecha)
        {
            var lst = await _turnoRepository.GetAll();
            //var existe = lst.Where(x => x.Cliente.Equals(cliente, StringComparison.CurrentCultureIgnoreCase) &&
            //x.Fecha.Equals(fecha)).FirstOrDefault();
            //return existe != null;

            var found = lst.FirstOrDefault(x=>x.Cliente.Equals(x.Cliente.Equals(cliente, StringComparison.CurrentCultureIgnoreCase) &&
            x.Fecha.Equals(fecha)));
            
            return found != null;
        }        
        public async Task<List<TTurno>> GetTurnosCancelados(int n)
        {
            return await _turnoRepository.FindCancel(n);
        }
    }
}
