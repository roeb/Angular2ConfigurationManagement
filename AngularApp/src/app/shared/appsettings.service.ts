import { Injectable } from '@angular/core';
//import { Observable } from 'rxjs/Observable';
import { Observable } from "rxjs/Rx";
import { AppSettings } from './appsettings';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { tap } from 'rxjs/operators/tap';
import { JsonpCallbackContext } from '@angular/common/http/src/jsonp';
import { transition } from '@angular/core/src/animation/dsl';

//const SETTINGS_LOCATION = "assets/appsettings.json"
const SETTINGS_LOCATION = "http://localhost:5000/api/Settings/Get";
const SETTINGS_KEY = "configuration";

@Injectable()
export class AppSettingsService {
    constructor(private httpClient: HttpClient) {

    }

    getSettings(): Observable<AppSettings> {
        let settings = localStorage.getItem(SETTINGS_KEY);
        if (settings) {
            let result: AppSettings = null;
            result = JSON.parse(settings);
            result.isFromLocalStorage = true; 

            return Observable.of(result);
        }
        else {
            return this.httpClient.get<AppSettings>(SETTINGS_LOCATION)
                .pipe(
                tap(settings => {
                    if (settings) {
                        this.saveSettings(settings);
                    }
                }),
                catchError(this.handleError<AppSettings>("getSettings", new AppSettings()))
                );
        }
    }

    saveSettings(appSettings: AppSettings) {
        localStorage.setItem(SETTINGS_KEY, JSON.stringify(appSettings));
    }

    deleteSettings() : void {
        localStorage.removeItem(SETTINGS_KEY);
    }

    private handleError<T>(operation = 'operation', result: T) {
        return (error: any): Observable<T> => {
            switch (error.status) {
                case 404:
                    console.error("Can't find file: " + SETTINGS_LOCATION);
                    break;

                default:
                    console.error(error);
                    break;
            }

            return Observable.of(result as T);
        }
    }
}