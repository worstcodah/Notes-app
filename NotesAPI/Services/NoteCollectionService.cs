using MongoDB.Driver;
using NotesAPI.Models;
using NotesAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class NoteCollectionService : INoteCollectionService
    {

        private readonly IMongoCollection<Note> _notes;

        public NoteCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<Note>(settings.NoteCollectionName);

        }


        public async Task<List<Note>> GetAll()
        {
            var result = await _notes.FindAsync(note => true);
            return result.ToList();
        }



        public async Task<List<Note>> GetNotesByOwnerId(Guid ownerId)
        {
            var result = await _notes.FindAsync((note) => note.Id.Equals(ownerId)).Result.ToListAsync();
            return result == null ? null : result;
        }

        public async Task<Note> Get(Guid id)
        {
            var result = await _notes.FindAsync((note) => note.Id.Equals(id)).Result.ToListAsync();
            if (result.Count.Equals(0))
            {
                return null;
            }
            return result.Where(note => note.Id.Equals(id)).ToList().First();
        }

        public async Task<bool> Create(Note model)
        {
            var result = await _notes.FindAsync((note) => note.Id.Equals(model.Id)).Result.ToListAsync();
            if (result.Count.Equals(0))
            {
                await _notes.InsertOneAsync(model);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Guid id, Note model)
        {
            var result = await _notes.ReplaceOneAsync(note => note.Id.Equals(id), model);
            if (result.IsAcknowledged && result.ModifiedCount.Equals(0))
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            //var result = await _notes.FindAsync((note) => note.Id.Equals(id)).Result.ToListAsync();
            var result = await _notes.DeleteOneAsync((note) => note.Id == id);

            if(result.IsAcknowledged && result.DeletedCount.Equals(0))
            {
                return false;
            }
            return true;
        }
    }
}
