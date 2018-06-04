<template>
  <v-container>
    <h2 v-if="notice">{{ notice.title }}</h2>
  </v-container>
</template>

<script>
import { noticeService } from '@/services'

export default {
  data: () => ({
    notice: null
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
      const id = this.$route.params.id
      noticeService
        .getById(id)
        .then(res => {
          this.notice = res.data
        })
        .catch(err => console.log('get notice by id =>', err))
    },

    getComment () {
      // TODO: get notice comment by notice id
    }
  }

}
</script>
