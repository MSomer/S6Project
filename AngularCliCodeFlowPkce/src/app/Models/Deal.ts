export class Deal {
  id: number;
  productId: number;
  name: string;
  description: string;
  productName: string;
  oldPrice: number;
  newPrice: number;
  productLink: string;
  rating: number;
  timestamp: string;

  constructor(id:number, productId:number, name: string, description: string, productName:string, oldPrice: number, newPrice: number, productLink: string, rating: number, timestamp: string) {
    this.id = id;
    this.productId = productId;
    this.name = name;
    this.description = description;
    this.productName = productName;
    this.oldPrice = oldPrice;
    this.newPrice = newPrice;
    this.productLink = productLink;
    this.rating = rating;
    this.timestamp = timestamp;
  }

  GetDiscountPercentage(): number {
    return (this.newPrice - this.oldPrice)*100;
  }
}

