import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { Department, Designation, Employee, EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.scss']
})
export class EmployeeCreateComponent implements OnInit {

  public firstName: string = '';
  public lastName: string = '';
  public birthDate: Date | null = null;
  public hireDate: Date | null = null;
  public salary: number = 0;
  public departmentId: number = 0;
  public designationId: number = 0;

  public departments: Department[] = [];
  public designations: Designation[] = [];

  constructor(private employeeService: EmployeeService, private router: Router) { }

  public ngOnInit(): void {
    this.employeeService.getDepartments().subscribe(d => this.departments = d);
    this.employeeService.getDesignations().subscribe(d => this.designations = d);
  }

  public submit(): void {
    let employee: Employee = {
      id: 0,
      firstName: this.firstName,
      lastName: this.lastName,
      birthDate: this.birthDate || new Date(),
      hireDate: this.hireDate || new Date(),
      salary: this.salary,
      department: this.departments.find(x => x.id == this.departmentId) || {id: 0, name: ''},
      designation: this.designations.find(x => x.id == this.designationId) || {id: 0, title: ''}
    }

    firstValueFrom(this.employeeService.create(employee)).then(x => this.router.navigate(["/"]));
    
  }
}
