import React, { useState, FC } from 'react';
import { LogIn } from '../LogIn/LogIn';
import { SignUp } from '../SignUp/SignUp';
import currentUser from '../../../stores/UserStore';
import { observer } from 'mobx-react-lite';

const Auth: FC = observer(() => {
  console.log(currentUser.modal);
  return (
    <div>
      {currentUser.modal === 'login' && <LogIn />}
      {currentUser.modal === 'signup' && <SignUp />}
    </div >
  );
});

export default Auth;
