using Domain.User.DTOs;
using Domain.User.Entities;
using Google.Cloud.Firestore;
using Infrastructure.Data.Firestore;
using UserApi.Repositories.v2.Interfaces;

namespace UserApi.Repositories.v2;

public class CustomerRespository(
    FirestoreContext firestoreDatabase
    ) : ICustomerRepository
{
    private readonly CollectionReference collection = firestoreDatabase.Users;

    public async Task CreateCustomerAsync(Customer customer)
    {
        try
        {
            var document = collection.Document(customer.Id);

            var user = new Dictionary<string, object>
            {
                {"first_name", customer.Name },
                {"last_name", customer.LastName },
                {"birthdate", customer.Birthdate },
                {"phone", customer.Phone! },
                {"role", customer.Role },
                {"email", customer.Email },
                {"password", customer.Password },
                {"created_at", customer.CreatedAt }
            };

            await document.SetAsync(user);
        }
        catch (Exception ex)
        {
            throw new Exception("An mongo error occurred while process your request: " + ex.Message);
        }
    }

    public async Task<List<CustomerResponseDto>> GetAllCustomersAsync()
    {
        try
        {


            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("An mongo error occurred while process your request: " + ex.Message);
        }
    }

    public async Task<Customer> GetCustomerByEmailAsync(string email)
    {
        try
        {


            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("An mongo error occurred while process your request: " + ex.Message);
        }
    }

    public async Task<Customer?> GetCustomerByCpfAsync(string cpf)
    {
        try
        {

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("An mongo error occurred while process your request: " + ex.Message);
        }
    }
}
