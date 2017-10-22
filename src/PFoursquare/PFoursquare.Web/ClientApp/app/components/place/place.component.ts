import { Component, OnInit, Input } from "@angular/core";
import { Router } from "@angular/router";
import { Title } from '@angular/platform-browser';
import { Observable, Subscription } from "rxjs/Rx";

import { Venue } from './../../shared/models/venue.model';
import { Search } from '../../shared/models/search.model';

import { MainService } from '../main/main.service';

@Component({
    selector: 'place',
    templateUrl: './place.component.html',
    styleUrls: ['./place.component.css']
})
export class PlaceComponent implements OnInit {
    @Input('Search') search: Search;

    venues: Venue[];
    isShowDetail: boolean = false;
    placeId: string;

    constructor(private title: Title, private mainService: MainService) {
        title.setTitle("");
    }

    ngOnInit(): void {
        this.mainService.search(this.search)
            .subscribe(data => {
                if (data) {
                    this.venues = data;
                }
            },
            error => {

            });
    }

    showDetail(venue: Venue) {
        this.placeId = venue.Id;
    }
}
