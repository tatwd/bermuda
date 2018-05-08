<template>
  <div class="layout--default">
    <v-app>
      <Navbar/>
      <v-content class="grey lighten-4">
        <router-view/>
      </v-content>
      <v-footer>footer</v-footer>
    </v-app>
  </div>
</template>

<script>
import Navbar from '@/components/shared/Navbar'

export default {
  components: {
    Navbar
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
