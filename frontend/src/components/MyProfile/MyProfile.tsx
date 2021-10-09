import React, { FC } from 'react';
import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';
import currentUser from '../../stores/UserStore';
import './myProfile.scss';


const MyProfile: FC = observer(() => {
  console.log(currentUser.id);
  return (
    <section className='my-profile'>
      <div className='container'>
        {/* tabs */}
        <div className='user__avatar'>
          <img src={currentUser.photoFileName} alt="user's avatar" width='160' height='160' />
        </div>
        <div className="user__info">
          <h2 className="user__title">{currentUser.name}</h2>
          <div className="email">{currentUser.email}</div>
          <div className="field">
            <p className="control has-icons-left">
              <input className="input" type="password" placeholder="Password" />
              <span className="icon is-small is-left">
                <i className="fas fa-lock"></i>
              </span>
            </p>
            <Link to=''>Change your password</Link>

            <div className="interests">
              <div className="interests__title">interests</div>
              {currentUser.interests.map(tag =>
                <img key='tag' src={`/icons/${tag.name}.png`} className='filter-green' />,
              )}
            </div>
            <div className="user-week">
              <div className="title">This week busy days:</div>
              <div className="week-days">MTWTFSS</div>
              <div className="week-date">2345678</div>
            </div>
            <div className="control">
              <button className='button is-success is-outlined'>Back to main</button>
              <button className='button is-success'>Edit Profile</button>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
});

export default MyProfile;
// id = '3fa85f64-5717-4562-b3fc-2c963f66afa6';
// email = 'string';
// name = 'string';
// photoFileName = 'avatar.png';
// interests = [
//   {
//     id: 0,
//     name: 'string',
//   },
// ];