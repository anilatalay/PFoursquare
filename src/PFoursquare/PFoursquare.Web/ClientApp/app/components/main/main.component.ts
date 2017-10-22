import { Component, OnInit, ViewChild, ViewChildren, QueryList } from "@angular/core";
import { Router } from "@angular/router";
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Observable, Subscription } from "rxjs/Rx";

import { MainService } from './main.service';

import { Category } from '../../shared/models/category.model';
import { Main } from '../../shared/models/main.model';
import { Search } from '../../shared/models/search.model';

@Component({
    selector: 'main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.css'],
    providers: [MainService]
})
export class MainComponent implements OnInit {
    myForm: FormGroup;
    submitted: boolean;
    isShowModel: boolean = false;
    isSearchCompleted: boolean = false;
    searcher: Search;

    categories: Array<Category> = [];

    constructor(private title: Title, private mainService: MainService, private formBuilder: FormBuilder) {
        title.setTitle("");
    }

    ngOnInit(): void {
        this.buildForm();
    }

    buildForm() {
        this.myForm = this.formBuilder.group({
            categoryId: ['', [<any>Validators.required, <any>Validators.minLength(3)]],
            place: ['',]
        });
    }

    search(model: Main, isValid: boolean) {
        if (!isValid) {
            this.isShowModel = true;
            console.log("modal çıkar");
        } else {
            this.isShowModel = false;

            this.mainService.getCategories()
                .subscribe(data => {
                    if (data) {
                        this.categories = data;
                    }
                },
                error => {

                });

            let cat = this.categories.find(x => x.Id == model.CategoryId);
            if (cat != undefined) {
                this.searcher.CategoryId = cat.Id;
                if (model.Search == "") {
                    // TODO: Tarayıcıdan Konum Çeken Kodu Ekle
                    this.searcher.Location = "";
                } else {
                    this.searcher.Area = model.Search;
                }

                this.isSearchCompleted = true;
            }
        }

        console.log(model, isValid);
    }

    onlyAlfabet($event: any) {
        if ($event.charCode > 47 && $event.charCode < 58) {
            return false;
        }
    }
}
