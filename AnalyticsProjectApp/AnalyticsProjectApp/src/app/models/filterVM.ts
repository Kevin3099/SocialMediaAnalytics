export class filterVM  {
    public sinceDate!: string;
    public untilDate!: string;
  
    constructor(data?: any) {
      const self = this;

      if (!data) {
        data = {};
      }

      Object.assign(self, data);
    }
  }