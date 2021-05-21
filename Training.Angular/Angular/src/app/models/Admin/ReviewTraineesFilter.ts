import { FilterModel } from "../Common/FilterModel"

 export class ReviewTraineesFilter extends FilterModel{
   orderBy: string;
   filter: string;
   active: Boolean;
   courseId:number;
   Payoff:boolean;
   letterStatus:boolean;
   traineeType:number;
   deletedPayOffStatus:number;
   attendanceStatus:boolean;
 }
