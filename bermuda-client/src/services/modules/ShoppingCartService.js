/**
 * Shopping Cart Service
 */
export default class ShoppingCartService {
  axios
  baseUrl

  constructor(axios, apiUrl) {
    this.axios = axios
    this.baseUrl = apiUrl
  }

  // get items of user shopping cart
  getItems (uid) {
    let self = this
    return self.axios.get(`${self.baseUrl}/cart/${uid}`)
  }

  // addItem (product) {
  //   let self = this
  //   return self.axios.post(`${self.baseUrl}/cart/`)
  // }
}
