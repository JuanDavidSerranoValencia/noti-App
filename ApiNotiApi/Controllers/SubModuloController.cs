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
    public class SubModuloController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubModuloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SubModuloDto>>> Get()
        {
            var subModulo = await _unitOfWork.SubModulos.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<SubModuloDto>>(subModulo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubModulo>> Post(SubModuloDto subModuloDto)
        {
            var subModulo = _mapper.Map<SubModulo>(subModuloDto);
            this._unitOfWork.SubModulos.Add(subModulo);
            await _unitOfWork.SaveAsync();
            if (subModulo == null)
            {
                return BadRequest();
            }
            subModuloDto.Id = subModulo.Id;
            return CreatedAtAction(nameof(Post), new { id = subModuloDto.Id }, subModuloDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubModuloDto>> Get(int id)
        {
            var subModulo = await _unitOfWork.SubModulos.GetByIdAsync(id);
            if (subModulo == null)
            {
                return NotFound();
            }
            return _mapper.Map<SubModuloDto>(subModulo);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubModuloDto>> Put(int id, [FromBody] SubModuloDto subModuloDto)
        {
            if (subModuloDto == null)
                return NotFound();
            var subModulo = _mapper.Map<SubModulo>(subModuloDto);
            _unitOfWork.SubModulos.Update(subModulo);
            await _unitOfWork.SaveAsync();
            return subModuloDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var subModulo = await _unitOfWork.SubModulos.GetByIdAsync(id);
            if (subModulo == null)
            {
                return NotFound();
            }
            _unitOfWork.SubModulos.Remove(subModulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}