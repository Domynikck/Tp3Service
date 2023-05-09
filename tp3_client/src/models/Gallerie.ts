import { Photo } from './Photo';
import { User } from './User';
export class Gallerie{
    constructor(public id : number, public publique : boolean, public gallerieName : string, public coverID ?: number){}
}