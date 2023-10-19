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
    public class MaestroVsSubmoduloController:BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaestroVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MaestroVsSubmoduloDto>>> Get()
        {
            var maestroVsSub = await _unitOfWork.MaestroVsSubmodulos.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<MaestroVsSubmoduloDto>>(maestroVsSub);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaestroVsSubmodulo>> Post(MaestroVsSubmoduloDto hiloRespuestaNotiDto)
        {
            var maestroVsSub = _mapper.Map<MaestroVsSubmodulo>(hiloRespuestaNotiDto);
            this._unitOfWork.MaestroVsSubmodulos.Add(maestroVsSub );
            await _unitOfWork.SaveAsync();
            if (maestroVsSub  == null)
            {
                return BadRequest();
            }
          hiloRespuestaNotiDto.Id = maestroVsSub .Id;
            return CreatedAtAction(nameof(Post), new { id = hiloRespuestaNotiDto.Id }, hiloRespuestaNotiDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaestroVsSubmoduloDto>> Get(int id)
        {
            var maestroVsSub = await _unitOfWork.MaestroVsSubmodulos.GetByIdAsync(id);
            if (maestroVsSub == null)
            {
                return NotFound();
            }
            return _mapper.Map<MaestroVsSubmoduloDto>(maestroVsSub);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaestroVsSubmoduloDto>> Put(int id, [FromBody]MaestroVsSubmoduloDto  hiloRespuestaNotiDto)
        {
            if ( hiloRespuestaNotiDto == null)
                return NotFound();
            var maestroVsSub= _mapper.Map<MaestroVsSubmodulo>( hiloRespuestaNotiDto);
            _unitOfWork.MaestroVsSubmodulos.Update(maestroVsSub);
            await _unitOfWork.SaveAsync();
            return hiloRespuestaNotiDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var maestroVsSub = await _unitOfWork.MaestroVsSubmodulos.GetByIdAsync(id);
            if (maestroVsSub == null)
            {
                return NotFound();
            }
            _unitOfWork.MaestroVsSubmodulos.Remove(maestroVsSub);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}