<template>
  <v-container>
    <v-carousel
      :style="carouselHeight"
      hide-delimiters
    >
      <v-carousel-item
        v-for="(item,i) in items"
        :src="item.src"
        :key="i"
      ></v-carousel-item>
    </v-carousel>
    <v-btn
      color="red"
      dark
      fixed
      bottom
      right
      fab
      to="/shop/cart"
    >
      <v-icon>shopping_cart</v-icon>
    </v-btn>
  </v-container>
</template>

<script>
export default {
  data () {
    return {
      items: [
        {
          src: 'http://localhost:53595/assets/img/caro/caro-1.jpeg'
        },
        {
          src: 'http://localhost:53595/assets/img/caro/caro-2.jpeg'
        },
        {
          src: 'http://localhost:53595/assets/img/caro/caro-3.jpeg'
        },
        {
          src: 'http://localhost:53595/assets/img/caro/caro-4.jpeg'
        }
      ]
    }
  },
  computed: {
    carouselHeight () {
      return this.$vuetify.breakpoint.smAndDown
        ? 'max-height:200px'
        : 'max-height:400px'
    }
  }
}
</script>

<style scoped>

</style>
