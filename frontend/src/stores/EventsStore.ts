import { makeAutoObservable } from 'mobx';

class EventsStore {
  baseUrl = 'https://eventino-dev.azurewebsites.net/api';

  isLoading = true;

  allEvents = [];

  constructor() {
    makeAutoObservable(this);
  }

  async getAllEvents() {
    const resHeaders = new Headers();

    // try {
    // this.isLoading = true;
    const res = await fetch(`${this.baseUrl}/Events/Search`, {
      method: 'POST',
      headers: {
        ...resHeaders, 'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        'skip': 0,
        'take': 1000,
      }),
    });
    const myRes = await res.json();

    console.log(myRes);

    this.allEvents = myRes;
    // } catch(err) {
    //   console.log(`We have some problem with geting events, response: ${err}`);
    //   throw err;
    // } finally {
    //   this.isLoading = false;
    // }



    // this.allEvents = await res.json();
    // const myRes = await res.json();
    // console.log(myRes);

    // this.allEvents = myRes;

    // return res.json();
  }

}

export default new EventsStore();