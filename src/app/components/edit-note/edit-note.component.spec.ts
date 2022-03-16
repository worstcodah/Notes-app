import { HttpClientModule } from '@angular/common/http'
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { ComponentFixture, TestBed } from '@angular/core/testing'
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms'
import { MatButtonModule } from '@angular/material/button'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select'
import { BrowserModule } from '@angular/platform-browser'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { RouterTestingModule } from '@angular/router/testing'
import { EMPTY, Observable, of, Subscription } from 'rxjs'
import { NoteService } from 'src/app/services/note.service'
import { Note } from '../note/note'

import { EditNoteComponent } from './edit-note.component'

describe('EditNoteComponent', () => {
  let component: EditNoteComponent
  let fixture: ComponentFixture<EditNoteComponent>

  const obj = of({
    id: 'ID',
    categoryId: '2',
    color: 'asd',
    description: 'desc',
    title: 'title',
  })
  beforeEach(async () => {
    const mockNoteService: NoteService = <any>{
      editNote() {
        return 'note'
      },
      getNote() {
        return obj
      },
    }
    await TestBed.configureTestingModule({
      declarations: [EditNoteComponent],
      imports: [
        HttpClientTestingModule,
        ReactiveFormsModule,
        RouterTestingModule,
        FormsModule,
        MatInputModule,
        MatFormFieldModule,
        MatButtonModule,
        MatSelectModule,
        BrowserAnimationsModule,
        BrowserModule,
      ],
      providers: [{ provide: NoteService, useFactory: () => mockNoteService }],
    }).compileComponents()
  })

  beforeEach(() => {
    fixture = TestBed.createComponent(EditNoteComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  afterEach(() => {
    fixture.destroy()
  })

  it('should create', () => {
    debugger
    expect(component).toBeTruthy()
  })

  it('filters getter', () => {
    expect(component.categories).toEqual([
      { id: '1', name: 'To Do' },
      { id: '2', name: 'Doing' },
      { id: '3', name: 'Done' },
    ])
  })

  fit('edit note', () => {
    const mockNoteService: NoteService = TestBed.inject(NoteService)
    let sub: Subscription

    spyOnProperty(component.selectedNote, 'id', 'get').and.returnValue('val')
    const spy = spyOn(mockNoteService, 'editNote').and.returnValue(sub)
    spyOn(mockNoteService, 'getNote').and.returnValue(obj)

    component.editNote()

    expect(spy).toHaveBeenCalledTimes(1)
  })
})
