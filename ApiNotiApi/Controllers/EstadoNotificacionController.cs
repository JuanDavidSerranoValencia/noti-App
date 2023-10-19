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
    public class EstadoNotificacionController:BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoNotificacionDto>>> Get()
        {
            var estadoNoti = await _unitOfWork.EstadoNotificaciones.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<EstadoNotificacionDto>>(estadoNoti);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoNotificacion>> Post(EstadoNotificacionDto estadoNotificacionDto)
        {
            var estadoNoti= _mapper.Map<EstadoNotificacion>(estadoNotificacionDto);
            this._unitOfWork.EstadoNotificaciones.Add(estadoNoti);
            await _unitOfWork.SaveAsync();
            if (estadoNoti == null)
            {
                return BadRequest();
            }
           estadoNotificacionDto.Id = estadoNoti.Id;
            return CreatedAtAction(nameof(Post), new { id = estadoNotificacionDto.Id }, estadoNotificacionDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoNotificacionDto>> Get(int id)
        {
            var estadoNoti = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);
            if (estadoNoti == null)
            {
                return NotFound();
            }
            return _mapper.Map<EstadoNotificacionDto>(estadoNoti);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoNotificacionDto>> Put(int id, [FromBody] EstadoNotificacionDto estadoNotificacionDto)
        {
            if (estadoNotificacionDto == null)
                return NotFound();
            var estadoNotificacion = _mapper.Map<EstadoNotificacion>(estadoNotificacionDto);
            _unitOfWork.EstadoNotificaciones.Update(estadoNotificacion);
            await _unitOfWork.SaveAsync();
            return estadoNotificacionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var estadoNotificacion = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);
            if (estadoNotificacion == null)
            {
                return NotFound();
            }
            _unitOfWork.EstadoNotificaciones.Remove(estadoNotificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}