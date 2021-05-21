export class GovernmentMailDTO {
    mailTo: number;
    title: string;
    message: string;
    emails:string[]=[];
    emailCC: string;
    emailBCC: string;
    mailAttach: string[]=[];
}