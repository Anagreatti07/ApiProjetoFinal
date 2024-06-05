using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ObjetosRepositorio : IObjetosRepositorio
    {
        private readonly Contexto _dbContext;

        public ObjetosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ObjetosModel>> GetAll()
        {
            return await _dbContext.Objeto.ToListAsync();
        }

        public async Task<ObjetosModel> GetById(int id)
        {
            return await _dbContext.Objeto.FirstOrDefaultAsync(x => x.ObjetoId == id);
        }

        public async Task<ObjetosModel> InsertObjeto(ObjetosModel objeto)
        {
            await _dbContext.Objeto.AddAsync(objeto);
            await _dbContext.SaveChangesAsync();
            return objeto;
        }

        public async Task<ObjetosModel> UpdateObjeto(ObjetosModel objeto, int id)
        {
            ObjetosModel objetos = await GetById(id);
            if (objetos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                objetos.ObjetoNome = objeto.ObjetoNome;
                objetos.ObjetoCor = objeto.ObjetoCor;
                objetos.ObjetoObservacao = objeto.ObjetoObservacao;
                objetos.ObjetoLocalDesaparecimento = objeto.ObjetoLocalDesaparecimento;
                objetos.ObjetoFoto = objeto.ObjetoFoto;
                objetos.ObjetoDtDesaparecimento = objeto.ObjetoDtDesaparecimento;
                objetos.ObjetoDtEncontro = objeto.ObjetoDtEncontro;
                objetos.ObjetoStatus = objeto.ObjetoStatus;
                objetos.UsuarioId = objeto.UsuarioId;

                _dbContext.Objeto.Update(objetos);
                await _dbContext.SaveChangesAsync();
            }
            return objetos;

        }

        public async Task<bool> DeleteObjeto(int id)
        {
            ObjetosModel objetos = await GetById(id);
            if (objetos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Objeto.Remove(objetos);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
