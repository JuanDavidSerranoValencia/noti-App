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
    public class ModuloNotificacionController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModuloNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ModuloNotificacionDto>>> Get()
        {
            var moduloNoti = await _unitOfWork.ModuloNotificaciones.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<ModuloNotificacionDto>>(moduloNoti);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloNotificacion>> Post(ModuloNotificacionDto moduloNotificacionDto)
        {
            var moduloNoti = _mapper.Map<ModuloNotificacion>(moduloNotificacionDto);
            this._unitOfWork.ModuloNotificaciones.Add(moduloNoti);
            await _unitOfWork.SaveAsync();
            if (moduloNoti == null)
            {
                return BadRequest();
            }
            moduloNotificacionDto.Id = moduloNoti.Id;
            return CreatedAtAction(nameof(Post), new { id = moduloNotificacionDto.Id }, moduloNotificacionDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuloNotificacionDto>> Get(int id)
        {
            var moduloNoti = await _unitOfWork.ModuloNotificaciones.GetByIdAsync(id);
            if (moduloNoti == null)
            {
                return NotFound();
            }
            return _mapper.Map<ModuloNotificacionDto>(moduloNoti);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloNotificacionDto>> Put(int id, [FromBody] ModuloNotificacionDto moduloNotificacionDto)
        {
            if (moduloNotificacionDto == null)
                return NotFound();
            var moduloNoti = _mapper.Map<ModuloNotificacion>(moduloNotificacionDto);
            _unitOfWork.ModuloNotificaciones.Update(moduloNoti);
            await _unitOfWork.SaveAsync();
            return moduloNotificacionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var moduloNoti = await _unitOfWork.ModuloNotificaciones.GetByIdAsync(id);
            if (moduloNoti == null)
            {
                return NotFound();
            }
            _unitOfWork.ModuloNotificaciones.Remove(moduloNoti);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}