using MongoDB.Driver;
using NotesAPI.Models;
using NotesAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class OwnerCollectionService : ICollectionService<Owner>
    {
        private readonly IMongoCollection<Owner> _owners;

        public OwnerCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _owners = database.GetCollection<Owner>(settings.OwnerCollectionName);
        }




        public async Task<bool> Create(Owner model)
        {
            var result = await _owners.FindAsync((owner) => owner.Id.Equals(model.Id)).Result.ToListAsync();
            if (result.Count.Equals(0))
            {
                await _owners.InsertOneAsync(model);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _owners.DeleteOneAsync((owner) => owner.Id == id);

            if (result.IsAcknowledged && result.DeletedCount.Equals(0))
            {
                return false;
            }
            return true;
        }

        public async Task<Owner> Get(Guid id)
        {
            var result = await _owners.FindAsync((owner) => owner.Id.Equals(id)).Result.ToListAsync();
            if (result.Count.Equals(0))
            {
                return null;
            }
            return result.Where(owner => owner.Id.Equals(id)).ToList().First();
        }

        public async Task<List<Owner>> GetAll()
        {
            var result = await _owners.FindAsync(owner => true);
            return result.ToList();
        }

        public async Task<bool> Update(Guid id, Owner model)
        {
            var result = await _owners.ReplaceOneAsync(owner => owner.Id.Equals(id), model);
            if (result.IsAcknowledged && result.ModifiedCount.Equals(0))
            {
                return false;
            }

            return true;
        }
    }
}
