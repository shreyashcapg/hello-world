import { Injectable, RootRenderer } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Hotels} from '../Models/Hotels';
import { MyBookings } from '../Models/Mybookings';

@Injectable
(
    {
        providedIn:'root'
    }
)
export class DestinationService 
{
    constructor(private httpClient:HttpClient)
{
    
}

GetHotelsByDestination(location:string): Observable<Hotels[]>
{
  return this.httpClient.get<Hotels[]>(`/api/hotels?location=${location}`);
}

AddBookingstoList(mbookings:MyBookings): Observable<boolean>
{
    return this.httpClient.post<boolean>(`/api/mybookings`,mbookings);
}

}
