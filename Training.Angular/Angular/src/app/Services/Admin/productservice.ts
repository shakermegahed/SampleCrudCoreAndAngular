import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { productDTO } from "src/app/models/Admin/productDTO";
import { productFilter } from "src/app/models/Admin/productFilter";
import { IResultForDatatTableDTO } from "src/app/models/Common/IResultForDatatTableDTO";
import { ResultSaveDTO } from "src/app/models/Common/ResultSaveDTO";
import { LookupDto } from "src/app/models/Common/WorkPlaceDTO";
import { environment } from "src/environments/environment";
import { baseService } from "../Shared/baseService.service";


@Injectable({
    providedIn: 'root'
  })
  export class productservice extends baseService<productDTO, number, productFilter> {

    constructor(protected _http: HttpClient) {
        super(_http, `${environment.baseUrl}${`Product/`}`);
      }

      GetProducts(filter: productFilter): Observable<IResultForDatatTableDTO<productDTO>> {
  
        return this.httpClient.post<IResultForDatatTableDTO<productDTO>>(`${this.myURL}${'GetAllProduct'}`, filter);
      };
      AddProduct(model: productDTO): Observable<ResultSaveDTO> {

        return this.httpClient.post<ResultSaveDTO>(`${this.myURL}${'AddProduct'}`, model)
      };
      UpdateProduct(model: productDTO): Observable<ResultSaveDTO> {
   
        return this.httpClient.post<ResultSaveDTO>(`${this.myURL}${'UpdateProduct'}`, model)
      };
      GetProductById(id:number): Observable<productDTO> {
 
        return this.httpClient.get<productDTO>(`${this.myURL}${'GetProductById'}?id=${id}`)
      };
      DeleteProduct(id:number): Observable<ResultSaveDTO> {
        //, { responseType: 'blob' }
        return this.httpClient.get<ResultSaveDTO>(`${this.myURL}${'DeleteProduct'}?id=${id}`);
      };
      GetCategs(): Observable<IResultForDatatTableDTO<LookupDto>> {
    
        return this.httpClient.get<IResultForDatatTableDTO<LookupDto>>(`${this.myURL}${'GetCategory'}`);
      };
  }