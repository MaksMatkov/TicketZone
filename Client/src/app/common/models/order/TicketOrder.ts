import { Status } from "../../enums/Status";

export class TicketOrder{
    public id! : number;
    public userId! : number;
    public  FilmViewingTimeId! : number;
    public creationDate! : Date;
    public status! : Status;
}