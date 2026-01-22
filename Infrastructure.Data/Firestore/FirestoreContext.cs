using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using Infrastructure.Data.Firestore.Settings;

namespace Infrastructure.Data.Firestore;

public class FirestoreContext
{
    private readonly FirestoreDb _database;
    public FirestoreContext(FirestoreDbSettings settings)
    {
        
        _database = new FirestoreDbBuilder 
        { 
            ProjectId = settings.ProjectId, 
            DatabaseId = settings.DatabaseId
        }.Build();
    }

    public CollectionReference Users
        => _database.Collection("users");
}
