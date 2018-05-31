/**
 * local shopping cart
 * using localStorage
 */
const KEY = 'LOCAL_CART'

function getLocalCart () {
  let cart = localStorage.getItem(KEY);
  return JSON.parse(cart);
}

function addProduct (product) {
  let cart = getLocalCart() || [];
  cart.push(product)
  localStorage.setItem(JSON.stringify(cart))
}

function removeProduct (productId) {
  let cart = getLocalCart() || [];
  cart = cart.filter(product => product.id !== productId)
}

export default {
  getLocalCart,
  addProduct,
  removeProduct
}
