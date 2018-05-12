<template>
  <div
    id="top-users"
    class="my-4"
  >
    <v-card>
      <v-card-title>
        <v-icon color="primary">assessment</v-icon>
        <span class="ml-2">{{ example }}</span>
      </v-card-title>
    </v-card>
  </div>
</template>

<script>
export default {
  name: 'TopUsers',
  data: () => ({
    example: '百慕达人'
  })
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
