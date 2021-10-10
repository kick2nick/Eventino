import React, { useState, FC } from 'react';
import { LogIn } from '../LogIn/LogIn';
import { SignUp } from '../SignUp/SignUp';
import currentUser from '../../../stores/UserStore';
import { observer } from 'mobx-react-lite';

export const Auth: FC = observer(() => {
  console.log(currentUser.modal);
  return (
    <div>
      <div className="control has-icons-left mt-2">
        <button className="button" onClick={() => currentUser.openLogIn()}>Log In</button>
        <span className="icon is-small is-left">
          <i className="fas fa-Google"></i>
        </span>
      </div>
      {currentUser.modal === 'login' && <LogIn />}
      {currentUser.modal === 'signup' && <SignUp />}
    </div>
  );
});
