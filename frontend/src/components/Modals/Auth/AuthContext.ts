import { createContext } from 'react';

type ContextProps = {
  switchToSignUp: () => void,
  switchToLogIn: () => void,
  switchToClose: () => void,
  active: string,
};

export const AuthContext = createContext<Partial<ContextProps>>({});
