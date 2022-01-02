import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { firstValueFrom } from 'rxjs';
import { Department, Designation, Employee, EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit, AfterViewInit {
  @ViewChild(MatSort) sort: MatSort = new MatSort();

  private _employees: Employee[] = [];
  public employeesDataSource = new MatTableDataSource<Employee>([]);

  public filterDepartmentId = 0;
  public filterDesignationId = 0;
  public filterSalaryMin: number | null = null;
  public filterSalaryMax: number | null = null;

  public departments: Department[] = [];
  public designations: Designation[] = [];

  public displayedColumns: string[] = ['id', 'firstName', 'lastName', 'department', 'title', 'salary', 'birthDate', 'hireDate', 'actions'];

  constructor(private employeeService: EmployeeService) { }

  public ngOnInit(): void {
    this.employeeService.getAll().subscribe(x => {
      this._employees = x;
      this.employeesDataSource.data = this._employees;
    });

    this.employeeService.getDepartments().subscribe(d => this.departments = d);
    this.employeeService.getDesignations().subscribe(d => this.designations = d);
  }

  public ngAfterViewInit() {
    this.employeesDataSource.sort = this.sort;
  }

  public delete(id: number) {
    firstValueFrom(this.employeeService.delete(id))
      .then(x => this._employees = this._employees.filter(x => x.id !== id))
      .then(x => this.employeesDataSource.data = this._employees);
  }

  public updateFilters() {
    this.employeesDataSource.filterPredicate = (employee, _) =>
      (this.filterDepartmentId === 0 || this.filterDepartmentId === employee.department.id) &&
      (this.filterDesignationId === 0 || this.filterDesignationId === employee.designation.id) &&
      (this.filterSalaryMin === null || this.filterSalaryMin <= employee.salary) &&
      (this.filterSalaryMax === null || this.filterSalaryMax >= employee.salary);

    // Bit of a hack to get changes to propagate to the data filtering loop
    this.employeesDataSource.filter = Math.random().toString();
  }
}
