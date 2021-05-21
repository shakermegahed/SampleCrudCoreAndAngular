import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LazyLoadEvent, MessageService, ConfirmationService } from 'primeng/api';
import { productDTO } from 'src/app/models/Admin/productDTO';
import { productFilter } from 'src/app/models/Admin/productFilter';
import { LookupDto } from 'src/app/models/Common/WorkPlaceDTO';
import { productservice } from 'src/app/Services/Admin/productservice';
import { SharedService } from 'src/app/Services/Shared/shared.service';

@Component({
  selector: 'app-productview',
  templateUrl: './productview.component.html',
  styleUrls: ['./productview.component.css'],
  providers: [MessageService, ConfirmationService],
})
export class ProductviewComponent implements OnInit {
  formSubmitted: boolean = false;
  element: any = [];
  loadingSpinner: boolean = false;
  displayModalPro: boolean;
  ModelTiltle: string;
  ProForm: FormGroup;
  loading: boolean = true;
  filter: productFilter = new productFilter();
  TableEvent: LazyLoadEvent;
  ProFormForSearch: FormGroup;
  Showingpagination: string;
  TOpagination: string;
  Ofpagination: string;
  Entriespagination: string;
  elements: productDTO[];
  totalRecords: number = 0;
  CloseVisible = false;
  Cats: LookupDto[] = [];
  position: string;
  btnsave = false;
  btnedit = false;
  CurrentLang: any;
  constructor(
    private myservice: productservice,
    private messageService: MessageService,
    public shared: SharedService
  ) {
    this.Showingpagination = "Showing";
    this.TOpagination = "to";
    this.Ofpagination = "of";
    this.Entriespagination = "entries";
  }

  ngOnInit(): void {
    this.ProForm = new FormGroup({
      name: new FormControl(""),
      categoryId: new FormControl("0"),
      price: new FormControl(""),
    });

    this.ProFormForSearch = new FormGroup({
      name: new FormControl(""),

      pageIndex: new FormControl("", Validators.required),
      pageSize: new FormControl("", Validators.required),
      OrderBy: new FormControl(""),
      OrderType: new FormControl(""),
    });

    this.myservice.GetCategs().subscribe((result) => {
      this.Cats = result.list;
    });
  }

  loadCustomers(event: LazyLoadEvent) {
    this.TableEvent = event;
    this.GetProData();
  }
  OpenModelAdd() {
    this.formSubmitted = false;
    this.displayModalPro = true;
    this.ModelTiltle = "AddProduct";
    this.ProForm.enable();
    this.onReset();
    this.btnsave = true;
    this.btnedit = false;
    this.ProForm.removeControl("productId");
  }

  viewmodelView(id) {
    this.displayModalPro = true;

    this.loadingSpinner = true;

    this.ModelTiltle = "Reviewdata";

    this.ProForm.addControl(
      "productId",
      new FormControl("", Validators.required)
    );

    this.ProForm.disable();
    this.myservice.GetProductById(id).subscribe((resp) => {
      this.loadingSpinner = false;

      this.ProForm.patchValue({
        name: resp.name,
        productId: resp.productId,
        categoryId: resp.categoryId,
        categoryName: resp.categoryName,
        price: resp.price,
      });
    });
  }

  viewmodeledit(id) {
    this.formSubmitted = true;

    this.displayModalPro = true;

    this.loadingSpinner = true;

    this.ModelTiltle = "Trainee.Modifytraineedata";

    this.ProForm.enable();
    this.ProForm.addControl(
      "productId",
      new FormControl("", Validators.required)
    );

    this.btnsave = false;
    this.btnedit = true;

    this.myservice.GetProductById(id).subscribe((resp) => {
      this.loadingSpinner = false;

      this.ProForm.patchValue({
        name: resp.name,
        productId: resp.productId,
        categoryId: resp.categoryId,
        price: resp.price,
      });
    });
  }
  onReset() {
    this.ProForm.reset();
  }

  printPage() {
    print();
  }

  ResetForm() {
    this.CloseVisible = false;

    this.ProFormForSearch.reset();
    this.GetProData();
  }

  GetProData() {
    //this.loadingSpinner = true;
    this.loading = true;

    this.filter.pageIndex = this.TableEvent.first / this.TableEvent.rows;
    this.filter.pageSize = this.TableEvent.rows;
    this.filter.OrderBy = this.TableEvent.sortField;
    this.filter.OrderType =
      this.TableEvent.sortOrder == undefined || this.TableEvent.sortOrder == 1
        ? "Asc"
        : "Des";

    this.ProFormForSearch.patchValue({
      pageIndex: this.filter.pageIndex,
      pageSize: this.filter.pageSize,
      OrderBy: this.filter.OrderBy,
      OrderType: this.filter.OrderType,
    });

    this.myservice
      .GetProducts(this.ProFormForSearch.value)
      .subscribe((resp) => {
        this.loadingSpinner = false;
        this.loading = false;
        this.elements = resp.list;
        //this.totalRecords = resp.length;
        this.totalRecords = resp.resultPaging.recordsFiltered;
      });
  }

  onSubmit() {
    this.loadingSpinner = true;

    if (this.ProForm.invalid) {
      this.formSubmitted = true;
      return;
    }

    this.formSubmitted = true;

    this.myservice.AddProduct(this.ProForm.value).subscribe(
      (result) => {
        if (result.success) {
          this.messageService.add({
            severity: "success",
            summary: "Success",
            detail: result.message,
          });
          debugger;
          this.displayModalPro = false;
          this.GetProData();
          this.onReset();
          this.loadingSpinner = false;
        } else {
          //split
          this.splitString(result.message);
          this.loadingSpinner = false;
          this.displayModalPro = true;
        }

        // this.closeModal.nativeElement.click();
      },
      (err) => {
        //...
        this.loadingSpinner = false;
      }
    );
  }
  splitString(str) {
    let splitted = str.split(",");
    for (let i = 0; i < splitted.length; i++) {
      this.messageService.add({
        severity: "error",
        summary: "Error",
        detail: splitted[i],
      });
    }
  }
  onSubmitedit() {
    if (this.ProForm.invalid) {
      this.formSubmitted = true;
      this.ProForm.markAllAsTouched();
      return;
    }

    this.loadingSpinner = true;

    //this.TraineeForm.patchValue({
    //  birthDateHijri:this.dateFormatterService.ToString(this.selectedDate)
    //});

    this.myservice.UpdateProduct(this.ProForm.value).subscribe(
      (result) => {
        if (result.success) {
          this.messageService.add({
            severity: "success",
            summary: "Success",
            detail: result.message,
          });
          this.loadingSpinner = false;
          this.displayModalPro = false;

          this.GetProData();
          this.onReset();
        } else {
          this.splitString(result.message);

          this.loadingSpinner = false;
          this.displayModalPro = true;
        }
        this.GetProData();
        this.onReset();
      },
      (err) => {
        //...
      }
    );
  }

  ConfirmDelete(id) {
    this.myservice.DeleteProduct(id).subscribe((result) => {
      this.loadingSpinner = false;

      if (result.success) {
        this.messageService.add({
          severity: "success",
          summary: "Success",
          detail: result.message,
        });
        this.GetProData();
      } else {
        this.messageService.add({
          severity: "error",
          summary: "Error",
          detail: result.message,
        });
      }
    });
  }

  changeCurrentLang(lang: string) {
    this.shared.changeCurrentLang(lang);
    this.CurrentLang = lang;
  }
}
