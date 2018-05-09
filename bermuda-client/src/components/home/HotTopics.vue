<template>
  <div id="hot-topics">
    <v-layout class="hot-topics__slider pb-5" row>
      <v-flex
        v-for="topic in topics"
        :key="topic.id"
        class="mr-3"
      >
        <v-card width="160px">
          <v-card-media
            height="220px"
            :src="topic.img_url"
          >
            <v-container fill-height fluid>
              <v-layout fill-height>
                <v-flex x12 align-end flexbox>
                  <span>{{ topic.name }}</span>
                </v-flex>
              </v-layout>
            </v-container>
          </v-card-media>
        </v-card>
      </v-flex>
    </v-layout>
  </div>
</template>

<script>
import cardSlider from '@/assets/js/card-slider'

export default {
  name: 'HotTopics',
  data: () => ({
    topics: []
  }),
  created () {
    // start sliding
    this.slideTopicCards()

    // get hot topics
    this.getHotTopics()
  },
  methods: {
    slideTopicCards () {
      // add DOMContentLoaded for document
      document.addEventListener('DOMContentLoaded', () => {
        cardSlider({
          element: document.querySelector('#hot-topics .hot-topics__slider'),
          duration: .5,
          trans: { x:  176},
          interval: 3000,
          timing: 'ease-in-out'
        })
      })
    },

    getHotTopics () {
      const self = this;

      for (let i = 0; i < 10; i++) {
        self.topics.push({
          id: null,
          name: '',
          img_url: 'https://images.pexels.com/photos/46274/pexels-photo-46274.jpeg?auto=compress&cs=tinysrgb&h=350' // '@/assets/template.svg'
        })
      }

      this.$store.state.services
        .topicService
        .getTop()
        .then(res => {
          res.data.forEach((topic, index) => {
            self.topics[index].id = topic.id
            self.topics[index].name = topic.name
            self.topics[index].img_url = 'http://localhost:53595' + topic.img_url
          });
        })
        .catch(err => console.log(err));
    }
  }
}
</script>

<style scoped>
#hot-topics {
  overflow: hidden;
}
</style>
