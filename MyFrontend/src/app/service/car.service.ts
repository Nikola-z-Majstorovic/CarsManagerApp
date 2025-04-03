import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../model/car';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private apiUrl = 'https://localhost:7129/api/cars';

  constructor(private http: HttpClient) {}

  getCars(): Observable<Car[]> {
    return this.http.get<Car[]>(this.apiUrl);
  }

  addCar(car: Car): Observable<void> {
    return this.http.post<void>(this.apiUrl, car);
  }

  deleteCar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
