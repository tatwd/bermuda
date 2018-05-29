import Vue from 'vue'
import Vuex from 'vuex'

import auth from './modules/auth'
import topics from './modules/topics'
import notices from './modules/notices'
import noticeSpecies from './modules/notice-species'
import search from './modules/search'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    auth,
    topics,
    notices,
    noticeSpecies,
    search
  }
})
