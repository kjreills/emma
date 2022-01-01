import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.scss']
})
export class EmployeeEditComponent implements OnInit {

  private isCreateMode: boolean = false;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    
  }

}
