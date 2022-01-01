import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable()
export class EmployeeService {
    
    constructor(private http: HttpClient) { }

    public getById(id: number) {
        return this.http.get<Employee>(`${environment.apiUrl}/employees/${id}`);
    }

    public getAll(): Observable<Employee[]> {
        return this.http.get<Employee[]>(`${environment.apiUrl}/employees`);
    }

    public getDepartments(): Observable<Department[]> {
        return this.http.get<Department[]>(`${environment.apiUrl}/departments`);
    }

    public getDesignations(): Observable<Designation[]> {
        return this.http.get<Designation[]>(`${environment.apiUrl}/designations`);
    }

    public create(employee: Employee): Observable<Employee> {
        return this.http.post<Employee>(`${environment.apiUrl}/employees`, employee);
    }

    public update(employee: Employee): Observable<Employee> {
        return this.http.put<Employee>(`${environment.apiUrl}/employees/${employee.id}`, employee);
    }

    public delete(id: number) {
        return this.http.delete(`${environment.apiUrl}/employees/${id}`);
    }
}

export interface Employee {
    id: number;
    firstName: string;
    lastName: string;
    birthDate: Date;
    hireDate: Date;
    salary: number;
    department: Department;
    designation: Designation;
}

export interface Department {
    id: number;
    name: string;
}

export interface Designation {
    id: number;
    title: string;
}
