import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable()
export class QuestionService {
  private headers: HttpHeaders;
  private accessPointUrl: string = "http://localhost:49319/api/questions";

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({
      "Content-Type": "application/json; charset=utf-8"
    });
  }

  public get() {
    return this.http.get(this.accessPointUrl + "?pageSize=200&pageNumber=1", {
      headers: this.headers
    });
  }

  public getRandom() {
    return this.http.get(this.accessPointUrl + "/random", {
      headers: this.headers
    });
  }

  public add(payload) {
    return this.http.post(this.accessPointUrl, payload, {
      headers: this.headers
    });
  }

  public remove(payload) {
    return this.http.delete(this.accessPointUrl + "/" + payload.QuestionId, {
      headers: this.headers
    });
  }

  public update(payload) {
    return this.http.put(
      this.accessPointUrl + "/" + payload.QuestionId,
      payload,
      {
        headers: this.headers
      }
    );
  }
}
