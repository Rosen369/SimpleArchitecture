using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArchitecture.Repository.Mongo
{
    public abstract class MongoRepo : IMongoRepo
    {
        public MongoRepo()
        {
            this.SetRepoConnection();
        }

        protected string _connectionString;
        protected string _databaseName;

        protected abstract void SetRepoConnection();

        protected virtual IMongoDatabase GetCurrentDb()
        {
            var client = new MongoClient(_connectionString);
            var database = client.GetDatabase(_databaseName);
            return database;
        }

        public IList<BsonDocument> FindAll(string collectionName)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(new BsonDocument()).ToList();
            return res;
        }

        public IList<BsonDocument> FindAll(string collectionName, int pageIndex, int pageSize)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(new BsonDocument()).Skip(pageIndex * pageSize).Limit(pageSize).ToList();
            return res;
        }

        public IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).ToList();
            return res;
        }

        public IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, int pageIndex, int pageSize)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).Skip(pageIndex * pageSize).Limit(pageSize).ToList();
            return res;
        }

        public IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, SortDefinition<BsonDocument> sorter)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).Sort(sorter).ToList();
            return res;
        }

        public IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, SortDefinition<BsonDocument> sorter, int pageIndex, int pageSize)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).Sort(sorter).Skip(pageIndex * pageSize).Limit(pageSize).ToList();
            return res;
        }

        public IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).Project(projection).ToList();
            return res;
        }

        public IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection, int pageIndex, int pageSize)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).Project(projection).Skip(pageIndex * pageSize).Limit(pageSize).ToList();
            return res;
        }

        public IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection, SortDefinition<BsonDocument> sorter)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).Project(projection).Sort(sorter).ToList();
            return res;
        }

        public IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection, SortDefinition<BsonDocument> sorter, int pageIndex, int pageSize)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).Project(projection).Sort(sorter).Skip(pageIndex * pageSize).Limit(pageSize).ToList();
            return res;
        }

        public void Insert(string collectionName, BsonDocument document)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
        }

        public string InsertForId(string collectionName, BsonDocument document)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
            var id = document["_id"].ToString();
            return id;
        }

        public bool ReplaceOne(string collectionName, FilterDefinition<BsonDocument> filter, BsonDocument document)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var r = collection.ReplaceOne(filter, document);
            return r.ModifiedCount > 0;
        }

        public bool Replace(string collectionName, FilterDefinition<BsonDocument> filter, BsonDocument document)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var r = collection.ReplaceOne(filter, document);
            return r.ModifiedCount > 0;
        }

        public bool UpdateOne(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var r = collection.UpdateOne(filter, update);
            return r.ModifiedCount > 0;
        }

        public long UpdateMany(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var r = collection.UpdateMany(filter, update);
            return r.ModifiedCount;
        }

        public bool DeleteOne(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var r = collection.DeleteOne(filter);
            return r.DeletedCount > 0;
        }

        public long DeleteMany(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var r = collection.DeleteMany(filter);
            return r.DeletedCount;
        }

        public BsonDocument FindFirstOrDefault(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var database = GetCurrentDb();
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var res = collection.Find(filter).FirstOrDefault();
            return res;
        }


        public byte[] DownloadByFileName(string fileName)
        {
            var database = GetCurrentDb();
            var fsBucket = new GridFSBucket(database);
            var bytes = fsBucket.DownloadAsBytesByName(fileName);
            return bytes;
        }

        public byte[] DownloadById(string id)
        {
            var database = GetCurrentDb();
            var fsBucket = new GridFSBucket(database);
            var bytes = fsBucket.DownloadAsBytes(id);
            return bytes;
        }

        public string Upload(string fileName, byte[] bytes)
        {
            var database = GetCurrentDb();
            var fsBucket = new GridFSBucket(database);
            var id = fsBucket.UploadFromBytes(fileName, bytes);
            return id.ToString();
        }

        public void DeleteFileById(string id)
        {
            var database = GetCurrentDb();
            var fsBucket = new GridFSBucket(database);
            fsBucket.Delete(id);
        }
    }
}
