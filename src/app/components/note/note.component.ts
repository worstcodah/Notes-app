import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core'
import { Subscription } from 'rxjs'
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
  filteredNotesSub: Subscription
  filteredNotesByTitleSub: Subscription
  filteredNotesByDescriptionSub: Subscription
  getNotesSub: Subscription

  constructor(private noteService: NoteService) {}
  ngOnChanges(): void {
    if (this.selectedCategoryId) {
      this.filteredNotesSub = this.noteService
        .getFilteredNotes(this.selectedCategoryId)
        .subscribe((notes) => {
          this.notes = notes
        })
      this.selectedCategoryId = ''
    }
    if (this.selectedSearchParams) {
      switch (this.selectedSearchParams.searchType) {
        case 'Title':
          this.filteredNotesByTitleSub = this.noteService
            .getFilteredNotesByTitle(this.selectedSearchParams.searchTerm)
            .subscribe((notes) => {
              this.notes = notes
            })
          break
        case 'Description':
          this.filteredNotesByDescriptionSub = this.noteService
            .getFilteredNotesByDescription(this.selectedSearchParams.searchTerm)
            .subscribe((next) => {
              this.notes = next
            })
          break
      }
      this.selectedSearchParams = null
    }
  }

  ngOnInit() {
    this.getNotesSub = this.noteService.getNotes().subscribe((notes) => {
      this.notes = notes
    })
  }

  ngOnDestroy() {
    if (this.filteredNotesSub != null) {
      this.filteredNotesSub.unsubscribe()
    }
    if (this.filteredNotesByDescriptionSub != null) {
      this.filteredNotesByDescriptionSub.unsubscribe()
    }
    if (this.filteredNotesByTitleSub != null) {
      this.filteredNotesByTitleSub.unsubscribe()
    }
    if (this.getNotesSub != null) {
      this.getNotesSub.unsubscribe()
    }
  }
}
