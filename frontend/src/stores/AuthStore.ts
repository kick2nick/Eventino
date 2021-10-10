import { makeAutoObservable } from 'mobx';

class AuthStore {
  logIn = false;
  singUp = false;

  constructor() {
    makeAutoObservable(this);
  }

}

export default new AuthStore();
