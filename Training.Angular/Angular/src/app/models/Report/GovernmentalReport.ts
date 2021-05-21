import { CourseTypes } from "../Courses/CourseTypes";

export class GovernmentalReport {
  governName: string;
  registerdTrainee: number;
  traineeInCourseCount: number;
  courseCount: number;
  attendedTrainee: number;
  attendedTraineeCount: number;
  courseTypeId: CourseTypes;
  govId: number;
  courseId: number;
  startDate: Date;
  endDate: Date;
}
