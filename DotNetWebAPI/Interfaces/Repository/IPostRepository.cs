using DotNetWebAPI.Models;
using EF.Core.Repository.Interface.Repository;

namespace DotNetWebAPI.Interfaces.Repository
{
    public interface IPostRepository:ICommonRepository<Post>
    {
    }
}
