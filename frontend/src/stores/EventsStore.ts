import { makeAutoObservable } from 'mobx';

class EventsStore {
  baseUrl = 'https://eventino-dev.azurewebsites.net/api';

  isLoading = true;

  allEvents = [];

  constructor() {
    makeAutoObservable(this);
    this.getAllEvents();
  }

  async getAllEvents() {
    const resHeaders = new Headers();
    const res = await fetch(`${this.baseUrl}/Events/Search`, {
      method: 'POST',
      headers: {
        ...resHeaders,
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        'skip': 0,
        'take': 1000,
      }),
    });

    this.allEvents = await res.json();
  }

}

export default new EventsStore();