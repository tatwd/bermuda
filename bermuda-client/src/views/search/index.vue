<template>
  <v-container grid-list-xs class="mt-3">
    <v-layout row wrap>
      <v-flex xs12 md4>
        <v-card class="mx-3 mb-3">
          <v-list>
            <v-list-tile
              v-for="type in types"
              :key="type.id"
              exact
              exact-active-class="primary--text grey lighten-3"
              :to="setRouterLink(type.name)"
            >
              <v-icon left :color="setIconColor(type.name)">{{ type.icon }}</v-icon>
              <span class="mx-2">{{ type.text }}</span>
            </v-list-tile>
          </v-list>
          <v-list v-if="searchHistory">
            <v-divider></v-divider>
            <v-subheader class="grey--text">
              最近搜索
              <v-spacer></v-spacer>
              <v-icon
                small
                class="pointer"
                @click="deleteSearchHistory"
              >delete</v-icon>
            </v-subheader>
            <v-layout row wrap class="px-3">
              <v-flex>
                <v-chip
                  v-for="(histroy, index) in searchHistory"
                  :key="index"
                >
                  {{ histroy }}
                </v-chip>
              </v-flex>
            </v-layout>
          </v-list>
        </v-card>
      </v-flex>
      <v-flex xs12 md8>
        <v-card class="mx-3 mb-3 grey--text">
          <v-card-title>
            <h3 v-html="msg"></h3>
          </v-card-title>
        </v-card>
        <v-container
          v-if="isLoading"
          class="text-xs-center"
        >
          <v-progress-circular indeterminate color="primary"></v-progress-circular>
        </v-container>
        <SearchNoticesResult
          v-if="currentType === 'notice'"
          :notices="result"
          :search-history="searchHistory"
        />
        <SearchUsersResult
          v-if="currentType === 'user'"
          :users="result"
        />
        <SearchTopicsResult
          v-if="currentType === 'topic'"
          :topics="result"
        />
        <SearchCurrentsResult
          v-if="currentType === 'current'"
          :currents="result"
        />
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex'
import { getSearchHistory, removeSearchHistory } from '@/utils/search-history'
import  SearchNoticesResult from '@/components/search/SearchNoticesResult'
import  SearchUsersResult from '@/components/search/SearchUsersResult'
import  SearchTopicsResult from '@/components/search/SearchTopicsResult'
import  SearchCurrentsResult from '@/components/search/SearchCurrentsResult'

export default {
  components: {
    SearchNoticesResult,
    SearchUsersResult,
    SearchTopicsResult,
    SearchCurrentsResult
  },
  data: () => ({
    msg: '请输入你要搜索的内容！',
    types: [
      { id: 1, text: '启示', name: 'notice', icon: 'assignment' },
      { id: 2, text: '用户', name: 'user', icon: 'assignment_ind' },
      { id: 3, text: '话题', name: 'topic', icon: 'layers' },
      { id: 4, text: '动态', name: 'current', icon: 'note' }
    ],
    currentType: '',
    searchHistory: getSearchHistory(),
    isLoading: false
  }),
  computed: mapGetters({
    result: 'currentResult'
  }),
  beforeRouteEnter (to, from, next) {
    if (to.query.q && to.query.type) {
      next(vm => {
        vm.startSearching(to.query.q, to.query.type)
      })
    } else {
      next()
    }
  },
  watch: {
    '$route': 'onRouteUpdate'
  },
  methods: {
    onRouteUpdate () {
      this.startSearching(this.$route.query.q, this.$route.query.type)
    },
    startSearching (query, type) {
      this.currentType = type
      this.isLoading = true
      this.msg = '正在为您搜索……'

      // clear cache result first
      this.$store.dispatch('updateSearchResult', { result: null })

      let bind = (data) => {
        this.msg = `
          您要搜索的内容是“<b class="red--text">${query}</b>”，
          搜索结果数为 <b class="red--text">${data ? data.length : 0}</b>！
        `
        this.searchHistory = getSearchHistory()
        this.isLoading = false
      }

      // get search result
      this.$store.dispatch('getSearchResult', { query, type, bind })
    },

    setRouterLink (typeName) {
      return {
        path: '/search',
        query: {
          q: this.$route.query.q,
          type: typeName
        }
      }
    },
    setIconColor (typeName) {
      return typeName === this.currentType ? 'primary': ''
    },
    deleteSearchHistory () {
      this.searchHistory = null
      removeSearchHistory()
    }
  }
}
</script>

<style scoped>
.pointer {
  cursor: pointer;
}
</style>
