import { Component, EventEmitter, OnInit, Output } from '@angular/core'
import { SearchParams } from './search-params'

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit {
  searchTerm: string
  searchType: string
  @Output() emitSearchTerm = new EventEmitter<SearchParams>()
  constructor() {}

  ngOnInit(): void {}

  emitSearch() {
    this.emitSearchTerm.emit({
      searchTerm: this.searchTerm,
      searchType: this.searchType,
    })
  }
}
