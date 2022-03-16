import { HttpClientTestingModule } from '@angular/common/http/testing'
import { forwardRef } from '@angular/core'
import { ComponentFixture, TestBed } from '@angular/core/testing'
import {
  FormsModule,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from '@angular/forms'
import { MatButtonModule } from '@angular/material/button'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatSelect, MatSelectModule } from '@angular/material/select'
import { BrowserModule } from '@angular/platform-browser'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { RouterTestingModule } from '@angular/router/testing'
import { AddNoteComponent } from './add-note.component'

describe('AddNoteComponent', () => {
  let component: AddNoteComponent
  let fixture: ComponentFixture<AddNoteComponent>

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddNoteComponent],
      imports: [
        HttpClientTestingModule,
        RouterTestingModule,
        ReactiveFormsModule,
        FormsModule,
        MatInputModule,
        MatFormFieldModule,
        MatButtonModule,
        MatSelectModule,
        BrowserAnimationsModule,
        BrowserModule,
      ],
    }).compileComponents()
  })

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNoteComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  afterEach(() => {
    fixture.destroy()
  })

  it('should create', () => {
    //debugger
    expect(component).toBeTruthy()
  })

  it('form should be invalid', () => {
    //debugger
    component.formGroup.get('title').setValue('')
    component.formGroup.get('description').setValue('')
    expect(component.formGroup.valid).toBeFalsy()
  })
  it('form should be valid', () => {
    //debugger
    component.formGroup.get('title').setValue('title')
    component.formGroup.get('description').setValue('description')
    component.formGroup.get('category').setValue('To Do')
    expect(component.formGroup.valid).toBeTruthy()
  })

  describe('control getters', () => {
    it('should return title control', () => {
      const control = component.formGroup.controls['title']
      expect(control).toBeTruthy()
    })

    it('should return description control', () => {
      const control = component.formGroup.controls['description']
      expect(control).toBeTruthy()
    })
    it('should return category control', () => {
      const control = component.formGroup.controls['category']
      expect(control).toBeTruthy()
    })
  })
})
