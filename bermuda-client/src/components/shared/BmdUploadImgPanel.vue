<template>
  <div class="upload-img">
    <v-icon v-if="!isLoading && !imgData" size="64px">camera_enhance</v-icon>
    <v-progress-circular
      v-if="isLoading"
      indeterminate color="green"
      class="pos-y-center"
    ></v-progress-circular>
    <!-- 上传图片 -->
    <input type="file" @change="onChange($event)">
    <img v-if="imgData" :src="imgData.url" :alt="imgData.file_name">
  </div>
</template>

<script>
import { fileService } from '@/services'

export default {
  model: {
    prop: 'imgData',
    event: 'change'
  },
  props: {
    imgData: {
      type: Object,
      default: null
    }
  },
  data: () => ({
    isLoading: false
  }),
  methods: {
    onChange (event) {
      this.isUploading = true
      const fd = new FormData()
      fd.append('img-upload', event.target.files[0])

      fileService
        .uploadImg(fd)
        .then(res => {
          this.isLoading = false
          this.$emit('change', res.data)
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

.pos-y-center {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
}
</style>
