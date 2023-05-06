using DotNetWebAPI.Models;
using EF.Core.Repository.Interface.Manager;

namespace DotNetWebAPI.Interfaces.Manager
{
    public interface IPostManager:ICommonManager<Post>
    {
        Post GetById(int id);
        ICollection<Post> GetAll(string title);
        ICollection<Post> SearchPost(string text);
        ICollection<Post> GetPosts(int page,int pageSize);
    }
}
