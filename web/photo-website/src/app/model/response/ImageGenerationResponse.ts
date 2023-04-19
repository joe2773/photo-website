export class ImageGenerationResponse {
  created: number;
  data: ImageData[];

  constructor(created: number, data: ImageData[]) {
    this.created = created;
    this.data = data;
  }
}

export class ImageData {
  url: string;

  constructor(url: string) {
    this.url = url;
  }
}
