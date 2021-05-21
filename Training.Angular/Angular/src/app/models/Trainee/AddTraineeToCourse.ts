export class AddTraineeToCourse{
  CourseId: number;
    Trainees: TraineeWithGovId[] = [];
  HostName: string;
}
export class TraineeWithGovId {
  TraineeId: number;
  GovId: number;
}
