<template>
  <div
    id="hot-currents"
    class="mt-4"
  >
    <v-card>
      <v-card-title>
        <v-icon color="primary">whatshot</v-icon>
        <span class="ml-2">{{ example }}</span>
      </v-card-title>
    </v-card>
  </div>
</template>

<script>
export default {
  data: () => ({
    example: '热门动态'
  })
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
