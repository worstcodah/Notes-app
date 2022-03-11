import { Injectable } from '@angular/core'

import { Note } from '../components/note/note'

@Injectable({
  providedIn: 'root',
})
export class NoteService {
  private notes: Note[] = [
    {
      id: 'Id1',
      title: 'First note',
      description: 'This is the description for the first note',
      color: 'red',
      categoryId: '1',
    },
    {
      id: 'Id1',
      title: 'Second note',
      description: 'This is the description for the second note',
      color: 'blue',
      categoryId: '2',
    },
    {
      id: 'Id1',
      title: 'Third note',
      description: 'This is the description for the third note',
      color: 'green',
      categoryId: '3',
    },
  ]

  constructor() {}

  serviceCall() {
    console.log('Note service was called')
  }

  getNotes() {
    return this.notes
  }

  addNote(note: Note) {
    this.notes.push(note)
  }

  getFilteredNotes(categoryId: string) {
    return this.notes.filter((note) => note.categoryId == categoryId)
  }

  getFilteredNotesByTitle(searchTerm: string) {
    return this.notes.filter((note) =>
      note.title.toLowerCase().includes(searchTerm.toLowerCase()),
    )
  }
  getFilteredNotesByDescription(searchTerm: string) {
    return this.notes.filter((note) =>
      note.description.toLowerCase().includes(searchTerm.toLowerCase()),
    )
  }
}
