import { Component, OnInit, ViewChild, ViewChildren, QueryList } from "@angular/core";
import { Router } from "@angular/router";
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Observable, Subscription } from "rxjs/Rx";

import { MainService } from './main.service';

import { Category } from '../../shared/models/category.model';

@Component({
    selector: 'main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.css'],
    providers: [MainService]
})
export class MainComponent implements OnInit {
    categories: Array<Category> = [];

    constructor(private title: Title, private mainService: MainService) {
        title.setTitle("");
    }

    ngOnInit(): void {
        this.categories = [];


        console.log("[this.categories]:");
        console.log(this.categories);
    }
}
