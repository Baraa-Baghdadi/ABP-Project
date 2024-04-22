import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CartDto, ItemDto, ProductDto } from '../acme/basket/baskets/models';

@Injectable({
  providedIn: 'root',
})
export class CartsService {
  apiName = 'Default';
  

  addToCart = (id: string, productId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, boolean>({
      method: 'POST',
      url: '/api/app/Carts/AddToCart',
      params: { id, productId },
    },
    { apiName: this.apiName,...config });
  

  getAllCart = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CartDto[]>({
      method: 'GET',
      url: '/api/app/Carts/GetAllCart',
    },
    { apiName: this.apiName,...config });
  

  getAllItems = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ItemDto[]>({
      method: 'GET',
      url: '/api/app/Carts/GetAllItem',
    },
    { apiName: this.apiName,...config });
  

  getAllProduct = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProductDto[]>({
      method: 'GET',
      url: '/api/app/Carts/GetAllProduct',
    },
    { apiName: this.apiName,...config });
  

  getCart = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CartDto>({
      method: 'GET',
      url: '/api/app/Carts/GetCartById',
      params: { id },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
