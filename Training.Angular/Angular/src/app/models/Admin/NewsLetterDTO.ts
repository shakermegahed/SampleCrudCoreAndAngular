

export class NewsLetterDTO {
  recipients:number[] ;
  recipientsType: number;
  title: string;
  body: string;
  newsId:number;
  mailAttach: string[]=[];
  }