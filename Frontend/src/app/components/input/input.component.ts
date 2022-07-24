import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'Input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss']
})
export class InputComponent implements OnInit {

  @Input() id: string = '';
  @Input() type: string = '';
  @Input() placeholder: string = '';
  @Input() disabled: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
