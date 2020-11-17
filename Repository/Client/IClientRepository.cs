using LinqKit;

using Repository.Database.Generic;

using System.Collections.Generic;

using VirtualMarketPlace.Domain.Models;

using X.PagedList;

namespace VirtualMarketPlace.Repositories
{
    public interface IClientRepository : IGenericRepository<ClientModel>
    {
        ClientModel Login(string Email, string Password);
        ClientModel GetClient(int id);
        List<ClientModel> GetClients();
        IPagedList<ClientModel> GetPagedClients(int index, ExpressionStarter<ClientModel> whereExpression);
    }
}
