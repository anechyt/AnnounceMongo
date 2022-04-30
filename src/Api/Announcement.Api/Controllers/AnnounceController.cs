using Announcement.Application.Common.Contracts;
using Announcement.Application.DTO;
using Announcement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnounceController : ControllerBase
    {
        private readonly IStrategy _strategy;
        private readonly IMapper _mapper;
        public AnnounceController(IStrategy strategy, IMapper mapper)
        {
            _strategy = strategy;
            _mapper = mapper;
        }

        [HttpPost("createAnnounce")]
        public async Task<ActionResult<Announce>> CreateAnnounce([FromBody] AnnounceDto announceDto)
        {
            var map = _mapper.Map<Announce>(announceDto);
            await _strategy.CreateAnnounce(map);

            return CreatedAtAction(nameof(CreateAnnounce), new { id = map.Id }, map);
        }

        [HttpGet("getallAnnounce")]
        public async Task<ActionResult<IEnumerable<Announce>>> GetAllAnnounce()
        {
            var result = await _strategy.GetAllAnnounce();
            return Ok(result);
        }
        [HttpGet("getAnnounceByName")]
        public async Task<ActionResult<IEnumerable<Announce>>> GetByName(string name)
        { 
            var result = await _strategy.GetAnnouceByName(name);
            if(result == null)
            {
                throw new Exception();
            }
            return Ok(result);
        }
    }
}
