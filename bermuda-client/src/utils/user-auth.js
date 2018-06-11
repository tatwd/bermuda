/**
 * user auth
 */
class UserAuth {
  key

  constructor(key) {
    this.key = key;
  }

  get token () {
    return this.getToken();
  }

  set token(token) {
    localStorage.setItem(this.key, JSON.stringify(token))
  }

  get currentUser () {
    return this.token ? this.token.current_user : null;
  }

  getToken () {
    let str = localStorage.getItem(this.key);
    return JSON.parse(str);
  }

  updateToken (token) {
    token.current_user = JSON.parse(token.current_user)
    localStorage.setItem(this.key, JSON.stringify(token));
  }

  removeToken () {
    localStorage.removeItem(this.key);
  }

  auth () {
    let now, loginAt;

    // check for `access_token` expired or not
    if (this.token) {
      now = new Date().getTime();
      loginAt = this.token.login_at;

      if ((now - loginAt) / 1000 > this.token.expires_in)
        this.removeToken();
    }

    return this;
  }
}

export default new UserAuth('BMD_USER_AUTH');
