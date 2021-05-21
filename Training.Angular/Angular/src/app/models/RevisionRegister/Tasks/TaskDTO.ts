import { Roles } from "../../Authentication/Roles";

export class TaskDTO {
  id:string;
  orderNumber:number;
  requesterName:string;
  requesterId:string;
  requestDate:string;
  requestType: string;
  requestTypeId: number;
  requestStatus: string;
  requestStatusId: number;
  requestStatusForTrainee:string;
  requestStatusForTraineeId:number;
  courseStartDate:string;
  courseType:string;
  userNameAssignedTo:string;
  courseId:number;
  courseName:string;
  otherCourseId:number;
  otherCourseName:string;
  paymentMethod:string;
  paymentStatus:boolean;
  relatedRoleNormalized: string;
  relatedRoleId: Roles;
  lastRejectReason: string;
  canRedoTest: boolean;
  reTakeDate: Date;
  reTookCourse: string;
  updatedByFinance: boolean;
}
