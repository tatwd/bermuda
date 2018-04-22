<template>
  <div id="bmd-navbar">
    <!-- <v-navigation-drawer app>nav-drawer</v-navigation-drawer> -->
    <v-toolbar app>
      <v-avatar size="64">
        <img src="../assets/bmd-logo.svg" alt="logo">
      </v-avatar>
      <v-toolbar-title>
        <h3>
          <router-link to="!#" style="text-decoration:none;">百慕大</router-link>
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
        solo-inverted
        flat
        label="搜索"
        prepend-icon="search"
      ></v-text-field>
      <v-spacer></v-spacer>

      <v-menu
        v-if="isSignIn"
        bottom
        left
        offset-y
        transition="slide-y-transition"
        full-width
      >
        <v-avatar slot="activator" size="40">
            <img src="../assets/avatar-tmp.svg" alt="avatar">
          </v-avatar>
        <v-list>
          <v-list-tile
            v-for="item in ['个人中心', '注销']"
            :key="item"
          >
            <v-list-tile-title>
              {{ item }}
            </v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-menu>

      <v-btn class="mr-3 mx-5 hidden-sm-and-down" color="info">
        <v-icon left>create</v-icon>
        发布
      </v-btn>
    </v-toolbar>
  </div>
</template>

<script>
export default {
  name: 'Navbar',
  data () {
    return {
      isSignIn: false
    }
  },
  methods: {
    showSearchInput () {}
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
a {
  text-decoration: none;
  color: #c66;
}
</style>
