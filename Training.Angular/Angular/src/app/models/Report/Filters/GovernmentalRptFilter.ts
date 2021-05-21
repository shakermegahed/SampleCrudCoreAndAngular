import { FilterModel } from "../../Common/FilterModel";
import { CourseTypes } from "../../Courses/CourseTypes";

export class GovernmentalRptFilter extends FilterModel {
  CourseType: CourseTypes;
  StartDate: Date;
  EndDate: Date;
}
