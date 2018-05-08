<template>
  <div id="app">
    <!-- <v-app>
      <Navbar/>
      <v-content class="grey lighten-4">
        <router-view/>
      </v-content>
      <v-footer>footer</v-footer>
    </v-app> -->
    <router-view/>
  </div>
</template>

<script>
// import Navbar from './components/shared/Navbar'

export default {
  name: 'App',
  components: {
    // Navbar
  }
}
</script>

<style>

</style>
