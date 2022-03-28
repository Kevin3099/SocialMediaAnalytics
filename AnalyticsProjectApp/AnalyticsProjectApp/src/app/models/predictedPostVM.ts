import { eventsVM } from "./eventsVM";

export class predictedPostVM  {

public Id: any;
public postContent!: string;
public platform!: string;
public postDate!: Date;
public postTime!: string;
public predictedLikes!: number;
public predictedRetweets!: number;
public bestPostTime!: Array<Date>;
public mostCommonEffectiveWord!: Array<string>;
public top5Posts!: Array<any>;

constructor(data?: any) {
  const self = this;

  if (!data) {
    data = {};
  }

  Object.assign(self, data);
}
}