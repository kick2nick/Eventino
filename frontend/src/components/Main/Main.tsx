/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { FC, useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import FilterBar from '../FiltersBar/FilterBar';
import { EventCard } from '../EventCard/EventCard';
import eventsStore from '../../stores/EventsStore';
import './main.scss';
import { Input } from 'antd';
import 'antd/dist/antd.css';
import 'react-date-range/dist/styles.css'; // main style file
import 'react-date-range/dist/theme/default.css'; // theme css file
import { DatePicker, Space } from 'antd';


const Main: FC = observer(() => {
  const title = 'Popular';
  const { RangePicker } = DatePicker;

  const { Search } = Input;

  const [allEvents, setAllEvents] = useState<any[]>([]);

  useEffect(() => {
    setAllEvents([...eventsStore.allEvents]);
  }, [eventsStore.allEvents]);

  return (
    <main className='main'>
      <FilterBar />

      <div className="search-and-calendar container">
        <Search placeholder="SEARCH EVENT" allowClear className="search" />
        <div className="site-calendar-demo-card">
          <Space direction="vertical" size={12}>
            <RangePicker />
          </Space>
        </div>
      </div>

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