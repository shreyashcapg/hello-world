import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/Services/commondataservice';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { DestinationService } from 'src/app/Services/destinationservices';
import { Hotels } from 'src/app/Models/Hotels';
import { MyBookings } from 'src/app/Models/Mybookings';
import { MybookingsServices } from 'src/app/Services/mybookingsservices';


@Component({
  selector: 'app-showbookings',
  templateUrl: './showbookings.component.html',
  styleUrls: ['./showbookings.component.scss']
})
export class ShowBookings implements OnInit
{

  
   mybookings:MyBookings[] = [];
    constructor(private mybookingsservice:MybookingsServices)
    {
     
    }
    ngOnInit()
    {
        this.mybookingsservice.GetAllBookings().subscribe
        (
         
            (response) =>
            {
              if(response!=null && response.length>0)
              {
               this.mybookings = response;    
               for(var i=2;i<this.mybookings.length;i++)
               {
                var d = this.mybookings[i].Checkin;
                d = d.split('T')[0];
                this.mybookings[i].Checkin = d;

                var e = this.mybookings[i].Checkout;
                e = e.split('T')[0];
                this.mybookings[i].Checkout = e;

                if(this.mybookings[i].Checkin == this.mybookings[i].Checkout )
                {
                  console.log("Works");
                }
               }
                   
              }
            },
            (error) =>
            {
              console.log(error);
            }
          );

    }

    
}