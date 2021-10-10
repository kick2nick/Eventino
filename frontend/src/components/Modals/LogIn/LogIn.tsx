import React, { useState, useEffect, useContext, FC } from 'react';
import { AuthApi } from '../../../services/apiService';
import './LogIn.scss';
import { AuthContext } from '../Auth/AuthContext';


export const LogIn: FC = () => {

  const { switchToSignUp, switchToClose, active } = useContext(AuthContext);
  const [validMail, setValidMail] = useState(false);
  const [email, setEmail] = useState('');
  const [errRequest, setErrRequest] = useState('');
  const authApi = new AuthApi();

  const def = () => null;

  const handleClickClose = switchToClose || def;
  const handleChangeEmail = (value: string) => setEmail(value);
  const handleClickSubmit = () => authApi.postSignIn(email).then(data => {
    if (typeof data === 'string') handleClickClose();
    else setErrRequest('Please sing up!');
  }).catch(() => setErrRequest('Please sign up!'));
  const handleClickGoogle = () => authApi.getGoogleLogIn().then(data => {
    if (typeof data === 'string') handleClickClose();
    else setErrRequest('Somthing heppend!');
  }).catch(() => setErrRequest('Somthing heppend!'));

  const isValidMail = () => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  };

  useEffect(() => {
    const validRes = isValidMail();
    if (validRes) setValidMail(true);
    else setValidMail(false);
  }, [email]);

  return (
    <div className={active === 'login' ? 'modal is-active' : 'modal'}>
      <div className="modal-background" onClick={handleClickClose}></div>
      <div className="modal-card">
        <div className="box">
          <div className="is-flex is-justify-content-end">
            <button className="delete" aria-label="close" onClick={handleClickClose}></button>
          </div>
          {errRequest !== '' ?
            <article className="message is-danger">
              <div className="message-header">
                <p>Danger</p>
              </div>
              <div className="message-body">
                {errRequest}
              </div>
            </article> : ''}
          <h2 className="title is-3 ">Log in</h2>
          <p className="subtitle is-6 ">to join or create an event, and invite your friends</p>
          <section className="modal-card-body">
            <div className="field">
              <p className="control has-icons-right">
                <input
                  className="input"
                  value={email}
                  type="text"
                  placeholder="Email"
                  onChange={(e) => handleChangeEmail(e.target.value)} />
                <span className="icon is-small is-right">
                  {validMail ? <i className="fas fa-angle-down"></i> : ''}
                </span>
              </p>
            </div>
            <button
              className="button is-success is-fullwidth"
              disabled={!validMail}
              onClick={handleClickSubmit}>LOG IN</button>
            <div className="control has-icons-left mt-2">
              <button className="button is-fullwidth" onClick={handleClickGoogle}>LOG IN WITH GOOGLE</button>
              <span className="icon is-small is-left">
                <i className="fas fa-Google"></i>
              </span>
            </div>

            <button className="sing-up-link mt-3" onClick={switchToSignUp}>Don't have an account? Sign Up</button>
          </section>
        </div>
      </div>
    </div>
  );
};
