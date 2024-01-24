namespace DVUProject.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product {  get; }
        ICategoryRepository Category { get; }

    }
}
