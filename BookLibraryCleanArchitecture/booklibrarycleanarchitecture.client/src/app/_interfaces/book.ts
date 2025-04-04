import { StatusEnum } from "./book-status";

export interface Book {
  id : number;
  ISBN?: string;
  title: string;
  publisher?: string;
  releaseYear: number;
  genre: string;
  status: StatusEnum;
  numberOfCopies: number;
  loanedQuantity: number;
  numberOfPages: number;
  version: string;
  authors: number[];
}
