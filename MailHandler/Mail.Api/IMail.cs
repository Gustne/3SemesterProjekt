using System;

public interface IMail
{
    Task<IEnumerable<Product>> GetAllMailsAsync();
    Task<Product> GetMailByIdAsync(int id);
    Task AddMailAsync(Mail mail);
    Task UpdateProductAsync(Mail mail);
    Task DeleteProductAsync(int id);
}
