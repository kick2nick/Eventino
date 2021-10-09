/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC } from 'react';
import './eventCard.scss';
import { Link } from 'react-router-dom';
export interface IEventCard {
  id: number,
  title: string,
  date?: any,    // new Date
  img?: string,
  description?: string,
  tags?: Array<string>,    // string[]
  watchCount?: number,
  friendsSubscr?: Array<string>
}

const EventCard: FC<IEventCard> = ({
  title = 'title',
  date = 'Oct 14, 2021',
  img = 'https://pbs.twimg.com/media/Cdx37K1UsAESeJp.jpg',
  description = 'Jake Burns will be joining us to tell us about where he thinks you can enjoy the best cycling.',
  tags = ['sport', 'outdoor'],
  watchCount = 17,
  friendsSubscr = ['Petya', 'Vasya'],
}) => {

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
          <div>M</div>
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
        {tags.map(tag => <button className='card__tag button is-rounded' key={tag}>
          <img className='tag__icon' src={`/icons/${tag}.png`} />{tag}
        </button>)}
        <Link to='' className='card__friends-subscr'>{friendsSubscr.length} friends subscribed</Link>
        <Link to='' className='card__link'>Subscribe</Link>
        <Link to='' className='card__link'>See more</Link>
      </div>
    </div>
  );
};

export { EventCard };