import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ProductService } from '../../../core/services/product.service';
import { Product, ProductResponse } from '../../../core/models/product.model';
import { PaginationComponent } from '../../../shared/components/pagination/pagination.component';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, PaginationComponent],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit, OnDestroy {
  products: Product[] = [];
  currentPage: number = 1;
  totalPages: number = 1;
  totalItems: number = 0;
  itemsPerPage: number = 50;
  loading: boolean = false;
  error: string = '';
  
  private destroy$ = new Subject<void>();

  constructor(
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  loadProducts(page: number = 1): void {
    this.loading = true;
    this.error = '';
    
    this.productService.getProducts(page, this.itemsPerPage)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response: ProductResponse) => {
          this.products = response.items;
          this.currentPage = response.currentPage;
          this.totalPages = response.totalPages;
          this.totalItems = response.totalItems;
          this.itemsPerPage = response.itemsPerPage;
          this.loading = false;
        },
        error: (error) => {
          this.error = 'Erro ao carregar produtos. Por favor, tente novamente.';
          this.loading = false;
        }
      });
  }

  onPageChange(page: number): void {
    console.log('Page change requested:', page);
    if (page >= 1 && page <= this.totalPages) {
      this.loadProducts(page);
    }
  }

  onEdit(product: Product): void {
    if (product.id) {
      this.router.navigate(['/products/edit', product.id]);
    }
  }

  onDelete(product: Product): void {
    debugger
    if (!product.id) return;
    
    if (confirm(`Tem certeza que deseja excluir o produto "${product.description}"?`)) {
      this.productService.deleteProduct(product.id)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: () => {
            this.loadProducts(this.currentPage);
          },
          error: (error) => {
            this.error = 'Erro ao excluir produto. Por favor, tente novamente.';
            console.error('Error deleting product:', error);
          }
        });
    }
  }

  onCreate(): void {
    this.router.navigate(['/products/new']);
  }
}
