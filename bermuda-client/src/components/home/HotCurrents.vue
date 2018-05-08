<template>
  <div id="hot-currents" class="ml-4 mt-4">
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
  name: 'HotCurrents',
  data: () => ({
    example: '热门动态'
  })
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
