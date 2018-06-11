<template>
  <v-card v-if="topic">
    <v-card-title>
      <v-avatar size="86" class="mx-auto">
        <img :src="topic.img_url | urlFilter" :alt="topic.name">
      </v-avatar>
    </v-card-title>
    <v-card-text class="text-xs-center">
      <h1 class="primary--text pb-3">{{ topic.name }}</h1>
      <p>
        {{ topic.detail }}
        <router-link to="#">@{{ topic.user.name }}</router-link>
      </p>
      <span>参与度：{{ topic.join_count }}</span>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  props: {
    topic: {
      type: Object,
      default: null
    }
  }
}
</script>
