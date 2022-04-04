import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpParams } from '@angular/common/http';

import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Evalcrud } from './evalcrud';

@Injectable({
  providedIn: 'root'
})
export class EvalcrudService {

  private apiURL = "http://localhost:27594/api/Travel";
  private ngUnsubscribe: Observable<any> = new Observable();

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  router: any;
  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<any> {

    return this.httpClient.get(this.apiURL + '/travels/')

    .pipe(
      catchError(this.errorHandler)
    )
  }
  create(evalcrud:Evalcrud): Observable<any> {

    return this.httpClient.post(this.apiURL + '/create/', JSON.stringify(evalcrud), this.httpOptions)

    .pipe(
      catchError(this.errorHandler)
    )
  }

  find(id:number): Observable<any> {

    return this.httpClient.get(this.apiURL + '/' + id)

    .pipe(
      catchError(this.errorHandler)
    )
  }

  update(id:number, evalcrud:Evalcrud): Observable<any> {
    var data = {"name":evalcrud.observations.toString(),
  "startDate": evalcrud.startDate,
  "email": evalcrud.email,
  "active": evalcrud.active,
  "nacionality": evalcrud.nacionality,
  "observations": evalcrud.observations}
    return this.httpClient.post(this.apiURL + '/Update?id=' + id, JSON.stringify(data), this.httpOptions)

    .pipe(
      catchError(this.errorHandler)
    )
  } delete(id:number){
    return this.httpClient.post(this.apiURL + '/delete?id=' + id, this.httpOptions)
    this.router.navigate(['/evalucrud/index'])
    .pipe(
      catchError(this.errorHandler)
    )
  }


  errorHandler(error:any) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
 }
}
