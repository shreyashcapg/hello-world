import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import {Hotels} from '../Models/Hotels';
import { Type } from '@angular/compiler';
import { MyBookings } from '../Models/Mybookings';

@Injectable()
export class DataService 
{

  mybook:MyBookings;
  private messageSource = new BehaviorSubject('default message');
  currentMessage = this.messageSource.asObservable();

  private object = new BehaviorSubject(this.mybook);
  currentobj = this.object.asObservable();

  constructor() { }

  changeMessage(message: string)
  {
    this.messageSource.next(message)
  }

 Bookings(bookings:MyBookings)
 {
   this.object.next(bookings);
 }

}