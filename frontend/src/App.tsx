import React, { FC } from 'react';
import './App.scss';
import Main from './components/Main/Main';

const App: FC = () => {
  return (
    <div className="App">
      <header className="App__header" />
      <Main />
      <footer />
    </div>
  );
};

export default App;
