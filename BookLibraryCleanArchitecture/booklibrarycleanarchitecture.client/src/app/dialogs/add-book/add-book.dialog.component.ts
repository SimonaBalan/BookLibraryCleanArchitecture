import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Book } from 'src/app/_interfaces/book';
import { StatusEnum } from 'src/app/_interfaces/book-status';
import { BookService } from 'src/app/shared/services/book.service';

@Component({
  selector: 'app-add.dialog',
  templateUrl: './add-book.dialog.component.html',
  styleUrls: ['./add-book.dialog.component.css'],
  standalone: false
})

export class AddBookDialogComponent {
  newBook: Book;
  response: boolean;
  statusEnumValues: (StatusEnum|string)[];  // Get the enum values for the dropdown
  
  constructor(public dialogRef: MatDialogRef<AddBookDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { version: Uint8Array },
    public bookService: BookService, private snackBar: MatSnackBar) {

      this.statusEnumValues = Object.values(StatusEnum);  // Get the enum values for the dropdown
      // Initialize newBook object with default properties
      this.newBook = {
        id: 0,
        title: '',
        authors: [],
        genre:'',
        loanedQuantity:0,
        numberOfCopies:0,
        numberOfPages:0,
        releaseYear:0,
        status:StatusEnum.Available,
        ISBN:'000-000-000-0',
        publisher:'',
        version: this.uint8ArrayToBase64(this.data.version)
      };
    }
    
  formControl = new FormControl('', [
      Validators.required
      // Validators.email,
      ]);

  getErrorMessage() {
    return this.formControl.hasError('required') ? 'Required field' :
    this.formControl.hasError('email') ? 'Not a valid email' :
    '';
  }

  submit() {
  // empty stuff
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public confirmAdd(): void {
    this.bookService.addBook(this.newBook).subscribe({
      next: (returnedData) => {
        this.response = returnedData as boolean;
        this.snackBar.open('Successfully added', "Okay!", {duration: 3000});
        this.dialogRef.close(1);
      },
      error: (err: HttpErrorResponse) => {
        this.snackBar.open('Error occurred. Details: ' + err.name + ' ' + err.message, "Okay!", {duration: 8000});
        this.dialogRef.close(0);
      }
    });
  }

  private uint8ArrayToBase64(uint8Array: Uint8Array): string {
    // Convert Uint8Array to string
    let binaryString = '';
    for (let i = 0; i < uint8Array.length; i++) {
        binaryString += String.fromCharCode(uint8Array[i]);
    }

    // Encode string as base64
    return btoa(binaryString);
}
}
