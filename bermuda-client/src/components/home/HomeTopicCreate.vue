<template>
  <v-layout d-inline-block>
    <v-dialog v-model="dialog" persistent max-width="500px">
      <v-btn slot="activator" color="success" dark large>申请话题</v-btn>
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
                  required
                ></v-text-field>
              </v-flex>
              <v-flex xs12>
                <v-text-field
                  label="描述"
                  v-model="topic.title"
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
          <v-btn color="blue darken-1" flat @click.native="dialog = false">取消</v-btn>
          <v-btn color="blue darken-1" flat @click.native="dialog = false">申请</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
import { fileService } from '@/services'

export default {
  data: () => ({
    dialog: false,
    topic: {
      name: null,
      detail: null,
      img_url: null,
      created_at: null
    },
    selected_img: null,
    isUploading: false
  }),
  methods: {
    onImgSelected (event) {
      this.selected_img = event.target.files[0]
      this.isUploading = true

      const fd = new FormData()
      fd.append('img', this.selected_img)

      fileService
        .uploadImg(fd)
        .then(res => {
          this.isUploading = false
          this.topic.img_url = res.data.url
        })
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
