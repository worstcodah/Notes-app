import { Subscription } from 'rxjs'
import { Component, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { ActivatedRoute } from '@angular/router'
import { FilterService } from 'src/app/services/filter.service'
import { NoteService } from 'src/app/services/note.service'
import { Category } from '../filter/category'

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss'],
})
export class AddNoteComponent implements OnInit {
  formGroup!: FormGroup
  selectedCategory: Category
  idCategoryNote: number
  addSubscription: Subscription
  constructor(
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private noteService: NoteService,
    private filterService: FilterService,
  ) {}

  get categories(): Category[] {
    return this.filterService.getFilters()
  }

  ngOnInit(): void {
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
      category: ['', [Validators.required]],
    })
    this.activatedRoute.params.subscribe((next) => {
      console.log(next['id'])
    })
    this.activatedRoute.queryParams.subscribe((parameters) => {
      console.log(parameters['title'])
      console.log(parameters['description'])
    })
  }

  ngOnDestroy() {
    this.addSubscription.unsubscribe()
  }

  get title() {
    return this.formGroup.get('title').value
  }
  get description() {
    return this.formGroup.get('description').value
  }

  get category() {
    return this.formGroup.get('category').value
  }

  addNote() {
    this.addSubscription = this.noteService.addNote({
      id: 'ID1',
      title: this.title,
      description: this.description,
      color: 'yellow',
      category: this.category,
      categoryId: this.category.id,
    })
  }
}
