using TurnoApi.Models;

namespace TurnoApi.Repositorios
{
    public interface ITurnoRepository
    {
        Task<List<TTurno>> GetAll();
        Task<bool> Save(TTurno turno);
        Task<bool> Update(TTurno turno, int id);
        Task<bool> Delete(int id,string motivo);

        //Task<TTurno> FindByClientDate(int id);
        Task<List<TTurno>> FindCancel(int n);
    }
}
