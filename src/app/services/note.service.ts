import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { map } from 'rxjs/operators' // This is where I import map operator
import { Note } from '../components/note/note'

@Injectable({
  providedIn: 'root',
})
export class NoteService {
  readonly baseUrl = 'https://localhost:4200'
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  }

  constructor(private http: HttpClient) {}

  serviceCall() {
    console.log('Note service was called')
  }

  getNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(this.baseUrl + `/notes`, this.httpOptions)
  }

  addNote(note: Note) {
    return this.http
      .post(this.baseUrl + '/notes', note, this.httpOptions)
      .subscribe()
  }

  getFilteredNotes(categoryId: string) {
    return this.http
      .get<Note[]>(this.baseUrl + `/notes`, this.httpOptions)
      .pipe(
        map((notes) => notes.filter((note) => note.categoryId === categoryId)),
      )
  }

  getFilteredNotesByTitle(searchTerm: string): Observable<Note[]> {
    return this.http
      .get<Note[]>(this.baseUrl + `/notes`, this.httpOptions)
      .pipe(
        map((notes) =>
          notes.filter((note) =>
            note.title.toLowerCase().includes(searchTerm.toLowerCase()),
          ),
        ),
      )
  }
  getFilteredNotesByDescription(searchTerm: string) {
    return this.http
      .get<Note[]>(this.baseUrl + `/notes`, this.httpOptions)
      .pipe(
        map((notes) =>
          notes.filter((note) =>
            note.description.toLowerCase().includes(searchTerm.toLowerCase()),
          ),
        ),
      )
  }
}
