<template>
  <v-container>
    <h2>Current Detail {{ id }}</h2>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    id: null,
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
      this.id = this.$route.params.id
    }
  }

}
</script>
