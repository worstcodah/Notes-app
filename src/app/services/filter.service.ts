import { Injectable } from '@angular/core'
import { Category } from '../components/filter/category'

@Injectable({
  providedIn: 'root',
})
export class FilterService {
  private filters: Category[] = [
    { id: '1', name: 'To Do' },
    { id: '2', name: 'Doing' },
    { id: '3', name: 'Done' },
  ]
  constructor() {}
  getFilters() {
    return this.filters
  }
}
