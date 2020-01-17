export class MyBookings
{
    id: number;
    Checkin: string;
    Checkout: string;
    Destination:string;
    Rooms:string;
    Price:string;
    constructor(ID:number,checkin:string,checkout:string,destination:string,rooms:string,price:string)
    {
        this.id = ID;
        this.Checkin = checkin;
        this.Checkout = checkout;
        this.Destination = destination;
        this.Rooms = rooms;
        this.Price = price;
    }
    
}
