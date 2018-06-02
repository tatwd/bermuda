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
</template>

<script>
export default {
  computed: {
    added () {
      return true
    }
  }
}
</script>
