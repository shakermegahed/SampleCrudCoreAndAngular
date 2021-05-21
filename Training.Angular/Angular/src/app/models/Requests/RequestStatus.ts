export enum RequestStatus {
  Accepted = 1,//اعتماد
  Rejected = 2,  // رفض      
  InProgress = 3,//اول حالة منتظر الرد
  Back = 4,//ارجاع,
  Temp = 5,
  //WaitingForPayment=6,
  WaitingForRevisorAcceptance = 7,
  WaitingForFinancialAcceptance = 8,

  AcceptFromRvsRgstr = 9,
  AcceptFromFinancial = 10,
  RejectFromRvsRgstr = 11,
  RejectFromFinancial = 12,
  RequestNotFinished = 13,
  RequestNeedUpdate = 14,
  RequestNew = 15,
  RequestDoneUpdate = 16
}
