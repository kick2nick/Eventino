import React, { FC } from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.scss';
import Main from './components/Main/Main';

const App: FC = () => {
  return (
    <div className="App">
      <BrowserRouter>
        <header className="App__header" />
        <Main />
        <footer />
      </BrowserRouter>
    </div>
  );
};

export default App;
