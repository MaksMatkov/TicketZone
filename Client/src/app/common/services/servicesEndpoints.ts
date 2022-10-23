import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class AuthDaSettings {
    static signInEndpointUrl: string = 'Authentication/login';
    static filmsEndpoint: string = 'Films';
    static usersEndpoint: string = 'Users';
    static roomsEndpoint: string = 'Rooms';
    static viewingTimeEndpoint: string = 'FilmViewingTimes';
    static ticketOrderEndpoint: string = 'TicketOrders';
}