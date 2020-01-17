import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HotelsComponent } from './Components/Hotels/hotels.component';

import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import {TravelPlannerDataService} from './InMemoryWebApiServices/TravelPlannerdataservices';
import { Destinations } from './Components/Hotels/Destinations/destinations.component';
import { DataService } from './Services/commondataservice';
import { MyBookings } from './Models/Mybookings';
import { ShowBookings } from './Components/Hotels/Showbookings/showbookings.component';
import { DestinationService } from './Services/destinationservices';
import { Hotelbookingservice } from './Services/Hotelbooking.service';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Config } from './Services/Content/Config';

@NgModule({
  declarations: [
    AppComponent,
    HotelsComponent,
    Destinations,
    ShowBookings
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientInMemoryWebApiModule.forRoot(TravelPlannerDataService, { delay: 1000 }),
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule,
  ],
  providers: [DataService,DestinationService,Hotelbookingservice,TravelPlannerDataService, Config],   
  bootstrap: [AppComponent]
})
export class AppModule { }
