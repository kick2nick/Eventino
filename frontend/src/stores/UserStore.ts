import { makeAutoObservable } from 'mobx';

class CurrentUser {

  id = '3fa85f64-5717-4562-b3fc-2c963f66afa6';

  email = 'string';

  name = 'string';

  photoFileName = 'string';

  interests = [
    {
      id: 0,
      name: 'string',
    },
  ];


  constructor() {
    makeAutoObservable(this);
  }

  getCurrentUser() {

  }

  updateCurrentUser() {

  }


}

export default new CurrentUser();