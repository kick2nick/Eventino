import React, { FC } from 'react';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';

import './App.scss';

import Main from './components/Main/Main';
import MyProfile from './components/MyProfile/MyProfile';


const App: FC = () => {
  const isAuth = true;
  // const myProfilePage = isAuth ? <MyProfile /> : <SignIn />;
  const myProfilePage = isAuth ? <MyProfile /> : <h1>Проход запрещен, иди регайся</h1>;
  return (
    <div className="App">
      <BrowserRouter>
        <header className="App__header" />
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
      </BrowserRouter>
    </div>
  );
};

export default App;
