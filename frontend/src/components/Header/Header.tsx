import React, { FC } from 'react';
import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';
import './Header.scss';
import currentUser from '../../stores/UserStore';

const Header: FC = observer(() => {
  return (
    <div className='header__background'>
      <header className="header container">
        <button className="button is-outlined header__button">
          <span className="icon is-small">
            <i className="fas fa-plus"></i>
          </span>
          <span>CREATE AN EVENT</span>
        </button>
        <div>
          <Link to='/'>
            <img src='/logo.png' />
          </Link>
        </div>
        <div>
          <div >
            {currentUser.isAuth ?
              <button className="button is-outlined header__button" onClick={() => currentUser.openLogIn()}>Sing Out</button> :
              <button className="button is-outlined header__button" onClick={() => currentUser.openLogIn()}>Log In</button>}
          </div>

        </div>
      </header>
    </div>
  );
});

export default Header;
