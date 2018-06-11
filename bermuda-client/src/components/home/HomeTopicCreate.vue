<template>
  <v-layout d-inline-block>
    <v-dialog v-model="showDialog" persistent max-width="500px">
      <v-btn slot="activator" color="success" dark large>申请话题</v-btn>
      <v-form ref="from" v-model="valid" lazy-validation>
        <v-card>
          <v-card-title>
            <span class="headline mx-auto">创建话题</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12>
                  <div class="upload-img">
                    <v-icon v-if="!isUploading && !topic.img_url" size="64px">camera_enhance</v-icon>
                    <v-progress-circular
                      v-else-if="isUploading"
                      indeterminate color="green"
                      class="pos-y-center"
                    ></v-progress-circular>
                    <!-- 上传图片 -->
                    <input type="file" @change="onImgSelected($event)">
                    <img v-if="topic.img_url" :src="topic.img_url" alt="img upload">
                  </div>
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

export default {
  data: () => ({
    showDialog: false,
    valid: true,
    selected_img: null,
    isUploading: false,

    topic: {
      user_id: null,
      name: null,
      detail: null,
      img_url: null,
    }
  }),
  methods: {
    onImgSelected (event) {
      const fd = new FormData()
      this.isUploading = true
      fd.append('img', event.target.files[0])

      fileService
        .uploadImg(fd)
        .then(res => {
          this.isUploading = false
          this.selected_img = res.data.file_name
          this.topic.img_url = res.data.url
        })
    },
    onCancel () {
      // delete upload img just now
      if (this.selected_img) {
        fileService
          .deleteImg(this.selected_img)
          .catch(err => console.log(err))
      }
      this.clearData()
    },
    onCreate () {
      if (this.$refs.from.validate()) {
        this.topic.user_id = this.$store.getters.currentUser.id
        topicService
          .createTopic(this.topic)
          .then(res => {
            this.clearData()
          })
          .catch(err => {
            fileService.deleteImg(this.selected_img)
            console.log(err)
          })
      }
    },
    clearData () {
      this.showDialog = false
      this.selected_img = null
      this.topic.name = null
      this.topic.detail = null
      this.topic.img_url = null
    }
  }
}
</script>

<style scoped>
.upload-img {
  position: relative;
  min-height: 196px;
  display: flex;
  justify-content: center;
  align-content: center;
}

.upload-img input {
  position: absolute;
  cursor: pointer;
  opacity: 0;
  height: 100%;
  width: 100%;
}

.upload-img img {
  max-width: 100%;
}

.hidden {
  display: none;
}

.pos-y-center {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
}
</style>
