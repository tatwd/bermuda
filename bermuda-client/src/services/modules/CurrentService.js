/**
 * Current Service
 */
export default class UserService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  // get current by id
  getById (id) {
    let self = this
    return self.axios.get(`${self.baseUrl}/current/${id}`)
  }

  // get currents by topic id
  getByTopicId (topicId) {
    let self = this
    return self.axios.get(`${self.baseUrl}/topic/${topicId}/currents`)
  }

  // get top
  getTop (count) {
    let self = this
    return self.axios.get(`${self.baseUrl}/currents/top/${count}`)
  }

  createCurrent (current) {
    let self = this
    return self.axios.post(`${self.baseUrl}/current/create`, current)
  }
}
