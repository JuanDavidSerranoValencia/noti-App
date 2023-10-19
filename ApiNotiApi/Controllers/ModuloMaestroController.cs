using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotiApi.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotiApi.Controllers
{
    public class ModuloMaestroController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModuloMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ModuloMaestroDto>>> Get()
        {
            var moduloMaestro = await _unitOfWork.ModuloMaestros.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<ModuloMaestroDto>>(moduloMaestro);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloMaestro>> Post(ModuloMaestroDto moduloMaestroDto)
        {
            var moduloMaestro = _mapper.Map<ModuloMaestro>(moduloMaestroDto);
            this._unitOfWork.ModuloMaestros.Add(moduloMaestro);
            await _unitOfWork.SaveAsync();
            if (moduloMaestro == null)
            {
                return BadRequest();
            }
            moduloMaestroDto.Id = moduloMaestro.Id;
            return CreatedAtAction(nameof(Post), new { id = moduloMaestroDto.Id }, moduloMaestroDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuloMaestroDto>> Get(int id)
        {
            var moduloMaestro = await _unitOfWork.ModuloMaestros.GetByIdAsync(id);
            if (moduloMaestro == null)
            {
                return NotFound();
            }
            return _mapper.Map<ModuloMaestroDto>(moduloMaestro);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloMaestroDto>> Put(int id, [FromBody] ModuloMaestroDto moduloMaestroDto)
        {
            if (moduloMaestroDto == null)
                return NotFound();
            var moduloMaestro = _mapper.Map<ModuloMaestro>(moduloMaestroDto);
            _unitOfWork.ModuloMaestros.Update(moduloMaestro);
            await _unitOfWork.SaveAsync();
            return moduloMaestroDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var moduloMaestro = await _unitOfWork.ModuloMaestros.GetByIdAsync(id);
            if (moduloMaestro == null)
            {
                return NotFound();
            }
            _unitOfWork.ModuloMaestros.Remove(moduloMaestro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}