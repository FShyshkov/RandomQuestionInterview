import { Component, OnInit } from "@angular/core";
import * as _ from "lodash";
import { QuestionService } from "../question-service.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  public questionData: Array<any>;
  public currentQuestion: any;

  constructor(private questionService: QuestionService) {
    this.questionData = [];
    questionService.get().subscribe((data: any) => {
      for (let i = 0; i < data.Model.length; i++) {
        this.questionData.push(data.Model[i]);
      }
    });

    this.currentQuestion = this.setInitialValuesForQuestionData();
  }

  private setInitialValuesForQuestionData() {
    return {
      QuestionId: 0,
      QuestionText: ""
    };
  }

  public createOrUpdateQuestion = function(question: any) {
    let questionWithId;
    questionWithId = _.find(
      this.questionData,
      el => el.QuestionId === question.QuestionId
    );

    if (questionWithId) {
      const updateIndex = _.findIndex(this.questionData, {
        id: questionWithId.QuestionId
      });
      this.questionService
        .update(question)
        .subscribe(questionRecord =>
          this.questionData.splice(updateIndex, 1, questionRecord.Model)
        );
    } else {
      this.questionService
        .add(question)
        .subscribe(questionRecord =>
          this.questionData.push(questionRecord.Model)
        );
    }

    this.currentQuestion = this.setInitialValuesForQuestionData();
  };

  public editClicked = function(record) {
    this.currentQuestion = record;
  };

  public newClicked = function() {
    this.currentQuestion = this.setInitialValuesForQuestionData();
  };

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.questionData, {
      QuestionId: record.QuestionId
    });
    this.questionService
      .remove(record)
      .subscribe(result => this.questionData.splice(deleteIndex, 1));
  }
  ngOnInit() {}
}
