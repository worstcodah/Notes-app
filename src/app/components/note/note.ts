import { Category } from './../filter/category'
export interface Note {
  id: string
  title: string
  description: string
  color: string
  category?: Category
  categoryId: string
}
