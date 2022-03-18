import { Subscription } from 'rxjs'
import { MatIconModule } from '@angular/material/icon'
/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing'
import { By } from '@angular/platform-browser'
import { DebugElement } from '@angular/core'
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing'

import { NoteComponent } from './note.component'
import { RouterTestingModule } from '@angular/router/testing'
import { NoteService } from 'src/app/services/note.service'
import { Note } from './note'

describe('NoteComponent', () => {
  let component: NoteComponent
  let fixture: ComponentFixture<NoteComponent>

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [NoteComponent],
      imports: [HttpClientTestingModule, RouterTestingModule, MatIconModule],
      providers: [NoteService],
    }).compileComponents()
  }))

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })

  it('remove note', () => {
    /*
    const mockService: NoteService = TestBed.inject(NoteService)
    let sub: Subscription
    let note: Note = {}

    const spy = spyOn(mockService, 'removeNote').and.returnValue(sub)
    component.removeNote()
*/
  })
})
