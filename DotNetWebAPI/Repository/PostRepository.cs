using DotNetWebAPI.Data;
using DotNetWebAPI.Interfaces.Repository;
using DotNetWebAPI.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPI.Repository
{
    public class PostRepository : CommonRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
