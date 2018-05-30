import { URL, topicService } from '@/services'

// init state
const state = {
  all: null,
  hot: null
}

// getters
const getters = {
  allTopics: state => state.all,
  hotTopics: state => state.hot
}

// mutations
const mutations = {
  setAllTopics (state, topics) {
    state.all = topics.map(topic => {
      topic.img_url = URL.ROOT + topic.img_url
      return topic
    })
  },
  setHotTopics(state, payload) {
    state.hot =  state.all && state.all
      .map(topic => topic)
      .sort((a, b) => b.join_count - a.join_count) // desc
      .slice(0, payload.count)
  }
}

// actions
const actions = {
  async getAllTopics ({ state, commit }) {
    await topicService
      .getAll()
      .then(res => {
        commit('setAllTopics', res.data)
      })
      .catch(err => console.log('getAllTopics => ', err))
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
