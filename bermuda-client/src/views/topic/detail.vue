<template>
  <v-container grid-list-lg>
    <v-layout row wrap>
      <v-flex xs12 md8 order-xs1 order-md0>
        <BmdCurrentList :currents="currents"/>
      </v-flex>
      <v-flex xs12 md4 order-xs0 order-md1>
        <TopicInfoCard :topic="topic"/>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import BmdCurrentList from '@/components/shared/BmdCurrentList'
import TopicInfoCard from '@/components/topic/TopicInfoCard'
import { currentService } from '@/services'

export default {
  components: {
    BmdCurrentList,
    TopicInfoCard
  },
  data: () => ({
    topic: null,
    currents: []
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
      const id = Math.round(this.$route.params.id)

      currentService
        .getByTopicId(id)
        .then(res => {
          this.topic = res.data.topic
          this.currents = res.data.currents
        })
        .catch(err => console.log('views/current/detail =>', err))
    }
  }
}
</script>
