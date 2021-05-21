
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';



import { ResultDeleteDTO } from 'src/app/models/Common/ResultDeleteDTO';
import { ResultSaveGeneric } from 'src/app/models/Common/ResultSaveGeneric';
import { CRUD_ServiceDTO } from 'src/app/models/Common/CRUD-ServiceDTO';
import { IResultForDatatTableDTO } from 'src/app/models/Common/IResultForDatatTableDTO';
import { CrudOperations } from 'src/app/models/Common/crud-operations.interface';


export abstract class baseService<DTO, ID, Filter> implements CrudOperations<DTO, ID, Filter> {

    constructor(
        protected httpClient: HttpClient,
        protected myURL: string
    ) { }

    GetAll(): Observable<IResultForDatatTableDTO<DTO>> {
    
    return this.httpClient.get<IResultForDatatTableDTO<DTO>>(`${this.myURL}`);
    }

    GetAll2(filter:Filter): Observable<IResultForDatatTableDTO<DTO>> {
        
        return this.httpClient.post<IResultForDatatTableDTO<DTO>>(`${this.myURL}${CRUD_ServiceDTO.GetAll2}`,filter);
    }
    Filter(filter:Filter): Observable<IResultForDatatTableDTO<DTO>> {
        
        return this.httpClient.post<IResultForDatatTableDTO<DTO>>(`${this.myURL}${CRUD_ServiceDTO.Filter}`,filter);
    }


    GetById(Id: ID): Observable<DTO> {
        
        return this.httpClient.get<DTO>(`${this.myURL}${CRUD_ServiceDTO.GetById}${Id.toString()}`);
    }

    GetByCode(Id: ID): Observable<DTO> {
        
        return this.httpClient.get<DTO>(`${this.myURL}${CRUD_ServiceDTO.GetByCode}${Id.toString()}`);
    }

    Insert(model: DTO): Observable<ResultSaveGeneric<DTO>> {
        
        return this.httpClient.post<ResultSaveGeneric<DTO>>
            (`${this.myURL}${CRUD_ServiceDTO.Insert}`, model);
    }



    Update(model: DTO): Observable<ResultSaveGeneric<DTO>> {
      
        return this.httpClient.put<ResultSaveGeneric<DTO>>
            (`${this.myURL}${CRUD_ServiceDTO.Update}`, model);
    }


//   updateElement(element): Observable<any>{
//     return this.httpClient.put(`${this.myURL}/${element.id}`, element);
//  }




    Delete(Id: ID): Observable<ResultDeleteDTO> {
       
        return this.httpClient.delete<ResultDeleteDTO>
            (`${this.myURL}${CRUD_ServiceDTO.DeleteById}${Id.toString()}`);
    }

}
