<template>
  <div id="app">
    <v-app>
      <Navbar/>

      <v-content>
        <!-- <img src="./assets/logo.png"> -->
        <router-view/>
      </v-content>
      <v-footer>footer</v-footer>
    </v-app>
  </div>
</template>

<script>
import Navbar from './components/shared/Navbar'

export default {
  name: 'App',
  components: {
    Navbar
  }
}
</script>

<style>

</style>
