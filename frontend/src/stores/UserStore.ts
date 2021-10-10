import { makeAutoObservable } from 'mobx';

class CurrentUser {

  id = '3fa85f64-5717-4562-b3fc-2c963f66afa6';

  email = 'email';

  name = 'Name';

  photoFileName = 'avatar.png';

  interests = [
    {
      id: 0,
      name: 'Music',
    },
    {
      id: 1,
      name: 'Party',
    },
    {
      id: 2,
      name: 'Outdoor',
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