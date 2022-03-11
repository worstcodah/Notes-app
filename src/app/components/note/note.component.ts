import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core'
import { NoteService } from 'src/app/services/note.service'
import { SearchParams } from '../search/search-params'
import { Note } from './note'

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss'],
})
export class NoteComponent implements OnInit, OnChanges {
  notes: Note[] = []
  @Input() selectedCategoryId: string
  @Input() selectedSearchParams: SearchParams

  constructor(private noteService: NoteService) {}
  ngOnChanges(): void {
    if (this.selectedCategoryId) {
      this.notes = this.noteService.getFilteredNotes(this.selectedCategoryId)
      this.selectedCategoryId = ''
    }
    if (this.selectedSearchParams) {
      switch (this.selectedSearchParams.searchType) {
        case 'Title':
          this.notes = this.noteService.getFilteredNotesByTitle(
            this.selectedSearchParams.searchTerm,
          )
          break
        case 'Description':
          this.notes = this.noteService.getFilteredNotesByDescription(
            this.selectedSearchParams.searchTerm,
          )
          break
      }
      this.selectedSearchParams = null
    }
  }

  ngOnInit() {
    this.notes = this.noteService.getNotes()
  }
}
