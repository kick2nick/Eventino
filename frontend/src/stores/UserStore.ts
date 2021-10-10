import { makeAutoObservable } from 'mobx';
import { AuthApi } from '../services/apiService';

const authApi = new AuthApi();

class CurrentUser {

  isAuth = false;

  id = '3fa85f64-5717-4562-b3fc-2c963f66afa6';

  email = 'test@gmail.com';

  name = 'Anna Iustus';

  photoFileName = 'avatar.png';

  modal = 'close';

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

  login() {
    this.isAuth = true;
  }

  logout() {
    this.isAuth = false;
  }

  closeModal() {
    this.modal = 'close';
  }

  openLogIn() {
    this.modal = 'login';
  }

  openSignUp() {
    this.modal = 'signup';
  }

  closeModalAndAuth() {
    this.modal = 'close';
    this.isAuth = true;
  }

  async singOutFromAccount() {
    await authApi.postSignOut().then(() => this.isAuth = false);
  }

  updateCurrentUser() {

  }

}

export default new CurrentUser();
