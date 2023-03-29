using DbRelationship.DataContext;
using DbRelationship.Entity;
using DbRelationship.Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbRelationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get(int blogId)
        {
            var characters = await _context.Posts.Where(x => x.Blog.BlogId == blogId).ToListAsync();
            return Ok(characters);
        }

        [HttpPost]
        public async Task<ActionResult<List<Post>>> Create(PostDTO post)
        {
            var blog = await _context.Blogs.FindAsync(post.BlogId);
            var newPost = new Post
            {
                Content = post.Content,
                Title = post.Title,
                Blog = blog,
            };

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            return await Get(newPost.BlogId);

        }

        [HttpPost("postImage")]
        public async Task<ActionResult<Post>> Create(PostImageDTO postImage)
        {
            var post = await _context.Posts.FindAsync(postImage.PostId);
            var newBlog = new PostImage
            {
                Caption = postImage.Caption,
                Post = post,
            };

            _context.PostImages.Add(newBlog);
            await _context.SaveChangesAsync();
            return post;

        }

        [HttpPost("postTag")]
        public async Task<ActionResult<Post>> Create(TagDTO tagDto)
        {
            var post = await _context.Posts.Where(x => x.PostId == tagDto.PostId)
                     .Include(x => x.Tags).FirstOrDefaultAsync();

            var tag = await _context.Tags.FindAsync(tagDto.TagId);

            post.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return post;


        }
    }
}
