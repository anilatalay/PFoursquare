import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    constructor(private _httpService: Http) { }

    ngOnInit() {
        this._httpService.get('https://jsonplaceholder.typicode.com/posts').subscribe(values => {
            console.log(values.json());
        });
    }
}