import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AddNoteComponent } from './components/add-note/add-note.component'
import { EditNoteComponent } from './components/edit-note/edit-note.component'
import { HomeComponent } from './components/home/home.component'

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'add-note', component: AddNoteComponent },
  { path: 'add-note/:id', component: AddNoteComponent },
  { path: 'edit-note/:id', component: EditNoteComponent },
  { path: '**', redirectTo: '' },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
