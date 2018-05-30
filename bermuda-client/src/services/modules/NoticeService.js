/**
 * Notice Service
 */
export default class NoticeService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  // get all notices
  getAll () {
    let self = this
    return self.axios.get(`${self.baseUrl}/notices`)
  }
}
