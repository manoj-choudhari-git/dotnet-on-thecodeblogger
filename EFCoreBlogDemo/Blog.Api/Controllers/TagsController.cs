using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Blog.Api.Models;
using Blog.Business.Contracts;
using Blog.Data.EF.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsBusiness _tagsBusiness;
        private readonly IMapper _mapper;
        private readonly ILogger<TagsController> _logger;

        public TagsController(ITagsBusiness tagsBusiness, IMapper mapper, ILogger<TagsController> logger)
        {
            _tagsBusiness = tagsBusiness;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagsBusiness.GetAllAsync();
            return Ok(_mapper.Map<IList<TagModel>>(tags));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagModel newTag)
        {
            if (newTag == null)
            {
                return BadRequest();
            }

            var tag = _mapper.Map<Tag>(newTag);
            await _tagsBusiness.CreateAsync(tag);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TagModel tagModel)
        {
            if (tagModel == null || id <= 0)
            {
                return BadRequest();
            }

            tagModel.Id = id;
            var tag = _mapper.Map<Tag>(tagModel);
            await _tagsBusiness.UpdateAsync(tag);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var isDeleted = await _tagsBusiness.DeleteAsync(id);
            return Ok(isDeleted);
        }
    }
}
