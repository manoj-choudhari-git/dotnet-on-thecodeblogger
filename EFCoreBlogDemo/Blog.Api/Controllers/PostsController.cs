using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Blog.Api.Models;
using Blog.Business;
using Blog.Business.Contracts;
using Blog.Data.EF.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsBusiness _postsBusiness;
        private readonly IMapper _mapper;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostsBusiness postsBusiness, IMapper mapper, ILogger<PostsController> logger)
        {
            _postsBusiness = postsBusiness;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Just for demo of composite specifications
            var posts = await _postsBusiness.GetAllAsync();
            return Ok(_mapper.Map<IList<PostModel>>(posts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var business = _postsBusiness as PostsBusiness;
            var posts = await business.GetById(id);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostModel newPost)
        {
            if (newPost == null)
            {
                return BadRequest();
            }

            var post = _mapper.Map<Post>(newPost);
            post.PostCategories = new List<PostCategories>();
            foreach (var category in newPost.PostCategories)
            {
                post.PostCategories.Add(new PostCategories()
                {
                    CategoryId = category.Id,
                    Post = post
                });
            }

            await _postsBusiness.CreateAsync(post);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PostModel postModel)
        {
            if (postModel == null || id <= 0)
            {
                return BadRequest();
            }

            postModel.Id = id;
            var post = _mapper.Map<Post>(postModel);
            await _postsBusiness.UpdateAsync(post);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var isDeleted = await _postsBusiness.DeleteAsync(id);
            return Ok(isDeleted);
        }
    }
}
