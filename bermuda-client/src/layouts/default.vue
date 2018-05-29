<template>
  <div class="layout--default">
    <v-app>
      <BmdNavbar/>
      <v-content class="grey lighten-4">
        <router-view/>
      </v-content>
      <v-footer app>
        <v-container>
          footer
        </v-container>
      </v-footer>
    </v-app>
  </div>
</template>

<script>
import BmdNavbar from '@/components/shared/BmdNavbar'

export default {
  name: 'default',
  components: {
    BmdNavbar
  }
}
</script>
