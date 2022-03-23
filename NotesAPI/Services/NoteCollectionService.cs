using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class NoteCollectionService : INoteCollectionService
    {

        private List<Note> _notes = new List<Note> { new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        };

        public List<Note> GetAll()
        {
            return _notes;
        }

        public bool Create(Note model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            var note = Get(id);
            if (note is null)
            {
                return false;
            }
            _notes.Remove(note);
            return true;
        }

        public Note Get(Guid id)
        {
            var noteIndex = _notes.FindIndex(note => note.Id.Equals(id));
            if (noteIndex != -1)
                return _notes.ElementAt(noteIndex);
            return null;
        }



        public List<Note> GetNotesByOwnerId(Guid ownerId)
        {
            var foundNotes = _notes.Where(note => note.OwnerId.Equals(ownerId)).ToList();
            if (foundNotes is null)
                return null;
            return foundNotes;
        }

        public bool Update(Guid id, Note model)
        {
            var index = _notes.FindIndex((note) => note.Id.Equals(id));
            if (index == -1)
            {
                return false;
            }
            _notes[index] = model;
            return true;
        }
    }
}
