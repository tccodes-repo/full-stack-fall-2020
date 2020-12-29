import { Emailer } from './lib/api/dist/emailer';

export function getApiClient() {
    return new Emailer({ baseUri: window.apiUrl });
}