import { FilterModel } from "../Common/FilterModel"

export class ReviewUsersFilter extends FilterModel {
  orderBy: string;
  filter: string;
  active: Boolean;
}
