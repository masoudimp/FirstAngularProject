import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//Angular Material Start
import { MatButtonModule } from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatListModule} from '@angular/material/list';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
//Angular Material End

import { AppComponent } from './app.component';

import { QuestionComponent } from './question.component';
import { QuestionsComponent } from './questions.Component';
import { HomeComponent } from './home.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule } from '@angular/forms';

import { ApiService } from './api.service';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

const appRoute: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'question', component: QuestionComponent},
  {path: 'questions', component: QuestionsComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    QuestionComponent,
    QuestionsComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(appRoute),
    BrowserAnimationsModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatSlideToggleModule,
    HttpClientModule,
    MatListModule,
    MatSidenavModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
