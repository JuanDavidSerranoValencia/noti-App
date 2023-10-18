using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotiApi.Dtos;
using AutoMapper;
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


}
