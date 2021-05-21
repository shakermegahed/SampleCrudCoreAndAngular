import { RequestType } from "./RequestTypes";

export interface EditRequestDetails {
  email: string,
  phone: string,
  workPlace: string,
  workplaceId: number,
  workplaceType: number,
  schoolCertificate: string,
  jobDescription: string,
  saudiPostalCode: string,
  buildingNumber: string,
  streetNumber: string,
  postalCode: string,
  extraCode: string,
  requestId: string,
  requestType: RequestType
}
