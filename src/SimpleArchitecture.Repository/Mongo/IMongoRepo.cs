using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArchitecture.Repository.Mongo
{
    internal interface IMongoRepo
    {
        IList<BsonDocument> FindAll(string collectionName);

        IList<BsonDocument> FindAll(string collectionName, int pageIndex, int pageSize);

        IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter);

        IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, int pageIndex, int pageSize);

        IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, SortDefinition<BsonDocument> sorter);

        IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, SortDefinition<BsonDocument> sorter, int pageIndex, int pageSize);

        IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection);

        IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection, int pageIndex, int pageSize);

        IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection, SortDefinition<BsonDocument> sorter);

        IList<BsonDocument> FindList(string collectionName, FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection, SortDefinition<BsonDocument> sorter, int pageIndex, int pageSize);

        void Insert(string collectionName, BsonDocument document);

        string InsertForId(string collectionName, BsonDocument document);

        bool Replace(string collectionName, FilterDefinition<BsonDocument> filter, BsonDocument document);

        bool UpdateOne(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update);

        long UpdateMany(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update);

        bool DeleteOne(string collectionName, FilterDefinition<BsonDocument> filter);

        long DeleteMany(string collectionName, FilterDefinition<BsonDocument> filter);

        BsonDocument FindFirstOrDefault(string collectionName, FilterDefinition<BsonDocument> filter);

        byte[] DownloadByFileName(string fileName);

        byte[] DownloadById(string id);

        string Upload(string fileName, byte[] bytes);

        void DeleteFileById(string id);
    }
}
