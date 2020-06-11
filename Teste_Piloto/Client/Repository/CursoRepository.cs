using Faculdade_FUP_Project.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Piloto.Client.Helpers;

namespace Teste_Piloto.Client.Repository
{
    public class CursoRepository : IRepositoryCursos
    {
        private readonly IHttpService httpService;
        private string url = "api/genres";

        public CursoRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Curso>> GetCursos()
        {
            var response = await httpService.Get<List<Curso>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task<Curso> GetCurso(int Id)
        {
            var response = await httpService.Get<Curso>($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task CreateCurso(Curso curso)
        {
            var response = await httpService.Post(url, curso);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdateCurso(Curso curso)
        {
            var response = await httpService.Put(url, curso);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteCurso(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
