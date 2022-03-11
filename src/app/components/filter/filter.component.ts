import { Component, EventEmitter, OnInit, Output } from '@angular/core'
import { FilterService } from 'src/app/services/filter.service'
import { Category } from './category'

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
})
export class FilterComponent implements OnInit {
  categories: Category[] = []
  @Output() emitSelectedFilter = new EventEmitter<string>()
  constructor(private filterService: FilterService) {}

  ngOnInit() {
    this.categories = this.filterService.getFilters()
  }

  selectFilter(categoryId: string) {
    this.emitSelectedFilter.emit(categoryId)
  }
}
