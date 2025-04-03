import { Component } from '@angular/core';
import { CarService } from '../../service/car.service';
import { Car } from '../../model/car';
import { CommonModule } from '@angular/common';
import { tap, catchError, of } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-car',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './car.component.html',
  styleUrl: './car.component.css',
})
export class CarComponent {
  cars: Car[] = [];
  constructor(private carService: CarService, private router: Router) {}

  ngOnInit() {
    this.loadCars();
  }

  loadCars() {
    this.carService
      .getCars()
      .pipe(
        tap((response) => console.log('Response:', response)),
        catchError((error) => {
          console.error('Error fetching cars:', error);
          return of([]);
        })
      )
      .subscribe((data) => {
        console.log(data);
        this.cars = data;
      });
  }

  addCar() {
    // if (this.newCar.brand && this.newCar.model) {
    //   this.carService.addCar(this.newCar).subscribe(() => {
    //     this.loadCars();
    //     this.newCar = {
    //       id: 0,
    //       brand: '',
    //       model: '',
    //       year: new Date().getFullYear(),
    //     };
    //   });
    // }
  }

  deleteCar(id: number) {
    this.carService.deleteCar(id).subscribe(() => this.loadCars());
  }

  goToAddCarForm() {
    this.router.navigate(['/add-car']); // Ruta ka formi
  }
}
