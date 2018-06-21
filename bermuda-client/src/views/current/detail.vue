<template>
  <v-container>
    <v-layout>
      <v-flex xs12 md8 offset-md2>
        <CurrentDetail :current="current"/>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { currentService } from '@/services'
import CurrentDetail from '@/components/current/CurrentDetail'

export default {
  components: {
    CurrentDetail
  },
  data: () => ({
    current: null
  }),
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.getCurrent()
    })
  },
  watch: {
    '$route': 'getCurrent'
  },
  methods: {
    getCurrent () {
      const id = this.$route.params.id
      currentService
        .getById(id)
        .then(res => {
          this.current = res.data
        })
        .catch(console.error)
    }
  }
}
</script>
