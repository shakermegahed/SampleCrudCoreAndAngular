import { FilterModel } from "../../Common/FilterModel";

export class GovernmentalFilter extends FilterModel {

    
        pageIndex: number;
        pageSize: number;
        orderBy: string;
        name: string;
      
}

export class GovernmentalWithCourseFilter extends GovernmentalFilter {
  courseId: number;  
}
