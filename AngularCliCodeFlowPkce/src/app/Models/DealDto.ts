export class DealDto {
  productid: number;
  name: string;
  description: string;
  productname: string;
  oldprice: number;
  newprice: number;
  productlink: string;

  constructor(productid:number, name: string, productname: string, description: string, oldprice: number, newprice: number, productlink: string) {
    this.productid = productid;
    this.name = name;
    this.description = description;
    this.productname = productname;
    this.oldprice = oldprice;
    this.newprice = newprice;
    this.productlink = productlink;
  }

  GetDiscountPercentage(): number {
    return (this.newprice - this.oldprice)*100;
  }
}

