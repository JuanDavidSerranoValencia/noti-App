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
    public class HiloRespuestaNotiController:BaseControllerApi
    {
          private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HiloRespuestaNotiController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HiloRespuestaNotiDto>>> Get()
        {
            var hiloRta = await _unitOfWork.HiloRespuestaNotis.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<HiloRespuestaNotiDto>>(hiloRta);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HiloRespuestaNoti>> Post(HiloRespuestaNotiDto hiloRespuestaNotiDto)
        {
            var hiloRta = _mapper.Map<HiloRespuestaNoti>(hiloRespuestaNotiDto);
            this._unitOfWork.HiloRespuestaNotis.Add(hiloRta );
            await _unitOfWork.SaveAsync();
            if (hiloRta  == null)
            {
                return BadRequest();
            }
          hiloRespuestaNotiDto.Id = hiloRta .Id;
            return CreatedAtAction(nameof(Post), new { id = hiloRespuestaNotiDto.Id }, hiloRespuestaNotiDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HiloRespuestaNotiDto>> Get(int id)
        {
            var hiloRta = await _unitOfWork.HiloRespuestaNotis.GetByIdAsync(id);
            if (hiloRta == null)
            {
                return NotFound();
            }
            return _mapper.Map<HiloRespuestaNotiDto>(hiloRta);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HiloRespuestaNotiDto>> Put(int id, [FromBody]HiloRespuestaNotiDto  hiloRespuestaNotiDto)
        {
            if ( hiloRespuestaNotiDto == null)
                return NotFound();
            var hiloRta= _mapper.Map<HiloRespuestaNoti>( hiloRespuestaNotiDto);
            _unitOfWork.HiloRespuestaNotis.Update(hiloRta);
            await _unitOfWork.SaveAsync();
            return hiloRespuestaNotiDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var hiloRta = await _unitOfWork.HiloRespuestaNotis.GetByIdAsync(id);
            if (hiloRta == null)
            {
                return NotFound();
            }
            _unitOfWork.HiloRespuestaNotis.Remove(hiloRta);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}