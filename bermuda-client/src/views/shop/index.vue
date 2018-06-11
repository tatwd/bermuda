<template>
  <v-layout>
    <v-flex xs12>
      <ShopCarousel/>
      <ShopProducts/>
      <ShopCartBtn/>
    </v-flex>
  </v-layout>
</template>

<script>
import ShopCarousel from '@/components/shop/ShopCarousel'
import ShopCartBtn from '@/components/shop/ShopCartBtn'
import ShopProducts from '@/components/shop/ShopProducts'

export default {
  components: {
    ShopCarousel,
    ShopCartBtn,
    ShopProducts
  }
}
</script>
