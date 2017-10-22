import { Items } from './items.model';

export interface Groups {
    Type: string,
    Count: number,
    Items: Array<Items>
}