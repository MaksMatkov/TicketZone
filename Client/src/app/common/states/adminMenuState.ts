import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class AdminMenuState {
    needApproveUsersCount: number = 0;
}