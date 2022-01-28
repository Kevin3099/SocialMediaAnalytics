export class filterVM  {
    public toDate!: Date;
    public fromDate!: Date;
    public platform!: string;
  
    constructor(data?: any) {
      const self = this;

      if (!data) {
        data = {};
      }

      Object.assign(self, data);
    }
  }