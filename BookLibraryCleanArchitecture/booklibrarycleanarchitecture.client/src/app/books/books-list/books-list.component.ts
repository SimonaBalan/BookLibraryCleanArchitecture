import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable, Subscription, catchError, of, switchMap } from 'rxjs';
import { Book } from 'src/app/_interfaces/book';
import { BookService } from '../../shared/services/book.service';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { AddBookDialogComponent } from 'src/app/dialogs/add-book/add-book.dialog.component';

@Component({
  selector: 'app-books-list',
  standalone: false,
  templateUrl: './books-list.component.html',
  styleUrl: './books-list.component.css'
})
export class BooksListComponent implements OnInit, AfterViewInit {
  displayedColumns = ['title', 'releaseYear', 'genre', 'numberOfPages', 'isbn', 'publisher', 'status', 'actions'];

  dataSource: any = [];
  exampleDatabase: BookService | null;
  books: Book[] = [];
  index: number=0;
  id: number=0;
  pageIndex: number=0;
  pageSize: number=10;
  sortColumn: string='title';
  sortDirection:string='asc';
  filters: {[prop:string]:string} = {
    title: '',
    releaseYear: '',
    genre: '',
    status: '',
  };
  totalItems:number=0;

  userRoles:string[] = [];
  userId: string='';
  @ViewChild('paginator', {static: true}) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort = {} as MatSort;

  constructor(private bookService: BookService,
     public dialog: MatDialog, 
     private authService: AuthenticationService,
     private httpClient: HttpClient) {

  }

ngOnInit(): void {
  this.userRoles = this.authService.getRoles();
  /*this.authorizeService.isAuthenticated().pipe(switchMap(loggedIn => {
    if(loggedIn) {
      return this.authorizeService.getUserRoles().pipe(
        catchError(error => {
          console.error('Error in getUserRoles:', error);
          return of([]); // Return an empty array or handle the error as needed
        })
      );
    }
    return of([]);
  })).subscribe((roles)=>{
    console.log('Roles received:', roles);
    this.userRoles = roles;
    if (this.userRoles.includes('Administrator')){*/
      this.loadBooks();
    /*}
    else{
      this.loadBooksForUser();
    }
  }
  );*/
}

ngAfterViewInit(): void {
  this.dataSource.paginator = this.paginator;
  this.dataSource.sort = this.sort;
}

loadBooks() {
  this.exampleDatabase = new BookService(this.httpClient);
  this.bookService.getBooksBySearchCriteria(this.pageIndex, this.pageSize, this.sortColumn, this.sortDirection, this.filters).subscribe({
    next: (data: { books: Book[], totalItems: number }) => {
      this.dataSource = new MatTableDataSource<Book>(data['books']);
      //this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.paginator.length = data['totalItems'];
      this.totalItems = data['totalItems'];
    },
    error: (error: any) => console.error(error)
  });
}

filter(event: Event) {
  const filterValue = (event.target as HTMLInputElement).value;
  this.dataSource.filter = filterValue.trim().toLowerCase();

  if (this.dataSource.paginator) {
    this.dataSource.paginator.firstPage();
  }
}

addNew() {
  const version = new Uint16Array([Date.now()]);

  const dialogRef = this.dialog.open(AddBookDialogComponent, {
    data: { version: new Uint8Array(0) }
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result === 1) {
      // After dialog is closed we're doing frontend updates
      // For add we're just pushing a new row inside DataService
      this.exampleDatabase?.dataChange.value.push(this.bookService.getDialogData());
      this.refreshTable();
    }
  });
}

onPageChanged(event: PageEvent) {
  this.pageIndex = event.pageIndex;
  this.pageSize = event.pageSize;
  this.loadBooks();
}

onSortOnHeader(columnName: string) {
  // Check if the clicked column is already the active sorting column
  /*if (this.dataSource?.sort?.active === columnName) {
    // Toggle the sorting direction
    this.dataSource.sort.direction =
    this.dataSource.sort.direction === 'asc' ? 'desc' : 'asc';
  } else {
    // Set the new sorting column and direction
    this.dataSource.sort.active = columnName;
    this.dataSource.sort.direction = 'asc';
  }*/

  // Apply sorting
  this.sortColumn = this.dataSource.sort.active;
  this.sortDirection = this.dataSource.sort.direction;
  this.loadBooks();
}


applyServerSideFilter(filters: Record<string, string>) {
  this.filters = filters;
  this.loadBooks();
}

private refreshTable() {
  // Refreshing table using paginator
  this.loadBooks();
  this.paginator._changePageSize(this.paginator.pageSize);
}
}

export class ExampleDataSource extends DataSource<Book> {

  connect(collectionViewer: CollectionViewer): Observable<readonly Book[]> {
    throw new Error('Method not implemented.');
  }

  disconnect(collectionViewer: CollectionViewer): void {
    throw new Error('Method not implemented.');
  }
}
