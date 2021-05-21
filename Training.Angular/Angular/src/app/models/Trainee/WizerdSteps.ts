import { RequestType } from "../Requests/RequestTypes";

export interface WizerdSteps {
  courseId: number;
  wizerdStep: number;
  requestId: string;
  wordFileName: string;
  approvalLetter: string;
  paymentMethod: number;
  paymentFileName: string;
  showWizerd: boolean;
  lastReason: string;
  requestType: RequestType;
}
