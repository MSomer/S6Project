export class Product {
  id: number;
  name: string;
  description: string;
  image:any;

  constructor(id: number, name: string, description: string, image:any) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.image = image;
  }
}
