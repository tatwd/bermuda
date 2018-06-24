<template>
  <v-card>
    <v-card-title>
      <h3>{{ comments ? comments.length : 0 }} 条评论</h3>
    </v-card-title>
    <v-divider></v-divider>
    <v-card-text>
      <v-layout
        v-for="comment in comments"
        :key="comment.id"
      >
        <v-flex xs1 class="text-xs-center">
          <v-avatar size="32">
            <img :src="comment.user.avatar_url | urlFilter" alt="">
          </v-avatar>
        </v-flex>
        <v-flex xs11>
          <v-layout row wrap>
            <v-flex xs12>
              <div class="grey--text">
                <router-link class="mr-2" :to="goto('UserProfile', comment.user.id)">{{ comment.user.name }}</router-link>
                <span>发于 {{ comment.created_at | dateFilter }}</span>
              </div>
              <p class="fs-large">{{ comment.text }}</p>
            </v-flex>
            <v-flex xs12>
              <v-layout
                row
                wrap
                v-for="reply in comment.replies"
                :key="reply.id"
              >
                <v-flex xs12>
                  <p>
                    <router-link
                      class="mr-1"
                      :to="goto('UserProfile', reply.user.id)"
                    >
                      {{ reply.user.name }}
                    </router-link>
                    <span v-if="reply.aims_user">
                        @{{ reply.aims_user ? reply.aims_user.name:'' }}
                    </span>
                    ：
                    <span>{{ reply.text }}</span>
                  </p>
                </v-flex>
              </v-layout>
            </v-flex>
          </v-layout>
        </v-flex>
      </v-layout>
    </v-card-text>
  </v-card>
</template>

<script>
import { goto } from '@/utils/link'

export default {
  props: {
    comments: {
      type: Array,
      default: () => null
    }
  },
  methods: {
    goto
  }
}
</script>

<style scoped>
.fs-large {
  font-size: 16px;
}
</style>

