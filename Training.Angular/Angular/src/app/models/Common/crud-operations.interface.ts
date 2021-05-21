
import { Observable } from 'rxjs';

import { ResultDeleteDTO } from './ResultDeleteDTO';
import { IResultForDatatTableDTO } from './IResultForDatatTableDTO';
import { ResultSaveGeneric } from './ResultSaveGeneric';


export interface CrudOperations<DTO, ID, Filter> {
    GetAll2(filter: Filter): Observable<IResultForDatatTableDTO<DTO>>;
    GetById(Id: ID): Observable<DTO>;
    Insert(model: DTO): Observable<ResultSaveGeneric<DTO>>;
    Update(model: DTO): Observable<ResultSaveGeneric<DTO>>;
    Delete(Id: ID): Observable<ResultDeleteDTO>;
}