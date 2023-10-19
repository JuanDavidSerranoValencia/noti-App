using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotiApi.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotiApi.Controllers
{
    public class BlockChainController : BaseControllerApi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlockChainController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /* Get all Auditors in the database */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BlockChainDto>>> Get()
        {
            var blockChain = await _unitOfWork.BlockChains.GetAllAsync();
            /* return Ok(auditors); */
            return _mapper.Map<List<BlockChainDto>>(blockChain);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlockChain>> Post(BlockChainDto blockChainDto)
        {
            var blockChain= _mapper.Map<BlockChain>(blockChainDto);
            this._unitOfWork.BlockChains.Add(blockChain);
            await _unitOfWork.SaveAsync();
            if (blockChain == null)
            {
                return BadRequest();
            }
           blockChainDto.Id = blockChain.Id;
            return CreatedAtAction(nameof(Post), new { id = blockChainDto.Id }, blockChainDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BlockChainDto>> Get(int id)
        {
            var blockChain = await _unitOfWork.BlockChains.GetByIdAsync(id);
            if (blockChain == null)
            {
                return NotFound();
            }
            return _mapper.Map<BlockChainDto>(blockChain);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlockChainDto>> Put(int id, [FromBody] BlockChainDto blockChainDto)
        {
            if (blockChainDto == null)
                return NotFound();
            var blockChain = _mapper.Map<BlockChain>(blockChainDto);
            _unitOfWork.BlockChains.Update(blockChain);
            await _unitOfWork.SaveAsync();
            return blockChainDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var blockChain = await _unitOfWork.BlockChains.GetByIdAsync(id);
            if (blockChain == null)
            {
                return NotFound();
            }
            _unitOfWork.BlockChains.Remove(blockChain);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}