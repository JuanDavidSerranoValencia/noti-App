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
    public class TipoNotiController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoNotiController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoNotiDto>>> Get()
        {
            var tipoNoti = await _unitOfWork.TipoNotis.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<TipoNotiDto>>(tipoNoti);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoNoti>> Post(TipoNotiDto tipoNotiDto)
        {
            var tipoNoti = _mapper.Map<TipoNoti>(tipoNotiDto);
            this._unitOfWork.TipoNotis.Add(tipoNoti);
            await _unitOfWork.SaveAsync();
            if (tipoNoti == null)
            {
                return BadRequest();
            }
            tipoNotiDto.Id = tipoNoti.Id;
            return CreatedAtAction(nameof(Post), new { id = tipoNotiDto.Id }, tipoNotiDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoNotiDto>> Get(int id)
        {
            var tipoNoti = await _unitOfWork.TipoNotis.GetByIdAsync(id);
            if (tipoNoti == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoNotiDto>(tipoNoti);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoNotiDto>> Put(int id, [FromBody] TipoNotiDto tipoNotiDto)
        {
            if (tipoNotiDto == null)
                return NotFound();
            var tipoNoti = _mapper.Map<TipoNoti>(tipoNotiDto);
            _unitOfWork.TipoNotis.Update(tipoNoti);
            await _unitOfWork.SaveAsync();
            return tipoNotiDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoNoti = await _unitOfWork.TipoNotis.GetByIdAsync(id);
            if (tipoNoti == null)
            {
                return NotFound();
            }
            _unitOfWork.TipoNotis.Remove(tipoNoti);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}