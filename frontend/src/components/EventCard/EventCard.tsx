/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC } from 'react';
// import { Card } from 'antd';
import './eventCard.scss';

export interface IEventCard {
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
  date = 'date',
  img = 'https://pbs.twimg.com/media/Cdx37K1UsAESeJp.jpg',
  description = 'description',
  tags = ['tag1', 'tag2'],
  watchCount = 0,
  friendsSubscr = ['Petya', 'Vasya'],
}) => {

  return (
    <div className='card Card' >
      <h2 className='card__title'>{title}</h2>
      <div className='card__watch-count'>{watchCount}</div>
      <div className='card__date'>{date}</div>
      <div className='card__date-day'>date table</div>
      <img src={img} className='card__img'></img>
      <p className='card__description'>{description}</p>
      {tags.map(tag => <div className='card__tag'>{tag}</div>)}
      <div className='card__friends-subscr'>{friendsSubscr.length} friends subscribed</div>
    </div>
  );
};

export { EventCard };