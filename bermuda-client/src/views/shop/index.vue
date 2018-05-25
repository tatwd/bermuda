<template>
  <v-container>
    <h1>Shop Page</h1>
    <v-carousel
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
      to="#"
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
            src: 'https://vuetifyjs.com/static/doc-images/carousel/squirrel.jpg'
          },
          {
            src: 'https://vuetifyjs.com/static/doc-images/carousel/sky.jpg'
          },
          {
            src: 'https://vuetifyjs.com/static/doc-images/carousel/bird.jpg'
          },
          {
            src: 'https://vuetifyjs.com/static/doc-images/carousel/planet.jpg'
          }
        ]
      }
    }
  }
</script>

<style scoped>

</style>
