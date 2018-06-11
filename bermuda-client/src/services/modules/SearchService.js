/**
 * Search Service
 */
export default class SearchService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  search (q, type) {
    let self = this
    return self.axios.get(`${self.baseUrl}/search/${type}s/${q}`)
  }
}
