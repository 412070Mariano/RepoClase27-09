using TurnoApi.Models;

namespace TurnoApi.Services
{
    public interface ITurnoService
    {
        Task<List<TTurno>> GetAll();
        Task<bool> Save(TTurno turno);
        Task<bool> Update(TTurno turno , int id);
        Task<bool> Delete(int id,string motivo);


        Task<List<TTurno>> GetTurnosCancelados(int n);

        Task<bool> ValidarTurnos(string cliente, DateTime fecha);
    }
}
