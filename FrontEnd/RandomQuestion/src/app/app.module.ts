import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import * as _ from "lodash";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { RouterModule, Routes } from "@angular/router";
import { GridQuestionsComponent } from "./grid-questions/grid-questions.component";
import { AddOrUpdateQuestionsComponent } from "./add-or-update-questions/add-or-update-questions.component";
import { QuestionService } from "./question-service.service";
import { HttpClientModule } from "@angular/common/http";
import { DecimalPipe } from "@angular/common";
import { DatePipe } from "@angular/common";
import { FormsModule } from "@angular/forms";

const appRoutes: Routes = [{ path: "", component: HomeComponent }];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GridQuestionsComponent,
    AddOrUpdateQuestionsComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  providers: [QuestionService],
  bootstrap: [AppComponent]
})
export class AppModule {}
