import { productService } from '@/services'

// init state
const state = {
  all: [],
  current: null
}

// getters
const getters = {
  allProducts: state => state.all,
  currentProduct: state => state.current
}

// mutations
const mutations = {
  setProducts (state, products) {
    state.all = products
  },
  setCurrentProduct (state, product) {
    state.current = product
  }
}

// actions
const actions = {
  getAllProducts ({ commit }) {
    productService
      .getAll()
      .then(res => {
        commit('setProducts', res.data)
      })
      .catch(err => console.log('getAllProducts =>', err))
  },
  getPorductById ({ state, commit }, payload) {
    if (state.all.length) {
      let product = state.all.find(product => product.id === payload.id) || null
      commit('setCurrentProduct', product)
    } else {
      productService
        .getById(payload.id)
        .then(res => {
          commit('setCurrentProduct', res.data)
        })
    }
  },
  decrementProductInventory (state, {id, quantity}) {
    console.log(id)
    const product = state.all.find(product => product.id === id)
    product.inventory -= quantity
    // update to db
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
