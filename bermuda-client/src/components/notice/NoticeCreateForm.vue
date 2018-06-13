<template>
  <v-card>
    <BmdUploadImgPanel v-model="image"/>
    <v-card-text>
      <v-form ref="form" lazy-validation v-model="valid">
        <v-layout row wrap>
          <v-flex xs12>
            <v-text-field
              label="标题"
              v-model="title"
              :rules="titleRules"
              counter="50"
              required
            ></v-text-field>
          </v-flex>
          <v-flex xs12>
            <v-radio-group
              row
              v-model="type"
              :rules="typeRules"
              required
            >
              <v-radio
                v-for="(text, index) in ['寻物启事', '招领启事']"
                :key="index"
                :label="text"
                :value="text"
                color="primary"
              ></v-radio>
            </v-radio-group>
          </v-flex>
          <v-flex xs12>
            <v-select
              :items="species"
              label="物品类别"
              item-text="title"
              item-value="id"
              v-model="specieId"
              :rules="specieIdRules"
              required
            ></v-select>
          </v-flex>
          <v-flex xs12>
            <v-text-field
              label="时间描述"
              v-model="eventTimeDesc"
              counter="50"
              :rules="eventTimeDescRules"
              required
            ></v-text-field>
          </v-flex>
          <v-flex xs12>
            <v-text-field
              label="地点描述"
              v-model="place"
              counter="50"
              :rules="placeRules"
              required
            ></v-text-field>
          </v-flex>
          <v-flex xs12>
            <v-text-field
              label="完整地点"
              v-model="fullPlace"
              counter="100"
              :rules="fullPlaceRules"
              required
            ></v-text-field>
          </v-flex>
          <v-flex xs12>
            <v-text-field
              label="联系方式"
              v-model="contactWay"
              counter="50"
              :rules="contactWayRules"
              required
            ></v-text-field>
          </v-flex>
          <v-flex xs12>
            <v-text-field
              label="详细信息"
              multi-line
              v-model="detail"
              counter="140"
              :rules="detailRules"
              required
            ></v-text-field>
          </v-flex>
        </v-layout>
      </v-form>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn large color="primary" @click="onSubmit" :disabled="!valid">发布启事</v-btn>
      <v-btn large color="grey" dark @click="onCancel">取消发布</v-btn>
      <v-spacer></v-spacer>
    </v-card-actions>
  </v-card>
</template>

<script>
import BmdUploadImgPanel from '@/components/shared/BmdUploadImgPanel'
import { noticeSpecieService } from '@/services'

export default {
  components: {
    BmdUploadImgPanel
  },
  data: () => ({
    valid: true,

    image: null,
    title: '',
    type: '',
    specieId: null,
    eventTimeDesc: '',
    place: '',
    fullPlace: '',
    contactWay: '',
    detail: '',

    species: []
  }),
  created () {
    this.getSpecies()
  },
  computed: {
    titleRules () {
      return this.createRules('标题', 0, 50)
    },
    typeRules () {
      return this.createRules('启事类型')
    },
    specieIdRules () {
      return this.createRules('分类')
    },
    eventTimeDescRules () {
      return this.createRules('时间描述', 0, 50)
    },
    placeRules () {
      return this.createRules('地点', 0, 50)
    },
    fullPlaceRules () {
      return this.createRules('完整地点', 0, 100)
    },
    contactWayRules () {
      return this.createRules('联系方式', 0, 50)
    },
    detailRules () {
      return this.createRules('详细信息', 0, 140)
    }
  },
  methods: {
    createRules (field, minLength, maxLength) {
      const required = v => !!v || `必须包含${field}`,
        counter = v => (v && v.length >= minLength && v.length <= maxLength) || `注意${field}的长度`
      return !isNaN(minLength) && !isNaN(maxLength)
        ? [required, counter]
        : [required]
    },
    getSpecies () {
      noticeSpecieService
        .getAll()
        .then(res => {
          this.species = res.data.map(item => ({ id: item.id, title: item.name }))
        })
        .catch(console.log)
    },
    onSubmit () {
      if (this.$refs.form.validate()) {
        console.log('on submit')
      }
    },
    onCancel () {
      console.log('on cancel')
      this.$refs.form.reset()
    }
  }
}
</script>
