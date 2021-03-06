import React, { FC } from 'react';
import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';
import currentUser from '../../stores/UserStore';
import Tabs from './Tabs';
import './myProfile.scss';


const MyProfile: FC = observer(() => {
  return (
    <section className='my-profile'>
      <Tabs />
      <div className='container'>
        <div className='user__avatar'>
          <img src={currentUser.photoFileName} alt="user's avatar" width='160' height='160' />
        </div>

        <div className="user__info">
          <h2 className="user__title">{currentUser.name}</h2>
          <div className="email">{currentUser.email}</div>

          <div className="field">
            <p className="control has-icons-left input-group">
              <input className="input is-large" type="password" placeholder="Password" />
              <span className="icon is-small is-left">
                <i className="fas fa-lock"></i>
              </span>
            </p>
            <Link to='' className='password-reset'>Change your password</Link>

            <div className="interests">
              <div className="interests__title">interests</div>
              <div className="icon-group">
                {currentUser.interests.map(tag =>
                  <img
                    key='tag'
                    src={`/icons/${tag.name}.svg`}
                    className='filter-green interests__icon'
                    width='32'
                    height='32' />,
                )}
              </div>
            </div>
            <div className="user-week">
              <div className="user-week__title">This week busy days:</div>
              <div className="week-days box">
                <div className=''>S</div>
                <div className="">M</div>
                <div className="">T</div>
                <div className="">W</div>
                <div className="">T</div>
                <div className="">F</div>
                <div className="">S</div>
              </div>
              <div className="week-date">
                <div className='is-active'>11</div>
                <div className="">12</div>
                <div className="">13</div>
                <div className="">14</div>
                <div className="">15</div>
                <div className="">16</div>
                <div className="">17</div>
              </div>
            </div>
            <div className="control">
              <Link to='/' className='button is-success is-outlined'>Back to main</Link>
              <Link to='/editProfile' className='button is-success'>Edit Profile</Link>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
});

export default MyProfile;

