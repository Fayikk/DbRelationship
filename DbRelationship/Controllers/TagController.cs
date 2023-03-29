using DbRelationship.DataContext;
using DbRelationship.Entity;
using DbRelationship.Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbRelationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TagController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag(TagAddDTO tag)
        {
            var result = new Tag
            {
                TagName = tag.TagName,
            };
            _context.Tags.Add(result);
            await _context.SaveChangesAsync();
            return Ok(result);  
        }
    }
}
