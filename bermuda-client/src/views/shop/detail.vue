<template>
  <v-layout>
    <v-container grid-list-lg>
      <v-layout row wrap>
        <v-flex xs12>
          <v-breadcrumbs>
            <v-icon slot="divider">chevron_right</v-icon>
            <v-breadcrumbs-item :to="{ name: 'Shop' }">市场</v-breadcrumbs-item>
            <v-breadcrumbs-item disabled>{{ id }}</v-breadcrumbs-item>
          </v-breadcrumbs>
        </v-flex>
        <v-flex xs12 md5>
          <h2>#{{ id }} Porduct Detail</h2>
        </v-flex>
        <v-flex xs12 md7>
          <h2>购买信息</h2>
        </v-flex>
        <v-flex xs12>
          <p>详细信息</p>
        </v-flex>
      </v-layout>
    </v-container>
  </v-layout>
</template>

<script>
export default {
  data: () => ({
    id: null
  }),
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.id = to.params.id
    })
  },
  watch: {
    '$route': 'fetchData'
  },
  methods: {
    fetchData () {
      this.id = this.$route.params.id
    }
  }
}
</script>
