<template>
  <v-container>
    <v-layout row wrap>
      <v-flex xs12 md8 offset-md2>
        <CurrentDetail :current="current"/>
        <v-spacer class="my-3"></v-spacer>
        <BmdCommentList
          :comments="comments"
          @comment="onComment"
        />
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { currentService } from '@/services'
import CurrentDetail from '@/components/current/CurrentDetail'
import BmdCommentList from '@/components/shared/BmdCommentList'

export default {
  components: {
    CurrentDetail,
    BmdCommentList
  },
  data: () => ({
    current: null,
    comments: []
  }),
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.fetchData()
    })
  },
  watch: {
    '$route': 'fetchData'
  },
  methods: {
    fetchData () {
      const id = this.$route.params.id
      this.getCurrent(id)
      this.getComments(id)
    },
    getCurrent (id) {
      setTimeout(() => {
        currentService
        .getById(id)
        .then(res => {
          this.current = res.data
        })
        .catch(console.error)
      }, 500)
    },
    getComments (id) {
      currentService
        .getComments(id)
        .then(res => {
          this.comments = res.data || []
        })
        .catch(console.error)
    },
    onComment (text) {
      const comment = {
        current_id: this.$route.params.id,
        text
      }
      currentService
        .createComment(comment)
        .then(res => {
          if (res.data.success) {
            this.getComments()
          } else {
            alert('评论失败！')
          }
        })
        .catch(console.err)
    }
  }
}
</script>
