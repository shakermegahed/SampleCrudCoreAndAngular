import { IResultPaging } from "./IResultPaging";
export interface IResultForDatatTableDTO<T> {
    [x: string]: any;
    list: T[];
    resultPaging: IResultPaging;

}
