/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC, useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import FilterBar from '../FiltersBar/FilterBar';
import { IEventCard, EventCard } from '../EventCard/EventCard';
import eventsStore from '../../stores/EventsStore';
import './main.scss';
import { Input } from 'antd';
import { Calendar } from 'react-date-range';

const Main: FC = observer(() => {
  const title = 'Popular';
  const eventsPopular: Array<IEventCard> = [];

  const { Search } = Input;

  const [allEvents, setAllEvents] = useState<any[]>([]);

  useEffect(() => {
    setAllEvents([...eventsStore.allEvents]);
  }, [eventsStore.allEvents]);

  const onSearch = () => {
    // to fill
  };

  // fix: DRY
  return (
    <main className='main'>
      <FilterBar />

      <Search placeholder="input search text" onSearch={onSearch} enterButton />
      <Calendar
        date={new Date()}
        // onChange={this.handleSelect}
      />
      <div>Здесь короче строка поиска и всякая фигня (дата)</div>

      <section className='events-by-type'>
        <h2 className='events-by-type__title'>{title}</h2>
        {/* <div>блок с сортировкой</div> */}

        <div className='events-group'>
          {allEvents.map(eventCard => {
            return (<EventCard
              title={eventCard.title}
              key={eventCard.id}
              id={eventCard.id}
              startDate={eventCard.startDate} />);
          })}
        </div>

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
              startDate={eventCard.startDate} />);
          })}
        </div>


        <button className='button button--more'>more events</button>
      </div>

    </main>
  );
});

export default Main;