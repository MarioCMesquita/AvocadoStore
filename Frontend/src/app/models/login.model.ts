import { User } from './user.model';

export interface Login {
    userData: User;
    token: string;
}