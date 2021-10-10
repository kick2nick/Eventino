import React, { useState, FC } from 'react';
import { LogIn } from '../LogIn/LogIn';
import { SignUp } from '../SignUp/SignUp';
import { AuthContext } from './AuthContext';

export const Auth: FC = () => {
  const [active, setActive] = useState('');

  const switchToSignUp = () => {
    setActive('signup');
  };

  const switchToLogIn = () => {
    setActive('login');
  };
  const switchToClose = () => {
    setActive('close');
  };

  return (
    <AuthContext.Provider value={{ switchToSignUp, switchToLogIn, switchToClose, active }}>
      <div className="control has-icons-left mt-2">
        <button className="button" onClick={() => switchToLogIn()}>Log In</button>
        <span className="icon is-small is-left">
          <i className="fas fa-Google"></i>
        </span>
      </div>
      {active === 'login' && <LogIn />}
      {active === 'signup' && <SignUp />}
    </AuthContext.Provider>
  );
};
