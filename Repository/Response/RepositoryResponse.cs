namespace AnimalWeb.Api.Repository.Responce
{
    public class RepositoryResponse<T>
    {
        public T? Data { get; set; }
        public bool Succes { get; set; } = true;
        public string Message { get; set; } = string.Empty;

    }
}