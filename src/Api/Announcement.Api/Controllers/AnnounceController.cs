using Announcement.Application.Common.Contracts;
using Announcement.Application.Common.Contracts.Queries;
using Announcement.Application.DTO;
using Announcement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Announcement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnounceController : ControllerBase
    {
        private readonly IStrategy _strategy;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public AnnounceController(IStrategy strategy, IMapper mapper, IUriService uriService)
        {
            _strategy = strategy;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpPost("createAnnounce")]
        public async Task<ActionResult<Announce>> CreateAnnounce([FromBody] AnnounceDto announceDto)
        {
            var map = _mapper.Map<Announce>(announceDto);
            await _strategy.CreateAnnounce(map);

            var locationUri = _uriService.GetPostUri(map.Id.ToString());

            return Ok(new AnnounceResponse { Id = map.Id});
        }

        [HttpGet("getallAnnounce")]
        public async Task<ActionResult<IEnumerable<Announce>>> GetAllAnnounce([FromQuery]PaginationQuery query)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(query);
            var result = await _strategy.GetAllAnnounce(paginationFilter);
            var postsResponce = _mapper.Map<List<Announce>>(result);

            if (paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return Ok(new PagedResponse<Announce>(postsResponce));
            }

            var nextPage = paginationFilter.PageNumber >= 1 ? _uriService
                .GetAllPostUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() : null;

            var previousPage = paginationFilter.PageNumber - 1 >= 1 ? _uriService
                .GetAllPostUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() : null;

            var paginationResponce = new PagedResponse<Announce>
            {
                Data = postsResponce,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?)null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?)null,
                NextPage = postsResponce.Any() ? nextPage : null,
                PreviousPage = previousPage
            };

            return Ok(paginationResponce);
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
