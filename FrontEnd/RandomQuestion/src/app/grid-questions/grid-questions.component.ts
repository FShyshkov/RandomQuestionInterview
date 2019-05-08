import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";

@Component({
  selector: "app-grid-questions",
  templateUrl: "./grid-questions.component.html",
  styleUrls: ["./grid-questions.component.css"]
})
export class GridQuestionsComponent implements OnInit {
  @Output() recordDeleted = new EventEmitter<any>();
  @Output() newClicked = new EventEmitter<any>();
  @Output() editClicked = new EventEmitter<any>();
  @Input() questionData: Array<any>;

  public deleteRecord(record) {
    console.log(record);
    this.recordDeleted.emit(record);
  }

  public editRecord(record) {
    console.log(record);
    const clonedRecord = Object.assign({}, record);
    this.editClicked.emit(clonedRecord);
  }

  public newRecord() {
    this.newClicked.emit();
  }
  constructor() {}

  ngOnInit() {}
}
