﻿using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacoesController : Controller
    {
        private readonly IObservacoesRepositorio _observacoesRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
        {
            _observacoesRepositorio = observacoesRepositorio;
        }

        [HttpGet("GetAllObservacao")]
        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacao()
        {
            List<ObservacoesModel> observacoes = await _observacoesRepositorio.GetAll();
            return Ok(observacoes);
        }

        [HttpGet("GetObservacaoId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetObservacaoId(int id)
        {
            ObservacoesModel observacao = await _observacoesRepositorio.GetById(id);
            return Ok(observacao);
        }

        [HttpPost("CreateObservacao")]
        public async Task<ActionResult<ObservacoesModel>> InsertObservacao([FromBody] ObservacoesModel observacaoModel)
        {
            ObservacoesModel observacao = await _observacoesRepositorio.InsertObservacao(observacaoModel);
            return Ok(observacao);
        }

        [HttpPut("UpdateObservacao/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> UpdateObservacao(int id, [FromBody] ObservacoesModel observacaoModel)
        {
            observacaoModel.ObservacaoId = id;
            ObservacoesModel observacao = await _observacoesRepositorio.UpdateObservacao(observacaoModel, id);
            return Ok(observacao);
        }

        [HttpDelete("DeleteObservacao/{id:int}")]
        public async Task<ActionResult<UsuariosModel>> DeleteObservacao(int id)
        {
            bool deleted = await _observacoesRepositorio.DeleteObservacao(id);
            return Ok(deleted);
        }
    }
}
