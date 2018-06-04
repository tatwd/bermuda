<template>
  <v-carousel
    :style="carouselHeight"
    hide-delimiters
  >
    <v-carousel-item
      v-for="(caroImg, i) in caroImgs"
      :src="caroImg.src | urlFilter"
      :key="i"
    ></v-carousel-item>
  </v-carousel>
</template>

<script>
export default {
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
    }
  }
}
</script>
