/* eslint-disable @typescript-eslint/ban-ts-comment */
import React, { FC, useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';
import './eventViewPage.scss';

const apiUrl = 'https://eventino-dev.azurewebsites.net/api';
const eventStore = {
  id: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
  hostId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
  title: 'Space kitten attack',
  description: 'This will be the most unforgettable '
    + 'event in your life! A giant kitten with the body of'
    + 'a t-rex walks around the city and shoots lasers from its eyes!',
  photoUrl: 'https://pbs.twimg.com/media/Cdx37K1UsAESeJp.jpg',
  place: 'string',
  type: 0,
  status: 0,
  maxMembers: 0,
  startDate: '2021-10-10T12:40:43.505Z',
  endDate: '2021-10-10T12:40:43.505Z',
  attendees: [
    '3fa85f64-5717-4562-b3fc-2c963f66afa6',
  ],
  friendsSubscr: [
    '3fa85f64-5717-4562-b3fc-2c963f66afa6',
  ],
  interests: [
    'Sports',
    'Music',
    'Outdoor',
    'Classes',
    'Online',
    'Games',
  ],
  viewsCount: 0,
};

const EventViewPage: FC = observer(() => {

  const [eventT, setEvent] = useState();

  useEffect(() => {
    const event = async (id: string) => {
      try {
        const response = await fetch(`${apiUrl}/Events/${id}`);
        const data = await response.json();
        return data;
      } catch (error: any) {
        if (error) {
          return error.message;
        }
      }
    };
    event('24479442-060d-493f-ae1f-86108a1e3860').then((value) => {
      setEvent(value);
      console.log(value);
    });

  }, []);

  const DateTransform = (string: string) => {
    const date = new Date(string);
    const options = { year: 'numeric', month: 'short', day: 'numeric' };
    //@ts-ignore
    return new Intl.DateTimeFormat('en-EN', options).format(date);
  };
  const DateTransformWeekday = (string: string) => {
    const date = new Date(string);
    const options = { weekday: 'long' };
    //@ts-ignore
    return new Intl.DateTimeFormat('en-EN', options).format(date);
  };

  const DateTransformTime = (string: string) => {
    const date = new Date(string);
    const options = {
      hour: 'numeric', minute: 'numeric',
      hour12: false,
    };
    //@ts-ignore
    return new Intl.DateTimeFormat('en-EN', options).format(date);
  };

  return (
    <section className='sectionEvent'>
      <h2 className='event-title'>{eventStore.title}</h2>

      <div className="event-view-page container">
        <div className="left-group">
          <img className='event-image' src={eventStore.photoUrl} alt="" width='560' height='320' />
          <div className="event-description">
            {eventStore.description}
          </div>
          <div className="control">
            <Link to='/' className='button is-outline'>Back to main</Link>
            <Link to='/' className='button is-primary'>SUBSCRIBE</Link>
          </div>
        </div>


        <div className="right-group">
          <div className="details-group">
            <div className="event-date">
              <div className='date'><img src="/icons/calendar.png" alt="" />{DateTransform(eventStore.startDate)}</div>
              <div className='weekday'>{DateTransformWeekday(eventStore.startDate)}</div>
            </div>
            <div className="event-time">
              <img src="/icons/date.png" alt="" /><span>{DateTransformTime(eventStore.startDate)}</span>
            </div>
            <div className="event-place">
              <img src="/icons/place.png" alt="" /><span>St. Petersburg</span>
            </div>
          </div>
          <div className="status"><div className='green-round' />Waiting</div>
          <div className="max-members">Max participants:<span>50</span></div>
          <div className="current">Current participants:<span>18</span></div>
          <div className="subs">2 friends subscribed</div>

          <div className="event-tags">
            {eventStore.interests.map(tag => <button className='card__tag button is-rounded' key={tag}>
              <img className='tag__icon' src={`/icons/${tag}.svg`} />{tag}
            </button>)}
          </div>
        </div>
      </div>
    </section>
  );
});

export default EventViewPage;

