import { SearchParams } from './../search/search-params'
import { Component, OnInit } from '@angular/core'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  categoryId: string
  searchParams: SearchParams
  constructor() {}

  ngOnInit(): void {}

  receiveCategory(categId: string) {
    this.categoryId = categId
  }

  receiveSearchParams(searchParams: SearchParams) {
    this.searchParams = searchParams
  }
}
