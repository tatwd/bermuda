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

  // register
  createUser (user) {
    let self = this
    return self.axios.post(`${self.baseUrl}/account/register`, user)
  }
}
