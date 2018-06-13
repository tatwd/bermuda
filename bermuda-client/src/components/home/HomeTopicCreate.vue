<template>
  <v-layout d-inline-block>
    <v-dialog v-model="showDialog" persistent max-width="500px">
      <v-btn slot="activator" color="success" dark large>申请话题</v-btn>
      <v-form ref="form" v-model="valid" lazy-validation>
        <v-card>
          <v-card-title>
            <span class="headline mx-auto">创建话题</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12>
                  <BmdUploadImgPanel  v-model="image"/>
                </v-flex>
                <v-flex xs12>
                  <v-text-field
                    label="标题"
                    v-model="topic.name"
                    full-width
                    counter
                    max="25"
                    :rules="[v => !!v || '请输入标题']"
                    required
                  ></v-text-field>
                </v-flex>
                <v-flex xs12>
                  <v-text-field
                    label="描述"
                    v-model="topic.detail"
                    counter
                    max="100"
                    multi-line
                    full-width
                  ></v-text-field>
                </v-flex>
              </v-layout>
            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="onCancel">取消</v-btn>
            <v-btn color="blue darken-1" flat @click="onCreate" :disabled="!valid">申请</v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
    </v-dialog>
  </v-layout>
</template>

<script>
import { fileService, topicService } from '@/services'
import BmdUploadImgPanel from '@/components/shared/BmdUploadImgPanel'

export default {
  components: {
    BmdUploadImgPanel
  },
  data: () => ({
    showDialog: false,
    valid: true,
    image: null,
    topic: {
      user_id: null,
      name: null,
      detail: null,
      img_url: null,
    }
  }),
  methods: {
    onCancel () {
      // delete upload img just now
      if (this.image) {
        fileService
          .deleteImg(this.image.file_name)
          .catch(err => console.log(err))
      }
      this.clearData()
    },
    onCreate () {
      if (this.$refs.form.validate()) {
        this.topic.user_id = this.$store.getters.currentUser.id
        this.topic.img_url = this.image.url
        topicService
          .createTopic(this.topic)
          .then(res => {
            this.clearData()
          })
          .catch(err => {
            fileService.deleteImg(this.image.url)
            console.log(err)
          })
      }
    },
    clearData () {
      this.showDialog = false
      this.image = null
      this.topic.name = null
      this.topic.detail = null
      this.topic.img_url = null
    }
  }
}
</script>
