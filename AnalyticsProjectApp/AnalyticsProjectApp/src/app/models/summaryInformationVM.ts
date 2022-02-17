export class summaryInformationVM  {
    public Platform: any;
    public Id: any;
    public DateFrom!: string;
    public DateTo!: string;
    public CountOfPosts!: number;
    public totalLikes!: number;
    public totalRetweets!: number;
    public totalComments!: number;
    public averageLikes!: number;
    public averageRetweets!: number;
    public averageComments!: number;

    constructor(data?: any) {
      const self = this;

      if (!data) {
        data = {};
      }

      Object.assign(self, data);
    }
  }