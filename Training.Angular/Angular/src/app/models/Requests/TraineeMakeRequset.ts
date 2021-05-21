import { RequestType } from "./RequestTypes";

export interface TraineeMakeRequest {
  CourseId: number,
  Reason: string,
  RequestStatus: number,
  RequestId: string,
  HostName: string;
  RequestType: RequestType
}

export class TraineeMakeRequestImp implements TraineeMakeRequest {
  constructor(courseId, Reason, RequestStatus, RequestId: string, WizerdStep: number = 1, RequestType: RequestType) {
    this.CourseId = courseId;
    if (Request != null) {
      this.RequestId = RequestId;
    }
    this.WizerdStep = WizerdStep;
    this.RequestType = RequestType;
  }

  CourseId: number;
  Reason: string;
  RequestStatus: number;
  RequestId: string;
  WizerdStep: number;
  RequestType: RequestType
  HostName: string;
}
