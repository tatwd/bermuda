import services from '../services'

// server assets url
const ASSETSS_URL = 'http://localhost:53595'

// init state
const state = {
  all: []
}

// getters
const getters = {
  allTopics: state => {
    let _all = state.all
    if (_all.length <= 0) {
      // init 10 topics
      for (let i = 0; i < 10; i++) {
        _all.push({
          id: null,
          name: '',
          img_url: '@/assets/template.svg'
        })
      }
    }
    return _all
  }
}

// mutations
const mutations = {
  setTopics (state, topics) {
    topics.forEach((topic, index) => {
      state.all[index].id = topic.id
      state.all[index].name = topic.name
      state.all[index].img_url = ASSETSS_URL + topic.img_url
    });
  }
}

// actions
const actions = {
  getAllTopics ({ commit }) {
    services.topicService.getTop().then(res => {
      commit('setTopics', res.data)
    })
    .catch(err => console.error(err))
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
