import { Component, OnInit, ViewChild, ViewChildren, QueryList } from "@angular/core";
import { Router } from "@angular/router";
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Observable, Subscription } from "rxjs/Rx";

import { MainService } from './main.service';

import { Category } from '../../shared/models/category.model';
import { Main } from '../../shared/models/main.model';

@Component({
    selector: 'main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.css'],
    providers: [MainService]
})
export class MainComponent implements OnInit {
    myForm: FormGroup;
    submitted: boolean;
    isShowModel: boolean;

    categories: Array<Category> = [];

    constructor(private title: Title, private mainService: MainService, private formBuilder: FormBuilder) {
        title.setTitle("");
    }

    ngOnInit(): void {
        this.isShowModel = false;

        this.myForm = this.formBuilder.group({
            categoryId: ['', [<any>Validators.required, <any>Validators.minLength(3)]],
            place: ['', ]
        });
    }

    search(model: Main, isValid: boolean) {
        if(!isValid) {
            this.isShowModel = true;
            console.log("modal çıkar");
        } else {
            this.isShowModel = false;
        }

        console.log(model, isValid);
    }

    onlyAlfabet($event: any) {
        console.log($event.charCode);
        if($event.charCode > 47 && $event.charCode < 58) {
            return false;
        }
    }
}
