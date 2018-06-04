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

  // get notice by id
  getById (id) {
    let self = this
    return self.axios.get(`${self.baseUrl}/notices/${id}`)
  }
}
