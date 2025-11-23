import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { Product, ProductResponse } from '../models/product.model';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    private readonly apiUrl = `${environment.apiUrl}/Product`;
    private productsSubject = new BehaviorSubject<Product[]>([]);
    public products$ = this.productsSubject.asObservable();

    constructor(private http: HttpClient) { }

    getProducts(page: number = 1, itemsPerPage: number = 50): Observable<ProductResponse> {
        const params = new HttpParams()
            .set('page', page.toString())
            .set('itemsPerPage', itemsPerPage.toString());

        return this.http.get<ProductResponse>(this.apiUrl, { params }).pipe(
            tap(response => {
                this.productsSubject.next(response.items);
            }),
            catchError(this.handleError)
        );
    }

    getProductById(id: number): Observable<Product> {
        return this.http.get<Product>(`${this.apiUrl}/${id}`).pipe(
            tap(product => console.log('Product loaded:', product)),
            catchError(this.handleError)
        );
    }

    //função para chamar a api de criar produto
    createProduct(product: Product): Observable<Product> {
        debugger
        return this.http.post<Product>(this.apiUrl, product).pipe(
            tap(newProduct => {
                console.log('Product created:', newProduct);
                this.refreshProducts();
            }),
            catchError(this.handleError)
        );
    }

    //função para chamar a api de atualizar produto
    updateProduct(id: number, product: Product): Observable<Product> {
        debugger
        let url = `${this.apiUrl}?Id=${id}`;
        return this.http.put<Product>(url, product).pipe(
            tap(updatedProduct => {
                console.log('Product updated:', updatedProduct);
                this.refreshProducts();
            }),
            catchError(this.handleError)
        );
    }

    //função para chamar a api de deletar produto
    deleteProduct(id: number): Observable<void> {

        let url = `${this.apiUrl}?Id=${id}`;
        return this.http.delete<void>(url).pipe(
            tap(() => {
                console.log('Product deleted:', id);
                this.refreshProducts();
            }),
            catchError(this.handleError)
        );
    }

    private refreshProducts(): void {
        this.getProducts().subscribe();
    }

    private handleError(error: any): Observable<never> {
        const errorMessage = error.error?.message || error.statusText || 'Server error';
        return throwError(() => new Error(errorMessage));
    }
}
