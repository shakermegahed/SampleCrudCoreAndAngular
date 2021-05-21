export class FilterModel{
  Id = 0;
  // tslint:disable-next-line: no-inferrable-types
  pageIndex: number = 0 ;
  // tslint:disable-next-line: no-inferrable-types
  pageSize: number = 0 ;
  // tslint:disable-next-line: no-inferrable-types
  pageCount:number = 0 ;
    pagelength: number = 0;

    totalCount: number = 0;
    OrderBy: string = "Id";
    OrderType: string = "Asc";
}
