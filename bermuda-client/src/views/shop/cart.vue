<template>
  <v-container>
    <v-list two-line class="elevation-1">
      <template v-for="cartProduct in cartProducts">
        <v-list-tile :key="cartProduct.id" avatar to="#">
          <v-list-tile-avatar>
            <img :src="cartProduct.product.img_url">
          </v-list-tile-avatar>
          <v-list-tile-content>
            <v-list-tile-title>
              {{ cartProduct.product.title }}
            </v-list-tile-title>
            <v-list-tile-sub-title>
              数量：{{ cartProduct.quantity }}
            </v-list-tile-sub-title>
          </v-list-tile-content>
        </v-list-tile>
      </template>
      <v-divider></v-divider>

      <v-subheader class="primary--text mt-3">
        <v-spacer></v-spacer>
        <span>总价：￥{{ cartTotalPrice }}</span>
        <v-btn large color="primary">提交订单</v-btn>
      </v-subheader>
    </v-list>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters([
      'cartProducts',
      'cartTotalPrice'
    ])
  },
  created () {
    this.$store.dispatch('getCartProducts')
  }
}
</script>
