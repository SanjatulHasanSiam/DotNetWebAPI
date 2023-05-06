using DotNetWebAPI.Data;
using DotNetWebAPI.Interfaces.Manager;
using DotNetWebAPI.Models;
using DotNetWebAPI.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace DotNetWebAPI.Manager
{
    public class PostManager : CommonManager<Post>,IPostManager
    {
        public PostManager(ApplicationDbContext _dbContext) : base(new PostRepository(_dbContext))
        {
        }

        public Post GetById(int id)
        {
            return GetFirstOrDefault(x=>x.Id==id);
        }
    }
}
