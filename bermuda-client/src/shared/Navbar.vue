<template>

  <div id="bmd-navbar">
    <!-- <v-navigation-drawer app>nav-drawer</v-navigation-drawer> -->
    <!-- <v-toolbar app>
      <v-container grid-list-xl my-0 py-0>
        <v-layout row wrap>
          <v-toolbar-title>
            <h3>
              <router-link to="!#" style="text-decoration:none;">百慕大</router-link>
            </h3>
          </v-toolbar-title>
          <v-toolbar-items>
            <v-btn flat v-for="item in ['首页', '话题', '商城']" :key="item">
              {{ item }}
            </v-btn>
          </v-toolbar-items>
        </v-layout>
      </v-container>
    </v-toolbar> -->
    <v-card app>
      <v-container py-0>
        <v-layout row child-flex wrap>
          <v-toolbar flat>
            <v-avatar size="64">
              <img src="../assets/bmd-logo.svg" alt="logo">
            </v-avatar>
            <v-toolbar-title>
              <h3>
                <router-link to="!#">百慕大</router-link>
              </h3>
            </v-toolbar-title>
            <v-toolbar-items>
              <v-btn
                flat
                v-for="item in ['首页', '话题', '商城']"
                :key="item"
              >
                {{ item }}
              </v-btn>
            </v-toolbar-items>
            <v-spacer></v-spacer>
            <!-- <v-text-flied ></v-text-flied> -->
            <v-btn icon class="hidden-xs-only">
              <v-icon>search</v-icon>
            </v-btn>
            <v-btn>发布</v-btn>
          </v-toolbar>
        </v-layout>
      </v-container>
    </v-card>
  </div>
</template>

<script>
export default {
  name: 'Navbar',
  data () {
    return {}
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
}
</style>
