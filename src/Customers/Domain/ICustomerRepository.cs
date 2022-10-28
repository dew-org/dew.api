namespace Dew.Customers.Domain;

public interface ICustomerRepository
{
    Task Save(Customer customer);
}
