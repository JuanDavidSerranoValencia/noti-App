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
    public class RolMaestroController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolMaestroDto>>> Get()
        {
            var rolMaestro = await _unitOfWork.RolMaestros.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<RolMaestroDto>>(rolMaestro);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolMaestro>> Post(RolMaestroDto rolMaestroDto)
        {
            var rolMaestro = _mapper.Map<RolMaestro>(rolMaestroDto);
            this._unitOfWork.RolMaestros.Add(rolMaestro);
            await _unitOfWork.SaveAsync();
            if (rolMaestro == null)
            {
                return BadRequest();
            }
            rolMaestroDto.Id = rolMaestro.Id;
            return CreatedAtAction(nameof(Post), new { id = rolMaestroDto.Id }, rolMaestroDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolMaestroDto>> Get(int id)
        {
            var rolMaestro = await _unitOfWork.RolMaestros.GetByIdAsync(id);
            if (rolMaestro == null)
            {
                return NotFound();
            }
            return _mapper.Map<RolMaestroDto>(rolMaestro);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolMaestroDto>> Put(int id, [FromBody] RolMaestroDto rolMaestroDto)
        {
            if (rolMaestroDto == null)
                return NotFound();
            var rolMaestro = _mapper.Map<RolMaestro>(rolMaestroDto);
            _unitOfWork.RolMaestros.Update(rolMaestro);
            await _unitOfWork.SaveAsync();
            return rolMaestroDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var rolMaestro = await _unitOfWork.RolMaestros.GetByIdAsync(id);
            if (rolMaestro == null)
            {
                return NotFound();
            }
            _unitOfWork.RolMaestros.Remove(rolMaestro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}