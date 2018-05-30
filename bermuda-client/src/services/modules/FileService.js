/**
 * File Service
 */
export default class TopicService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  // upload img
  uploadImg (imgData) {
    let self = this
    return self.axios.post(`${self.baseUrl}/files/img/upload`, imgData)
  }
}
