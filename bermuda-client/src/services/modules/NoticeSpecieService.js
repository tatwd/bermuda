/**
 * Notice Specie Service
 */
export default class NoticeSpecieService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  // get all speices
  getAll () {
    let self = this
    return self.axios.get(`${self.baseUrl}/notice/species`)
  }
}
