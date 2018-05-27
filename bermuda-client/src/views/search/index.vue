<template>
  <v-container grid-list-xs class="mt-3">
    <v-layout row wrap>
      <v-flex xs12 md4>
        <v-card class="mx-3 mb-3">
          <v-list>
            <v-list-tile
              v-for="type in types"
              :key="type.id"
              exact
              exact-active-class="primary--text grey lighten-3"
              :to="setRouterLink(type.name)"
            >
              <v-icon left :color="setIconColor(type.name)">{{ type.icon }}</v-icon>
              <span class="mx-2">{{ type.text }}</span>
            </v-list-tile>
          </v-list>
        </v-card>
      </v-flex>
      <v-flex xs12 md8>
        <v-card class="mx-3 mb-3">
          <v-card-title>
            <p>{{ msg }}</p>
          </v-card-title>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    msg: '',
    types: [
      { id: 1, text: '启示', name: 'notice', icon: 'assignment' },
      { id: 2, text: '用户', name: 'user', icon: 'assignment_ind' },
      { id: 3, text: '话题', name: 'topic', icon: 'layers' },
      { id: 4, text: '动态', name: 'current', icon: 'note' }
    ],
    currentType: '',
  }),
  beforeRouteEnter (to, from, next) {
    // get data
    // then next
    // searchData(
    //   to.query.q,
    //   to.query.t,
    //   (data) => {
    //     next(vm => {
    //       // vm.msg = data
    //       vm.updateData(data)
    //     })
    //   }
    // )
    next(vm => {
      vm.fetchData(
        to.query.q,
        to.query.type,
        (data) => {
          vm.updateData(data)
          vm.currentType = to.query.type
        }
      )
    })
  },
  // watch: {
  //   '$route': 'updateData'
  // },
  // methods: {
  //   updateData () {
  //     searchData(
  //       this.$route.query.q,
  //       this.$route.query.t,
  //       (data) => {
  //         this.msg = data
  //       }
  //     )
  //   }
  // }
  beforeRouteUpdate (to, from, next) {
    // searchData(
    this.fetchData(
      to.query.q,
      to.query.type,
      (data) => {
        this.updateData(data)
        this.currentType = to.query.type
        next()
      }
    )
  },
  methods: {
    updateData (data) {
      this.msg = data
    },
    fetchData (query, type, cb) {
      let data = `query: ${query}  type: ${type}`
      cb.call(this, data)
    },
    // changeType (type) {
    //   this.$router.push({
    //     path: '/search',
    //     query: {
    //       q: this.$route.query.q,
    //       t: type
    //     }
    //   })
    // },
    setRouterLink (typeName) {
      return {
        path: '/search',
        query: {
          q: this.$route.query.q,
          type: typeName
        }
      }
    },
    setIconColor (typeName) {
      return typeName === this.currentType ? 'primary': ''
    }
  }
}
</script>
