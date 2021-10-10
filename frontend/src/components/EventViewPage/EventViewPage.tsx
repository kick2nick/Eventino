import React, { FC, useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';
import './eventViewPage.scss';

const apiUrl = 'https://eventino-dev.azurewebsites.net/api';
const eventStore = {
  id: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
  hostId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
  title: 'Test titkle',
  description: 'test descript',
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

  return (
    <section>
      <h2 className='event-title'>{eventStore.title}</h2>

      <div className="event-view-page container">
        <div className="left-group">
          <img className='event-image' src={eventStore.photoUrl} alt="" width='560' height='320' />
          <div className="event-description">
            {eventStore.description}
          </div>
          <div className="control">
            <Link to='/' className='back-to-menu-button'>BACK TO MENU</Link>
            <Link to='/' className='subscribe-button'>SUBSCRIBE</Link>
          </div>
        </div>


        <div className="right-group">
          <div className="details-group">
            <div className="event-date">
              {eventStore.startDate}
            </div>
            <div className="event-time">
              {eventStore.startDate}
            </div>
            <div className="event-place">
              {eventStore.place}
            </div>
          </div>
          <div className="status">{eventStore.status}</div>
          <div className="max-members">{eventStore.maxMembers}</div>
          <div className="current">{eventStore.attendees}</div>
          <div className="subs">{eventStore.friendsSubscr}</div>
          {eventStore.interests.map(tag => <button className='card__tag button is-rounded' key={tag}>
            <img className='tag__icon' src={`/icons/${tag}.svg`} />{tag}
          </button>)}
        </div>
      </div>
    </section>
  );
});

export default EventViewPage;

