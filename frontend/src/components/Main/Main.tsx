import React, { FC } from 'react';
import FilterBar from '../FiltersBar/FilterBar';
import { IEventCard } from '../EventsCard/EventsCard';

const Main: FC = () => {
  const title = 'Popular';
  const eventsPopular: Array<IEventCard> = [{ title: 'testTitle' }, { title: 'testTitle' }, { title: 'testTitle' }];

  return (
    <main className='main'>
      <FilterBar />
      <div>Здесь короче строка поиска и всякая фигня (дата)</div>

      <div className='event__group'>
        <h2>{title}</h2>
        {eventsPopular.map(eventCard => { return (<div>{eventCard.title}</div>); })}
        <button>more events</button>
      </div>

      <div className='event__group'>
        <h2>{title}</h2>
        {eventsPopular.map(eventCard => { return (<div>{eventCard.title}</div>); })}
        <button>more events</button>
      </div>

    </main>
  );
};

export default Main;