import { Component, EventEmitter, Input, Output, OnInit } from "@angular/core";

@Component({
  selector: "app-add-or-update-questions",
  templateUrl: "./add-or-update-questions.component.html",
  styleUrls: ["./add-or-update-questions.component.css"]
})
export class AddOrUpdateQuestionsComponent implements OnInit {
  @Output() questionCreated = new EventEmitter<any>();
  @Input() questionInfo: any;
  public buttonText = "Save";

  constructor() {
    this.clearQuestionInfo();
  }
  private clearQuestionInfo = function() {
    // Create an empty question object
    this.questionInfo = {
      QuestionId: undefined,
      QuestionText: ""
    };
  };

  public addOrUpdateQuestion = function(event) {
    this.questionCreated.emit(this.questionInfo);
    this.clearQuestionInfo();
  };

  ngOnInit() {}
}
