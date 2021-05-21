import { FilterModel } from "../../Common/FilterModel";


export class CoursesTraineeFilter extends  FilterModel {

 
  pageIndex: number;
  pageSize: number;
  orderBy: string;
  orderType: string;
  year: number;
  month: number;
  courseTypeId: number;
  courseStatusId: number;
  courseName: string;
  cityId: number;



    
}
