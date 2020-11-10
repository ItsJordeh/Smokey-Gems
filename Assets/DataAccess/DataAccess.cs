using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class DataAccess : MonoBehaviour
// {
//   private const string MONGO_URI = "mongodb://username:password@127.0.0.1:27017";
//   private MongoClient client = new MongoClient(MONGO_URI);
//   private IMongoDatabase db;
//   private IMongoCollection<BsonDocument> collection;


//     // Start is called before the first frame update
//    void Start()
//    {

//   const string DATABASE_NAME = "smokey_gems";

//     // client = new MongoClient(MONGO_URI);
//     db = client.GetDatabase(DATABASE_NAME);
//     collection = db.GetCollection<BsonDocument>("accounts");

//     // collection.find({});
//     // Debug.log(collection.find({}));

//     // BsonDocument document = new BsonDocument{{"username":"Xenon","password":"haha","email":"xenon@no.no","purchases":"" }};
//     collection.InsertOne(document);
//    }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
