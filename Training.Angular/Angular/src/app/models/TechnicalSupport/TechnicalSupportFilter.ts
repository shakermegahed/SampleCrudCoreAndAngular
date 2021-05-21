import { FilterModel } from "../Common/FilterModel";


export class TechnicalSupportFilter extends FilterModel {

    
        pageIndex: number;
        pageSize: number;
        orderBy: string;
        searchKeyWord: string;
        sender:string;
        year:number;
        month:number;
      
}