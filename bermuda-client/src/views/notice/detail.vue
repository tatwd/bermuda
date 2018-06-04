<template>
  <v-container>
    <h2>Notice Detail {{ id }}</h2>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    id: null,
  }),
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.getNotice()
    })
  },
  watch: {
    '$route': 'getNotice'
  },
  methods: {
    getNotice () {
      this.id = this.$route.params.id
    }
  }

}
</script>
