<template>
  <v-container>
    <h1>Topic ID: {{ id }}</h1>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    id: null
  }),
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.getCurrentsByTopicId()
    })
  },
  watch: {
    '$route': 'getCurrentsByTopicId'
  },
  methods: {
    getCurrentsByTopicId () {
      this.id = Math.round(this.$route.params.id)
    },
  }
}
</script>
