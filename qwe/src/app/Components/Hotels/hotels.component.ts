import { Component, OnInit, ɵConsole } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Hotelbookingservice } from 'src/app/Services/Hotelbooking.service';
import { DataService } from 'src/app/Services/commondataservice';
import { Hotels } from 'src/app/Models/Hotels';
import { MyBookings } from 'src/app/Models/Mybookings';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { MybookingsServices } from 'src/app/Services/mybookingsservices';
// import { clearScreenDown } from 'readline';
import {Config} from '../../../app/Services/Content/Config';

@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.scss']
})

export class HotelsComponent implements OnInit
{
  MinDateCheckIn: Date;
  MaxDateCheckIn: Date;
  MinDateCheckOut:Date;
  MaxDateCheckOut:Date;

  Disabledvalue:boolean = false;
  error:any={isError:false,errorMessage:''};


  mybookings:MyBookings={id:5,Checkin:"10",Checkout:"11",Destination:"Pune",Rooms:"10",Price:""};
  b1:MyBookings;
  hoteldetails: FormGroup;
  location:string='';
  Hotelformmessage: any;
  valid:boolean=true;


  constructor(public hotelbookingservice: Hotelbookingservice,private router: Router,private data:DataService,
    private config:Config) 
  {

    console.log(this.config.Data.MaxDateCheckOut)
    this.hoteldetails = new FormGroup(
      {
        Checkin: new FormControl(null,[Validators.required]),
        Checkout: new FormControl(null,[Validators.required]),
        Destination: new FormControl(null,[Validators.required])
      });

      this.Hotelformmessage =
      {
        Checkin:{required:"Select check in date"},
        Checkout:{required:"Select check out date"}
      }
      this.MinDateCheckIn = new Date();
      this.MaxDateCheckOut = new Date();
      this.MaxDateCheckIn = new Date();
      this.MinDateCheckOut = new Date();
      this.MinDateCheckOut.setDate(this.MinDateCheckOut.getDate());
      this.MinDateCheckIn.setDate(this.MinDateCheckIn.getDate());
      this.MaxDateCheckOut.setDate(this.MaxDateCheckOut.getDate() + 31);
      this.MaxDateCheckIn.setDate(this.MaxDateCheckIn.getDate()+30);

  }
    // Function to compare the two Dates
    // Gets Triggered when user selects checkout date
  compareTwoDates()
  {
 

     if(new Date(this.hoteldetails.value.Checkout) < new Date(this.hoteldetails.value.Checkin))
     {
      this.Disabledvalue=true;
        this.error={isError:true,errorMessage:'Check out must be same day or  atleast 1 day ahead'};
     }
     else if(new Date(this.hoteldetails.value.Checkout) == new Date(this.hoteldetails.value.Checkin))
     {
      this.Disabledvalue=true;
      this.error={isError:true,errorMessage:'Check out must be same day or  atleast 1 day ahead'};
     }

      else{
        this.Disabledvalue=false;
        this.error={isError:false,errorMessage:''};
      }
  }
      // Function to compare the two Dates
    // Gets Triggered when user selects checkin date
  compareTwoDatescheckin()
  {

    


     if(new Date(this.hoteldetails.value.Checkout) < new Date(this.hoteldetails.value.Checkin))
     {
      var d = String(this.hoteldetails.value.Checkout);
      d = d.split('T')[0];
      this.hoteldetails.value.Checkout = d;
  
      var e = String(this.hoteldetails.value.Checkin);
      e = e.split('T')[0];
      this.hoteldetails.value.Checkin = e;
        console.log(e);
        if(d==e)
            {
              this.Disabledvalue=true;
              this.error={isError:true,errorMessage:'Check out must be same day or  atleast 1 day ahead'};
            }
            else
            {
              console.log(e);
              this.Disabledvalue=true;
              this.error={isError:true,errorMessage:'Check out must be same day or  atleast 1 day ahead'};
            }

    
     }
      else{
        this.Disabledvalue=false;
        this.error={isError:false,errorMessage:''};
      }
    }

    // Function to take input from the drop clearScreenDown
    // It takes selected value from dropdown and puts in the variable
  selectChangeHandler (event: any)
   {
    this.location = event.target.value;
    this.valid=true;   
  }

  ngOnInit()
  {
  }

  // Function which gets executed when the user clicks on Get Hotels Button
  // It calls the function from the service and navigates to the Destination component
onSubmit()
{
  this.hoteldetails["submitted"] = true;

  if(this.hoteldetails.valid==true)
  {
    this.hotelbookingservice.Showhotels(this.location).subscribe(
      (response) =>
      {
        if(response!=null && response.length>0)
        {
          this.mybookings.Checkin = this.hoteldetails.value.Checkin;
          this.mybookings.Checkout = this.hoteldetails.value.Checkout;
          this.mybookings.Destination = this.location;
          this.data.changeMessage(this.location);
          this.data.Bookings(this.mybookings);
          this.router.navigate( [ "/destinations"] );
        }
      },
      (error) =>
      {
        console.log(error);
      }
    );
        console.log("Works");
  } 
}
}


