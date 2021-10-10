import React, { FC } from 'react';

const FilterBar: FC = () => {

  const interests = ['Sports', 'Outdoor', 'Games', 'Party', 'Movie', 'Music', 'Online', 'Restaurant', 'Training', 'Classes'];
  

  return (
    <div>
      {interests.map((tag, i) => <button className='card__tag button is-rounded' key={i}>
            <img className='tag__icon' src={`/icons/${tag}.svg`} />{tag}
          </button>)}
    </div>
  );
};

export default FilterBar;