import React, { FC } from 'react';
import { observer } from 'mobx-react-lite';
// import { ICurrentUser } from '../../stores/UserStore';
import currentUser from '../../stores/UserStore';

// interface IUser {
//   id: string,
//   avatar: string,
//   name: string,
//   tags: Array<string>,
//   calendar: Array<boolean>,
//   friends: Array<string>,
// }

export interface IMyProfile {
  // userStore?: ICurrentUser,
  currentUser?: unknown,
}

const MyProfile: FC<IMyProfile> = observer(() => {
  console.log(currentUser.id);
  return (
    <section className='my-profile'>
      <div className='container'>
        {/* tabs */}
        <div className='user__avatar'>
          <img src="/avatar.png" alt="user's avatar" width='160' height='160' />
          {/* <img src={currentUser.avatar} alt="user's avatar" width='160' height='160' /> */}
        </div>
        <div className="user__info">
          <h2 className="user__title"></h2>
        </div>
      </div>
    </section>
  );
});

export default MyProfile;