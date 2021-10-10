/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC, useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import FilterBar from '../FiltersBar/FilterBar';
import { EventCard } from '../EventCard/EventCard';
import eventsStore from '../../stores/EventsStore';
import './main.scss';

const Main: FC = observer(() => {
  const title = 'Popular';
  const [allEvents, setAllEvents] = useState<any[]>([]);

  useEffect(() => {
    setAllEvents([...eventsStore.allEvents]);
  }, [eventsStore.allEvents]);

  return (
    <main className='main'>
      <FilterBar />
      <div>Здесь короче строка поиска и всякая фигня (дата)</div>

      <section className='events-by-type'>
        <h2 className='events-by-type__title'>{title}</h2>
        <button className='button button--more'>more events</button>
      </section>

      <div className='events-by-type'>
        <h2 className='events-by-type__title'>{title}</h2>

        <div className='events-group'>
          {allEvents.map(eventCard => {
            return (<EventCard
              title={eventCard.title}
              key={eventCard.id}
              id={eventCard.id}
              viewsCount={eventCard.viewsCount}
              startDate={eventCard.startDate}
              endDate={eventCard.endDate}
              photoUrl={eventCard.photoUrl}
              interests={eventCard.interests}
              description={eventCard.description}
              friendsSubscr={eventCard.friendsSubscr}
            />);
          })}
        </div>

        <button className='button button--more'>more events</button>
      </div>

    </main>
  );
});

export default Main;