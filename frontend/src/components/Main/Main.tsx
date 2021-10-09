import React, { FC } from 'react';
import FilterBar from '../FiltersBar/FilterBar';
import { IEventCard, EventCard } from '../EventCard/EventCard';
import './main.scss';

const Main: FC = () => {
  const title = 'Popular';
  const eventsPopular: Array<IEventCard> = [
    { title: 'Title', id: 1 },
    { title: 'Title', id: 2 },
    { title: 'Title', id: 3 }];
  // fix: DRY
  return (
    <main className='main'>
      <FilterBar />
      <div>Здесь короче строка поиска и всякая фигня (дата)</div>

      <section className='events-by-type'>
        <h2 className='events-by-type__title'>{title}</h2>
        {/* <div>блок с сортировкой</div> */}

        <div className='events-group'>
          {eventsPopular.map(eventCard => {
            return (<EventCard
              title={eventCard.title}
              key={eventCard.id}
              id={eventCard.id} />);
          })}
        </div>

        <button className='button button--more'>more events</button>
      </section>

      <div className='events-by-type'>
        <h2 className='events-by-type__title'>{title}</h2>

        <div className='events-group'>
          {eventsPopular.map(eventCard => {
            return (<EventCard
              title={eventCard.title}
              key={eventCard.id}
              id={eventCard.id} />);
          })}
        </div>

        <button className='button button--more'>more events</button>
      </div>

    </main>
  );
};

export default Main;