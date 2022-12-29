import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()

export class ApiService{

  constructor(private http: HttpClient){}

  postQuestion(question: {question: string, correctAnswer: string, option1: string, option2: string, option3: string}){
    this.http.post('http://localhost:44543/api/Questions', question).subscribe(result => {
      console.log(result);
    })}

  GetQuestion(){
      return this.http.get('http://localhost:44543/api/Questions');
    }

    GetAnswer(optionId: number){
      const postValue: {answerId: Number} = {answerId: optionId}
      return this.http.post('http://localhost:44543/api/Questions/CheckAnswer', postValue);
    }


  }

