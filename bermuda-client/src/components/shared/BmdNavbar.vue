<template>
  <div id="bmd-navbar">
    <v-navigation-drawer
      v-if="show"
      v-model="sidedNav"
      app
      width="200"
    >
      <v-list>
        <v-list-tile
          v-for="(nav, index) in navs"
          :key="index"
          :to="nav.to"
        >
          <v-list-tile-action>
            <v-icon>{{ nav.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>{{ nav.title }}</v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>

    <v-toolbar app>
      <v-avatar size="64">
        <img src="@/assets/bmd-logo.svg" alt="logo">
      </v-avatar>
      <v-toolbar-title>
        <h3>
          <router-link to="/" style="text-decoration:none;">百慕大</router-link>
        </h3>
      </v-toolbar-title>
      <v-toolbar-items
        class="mx-5 hidden-sm-and-down"
         v-if="!show"
      >
        <v-btn
          class="subheading"
          flat
          v-for="nav in navs"
          :key="nav.title"
          :to="nav.to"
          exact-active-class="primary--text"
        >
          {{ nav.title }}
        </v-btn>
      </v-toolbar-items>
      <!-- <v-spacer></v-spacer> -->
      <v-text-field
        class="hidden-sm-and-down"
        solo
        flat
        label="搜索"
        prepend-icon="search"
        v-model="searchText"
        @keyup.enter="onSearch"
      ></v-text-field>

      <v-spacer></v-spacer>

      <v-menu
        v-if="isSignIn"
        offset-y
        transition="slide-y-transition"
        bottom
        left
        full-width
        open-on-hover
      >
        <v-avatar
          slot="activator"
          size="40"
        >
          <img src="@/assets/avatar-tmp.svg" alt="avatar">
        </v-avatar>
        <v-list>
          <v-list-tile to="#">
            <v-list-tile-title>个人中心</v-list-tile-title>
          </v-list-tile>
          <v-list-tile @click="onSignout">
            <v-list-tile-title>注销</v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-menu>

      <v-toolbar-side-icon
        class="hidden-md-and-up"
        @click.native.stop="sidedNav = !sidedNav"
      ></v-toolbar-side-icon>

      <v-btn
        class="mr-3 mx-5 hidden-sm-and-down"
        color="primary"
      >
        <v-icon left>create</v-icon>
        发布启示
      </v-btn>
    </v-toolbar>
  </div>
</template>

<script>
import { updateSearchHistory } from '@/utils/search-history'

export default {
  name: 'BmdNavbar',
  data: () => ({
    sidedNav: false,
    searchText: null,
  }),
  computed: {
    navs () {
      return [
        { title: '话题', to: '/topic', icon: 'bookmark' },
        { title: '商城', to: '/shop', icon: 'store' }
      ]
    },
    isSignIn () {
      return this.$store.getters.currentUser != null
    },
    show () {
      return this.$vuetify.breakpoint.smAndDown
    }
  },
  watch: {
    '$route': 'clearSearchText'
  },
  methods: {
    onSearch () {
      if (this.searchText && this.searchText !== '') {
        // update search history in localStorage
        updateSearchHistory(this.searchText)

        this.$router.push({
          path: '/search',
          query: {
            q: this.searchText,
            type: this.$route.query.type || 'notice'
          }
        })
      }
    },
    onSignout () {
      this.$store.dispatch('signout', {
        redirect: () => this.$router.push({
          path: '/account/signin',
          query: {
            redirect: this.$route.path
          }
        })
      })
    },
    clearSearchText () {
      if (this.$route.name !== 'Search') {
        this.searchText = null
      }
    }
  }
}
</script>

<style scoped>
a {
  text-decoration: none;
}
</style>
