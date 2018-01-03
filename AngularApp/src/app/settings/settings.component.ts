import { Component, OnInit } from '@angular/core';
import { AppSettingsService } from '../shared/appsettings.service';
import { AppSettings } from '../shared/appsettings';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'settings',
    templateUrl: 'settings.component.html'
})

export class SettingsComponent implements OnInit {
    constructor(private appSettingsService: AppSettingsService) { }

    settings: AppSettings;

    ngOnInit() {
        this.appSettingsService.getSettings().subscribe(settings => this.settings = settings);
    }

    saveSettings(): void {
        this.appSettingsService.saveSettings(this.settings);
    }

    deleteSettings() : void {
        this.appSettingsService.deleteSettings();
        this.appSettingsService.getSettings().subscribe(settings => this.settings = settings);
    }

}