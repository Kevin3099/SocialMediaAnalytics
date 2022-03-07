import { filterVM } from "./filterVM";
import { summaryInformationVM } from "./summaryInformationVM";

export class eventsVM  {
    public eventsId: any;
    public fromDate!: Date;
    public toDate!: Date;
    public fromDateDisplay!: string;
    public toDateDisplay!: string;
    public hashtag!: string;
    public summaryInformations!: Array<summaryInformationVM>;
  
    constructor(data?: any) {
      const self = this;

      if (!data) {
        data = {};
      }

      Object.assign(self, data);
    }
  }