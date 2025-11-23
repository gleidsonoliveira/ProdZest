import { DecimalPipe } from "@angular/common";

//Interface que define a estrutura de um produto na api
export interface Product {
  id?: number;
  description: string;
  unitPrice: DecimalPipe;
  grossPrice: DecimalPipe;
  stockQuantity: number;
}

export interface PaginatedResponse<T> {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
  items: T[];
}

export interface ProductResponse extends PaginatedResponse<Product> {}
