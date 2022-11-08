import { Status } from "../../enums/Status";

export class TicketOrder{
    public id! : number;
    public userId! : number;
    public  filmViewingTimeId! : number;
    public filmName! : string;
    public roomNumber! : number;
    public userEmail! : string;
    public creationDate! : Date;
    public status! : Status;
}