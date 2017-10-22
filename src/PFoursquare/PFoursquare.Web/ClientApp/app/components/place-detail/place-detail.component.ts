import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { Title } from '@angular/platform-browser';
import { Observable, Subscription } from "rxjs/Rx";

import { Venue } from './../../shared/models/venue.model';

import { MainService } from '../main/main.service';

@Component({
    selector: 'place-detail',
    templateUrl: './place-detail.component.html',
    styleUrls: ['./place-detail.component.css']
})
export class PlaceDetailComponent implements OnInit {
    @Input('PlaceId') placeId: string;

    venueDetail: Venue;

    constructor(private title: Title, private mainService: MainService) {
        title.setTitle("");
    }

    ngOnInit(): void {
        this.mainService.details(this.placeId)
            .subscribe(data => {
                if (data) {
                    this.venueDetail = data;
                }
            },
            error => {

            });
    }
}
