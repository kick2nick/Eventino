import React, { FC } from 'react';
import { Auth } from '../Modals/Auth/Auth';

const Header: FC = () => {
  return (
    <header className="App__header" >
      <Auth />
    </header>
  );
};

export default Header;
