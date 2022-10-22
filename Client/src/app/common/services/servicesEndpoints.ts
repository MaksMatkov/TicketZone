import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class AuthDaSettings {
    static signInEndpointUrl: string = 'Authentication/login';
    static filmsEndpoint: string = 'Films'
    
}