/**
 * User Service
 */
export default class UserService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  // signup
  signup (user) {
    let self = this

    return self.axios.post(`${self.baseUrl}/account/register`, user)
  }

  // signin
  signin (user) {
    let self = this
    let data = `username=${user.username}&password=${user.password}&grant_type=password`
    let headers = {
      'Content-Type': 'application/x-www-form-urlencoded',
      'No-Auth':'True'
    }
    return self.axios.post(`${self.baseUrl}/token`, data, { headers })
  }

  // signout
  signout () {}
}
