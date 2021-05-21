export interface CoursesTraineeDetailsDTO {


  courseTypeNotes:string;
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
  generalQuestions:string;
  generalAdvices:string;
  termsandConditions:string;
  generalAdvicesPro:string;
  generalInfoPro:string;
  generalQuestionsPro:string;
  termsandConditionsPro:string;
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
  languageTrans: string;
}



