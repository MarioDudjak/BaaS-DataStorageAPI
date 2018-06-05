using DataStorage.Model.Common;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;
using System;

namespace DataStorage.Model
{
    public class Schema : ISchema
    {
        public Schema()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }

        [BsonId]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public JObject Options { get;  set; }
        public int Version { get; set; }
    }
}
