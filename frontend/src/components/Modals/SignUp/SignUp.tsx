import React, { useState, useEffect, FC } from 'react';
import { AuthApi } from '../../../services/apiService';
import './SignUp.scss';
import CurrentUser from '../../../stores/UserStore';

export const SignUp: FC = () => {
  const [validMail, setValidMail] = useState(false);
  const [validFullName, setValidFullName] = useState(false);
  const [validSubmit, setValidSubmit] = useState(false);
  const [email, setEmail] = useState('');
  const [fullName, setFullName] = useState('');
  const [errRequest, setErrRequest] = useState('');

  const authApi = new AuthApi();

  const handleChangeEmail = (value: string) => setEmail(value);
  const handleChangeName = (value: string) => setFullName(value);

  const def = () => null;


  const handleClickSubmit = () => authApi.postRegister(fullName, email).then(data => {
    if (typeof data === 'string') CurrentUser.closeModal();
    else setErrRequest('Somthing heppend!');
  }).catch(() => setErrRequest('Somthing heppend!'));

  const handleClickGoogle = () => authApi.getGoogleLogIn().then(data => {
    if (typeof data === 'string') CurrentUser.closeModal();
    else setErrRequest('Somthing heppend!');
  }).catch(() => setErrRequest('Somthing heppend!'));


  const isValidMail = () => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  };

  useEffect(() => {
    const validRes = isValidMail();
    if (validRes) setValidMail(true);
    if (!validRes) setValidMail(false);
    if (fullName !== '') setValidFullName(true);
    if (fullName === '') setValidFullName(false);
    if (validRes && fullName !== '') setValidSubmit(true);
    else setValidSubmit(false);
  }, [email, fullName]);

  return (
    <div className={CurrentUser.modal === 'signup' ? 'modal is-active' : 'modal'}>
      <div className="modal-background" onClick={() => CurrentUser.closeModal()}></div>
      <div className="modal-card">
        <div className="box">
          <div className="is-flex is-justify-content-end">
            <button className="delete" aria-label="close" onClick={() => CurrentUser.closeModal()}></button>
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
          <h2 className="title is-3 ">Create account</h2>
          <p className="subtitle is-6 ">to join or create an event, and invite your friends</p>
          <section className="modal-card-body">
            <div className="field">
              <p className="control has-icons-right">
                <input
                  className="input"
                  value={fullName} type="text"
                  placeholder="Full Name"
                  onChange={(e) => handleChangeName(e.target.value)} />
                <span className="icon is-small is-right">
                  {validFullName ? <i className="fas fa-angle-down"></i> : ''}
                </span>
              </p>
            </div>
            <div className="field">
              <p className="control has-icons-right">
                <input
                  className="input"
                  value={email} type="text"
                  placeholder="Email"
                  onChange={(e) => handleChangeEmail(e.target.value)} />
                <span className="icon is-small is-right">
                  {validMail ? <i className="fas fa-angle-down"></i> : ''}
                </span>
              </p>
            </div>
            <button
              className="button is-success is-fullwidth"
              disabled={!validSubmit}
              onClick={handleClickSubmit}>CREATE ACCOUNT</button>
            <div className="control has-icons-left mt-2">
              <button className="button is-fullwidth" onClick={handleClickGoogle}>SING UP WITH GOOGLE</button>
              <span className="icon is-small is-left">
                <i className="fas fa-Google"></i>
              </span>
            </div>
            <button className="sing-up-link mt-3" onClick={() => CurrentUser.openLogIn()}>Have an account? Log in</button>
          </section>
        </div>
      </div>
    </div>
  );
};
