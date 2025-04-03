import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuicklinkModule, QuicklinkStrategy } from 'ngx-quicklink';
import { CarComponent } from './pages/car/car.component';
import { AddCarComponent } from './pages/add-car/add-car.component';

export const routes: Routes = [
  {
    path: 'cars',
    component: CarComponent,
  },
  {
    path: 'add-car',
    component: AddCarComponent,
  },
];

@NgModule({
  imports: [
    QuicklinkModule,
    RouterModule.forRoot(routes, {
      preloadingStrategy: QuicklinkStrategy,
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
