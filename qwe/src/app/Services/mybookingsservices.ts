import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { MyBookings } from '../Models/Mybookings';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable
(
    {
        providedIn:'root'
    }
)

export class MybookingsServices
{
    constructor(private httpClient:HttpClient)
    {
       
    }
    GetAllBookings(): Observable<MyBookings[]>
    {  
        return this.httpClient.get<MyBookings[]>(`/api/mybookings`);     
    }
}