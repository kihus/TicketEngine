using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.TicketEngine.CustomerApi.Entities;

public class Customer(
    string name,
    string lastName,
    DateOnly birthdate,
    string document,
    string email,
    string password
    )
{
    [BsonId]
    public ObjectId Id { get; init; } = ObjectId.GenerateNewId();
    public string Name { get; private set; } = name;
    public string LastName { get; private set; } = lastName;
    public DateOnly Birthdate { get; private set; } = birthdate;
    public string? Phone { get; private set; } = null;
    public string Document { get; private set; } = document;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;

    public Customer(
        string name,
        string lastName,
        DateOnly birthdate,
        string? phone, 
        string document,
        string email,
        string password
        ) : this (
            name, 
            lastName, 
            birthdate, 
            document, 
            email, 
            password
            )
    {
        Phone = phone;
    }
}
