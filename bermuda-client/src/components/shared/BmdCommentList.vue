<template>
  <v-layout row wrap>
    <v-flex xs12>
      <v-card>
        <v-card-text>
          <v-text-field
            label="请输入评论内容（140 字以内）"
            textarea
            v-model="commentText"
          ></v-text-field>
          <div class="text-xs-right">
            <v-btn
              color="primary"
              @click="onComment"
            >评论</v-btn>
          </div>
        </v-card-text>
      </v-card>
      <v-card>
        <v-card-title>
          <h3>{{ comments.length || 0 }} 条评论</h3>
        </v-card-title>
        <v-card-text v-if="comments.length">
          <v-layout
            v-for="comment in comments"
            :key="comment.id"
          >
            <v-flex xs2 md1 class="text-xs-center">
              <v-avatar size="32">
                <img :src="comment.user.avatar_url | urlFilter" alt="">
              </v-avatar>
            </v-flex>
            <v-flex xs10 md11>
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
                  >
                    <v-flex xs12
                      v-for="reply in comment.replies"
                      :key="reply.id"
                    >
                      <p>
                        <router-link
                          class="mr-1"
                          :to="goto('UserProfile', reply.user.id)"
                        >
                          {{ reply.user.name }}
                        </router-link>
                        <span v-if="reply.aims_user">
                          <router-link :to="goto('UserProfile', reply.aims_user.id)">
                            @{{ reply.aims_user.name }}
                          </router-link>
                        </span>
                        ：
                        <span>{{ reply.text }}</span>
                      </p>
                    </v-flex>
                    <!-- <v-flex xs12>
                      <v-text-field
                        label="回复"
                        solo
                        v-model="replyText"
                        @keyup.enter="onReply"
                      ></v-text-field>
                    </v-flex> -->
                  </v-layout>
                </v-flex>
              </v-layout>
            </v-flex>
          </v-layout>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import { goto } from '@/utils/link'

export default {
  props: {
    comments: {
      type: Array,
      default: () => []
    }
  },
  data: () => ({
    commentText: null,
    replyText: null
  }),
  methods: {
    goto,
    onComment () {
      this.$emit('comment', this.commentText)
    },
    // onReply () {
    //   console.log('xx')
    // }
  }
}
</script>

<style scoped>
.fs-large {
  font-size: 16px;
}
</style>

