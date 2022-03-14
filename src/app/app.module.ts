import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { NoteComponent } from './components/note/note.component'
import { ToolsComponent } from './components/tools/tools.component'
import { MatInputModule } from '@angular/material/input'
import { MatFormFieldModule } from '@angular/material/form-field'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AddValuePipe } from './pipes/add-value.pipe'
import { MatCardModule } from '@angular/material/card'
import { FilterComponent } from './components/filter/filter.component'
import { HomeComponent } from './components/home/home.component'
import { AddNoteComponent } from './components/add-note/add-note.component'
import { BackgroundDirective } from './directives/background.directive'
import { MatSelectModule } from '@angular/material/select'
import { SearchComponent } from './components/search/search.component'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { HttpMockApiInterceptor } from './services/http-mock-api.interceptor'
@NgModule({
  declarations: [
    AppComponent,
    NoteComponent,
    ToolsComponent,
    AddValuePipe,
    FilterComponent,
    HomeComponent,
    AddNoteComponent,
    BackgroundDirective,
    SearchComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    FormsModule,
    MatCardModule,
    ReactiveFormsModule,
    MatSelectModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpMockApiInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
