import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions, ResponseContentType } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";

import { BaseService } from './../../shared/services/base.service';

import { Category } from '../../shared/models/category.model';
import { Search } from './../../shared/models/search.model';
import { Venue } from '../../shared/models/venue.model';

@Injectable()
export class MainService extends BaseService {
    private headers = new Headers();
    private headerKey = "Auth-Token";
    private headerValue = "B91F06CB-BD21-4867-9C35-DB49FD167993";

    constructor(private http: Http) {
        super();
        // Middleware yazılabilir
        this.headers.append(this.headerKey, this.headerValue);
    }

    getCategories(): Observable<Category[]> {
        var data = this.http.get("http://localhost:60124/v1/Venues", { headers: this.headers} )
            .map(res => {
                let body = res.json();
                let categories: Category[] = [];

                if (body.Data && body.Code == 200) {
                    categories = body.Data;
                }

                return categories;
            })
            .catch(super.handleError);

        return data;
    }

    search(search: Search): Observable<Category[]> {
        var data = this.http.post("http://localhost:60124/v1/Venues/Search/", search, { headers: this.headers})
        .map(res => {
            let body = res.json();
            let categories: Category[] = [];

            if (body.Data && body.Code == 200) {
                categories = body.Data;
            }

            return categories;
        })
        .catch(super.handleError);

    return data;
    }

    details(id: string): Observable<Venue> {
        var data = this.http.get(`http://localhost:60124/v1/Venues/${id}`, { headers: this.headers})
            .map(res => {
                let body = res.json();

                return body.Data;;
            })
            .catch(super.handleError);

        return data;
    }
}