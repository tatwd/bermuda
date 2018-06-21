<template>
  <v-container>
    <v-layout>
      <v-flex xs12 md8 offset-md2>
        <NoticeDetail :notice="notice"/>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { noticeService } from '@/services'
import NoticeDetail from '@/components/notice/NoticeDetail'

export default {
  components: {
    NoticeDetail
  },
  data: () => ({
    notice: null,
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
      const id = Math.round(this.$route.params.id)
      if (id) {
        noticeService
          .getById(id)
          .then(res => {
            this.notice = res.data
          })
          .catch(err => console.log('get notice by id =>', err))
      }
    },

    getComment () {
      // TODO: get notice comment by notice id
    }
  }

}
</script>
