import { URL, productService } from '@/services'
import imgUrlFilter from '@/filter/img-url'

// init state
const state = {
  all: []
}

// getters
const getters = {
  allProducts: state => state.all
}

// mutations
const mutations = {
  setProducts (state, products) {
    state.all = products
  }
}

// actions
const actions = {
  getAllProducts ({ commit }) {
    productService
      .getAll()
      .then(res => {
        imgUrlFilter(res.data, URL.ROOT)
        commit('setProducts', res.data)
      })
      .catch(err => console.log('getAllProducts =>', err))
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
