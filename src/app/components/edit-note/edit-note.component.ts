import { Subscription } from 'rxjs'
import { Note } from './../note/note'
import { AfterViewInit, Component, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { FilterService } from 'src/app/services/filter.service'
import { Category } from '../filter/category'
import { NoteService } from 'src/app/services/note.service'
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss'],
})
export class EditNoteComponent implements OnInit {
  formGroup: FormGroup
  selectedNote: Note
  colors: string[] = ['Red', 'Green', 'Blue', 'Yellow']
  notesSub: Subscription

  constructor(
    private formBuilder: FormBuilder,
    private filterService: FilterService,
    private noteService: NoteService,
    private activatedRoute: ActivatedRoute,
  ) {}

  ngOnInit(): void {
    debugger
    this.notesSub = this.noteService.getNote('2').subscribe((note) => {
      this.selectedNote = note
      console.log(this.selectedNote)
    })
    /*
    this.formGroup = this.formBuilder.group({
      title: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(20),
        ],
      ],
      description: [
        '',
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(50),
        ],
      ],
      color: [this.selectedNote.color, [Validators.required]],
      category: [this.selectedNote.categoryId, [Validators.required]],
    })
    */
  }

  ngOnDestroy() {
    if (this.notesSub) {
      this.notesSub.unsubscribe()
    }
  }

  get categories(): Category[] {
    return this.filterService.getFilters()
  }

  editNote() {
    this.noteService.editNote(this.selectedNote.id, this.selectedNote)
  }
}
