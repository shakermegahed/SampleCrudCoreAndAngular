import { LookupDto } from "../Common/WorkPlaceDTO";

export interface GovernmentsWithTrainees {
  name: string;
  id: number;
  trainees: traineeSimpleData[];
  allowTrainee: boolean;
}
export interface traineeSimpleData {
  id: number;
  name: string;
  email: string;
  alreadyRegisterd: boolean;
}
