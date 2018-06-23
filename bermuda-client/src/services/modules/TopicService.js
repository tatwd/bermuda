/**
 * Topic Service
 */
export default class TopicService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  // get all topics
  getAll () {
    let self = this
    return self.axios.get(`${self.baseUrl}/topics`)
  }

  // get hot topics
  getTop (count) {
    let self = this
    let countStr = count ? '/' + count : ''
    return self.axios.get(`${self.baseUrl}/topics/top${ countStr }`)
  }

  // get by id
  getById (id) {
    let self = this
    return self.axios.get(`${self.baseUrl}/topic/${id}`)
  }

  // create a topic
  createTopic (newTopic) {
    let self = this
    return self.axios.post(`${self.baseUrl}/topic/create`, newTopic)
  }
}
