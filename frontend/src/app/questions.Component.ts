import { JsonPipe } from '@angular/common';
import { Component } from '@angular/core';
import { ApiService } from './api.service'

@Component({
  selector: "questions",
  templateUrl: './questions.component.html'
})

export class QuestionsComponent{

  questions: any;
  answerId!: number;
  questionId!: number;
  alert: any;

  constructor(private api: ApiService){}

  ngOnInit(){
    this.api.GetQuestion().subscribe(result => this.questions = result);
  }

  CheckAnswer(option: number, questionnn: number){
    this.api.GetAnswer(option).subscribe(res => alert(JSON.stringify(res)));
  }

}
