import type { WorkingTimeForMobileDto } from '../models';

export interface PharmacyInfoDto {
  id?: string;
  name?: string;
  phone?: string;
  image?: string;
  longitude?: string;
  latitude?: string;
  address?: string;
  addingDate?: string;
  workingTimes: WorkingTimeForMobileDto[];
}
