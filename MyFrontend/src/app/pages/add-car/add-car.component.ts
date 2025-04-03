import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Car } from '../../model/car';
import { CarService } from '../../service/car.service';

@Component({
  selector: 'app-add-car',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-car.component.html',
  styleUrl: './add-car.component.css',
})
export class AddCarComponent {
  carForm: FormGroup;
  id: number = 0;

  constructor(private fb: FormBuilder, private carService: CarService) {
    this.carForm = this.fb.group({
      brand: ['', Validators.required],
      model: ['', Validators.required],
      year: ['', Validators.required],
      type: ['Diesel', Validators.required],
    });
  }

  addCar() {
    if (this.carForm.valid) {
      this.id++;
      const newCar: Car = {
        id: this.id,
        brand: this.carForm.value.brand,
        model: this.carForm.value.model,
        year: this.carForm.value.year,
        fuelType: this.carForm.value.type,
      };
      console.log(newCar);
      this.carService.addCar(newCar).subscribe();
    }
  }
}
