<template>
  <div id="bmd-navbar">
    <v-navigation-drawer
      v-model="sidedNav"
      app
    >
      <v-list>
        <v-list-tile to="#">
          <v-list-tile-action>
            <v-icon>supervisor_account</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>test content</v-list-tile-content>
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
      <v-toolbar-items class="mx-5 hidden-sm-and-down">
        <v-btn class="subheading" flat v-for="item in ['首页', '话题', '商城']" :key="item" :to="item">
          {{ item }}
        </v-btn>
      </v-toolbar-items>
      <!-- <v-spacer></v-spacer> -->
      <v-text-field
        class="hidden-sm-and-down"
        solo
        flat
        label="搜索"
        prepend-icon="search"
      ></v-text-field>
      <v-spacer></v-spacer>

      <v-toolbar-side-icon
        class="hidden-sm-and-up"
        @click.native.stop="sidedNav = !sidedNav"
      ></v-toolbar-side-icon>

      <v-menu
        v-if="isSignIn"
        offset-y
        transition="slide-y-transition"
        bottom
        left
        full-width
        open-on-hover
      >
        <v-avatar slot="activator" size="40">
          <img src="@/assets/avatar-tmp.svg" alt="avatar">
        </v-avatar>
        <v-list>
          <v-list-tile
            v-for="item in ['个人中心', '注销']"
            :key="item"
            to="#"
          >
            <v-list-tile-title>
              {{ item }}
            </v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-menu>

      <v-menu
        offset-y
        full-width
        dark
      >
        <v-btn slot="activator" class="mr-3 mx-5 hidden-sm-and-down" color="info">
          <v-icon left>create</v-icon>
          发布
        </v-btn>
        <v-list-tile
          v-for="(item, index) in ['失物招领', '动态', '话题']"
          :key="index"
          to="#"
        >
          <v-list-tile-title>
            {{ item }}
          </v-list-tile-title>
        </v-list-tile>
      </v-menu>
    </v-toolbar>
  </div>
</template>

<script>
import userAuth from '@/assets/js/user-auth'
// import { mapGetters } from 'vuex'

export default {
  name: 'Navbar',
  data: () => ({
    isSignIn: false,
    sidedNav: false
  }),
  created () {
    if (userAuth.auth().currentUser) {
      this.isSignIn = true
    }
  },
  // computed: mapGetters({
  //   user: 'currentUser'
  // }),
  methods: {
    showSearchInput () {}
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
a {
  text-decoration: none;
  /* color: #c66; */
}
</style>
