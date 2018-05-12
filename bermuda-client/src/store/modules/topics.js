import services from '../services'

// server assets url
const ASSETSS_URL = 'http://localhost:53595'

// init state
const state = {
  all: [],
  hot: [],
  isLoaded: false
}

// getters
const getters = {
  allTopics: state => state.all,
  hotTopics: state => (
    state.hot.length
      ? state.hot
      : Array(10).fill({
        id: null,
        name: '',
        img_url: '@/assets/template.svg'
      })
  )
}

// mutations
const mutations = {
  setAllTopics (state, topics) {
    state.all = topics.map(topic => {
      topic.img_url = ASSETSS_URL + topic.img_url
      return topic
    })

    // loaded all topics
    state.isLoaded = true
  },
  setHotTopics(state, payload) {
    state.hot = state.all
      .map(topic => topic)
      .sort((a, b) => b.join_count - a.join_count) // desc
      .slice(0, payload.count)
  }
}

// actions
const actions = {
  async getAllTopics ({ state, commit }) {
    if (!state.isLoaded) {
      await services.topicService
      .getAll()
      .then(res => {
        commit('setAllTopics', res.data)
      })
      .catch(err => console.error(err))
    }
  },
  async getHotTopics ({ dispatch, commit }, payload) {
    await dispatch('getAllTopics')
    await commit('setHotTopics', payload)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
