import React, { FC, useState } from 'react';
import { Link } from 'react-router-dom';
import './tabs.scss';


const Tabs: FC = () => {
  // to do: move to constanst
  const tabsData = [
    {
      id: '1',
      path: '/profile',
      tabTitle: 'profile',
    },
    {
      id: '2',
      path: '/subscribed-events',
      tabTitle: 'subscribed events',
    },
    {
      id: '3',
      path: '/hosted-events',
      tabTitle: 'hosted events',
    },
    {
      id: '4',
      path: '/friends',
      tabTitle: 'friends',
    },
  ];
  const [isVisibleTab, setVisibleTab] = useState(tabsData[0].id);

  return (
    <div className="tabs is-centered is-large">
      <ul>
        {tabsData.map(tab => (
          <li className={isVisibleTab === tab.id ? 'is-active' : ''} onClick={() => setVisibleTab(tab.id)} key={tab.id}>
            <Link to={tab.path}>{tab.tabTitle}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Tabs;