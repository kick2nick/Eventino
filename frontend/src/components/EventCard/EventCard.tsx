/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC } from 'react';
import './eventCard.scss';
import { Link } from 'react-router-dom';
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

const EventCard: FC<IEventCard> = ({
  title,
  id,
  viewsCount,
  startDate,
  endDate,
  photoUrl,
  interests,
  description,
  friendsSubscr,
}) => {

  const startDateDay = new Date(startDate!).getDay();
  const weeks = ['S', 'M', 'T', 'W', 'T', 'F', 'S'];

  return (
    <div className='card Card' >

      <div className='card__top-group'>
        <h3 className='card__title'>{title}</h3>
        <div className='card__watch-count watch-count'>
          <img className='watch-count__icon' src='/icons/eye.png' width='22' height='15' />
          <div>{viewsCount}</div>
        </div>
        <div className='card__date date'>
          <div className='img-container'>
            <img className='date__icon' src='/icons/date.png' width='20' height='20' />
          </div>
          <div>{startDate}</div>
        </div>
        <div className='card__date-week date-week'>
          {weeks.map((weekday, i) => <div className={startDateDay === i ? 'is-active' : ''} key={i}>{weekday}</div>)}
        </div>
      </div>

      <img src={photoUrl} className='card__img' />

      <div className='card__bottom-group'>
        <p className='card__description'>{description}</p>
        {interests?.map(tag => <button className='card__tag button is-rounded' key={id}>
          <img className='tag__icon' src={`/icons/${tag}.svg`} />{tag}
        </button>)}
        <Link to='' className='card__friends-subscr'>{friendsSubscr?.length} friends subscribed</Link>
        <Link to='' className='card__link'>Subscribe</Link>
        <Link to='' className='card__link'>See more</Link>
      </div>
    </div>
  );
};

export { EventCard };