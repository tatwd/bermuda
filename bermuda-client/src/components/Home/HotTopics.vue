<template>
  <div id="hot-topics">
    <v-layout class="hot-topics__slider pb-5" row>
      <v-flex
        v-for="i in 10"
        :key="i"
        class="mr-3"
      >
        <v-card width="160px">
          <v-card-media
            height="220px"
            src="https://images.pexels.com/photos/556903/pexels-photo-556903.jpeg?auto=compress&cs=tinysrgb&h=350"
          >
            <v-container fill-height fluid>
              <v-layout fill-height>
                <v-flex x12 align-end flexbox>
                  <span>hot topic {{ i }}</span>
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
  data () {
    return {}
  },
  created () {

    // add DOMContentLoaded for document
    document.addEventListener('DOMContentLoaded', () => {
      const hotTopicSlider = document.querySelector('.hot-topics__slider')
      const x = 176
      console.log(

      )
      cardSlider({
        element: hotTopicSlider,
        duration: .5,
        trans: { x:  x},
        interval: 3000,
        timing: 'ease-in-out'
      })
    })

  }
}
</script>

<style scoped>
#hot-topics {
  overflow: hidden;
}
</style>
