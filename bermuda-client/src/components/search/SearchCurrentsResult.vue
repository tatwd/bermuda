<template>
  <v-layout row wrap>
    <v-flex
      xs12
      class="mx-3 mb-3"
    >
      <v-card>
        <v-card-title>
          开发中。。。
        </v-card-title>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  props: {
    currents: {
      type: Array,
      default: null
    }
  }
}
</script>
