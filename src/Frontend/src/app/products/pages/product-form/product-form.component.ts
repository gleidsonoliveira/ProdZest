import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ProductService } from '../../../core/services/product.service';
import { Product } from '../../../core/models/product.model';

@Component({
    selector: 'app-product-form',
    standalone: true,
    imports: [CommonModule, ReactiveFormsModule],
    templateUrl: './product-form.component.html',
    styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit, OnDestroy {
    productForm!: FormGroup;
    isEditMode: boolean = false;
    productId?: number;
    loading: boolean = false;
    error: string = '';


    private destroy$ = new Subject<void>();

    constructor(
        private fb: FormBuilder,
        private productService: ProductService,
        private router: Router,
        private route: ActivatedRoute
    ) {
        this.initForm();
    }

    ngOnInit(): void {
        const id = this.route.snapshot.paramMap.get('id');

        if (id) {
            this.isEditMode = true;
            this.productId = +id;
            this.loadProduct(this.productId);
        }
    }

    ngOnDestroy(): void {
        this.destroy$.next();
        this.destroy$.complete();
    }

    private initForm(): void {
        this.productForm = this.fb.group({
            description: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
            unitPrice: [0, [Validators.required, Validators.min(0)]],
            grossPrice: [0, [Validators.required, Validators.min(0)]],
            stockQuantity: [0, [Validators.required, Validators.min(0)]]
        });
    }

    private loadProduct(id: number): void {
        this.loading = true;

        this.productService.getProductById(id)
            .pipe(takeUntil(this.destroy$))
            .subscribe({
                next: (product: Product) => {
                    this.productForm.patchValue({
                        description: product.description,
                        unitPrice: product.unitPrice,
                        grossPrice: product.grossPrice,
                        stockQuantity: product.stockQuantity
                    });
                    this.loading = false;
                },
                error: (error: any) => {
                    this.error = 'Erro ao carregar produto. Por favor, tente novamente.';
                    console.error('Error loading product:', error);
                    this.loading = false;
                }
            });
    }

    onSubmit(): void {
        debugger
        if (this.productForm.invalid) {
            this.markFormGroupTouched(this.productForm);
            return;
        }

        this.loading = true;
        this.error = '';

        const product: Product = {
            description: this.productForm.value.description,
            unitPrice: this.productForm.value.unitPrice,
            grossPrice: this.productForm.value.grossPrice,
            stockQuantity: this.productForm.value.stockQuantity
        };

        const operation = this.isEditMode && this.productId
            ? this.productService.updateProduct(this.productId, product)
            : this.productService.createProduct(product);

        operation
            .pipe(takeUntil(this.destroy$))
            .subscribe({
                next: () => {
                    this.router.navigate(['/products']);
                },
                error: (error: any) => {
                    this.error = `Erro ao ${this.isEditMode ? 'atualizar' : 'criar'} produto. Por favor, tente novamente.`;
                    console.error('Error saving product:', error);
                    this.loading = false;
                }
            });
    }

    onCancel(): void {
        this.router.navigate(['/products']);
    }

    private markFormGroupTouched(formGroup: FormGroup): void {
        Object.keys(formGroup.controls).forEach(key => {
            const control = formGroup.get(key);
            control?.markAsTouched();

            if (control instanceof FormGroup) {
                this.markFormGroupTouched(control);
            }
        });
    }

    // Validação da descrição do produto
    get description() {
        return this.productForm.get('description');
    }

    get isDescriptionInvalid(): boolean {
        const control = this.description;
        return !!(control && control.invalid && (control.dirty || control.touched));
    }

    get descriptionErrorMessage(): string {
        const control = this.description;
        if (control?.hasError('required')) {
            return 'A descrição é obrigatória.';
        }
        if (control?.hasError('minlength')) {
            return 'A descrição deve ter no mínimo 3 caracteres.';
        }
        if (control?.hasError('maxlength')) {
            return 'A descrição deve ter no máximo 200 caracteres.';
        }
        return '';
    }
}
