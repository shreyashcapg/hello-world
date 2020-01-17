import { Injectable, RootRenderer } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Hotels} from '../Models/Hotels';


@Injectable
(
    {
        providedIn:'root'
    }
)


export class Hotelbookingservice
{
    constructor(private httpClient:HttpClient)
{

}
    
    Showhotels(destination:string):Observable<any>
    {
        return this.httpClient.get(`/api/hotels?location=${destination}`);
    }
}
