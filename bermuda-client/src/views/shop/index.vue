<template>
  <v-layout>
    <v-flex xs12>
      <!-- carousel -->
      <v-carousel
        :style="carouselHeight"
        hide-delimiters
      >
        <v-carousel-item
          v-for="(caroImg, i) in caroImgs"
          :src="caroImg.src"
          :key="i"
        ></v-carousel-item>
      </v-carousel>

      <v-container
        v-bind="{ [`grid-list-${breakpoint}`]: true }"
      >
        <v-layout row wrap>
          <v-flex
            v-for="x in ['test 1', 'test 2', 'test 3']"
            :key="x"
            xs4
          >
            <v-card class="my-3">
              <v-card-title>
                {{ x }}
              </v-card-title>
            </v-card>
          </v-flex>
          <v-flex
            v-for="n in 9"
            :key="n"
            xs6
            md3
            my-3
          >
            <v-card>
              <router-link :to="goto(n)">
                <v-card-media
                  src="https://picsum.photos/200/300"
                  height="240"
                ></v-card-media>
              </router-link>
              <v-card-text class="text-xs-center">
                <div>
                  <router-link class="black--text" :to="goto(n)">{{ 'name' }}</router-link>
                </div>
                <div class="primary--text">￥{{ n }}</div>
              </v-card-text>
            </v-card>
          </v-flex>
        </v-layout>
      </v-container>

      <!-- go to cart page btn -->
      <v-speed-dial
        fixed
        bottom
        right
      >
        <v-badge
          left
          overlap
          color="green"
          slot="activator"
          v-model="added"
        >
          <span slot="badge">0</span>
          <v-btn
            color="red"
            dark
            fab
            :to="{ name: 'ShoppingCart' }"
            class="mt-0 ml-0"
          >
            <v-icon>shopping_cart</v-icon>
          </v-btn>
        </v-badge>
      </v-speed-dial>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  data: () => ({
    // todo
  }),
  computed: {
    carouselHeight () {
      return this.$vuetify.breakpoint.smAndDown
        ? 'max-height:200px'
        : 'max-height:420px'
    },
    caroImgs () {
      return [
        { src: 'http://localhost:53595/assets/img/caro/caro-1.jpeg' },
        { src: 'http://localhost:53595/assets/img/caro/caro-2.jpeg' },
        { src: 'http://localhost:53595/assets/img/caro/caro-3.jpeg' },
        { src: 'http://localhost:53595/assets/img/caro/caro-4.jpeg' }
      ]
    },
    added () {
      return true
    },
    breakpoint () {
      return this.$vuetify.breakpoint.name
    }
  },
  methods: {
    goto(id) {
      return {
        name: 'ProductDetail',
        params: {
          id
        }
      }
    }
  }
}
</script>

<style scoped>

</style>
