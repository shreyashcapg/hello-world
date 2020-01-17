import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HotelsComponent } from './Components/Hotels/hotels.component';
import { Destinations } from './Components/Hotels/Destinations/destinations.component';
import { ShowBookings } from './Components/Hotels/Showbookings/showbookings.component';


const routes: Routes = [
  { 
path: "hotels", component: HotelsComponent },
{path:"destinations",component:Destinations},
{path:"showbookings",component:ShowBookings}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
