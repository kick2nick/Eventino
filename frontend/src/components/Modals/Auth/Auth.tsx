import React, { useState, FC } from 'react';
import { LogIn } from '../LogIn/LogIn';
import { SignUp } from '../SignUp/SignUp';
import currentUser from '../../../stores/UserStore';
import { observer } from 'mobx-react-lite';

export const Auth: FC = observer(() => {
  console.log(currentUser.modal);
  return (
    <div>
      <button className="button is-outlined header__button" onClick={() => currentUser.openLogIn()}>Log In</button>
      {currentUser.modal === 'login' && <LogIn />}
      {currentUser.modal === 'signup' && <SignUp />}
    </div >
  );
});
