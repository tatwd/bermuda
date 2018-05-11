import Vue from 'vue'
import Vuex from 'vuex'

// import services from './services'

import topics from './modules/topics'

Vue.use(Vuex)

// const state = {
//   services
// }

export default new Vuex.Store({
  // state
  modules: {
    topics
  }
})
