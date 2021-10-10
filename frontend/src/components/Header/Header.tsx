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
          <div className='header__photo'>
            {currentUser.isAuth && <Link to="/myProfile" className="image is-32x32 mr-2">
              <img className='is-rounded' src={`/${currentUser.photoFileName}`} alt='user icon' />
            </Link>}
            {currentUser.isAuth ?
              <button className="button is-outlined header__button" onClick={() => currentUser.singOutFromAccount()}>
                Sing Out
              </button> :
              <div className="logIn-group">

                <Link to='/myProfile' className='img-group'> <img src="/icons/avatar_mock.png" alt="it's you" /> </Link>
                <button className="button is-outlined header__button" onClick={() => currentUser.openLogIn()}>
                  Log In
                </button>
              </div>
            }
          </div>

        </div>
      </header>
    </div>
  );
});

export default Header;
