import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { DataService } from 'src/app/Services/commondataservice';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { DestinationService } from 'src/app/Services/destinationservices';
import { Hotels } from 'src/app/Models/Hotels';
import { MyBookings } from 'src/app/Models/Mybookings';
import * as $ from "jquery";
import { strictEqual } from 'assert';

@Component({
    selector: 'app-destinations',
    templateUrl: './destinations.component.html',
    styleUrls: ['./destinations.component.scss']
  })

export class Destinations implements OnInit 
{
  mybookingsform:FormGroup;
    bookings:MyBookings={id:1,Checkin:"",Checkout:"",Destination:"",Rooms:"",Price:""};
    location:string;
    hotels:Hotels[] = [];
    roomsmessage:boolean =false;
    confirmbookingdisabled:boolean = false;
    Promocode:boolean = false;
    Finalprice:boolean = false;
    Hotelprice:string;
    Tempprice:string;
    Temptotalprice:string;
    Days:string;

constructor(private router :Router,private data: DataService,private source:DestinationService )
{
  this.data.currentMessage.subscribe(message => this.location = message)
  this.data.currentobj.subscribe(message1 =>  this.bookings=message1)
  if (typeof(this.bookings) == 'undefined')
   {
     console.log("Undefined");
    
  }
  this.mybookingsform = new FormGroup
  (
    {
    Rooms:new FormControl(null,[Validators.required]),
    Price:new FormControl(),
    Checkin: new FormControl(),
    Checkout: new FormControl(),
    Destination:new FormControl(),
    Promocode: new FormControl(),
    Totalprice: new FormControl()
  
  }
  );
}

ngOnInit()
{
  
  this.source.GetHotelsByDestination(this.location).subscribe
  (
    (response) =>
    {
      if(response!=null && response.length>0)
      {    
       this.hotels = response;    
      }
    },
    (error) =>
    {
      console.log(error);
    }
  );
}



selectChangeHandler (event: any)
   {
    this.bookings.Rooms = event.target.value;
    this.confirmbookingdisabled = false;
    this.roomsmessage = false; 
    console.log(this.Hotelprice)
    this.Temptotalprice = String(+this.Hotelprice*+event.target.value*+this.Days);
    this.mybookingsform.value.Totalprice = String(+this.Hotelprice*+event.target.value*+this.Days)
    console.log(this.mybookingsform.value.Totalprice)
    this.Finalprice = true; 
  }

  onBooknowClick(index)
  {
    
     var date2 = new Date(this.bookings.Checkout);
      var date1 = new Date(this.bookings.Checkin);
      var diff = (+date2 - +date1)  / 1000 / 60 / 60 / 24;
      var diff=Math.round(diff);
      if(diff==0)
      {
        diff=1;
      }
      console.log(diff);

      this.Days = String(diff);
     
     console.log(date2); 
    this.mybookingsform.reset();
    this.Hotelprice =this.hotels[index].price; 
    this.mybookingsform.patchValue
    (
      {
        Price:this.hotels[index].price,
        Checkin:this.bookings.Checkin,
        Checkout:this.bookings.Checkout,
      
      }
    );
  }
  Seecode()
  {
    
    if(this.mybookingsform.value.Promocode=="FLAT500" )
    {
      this.Promocode =true;
      this.Tempprice = this.Temptotalprice;
      this.mybookingsform.value.Totalprice = String(+this.Temptotalprice - 500); 
    }
    else
    {
      this.Promocode =false;
      this.mybookingsform.value.Totalprice = this.Tempprice;

    }
   
  }

  onConfirmBookingClick(event)
  {
    if(this.mybookingsform.valid==true)
    {
      var newbookingvalue: MyBookings = this.mybookingsform.value;
      if(this.mybookingsform.value.Promocode == "FLAT500")
      {
        this.Promocode =true;
        newbookingvalue.Rooms=this.bookings.Rooms;
        newbookingvalue.Price = String(+newbookingvalue.Price*+newbookingvalue.Rooms*+this.Days);
        newbookingvalue.Price = String(+newbookingvalue.Price - 500);

        newbookingvalue.Destination = this.location;     
      }
      else
      {      
        newbookingvalue.Rooms=this.bookings.Rooms;
        newbookingvalue.Price = String(+newbookingvalue.Price*+newbookingvalue.Rooms*+this.Days);
        newbookingvalue.Destination = this.location; 

      }
      this.source.AddBookingstoList(newbookingvalue).subscribe((addResponse) =>
        {
          console.log(addResponse);
          $("#btnconfirmbookingcancel").trigger("click");        
  if(addResponse==true)
          {                  
          }
        },
        (error) =>
        {       
          console.log(error);
        }
      );
    }
    else
    { 
      this.confirmbookingdisabled = true;
      this.roomsmessage = true;      
    }  

  } 

}