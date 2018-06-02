/**
 * Product Service
 */
export default class ProductService {
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

  getById (id) {
    let self = this
    return self.axios.get(`${self.baseUrl}/products/${id}`)
  }
}
