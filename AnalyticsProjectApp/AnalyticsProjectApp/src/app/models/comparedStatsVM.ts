import { eventsVM } from "./eventsVM";

export class comparedStatsVM  {
    public Id: any;
    public averageFollowerIncrease!: number;
    public averageLikesIncrease!: number;
    public averageRetweetIncrease!: number;
    public averageCommentsIncrease!: number;
    public bestPostTime!: Array<Date>;
    public mostCommonEffectiveWord!: Array<string>;
    public top5Posts!: Array<any>;
    public EventsUsed!: Array<eventsVM>;
  
    constructor(data?: any) {
      const self = this;

      if (!data) {
        data = {};
      }

      Object.assign(self, data);
    }
  }