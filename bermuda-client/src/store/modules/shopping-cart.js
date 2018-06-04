import { URL, shoppingCartService, productService } from '@/services'
import userAuth from '@/utils/user-auth'
import localCart from '@/utils/local-cart'

// init state
// [{id, product:{}, quantity, created_at}]
const state = {
  added: [],
  checkoutStatus: null
}

// getters
const getters = {
  currentSatus: state => state.status,
  cartProducts: state => state.added,
  cartTotalPrice: (state, getters) => {
    return getters.cartProducts.reduce((total, { product, quantity }) => {
      return total += product.price * quantity
    }, 0)
  }
}

// mutations
const mutations = {
  pushProductToCart (state, cartProduct) {
    state.added.push(cartProduct)
  },
  setAddedProducts (state, cartProducts) {
    state.added = cartProducts
  },
  setCheckoutStatus (state, status) {
    state.checkoutStatus = status
  },
  incrementItemQuantity (state, { product, quantity }) {
    const cartItem = state.added.find(i => i.product.id === product.id)
    cartItem.quantity += Math.round(quantity)
  },

}

// actions
const actions = {
  getCartProducts ({ commit }) {
    // commit('setAddedProducts', [])
    const user = userAuth.auth().currentUser
    if (!user) {
      // add to localStorage
      const cartProducts = localCart.getLocalCart() || []
      commit('setAddedProducts', cartProducts)
    } else {
      shoppingCartService
        .getItems(user.id)
        .then(res => {
          commit('setAddedProducts', res.data || [])
        })
        .catch(err => console.log('getCartProducts =>', err))
    }
  },
  addProductToCart ({ state, commit }, { product, quantity }) {
    commit('setCheckoutStatus', null)

    if (quantity > 0) {
      const cartItem = state.added.find(i => i.product.id === product.id)
      const toAdd = {
        id: new Date().getTime(),
        product,
        quantity,
        created_at: new Date()
      }

      if (!cartItem) {
        localCart.addProduct(
          toAdd,
          () => commit('pushProductToCart', toAdd)
        )
      } else {
        localCart.updateProduct(toAdd)
        commit('incrementItemQuantity', toAdd)
      }

      // 更新库存
      commit('decrementProductInventory', { id: product.id, quantity })
    }
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
