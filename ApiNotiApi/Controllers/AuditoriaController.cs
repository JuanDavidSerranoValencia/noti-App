using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotiApi.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotiApi.Controllers;

public class AuditoriaController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuditoriaController(IUnitOfWork unitOfWork ,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

        /* Get all Auditors in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AuditoriaDto>>> Get()
    {
        var auditoria = await _unitOfWork.Auditorias.GetAllAsync();
        /* return Ok(auditors); */
        return _mapper.Map<List<AuditoriaDto>>(auditoria);
    }
     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Auditoria>> Post(AuditoriaDto auditoriaDtos)
    {
        var auditoria = _mapper.Map<Auditoria>(auditoriaDtos);
        this._unitOfWork.Auditorias.Add(auditoria);
        await _unitOfWork.SaveAsync();
        if (auditoria == null)
        {
            return BadRequest();
        }
        auditoriaDtos.Id = auditoria.Id;
        return CreatedAtAction(nameof(Post), new { id = auditoriaDtos.Id }, auditoriaDtos);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuditoriaDto>> Get(int id)
    {
        var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
        if (auditoria == null){
            return NotFound();
        }
        return _mapper.Map<AuditoriaDto>(auditoria);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AuditoriaDto>> Put(int id, [FromBody]AuditoriaDto  auditoriaDtos)
    {
        if ( auditoriaDtos == null)
            return NotFound();
        var auditoria = _mapper.Map<Auditoria>( auditoriaDtos);
        _unitOfWork.Auditorias.Update(auditoria);
        await _unitOfWork.SaveAsync();
        return auditoriaDtos;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
        if (auditoria == null)
        {
            return NotFound();
        }
        _unitOfWork.Auditorias.Remove(auditoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}
