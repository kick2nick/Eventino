import React, { FC } from 'react';
import FilterBar from '../FiltersBar/FilterBar';
import { IEventCard, EventCard } from '../EventCard/EventCard';

const Main: FC = () => {
  const title = 'Popular';
  const eventsPopular: Array<IEventCard> = [{ title: 'Title' }, { title: 'Title' }, { title: 'Title' }];

  return (
    <main className='main'>
      <FilterBar />
      <div>Здесь короче строка поиска и всякая фигня (дата)</div>

      <div className='event__group'>
        <h2>{title}</h2>
        {eventsPopular.map(eventCard => { return (<EventCard title={eventCard.title} />); })}
        <button>more events</button>
      </div>

      <div className='event__group'>
        <h2>{title}</h2>
        {eventsPopular.map(eventCard => { return (<EventCard title={eventCard.title} />); })}
        <button>more events</button>
      </div>

    </main>
  );
};

export default Main;