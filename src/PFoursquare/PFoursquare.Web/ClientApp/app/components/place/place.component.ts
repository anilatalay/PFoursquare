import { Component, OnInit, ViewChild, ViewChildren, QueryList } from "@angular/core";
import { Router } from "@angular/router";
import { Title } from '@angular/platform-browser';
import { Observable, Subscription } from "rxjs/Rx";

@Component({
    templateUrl: './place.component.html',
    styleUrls: ['./place.component.css']
})
export class PlaceComponent implements OnInit {
    constructor(private title: Title) {
        title.setTitle("");
    }

    ngOnInit(): void {
    }
}
