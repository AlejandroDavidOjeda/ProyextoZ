import { Component } from '@angular/core';
import { CategoriaService } from './api/services';
import { Categoria } from './api/models/categoria-view';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'FrontEnd';
  public categoria: Categoria[];

  public constructor(private api: CategoriaService) {
    this.categoria = [];
    this.api.apiCategoriaGet$Json({Id: 1}).subscribe(x => {
      this.categoria = x;
    });
  }
}
