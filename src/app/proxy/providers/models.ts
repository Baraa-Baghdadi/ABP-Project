import type { EntityDto } from '@abp/ng.core';
import type { ProviderWorkDay } from '../dawaa24-neo/providers/provider-work-day.enum';

export interface ProviderDto {
  id?: string;
  tenantId?: string;
  email?: string;
  pharmacyName?: string;
  pharmacyPhone?: string;
  concurrencyStamp?: string;
  workingTimes: WorkingTimeDto[];
}

export interface WorkingTimeDto extends EntityDto<string> {
  providerId?: string;
  workDay: ProviderWorkDay;
  from?: string;
  to?: string;
}

export interface ProviderAddressDto extends EntityDto {
  latitude: number;
  longitude: number;
  address?: string;
  cityId: number;
}

export interface WorkingTimeForMobileDto {
  workDay: ProviderWorkDay;
  from?: string;
  to?: string;
}
