using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataAccess.cs : MonoBehaviour
{
    private const string MONGO_URI = "mongodb://username:password@127.0.0.1:27017";
private const string DATABASE_NAME = "testDatabase";
private MongoClient client;
private IMongoDatabase db;

client = new MongoClient(MONGO_URI);
db = client.GetDatabase(DATABASE_NAME);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
