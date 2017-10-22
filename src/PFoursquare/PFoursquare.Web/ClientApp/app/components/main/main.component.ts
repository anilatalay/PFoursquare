import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Title } from '@angular/platform-browser';
import { Observable, Subscription } from "rxjs/Rx";

import { MainService } from './main.service';

@Component({
    selector: 'main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.css'],
    providers: [MainService]
})
export class MainComponent implements OnInit {
    constructor(private title: Title) {
        title.setTitle("");
    }

    ngOnInit(): void {
    }
}
