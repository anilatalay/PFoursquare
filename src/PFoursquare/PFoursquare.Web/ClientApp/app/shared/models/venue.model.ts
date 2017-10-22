import { Tips } from './tips-model';
import { Location } from './location.model';

export interface Venue {
    Id: string,
    Name: string
    Location: Location,
    Tips: Tips
}