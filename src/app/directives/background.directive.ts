import { Directive, ElementRef, Input } from '@angular/core'

@Directive({
  selector: '[background]',
})
export class BackgroundDirective {
  @Input() inputColor: string = ''
  constructor(private elementRef: ElementRef) {}

  ngAfterViewInit(): void {
    this.elementRef.nativeElement.style.background = this.inputColor
  }
}
