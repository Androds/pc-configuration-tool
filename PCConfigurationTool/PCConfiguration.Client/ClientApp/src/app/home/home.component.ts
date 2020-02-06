import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public cases: ICase[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ICase[]>(baseUrl + 'case').subscribe(result => {
      console.log(result);
        this.cases = result;
      }, error => console.error(error));
  }
}

interface ICase {
  id: number;
  name: string;
  price: number;
  color: string;
  powerSupply: boolean;
  window: boolean;
  externalBays: number;
  internalBays: number;
  quantity: number;
  typeId: number;
  type: string;
  ImageSrc: string;
}
