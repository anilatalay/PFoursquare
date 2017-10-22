import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { MainComponent } from './components/main/main.component';
import { PlaceComponent } from './components/place/place.component';
import { PlaceDetailComponent } from './components/place-detail/place-detail.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        MainComponent,
        PlaceComponent,
        PlaceDetailComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'main', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'main', component: MainComponent },
            { path: '**', redirectTo: 'main' }
        ])
    ]
})
export class AppModuleShared {
}
