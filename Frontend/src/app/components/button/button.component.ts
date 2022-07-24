import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'CustomButton',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {

  @Input() type: string = "";
  @Input() title: string = "";
  @Input() disabled: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
