<template>
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
      <span slot="badge">{{ count }}</span>
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
</template>

<script>
export default {
  computed: {
    count () {
      return this.$store.state.shoppingCart.added.length
    },
    added () {
      return this.count > 0
    }
  },
  created () {
    this.$store.dispatch('getCartProducts')
  }
}
</script>
