import { FuelTypes } from './enums/fuel-type';

export interface Car {
  id?: number;
  brand: string;
  model: string;
  year: number;
  fuelType: FuelTypes;
}
