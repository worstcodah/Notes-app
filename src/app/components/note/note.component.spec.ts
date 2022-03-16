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

describe('NoteComponent', () => {
  let component: NoteComponent
  let fixture: ComponentFixture<NoteComponent>

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [NoteComponent],
      imports: [HttpClientTestingModule, RouterTestingModule, MatIconModule],
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
})
