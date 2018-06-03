<template>
  <v-layout>
    <ShopProductDetail/>
    <ShopCartBtn/>
  </v-layout>
</template>

<script>
import ShopProductDetail from '@/components/shop/ShopProductDetail'
import ShopCartBtn from '@/components/shop/ShopCartBtn'

export default {
  components: {
    ShopCartBtn,
    ShopProductDetail
  },
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.getProduct()
    })
  },
  watch: {
    '$route': 'getProduct'
  },
  methods: {
    getProduct () {
      this.id = this.$route.params.id
      this.$store.dispatch('getPorductById', {
        id: this.$route.params.id
      })
    }
  }
}
</script>
