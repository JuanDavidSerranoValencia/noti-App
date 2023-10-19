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
    public class GenericoVsSubmoduloController:BaseControllerApi
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericoVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GenericoVsSubmoduloDto>>> Get()
        {
            var genericoVs = await _unitOfWork.GenericoVsSubmodulos.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<GenericoVsSubmoduloDto>>(genericoVs);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenericoVsSubmodulo>> Post(GenericoVsSubmoduloDto genericoVsSubmoduloDto)
        {
            var genericoVs = _mapper.Map<GenericoVsSubmodulo>(genericoVsSubmoduloDto);
            this._unitOfWork.GenericoVsSubmodulos.Add(genericoVs);
            await _unitOfWork.SaveAsync();
            if (genericoVs == null)
            {
                return BadRequest();
            }
          genericoVsSubmoduloDto.Id = genericoVs.Id;
            return CreatedAtAction(nameof(Post), new { id = genericoVsSubmoduloDto.Id }, genericoVsSubmoduloDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericoVsSubmoduloDto>> Get(int id)
        {
            var genericoVs = await _unitOfWork.GenericoVsSubmodulos.GetByIdAsync(id);
            if (genericoVs == null)
            {
                return NotFound();
            }
            return _mapper.Map<GenericoVsSubmoduloDto>(genericoVs);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenericoVsSubmoduloDto>> Put(int id, [FromBody]GenericoVsSubmoduloDto  genericoVsSubmoduloDto)
        {
            if ( genericoVsSubmoduloDto == null)
                return NotFound();
            var genericoVs = _mapper.Map<GenericoVsSubmodulo>( genericoVsSubmoduloDto);
            _unitOfWork.GenericoVsSubmodulos.Update(genericoVs);
            await _unitOfWork.SaveAsync();
            return  genericoVsSubmoduloDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var genericoVs = await _unitOfWork.GenericoVsSubmodulos.GetByIdAsync(id);
            if (genericoVs == null)
            {
                return NotFound();
            }
            _unitOfWork.GenericoVsSubmodulos.Remove(genericoVs);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}