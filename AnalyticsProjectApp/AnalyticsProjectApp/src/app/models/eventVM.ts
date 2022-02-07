import { filterVM } from "./filterVM";
import { summaryInformationVM } from "./summaryInformationVM";

export class eventVM  {
    public hashtag!: string;
    public filter!: filterVM;
    public eventStats!: Array<summaryInformationVM>;
  
    constructor(data?: any) {
      const self = this;

      if (!data) {
        data = {};
      }

      Object.assign(self, data);
    }
  }