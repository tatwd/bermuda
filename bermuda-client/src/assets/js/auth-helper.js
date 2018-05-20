function AuthHelper(key) {
  this.key = key;
}

// AuthHelper.prototype.currentToken =

// save token to localStorage
AuthHelper.prototype.saveToken = function (token) {
  localStorage.setItem(this.key, JSON.stringify(token));
}

// get token from localStorage
AuthHelper.prototype.getToken = function () {
  return JSON.parse(localStorage.getItem(this.key));
}

// remove token by key
AuthHelper.prototype.removeToken = function () {
  localStorage.removeItem(this.key);
}

// update token
AuthHelper.prototype.updateToken = function (newToken) {
  localStorage.setItem(this.key, newToken);
}

// check for token expired or not
AuthHelper.prototype.expired = function () {
  let now = new Date().getTime();
  let loginAt = this.getToken().login_at;
  return now - loginAt
}

export default AuthHelper;
