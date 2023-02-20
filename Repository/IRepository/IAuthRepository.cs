namespace AnimalWeb.Api.Repository.IRepository
{
    public interface IAuthRepository
    {
        Task<RepositoryResponse<int>> Register(User user, string password);
        Task<RepositoryResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}