using EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAssync();
        //incluirBatalha para evitar loop infinito (além do options do startup)
        Task<Heroi[]> GetAllHerois(bool incluirBatalha = false);
        Task<Heroi> GetHeroiById(int id, bool incluirBatalha = false);
        Task<Heroi[]> GetHeroisByNome(string nome, bool incluirBatalha = false);

        Task<Batalha[]> GetAllBatalhas(bool incluirHerois = false);
        Task<Batalha> GetBatalhaById(int id, bool incluirHerois = false);
    }
}
