import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'CustomButtom',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {

  @Input() type: string = "";
  @Input() title: string = "";

  constructor() { }

  ngOnInit(): void {
  }

}