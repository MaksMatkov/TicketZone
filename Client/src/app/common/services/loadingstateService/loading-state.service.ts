import {Injectable} from '@angular/core';
import { LoadingState } from '../../states/loadingState';

@Injectable({
    providedIn: 'root'
})
export class LoadingStateService {

    constructor(private loadingState: LoadingState) {
    }

    get State(): LoadingState {
        return this.loadingState;
    }

    Show() {
        this.loadingState.Show = true;
    }

    Hide() {
        this.loadingState.Show = false;
    }
}
