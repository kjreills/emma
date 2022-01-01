import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Employee, EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit, OnDestroy {
  private subscriptions: Subscription[] = []; 
  private _employees: Employee[] = [];

  public displayedColumns: string[] = ['id', 'name', 'department', 'title', 'salary', 'birthDate', 'hireDate'];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.subscriptions.push(
      this.employeeService.getAll().subscribe(x => this._employees = x));
  }

  ngOnDestroy(): void {
    for (let sub of this.subscriptions) {
      sub.unsubscribe();
    }
  }

  public get employees() {
    return this._employees;
  }
}
