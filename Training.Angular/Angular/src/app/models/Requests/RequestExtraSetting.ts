export class ProFormEducation {
  ed: string;
  edfrom: Date;
  edto: Date;
  edg: Date;
  edd: string;
  edf: string;
}

export class ProReg {
  pc: string;
  pr: string;
  pd: Date;
  pyn: string;
}

export class ProRegBool {
  proEng: string;
  regArch: string;
  eIT: string;
  cPE: string;
  eA: string;
  anyRegectOrSus: string;
}

export class ExpRec {
  exfrom: Date;
  exto: Date;
  exna: string;
  exp: string;
  ext: string;
}
export class Ref {
  rn: string;
  rca: string;
  rcp: string;
}

export class FullExtraProData {
  proCouresEducation: ProFormEducation;
  proRegBool: ProRegBool;
  proReg: ProReg[];
  proRef: Ref[];
  poExpRec: ExpRec[];
  proformid: number;
}
