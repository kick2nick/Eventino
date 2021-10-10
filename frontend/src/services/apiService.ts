
const apiUrl = 'https://eventino-dev.azurewebsites.net/api';

export interface IResSignIn {
  type: string;
  title: string;
  status: number;
  detail: string;
  instance: string;
}
export class AuthApi {
  async postSignIn(email: string): Promise<any> {
    try {
      const response = await fetch(`${apiUrl}/LogIn/SignIn`,
        {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({ 'email': email }),
        });
      const data = await response.json();
      return data;
    } catch (error: any) {
      if (error) {
        return error.message;
      }
    }
  }

  async postSignOut(): Promise<any> {
    try {
      const response = await fetch(`${apiUrl}/LogIn/SignOut`,
        {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
          },
          body: '',
        });
      const data = await response.json();
      return data;

    } catch (error: any) {
      if (error) {
        return error.message;
      }
    }
  }

  async postRegister(userName: string, email: string): Promise<any> {
    try {
      const response = await fetch(`${apiUrl}/Register`,
        {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({ 'userName': userName, 'email': email }),
        });
      const data = await response.json();
      return data;

    } catch (error: any) {
      if (error) {
        return error.message;
      }
    }
  }

  async getGoogleLogIn(): Promise<any> {
    try {
      const response = await fetch((`${apiUrl}/Login/googleLogin`));
      const data = await response.json();
      return data;
    } catch (error: any) {
      if (error) {
        return error.message;
      }
    }
  }

}
