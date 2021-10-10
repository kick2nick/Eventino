import React, { FC } from 'react';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';

import './App.scss';

import Main from './components/Main/Main';
import MyProfile from './components/MyProfile/MyProfile';
import Header from './components/Header/Header';
import Auth from './components/Modals/Auth/Auth';


const App: FC = () => {
  const isAuth = true;
  // const myProfilePage = isAuth ? <MyProfile /> : <SignIn />;
  const myProfilePage = isAuth ? <MyProfile /> : <h1>Проход запрещен, иди регайся</h1>;
  return (
    <div className="App">
      <BrowserRouter>
        <Header />
        <Switch>
          <Route path="/" exact>
            <Main />
          </Route>

          <Route path="/myProfile" exact>
            {myProfilePage}
          </Route>
          <Redirect to="/" />
        </Switch>
        <footer />
        <Auth />

      </BrowserRouter>
    </div>
  );
};

export default App;
