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
    public class TipoRequerimientoController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoRequerimientoController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoRequerimientoDto>>> Get()
        {
            var tipoRequerimiento = await _unitOfWork.TipoRequerimientos.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<TipoRequerimientoDto>>(tipoRequerimiento);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoRequerimiento>> Post(TipoRequerimientoDto tipoRequerimientoDto)
        {
            var tipoRequerimiento = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
            this._unitOfWork.TipoRequerimientos.Add(tipoRequerimiento);
            await _unitOfWork.SaveAsync();
            if (tipoRequerimiento == null)
            {
                return BadRequest();
            }
            tipoRequerimientoDto.Id = tipoRequerimiento.Id;
            return CreatedAtAction(nameof(Post), new { id = tipoRequerimientoDto.Id }, tipoRequerimientoDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoRequerimientoDto>> Get(int id)
        {
            var tipoRequerimiento = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);
            if (tipoRequerimiento == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoRequerimientoDto>(tipoRequerimiento);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoRequerimientoDto>> Put(int id, [FromBody] TipoRequerimientoDto tipoRequerimientoDto)
        {
            if (tipoRequerimientoDto == null)
                return NotFound();
            var tipoRequerimiento = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
            _unitOfWork.TipoRequerimientos.Update(tipoRequerimiento);
            await _unitOfWork.SaveAsync();
            return tipoRequerimientoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoRequerimiento = await _unitOfWork.TipoRequerimientos.GetByIdAsync(id);
            if (tipoRequerimiento == null)
            {
                return NotFound();
            }
            _unitOfWork.TipoRequerimientos.Remove(tipoRequerimiento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
