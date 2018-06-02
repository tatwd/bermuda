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

  getAll () {
    let self = this
    return self.axios.get(`${self.baseUrl}/products`)
  }
}
