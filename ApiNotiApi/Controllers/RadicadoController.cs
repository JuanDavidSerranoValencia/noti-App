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
    public class RadicadoController:BaseControllerApi
    {
          private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RadicadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RadicadoDto>>> Get()
        {
            var radicado = await _unitOfWork.Radicados.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<RadicadoDto>>(radicado);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Radicado>> Post(RadicadoDto radicadoDto)
        {
            var radicado = _mapper.Map<Radicado>(radicadoDto);
            this._unitOfWork.Radicados.Add(radicado);
            await _unitOfWork.SaveAsync();
            if (radicado == null)
            {
                return BadRequest();
            }
            radicadoDto.Id = radicado.Id;
            return CreatedAtAction(nameof(Post), new { id = radicadoDto.Id }, radicadoDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RadicadoDto>> Get(int id)
        {
            var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);
            if (radicado == null)
            {
                return NotFound();
            }
            return _mapper.Map<RadicadoDto>(radicado);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RadicadoDto>> Put(int id, [FromBody] RadicadoDto radicadoDto)
        {
            if (radicadoDto == null)
                return NotFound();
            var radicado = _mapper.Map<Radicado>(radicadoDto);
            _unitOfWork.Radicados.Update(radicado);
            await _unitOfWork.SaveAsync();
            return radicadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);
            if (radicado == null)
            {
                return NotFound();
            }
            _unitOfWork.Radicados.Remove(radicado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}