/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC } from 'react';
import './eventCard.scss';
import { Link } from 'react-router-dom';
// export interface IEventCard {
//   id: string,
//   title: string,
//   date?: any,    // new Date
//   img?: string,
//   description?: string,
//   tags?: Array<string>,    // string[]
//   watchCount?: number,
//   friendsSubscr?: Array<string>
// }

export interface IEventCard {
  id: string,
  hostId?: string,
  title?: string,
  description?: string,
  photoUrl?: string,
  place?: string,
  type?: number,
  status?: number,
  maxMembers?: number,
  startDate?: string,
  endDate?: string,
  attendees?: Array<string>,
  friendsSubscr?: Array<string>,
  interests?: Array<string>,
  viewsCount?: number
}

const EventCard: FC<IEventCard> = () => {

  // console.log(id);
  const title = 'title';
  const watchCount = 0;
  const date = 0;
  const img = 'https://cdn1.flamp.ru/e99752ed0f4211de562238f7d1b3faef.jpg';
  const interests = [{ tag: 'Sports' }];
  const description = 'description';
  const friendsSubscr = ['friendsSubscr', 'friendsSubscr'];

  return (
    <div className='card Card' >

      <div className='card__top-group'>
        <h3 className='card__title'>{title}</h3>
        <div className='card__watch-count watch-count'>
          <img className='watch-count__icon' src='/icons/eye.png' width='22' height='15' />
          <div>{watchCount}</div>
        </div>
        <div className='card__date date'>
          <div className='img-container'>
            <img className='date__icon' src='/icons/date.png' width='20' height='20' />
          </div>
          <div>{date}</div>
        </div>
        <div className='card__date-week date-week'>
          <div className='is-active'>M</div>
          <div>T</div>
          <div>W</div>
          <div>T</div>
          <div>F</div>
          <div>S</div>
          <div>S</div>
        </div>
      </div>

      <img src={img} className='card__img' />

      <div className='card__bottom-group'>
        <p className='card__description'>{description}</p>
        {interests.map(tag => <button className='card__tag button is-rounded' key={tag.tag}>
          <img className='tag__icon' src={`/icons/${tag.tag}.svg`} />{tag.tag}
        </button>)}
        <Link to='' className='card__friends-subscr'>{friendsSubscr.length} friends subscribed</Link>
        <Link to='' className='card__link'>Subscribe</Link>
        <Link to='' className='card__link'>See more</Link>
      </div>
    </div>
  );
};

export { EventCard };