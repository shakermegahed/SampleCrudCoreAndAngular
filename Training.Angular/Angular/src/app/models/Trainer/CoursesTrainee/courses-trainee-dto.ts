import { RequestType } from "../../Requests/RequestTypes";

export interface CoursesTraineeDTO {

  id: number;
  number: string;
  courseName: string;
  courseType: string;
  courseTypeId: number;
  courseStatusId: number;
  courseStatus: string;
  startDate: string;
  endDate: string;
  city: string;
  cityId: number;
  isFree: boolean;
  fees: number;
  trainerName: string;
  trainerId: number;
  address: string;
  numberOfDays: number;
  isEvaluationEnabled: boolean;
  highestScore: number;
  minimumSuccessScore: number;
  miminumAttendance: number;
  hasCourseCertificate: boolean;
  isExtraCourse: boolean;
  dates: string[];
  extraSetting: ExtraSetting;
  numberOfRegisterd: number;
  numberOfDeclined: number;
  numberOfWaiting: number;
  numberOfHolding: number;
  numberOfAttendance: number;
  numberWaitingSeats: number;
  numberAvailableSeats: number;
  rowError: string;
  courselanguage: string;
  logedTraineeApprovedInCourse: boolean;
  logedTraineeTempCourseRequest: boolean;
  allSeatsBooked: boolean;
  buttonString: string;
  requestType: RequestType;
  availableSeats: number;
  regType: RegTypeEnum;
}







interface ExtraSetting {
  courseId: number;
  schoolCertificate: boolean;
  jobDescription: boolean;
  saudiPostalCode: boolean;
  buildingNumber: boolean;
  streetNumber: boolean;
  postalCode: boolean;
  extraCode: boolean;
  fillExcelForProfessionalCourse: boolean;
  fillWordForProfessionalCourse: boolean;
  fillEnergyForm: boolean;
  approvalLetter: boolean;
  canLeave: boolean;
  canChangeDate: boolean;
  canLeaveAndMoneyBack: boolean;
  canRedoTest: boolean;
  canChangeTestDate: boolean;
  canRegisterInWaitingList: boolean;
}


export enum RegTypeEnum {
  CanRegister = 1,
  WaitingList = 2,
  AlreadyRegister = 3,
  AlreadyWatingListRegsiter = 4,
  RegistrationEnded = 5,
  CompeleteRegister = 6,
  CompeleteRegisterInWaitingList = 7,
}
