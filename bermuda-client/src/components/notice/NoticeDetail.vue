<template>
  <v-card v-if="notice">
    <v-layout>
      <v-flex>
        <v-card-title>
          <h1 class="mr-3">{{ notice.title }}</h1>
          <span class="grey--text">
            {{ notice.user.name }} 发表于 {{ notice.created_at | dateFilter }}
          </span>
        </v-card-title>
        <v-card-text>
          <p>时间：{{ notice.event_time_desc }}</p>
          <p>地点：{{ notice.place }}</p>
          <p>详细地点：{{ notice.full_place }}</p>
          <p>详细信息：{{ notice.detail }}</p>
          <p>
            <img
              class="responsive-img pointer"
              :src="notice.img_url | urlFilter"
              :alt="notice.title"
              @click="showDialog = true"
            >
            <v-dialog v-model="showDialog" max-width="666">
              <v-card>
                <v-card-media :src="notice.img_url | urlFilter" height="380"></v-card-media>
              </v-card>
            </v-dialog>
          </p>
        </v-card-text>
        <!-- <v-card-media
          :src="notice.img_url | urlFilter"
          height="320"
          class="ma-3 d-block"
          contain
        ></v-card-media> -->
        <v-card-actions>
          <v-btn color="primary" @click="onTraceHandle">
            <v-icon left>near_me</v-icon>
            <span>追踪</span>
          </v-btn>
          <span></span>
        </v-card-actions>
      </v-flex>
    </v-layout>
  </v-card>
</template>

<script>
export default {
  props: {
    notice: {
      type: Object,
      default: null,
    },
    onTraceHandle: {
      type: Function,
      default: () => (
        console.log('ok')
      )
    }
  },
  data: () => ({
    showDialog: false
  })
}
</script>

<style scoped>
.responsive-img {
  max-width: 100%;
  height: auto;
}

.pointer {
  cursor: pointer;
}
</style>
