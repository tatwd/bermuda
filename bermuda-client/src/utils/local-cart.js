/**
 * local shopping cart
 * using localStorage
 */
const KEY = 'LOCAL_CART'

function getLocalCart () {
  let cart = localStorage.getItem(KEY);
  return JSON.parse(cart);
}

function addProduct (product, cb) {
  let cart = getLocalCart() || [];
  cart.push(product)
  localStorage.setItem(KEY, JSON.stringify(cart))
  cb && cb()
}

function updateProduct({ product, quantity }) {
  let cart = getLocalCart();
  if (cart) {
    const item = cart.find(i => i.product.id === product.id)
    item.quantity += Math.round(quantity)
    localStorage.setItem(KEY, JSON.stringify(cart))
  }
}

function removeProduct (productId) {
  let cart = getLocalCart() || [];
  cart = cart.filter(product => product.id !== productId)
}

export default {
  getLocalCart,
  addProduct,
  updateProduct,
  removeProduct
}
