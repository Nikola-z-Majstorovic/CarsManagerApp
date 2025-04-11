import { Component } from '@angular/core';
import { CarService } from '../../service/car.service';
import { Car } from '../../model/car';
import { CommonModule } from '@angular/common';
import { tap, catchError, of } from 'rxjs';
import { Router } from '@angular/router';
import { FuelTypes } from '../../model/enums/fuel-type';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-car',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './car.component.html',
  styleUrl: './car.component.css',
})
export class CarComponent {
  cars: Car[] = [];
  newCar?: Car;

  yearFilter: number | null = null;
  fuelTypeFilter: FuelTypes | null = null;

  FuelTypes = FuelTypes;
  fuelTypeOptions = Object.values(FuelTypes);

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

  filterCars() {
    const params: any = {};
    if (this.yearFilter) params.year = this.yearFilter;
    if (this.fuelTypeFilter) params.fuelType = this.fuelTypeFilter;

    this.carService.getFilteredCars(params).subscribe((data) => {
      this.cars = data;
    });
  }

  deleteCar(id: number) {
    this.carService.deleteCar(id).subscribe(() => this.loadCars());
  }

  goToAddCarForm() {
    this.router.navigate(['/add-car']);
  }
}
