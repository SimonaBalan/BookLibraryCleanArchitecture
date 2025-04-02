import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, of, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from 'src/app/_interfaces/book';
import { BookBase } from 'src/app/_interfaces/book-base';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  dialogData: any;
  private booksCache: BookBase[] | null = null;
  dataChange: BehaviorSubject<Book[]> = new BehaviorSubject<Book[]>([]);

constructor(private http: HttpClient) {

  }

getBooksAsync() :Observable<Book[]> {
  return this.http.get(environment.serviceUrl + 'books/').pipe(
    map((response: any) => {
      console.log(response);
      return response;

    }));
}

getBooksBySearchCriteria(pageIndex: number, pageSize: number, sortColumn: string, sortDirection:string, filters: any): Observable<any>{
  let params = new HttpParams()
              .set('pageIndex', pageIndex.toString())
              .set('pageSize', pageSize.toString())
              .set('sortColumn', sortColumn)
              .set('sortDirection', sortDirection);

  // Add filter parameters
  for (const key in filters) {
    if (filters.hasOwnProperty(key)) {
      params = params.set(`filters[${key}]`, filters[key]);
    }
  }

  return this.http.get(environment.serviceUrl + '/books/getBySearchCriteriaAsync', { params });
}


addBook(newBook: Book) {
  let headers = new HttpHeaders({
    'Content-Type': 'application/json', // Set the Content-Type to JSON
  });

  return this.http.post(`${environment.serviceUrl}/books/`, newBook, {headers});
 }

 getDialogData(){
  return this.dialogData;
 }
}
