import Vue from 'vue'
import Vuex from 'vuex'

import auth from './modules/auth'
import topics from './modules/topics'
import notices from './modules/notices'
import noticeSpecies from './modules/notice-species'
import products from './modules/products'
import shoppingCart from './modules/shopping-cart'
import search from './modules/search'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'product'

export default new Vuex.Store({
  modules: {
    auth,
    topics,
    notices,
    noticeSpecies,
    products,
    shoppingCart,
    search
  },
  strict: debug
})
