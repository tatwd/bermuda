<template>
  <v-container>
    <v-layout>
      <v-flex xs12 md8 offset-md2>
        <v-card>
          <v-card-title>
            <v-text-field
              solo
              flat
              label="标题"
              class="font-size-large"
              required
              v-model="title"
            ></v-text-field>
          </v-card-title>
          <v-card-text>
            <v-select
              :loading="loading"
              :items="topics"
              item-text="name"
              item-value="id"
              :rules="[() => (joinTopics.length > 0 && joinTopics.length <= 3) || '您最多选择 3 个话题！']"
              :search-input.sync="searchTopics"
              v-model="joinTopics"
              no-data-text="没有找到您要的！"
              label="搜索您要的话题，最多选择 3 个！"
              autocomplete
              multiple
              cache-items
              chips
              required
              solo
              flat
              append-icon=""
              class="font-size-middle"
            >
              <template slot="no-data"></template>
            </v-select>
          </v-card-text>
          <v-card-text>
            <CurrentEditor v-model="text"/>
          </v-card-text>
          <v-card-text>
            <v-btn block color="info" @click="onSubmit">推送</v-btn>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { topicService, currentService } from '@/services'
import CurrentEditor from '@/components/current/CurrentEditor'
import briefTextGen from '@/utils/brief-text-gen'

export default {
  components: {
    CurrentEditor
  },
  data: () => ({
    loading: false,
    topics: [],
    searchTopics: null,

    joinTopics: [],
    title: null,
    text: null
  }),
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.defaultSelectedTopic(to.query.selected)
    })
  },
  beforeRouteUpdate (to, from, next) {
    this.defaultSelectedTopic(to.query.selected)
    next();
  },
  watch: {
    searchTopics (val) {
      val && this.queryTopics(val)
    }
  },
  methods: {
    defaultSelectedTopic (selected) {
      if (isNaN(selected)) return
      selected = Math.round(selected)
      this.joinTopics.push(selected)
      topicService
        .getById(selected)
        .then(res => {
          const topic = {
            id: res.data.id,
            name: res.data.name
          }
          this.topics.push(topic)
        })
        .catch(console.error)
    },
    queryTopics (v) {
      this.loading = true
      window.setTimeout(() => {
        topicService.getAll().then(res => {
          this.topics = res.data
            .filter(e =>
              (e.name || '').toLowerCase().indexOf((v || '').toLowerCase()) > -1
            )
            .map(({id, name}) => ({ id, name }))
          this.loading = false
        })
      }, 500)
    },
    onSubmit () {
      if (!this.isValided()) {
        alert('请填写完！')
        console.log(
          briefTextGen(this.text, 240)
        )
        return
      }
      const current = {
        topic_ids: this.joinTopics,
        title: this.title,
        text: this.text,
        brief_text: briefTextGen(this.text, 240) // max: 280
      }
      currentService
        .createCurrent(current)
        .then(res => {
          console.log(res.data)
        })
        .catch(console.error)
    },
    isValided () {
      return this.joinTopics.length && this.title && this.text
    }
  }
}
</script>

<style lang="scss">
.font-size-middle {
  label, input {
    font-size: 16px;
    font-weight: 900;
  }
}

.font-size-large {
  label, input {
    font-size: 28px;
    font-weight: 900;
  }
}
</style>
