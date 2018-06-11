<template>
  <div class="layout--default">
    <v-app>
      <BmdNavbar/>
      <v-content class="grey lighten-4">
        <router-view/>
      </v-content>
      <v-footer height="auto">
        <BmdFooter/>
      </v-footer>
    </v-app>
  </div>
</template>

<script>
import BmdNavbar from '@/components/shared/BmdNavbar'
import BmdFooter from '@/components/shared/BmdFooter'

export default {
  name: 'default',
  components: {
    BmdNavbar,
    BmdFooter
  }
}
</script>
