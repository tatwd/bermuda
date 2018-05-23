import Vue from 'vue'
import Vuex from 'vuex'

import topics from './modules/topics'
import noticeSpecies from './modules/notice-species'
import auth from './modules/auth'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    topics,
    noticeSpecies,
    auth
  }
})
