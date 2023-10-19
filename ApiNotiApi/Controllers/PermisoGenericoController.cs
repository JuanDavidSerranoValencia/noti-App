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
    public class PermisoGenericoController:BaseControllerApi
    {
          private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermisoGenericoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PermisoGenericoDto>>> Get()
        {
            var permisoGen = await _unitOfWork.PermisoGenericos.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<PermisoGenericoDto>>(permisoGen);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PermisoGenerico>> Post(PermisoGenericoDto permisoGenericoDto)
        {
            var permisoGen = _mapper.Map<PermisoGenerico>(permisoGenericoDto);
            this._unitOfWork.PermisoGenericos.Add(permisoGen);
            await _unitOfWork.SaveAsync();
            if (permisoGen == null)
            {
                return BadRequest();
            }
            permisoGenericoDto.Id = permisoGen.Id;
            return CreatedAtAction(nameof(Post), new { id = permisoGenericoDto.Id }, permisoGenericoDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermisoGenericoDto>> Get(int id)
        {
            var permisoGen = await _unitOfWork.PermisoGenericos.GetByIdAsync(id);
            if (permisoGen == null)
            {
                return NotFound();
            }
            return _mapper.Map<PermisoGenericoDto>(permisoGen);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PermisoGenericoDto>> Put(int id, [FromBody] PermisoGenericoDto permisoGenericoDto)
        {
            if (permisoGenericoDto == null)
                return NotFound();
            var permisoGen = _mapper.Map<PermisoGenerico>(permisoGenericoDto);
            _unitOfWork.PermisoGenericos.Update(permisoGen);
            await _unitOfWork.SaveAsync();
            return permisoGenericoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var permisoGen = await _unitOfWork.PermisoGenericos.GetByIdAsync(id);
            if (permisoGen == null)
            {
                return NotFound();
            }
            _unitOfWork.PermisoGenericos.Remove(permisoGen);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}