import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'ProductCard',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {

  @Input() title: string = '';
  @Input() description: string = '';
  @Input() imgPath: string = ''; 

  constructor() { }

  ngOnInit(): void {
  }

}
