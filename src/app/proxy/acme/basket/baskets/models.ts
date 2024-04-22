
export interface CartDto {
  id?: string;
  items: ItemDto[];
}

export interface ItemDto {
  id?: string;
  cartId?: string;
  quantity: number;
  dateCreated?: string;
  productId?: string;
  productName?: string;
  productDescription?: string;
  productPrice?: number;
}

export interface ProductDto {
  id?: string;
  name?: string;
  description?: string;
  price?: number;
}
