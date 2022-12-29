import { Component } from "@angular/core";
import { ApiService } from './api.service';

@Component({
  "selector" : "question",
  templateUrl : '\question.component.html'
})

export class QuestionComponent{

  constructor(private api: ApiService){}

  text: {question: string, correctAnswer: string, option1: string, option2: string, option3: string} = {
    question: "",
    correctAnswer: "",
    option1: "",
    option2: "",
    option3: ""
  };

  Post(question: {question: string, correctAnswer: string, option1: string, option2: string, option3: string}){
    const newQuestion: {question: string, correctAnswer: string, option1: string, option2: string, option3: string} =
    {question: question.question, correctAnswer: question.correctAnswer, option1: question.option1, option2: question.option2, option3: question.option3}
    this.api.postQuestion(newQuestion);
  }

}
