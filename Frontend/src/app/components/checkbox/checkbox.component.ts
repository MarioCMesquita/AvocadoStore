import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'Checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss']
})
export class CheckboxComponent implements OnInit {

  @Input() id: string = '';
  @Input() title: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
