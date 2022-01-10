export class homeVM  {
    public name: any;
    
  
  
    constructor(data?: any) {
      const self = this;
  
      if (!data) {
        data = {};
      }
  
      Object.assign(self, data);
    }
  }