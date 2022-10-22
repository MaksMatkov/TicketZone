import { ViewingTimeLite } from "../viewingTimes/ViewingTimeLite";

export class Film {
    public id! : number;
    public name! : string;
    public description! : string;
    public posterUrl! : string;
    public trailerUrl! : string;

    public viewingTimes! : ViewingTimeLite[]; 
}