import React, { FC } from 'react';
import './filtersBar.scss';

const FilterBar: FC = () => {

  const interests = [
    'Sports',
    'Outdoor',
    'Games',
    'Party',
    'Movie',
    'Music',
    'Online',
    'Restaurant',
    'Training',
    'Classes',
  ];


  return (
    <div className='container'>
      <div className="filter-bar">
        {interests.map((tag, i) => <button className='card__tag button is-rounded' key={i}>
          <img className='tag__icon' src={`/icons/${tag}.svg`} />{tag}
        </button>)}
      </div>
    </div>
  );
};

export default FilterBar;