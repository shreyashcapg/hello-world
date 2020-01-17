import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import {Hotels} from '../Models/Hotels';
import { MyBookings } from '../Models/Mybookings';

@Injectable({
    providedIn: 'root'
  })

  export class TravelPlannerDataService implements InMemoryDbService
{
  constructor() { }

  createDb()
  {
    let hotels = [
      new Hotels('Goa','3000','20','Relaxo'),
      new Hotels('Goa','3500','10','Dona Resort'),
      new Hotels('Goa','3800','40','Marquis Beach Resort'),
      new Hotels('Goa','4000','20','Ronil Resort')
    ];

    let mybookings = [
      new MyBookings (3,"Temp","Temp","Goa","30","3000"),
      new MyBookings (4,"Temp","Temp","Goa","30","3500")
     ];
    
    return {hotels,mybookings };
  }
}


