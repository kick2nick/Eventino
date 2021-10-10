/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC, useEffect, useState } from 'react';
import './eventCard.scss';
import { Link, useHistory } from 'react-router-dom';
import eventsStore from '../../stores/EventsStore';

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
  // onClick: () => void;
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
  const [allEvents, setAllEvents] = useState<any[]>([]);

  useEffect(() => {
    setAllEvents([...eventsStore.allEvents]);
  }, [eventsStore.allEvents]);

  console.log(description, endDate);
  const history = useHistory();

  const currentCardId = id;
  function handleClick() {
    history.push(`/event/${currentCardId}`);
  }

  const weeks = ['T', 'W', 'T', 'F', 'S', 'S'];
  return (
    <div className='card Card' onClick={() => handleClick()} >

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
          {/* функция генерации стиля на основе даты начала-даты конца и сопоставления с днями недели */}
          {/* {weeks.map(weekday => <div className={... ? 'is-active' : ''} key={ }>{weekday} </div>)} */}
          <div className='is-active'>M</div>
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