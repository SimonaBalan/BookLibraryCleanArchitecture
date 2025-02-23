import { Component } from '@angular/core';

@Component({
  selector: 'app-not-found',
  standalone: false,
  templateUrl: './not-found.component.html',
  styleUrl: './not-found.component.css'
})
export class NotFoundComponent {
  public notFoundText: string = `404 SORRY COULDN'T FIND IT!!!`

  constructor() { }

  ngOnInit(): void {
  }
}
