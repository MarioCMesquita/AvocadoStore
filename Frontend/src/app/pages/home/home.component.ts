import { Component, OnInit } from '@angular/core';

// Models
import { Product } from '../../models/product.model'
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {

  productList: Product[] = [
    {
      name: 'Maionese de Abacate',
      description: 'Maionese vegana feita com o extrato do abacate',
      imgPath: 'assets/maionese_abacate.png'
    },
    {
      name: 'Abacate de Pelúcia',
      description: 'Mascote de pelúcia feito de algodão e fibras sintéticas',
      imgPath: 'assets/pelucia_abacate.png'
    },
    {
      name: 'Creme de Abacate',
      description: 'Creme feito a base de abacate mexicano',
      imgPath: 'assets/pasta_abacate.png'
    },
    {
      name: 'Vitamina de Abacate',
      description: 'Vitamina antioxidante feita de abacate e leite',
      imgPath: 'assets/vitamina_abacate.png'
    },
    {
      name: 'Sorvete de Abacate',
      description: 'Sorvete italiano feito com abacate e hortelã',
      imgPath: 'assets/sorvete_abacate.png'
    },
    {
      name: 'Mochila de Abacate',
      description: 'Mochila de lona verde com desenhos de abacates',
      imgPath: 'assets/mochila_abacate.png'
    },
    {
      name: 'Guarda Chuva de Abacate',
      description: 'Guarda Chuva médio com material em alúminio e lona',
      imgPath: 'assets/guarda_chuva_abacate.png'
    },
    {
      name: 'Camiseta de Abacate',
      description: 'Camiseta Hawaiana de algodão estampada com abacates',
      imgPath: 'assets/camiseta_abacate.png'
    },
  ];

  ngOnInit(): void {}
}
