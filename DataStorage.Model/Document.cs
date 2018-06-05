using DataStorage.Model.Common;
using System;
using MongoDB.Bson.Serialization.Attributes;


namespace DataStorage.Model
{
    public class Document : IDocument
    {
        
        public Document()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }

        [BsonId]
        public Guid Id { get; set; }       
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int Version { get; set; }
    }
}
