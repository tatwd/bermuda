<template>
  <v-form ref="form" v-model="valid" lazy-validation>
    <v-text-field
      v-model="username"
      :counter="25"
      :rules="usernameRules"
      label="用户名"
      required
    ></v-text-field>
    <v-text-field
      v-model="email"
      :counter="50"
      :rules="emailRules"
      type="email"
      label="邮箱"
      required
    ></v-text-field>
    <v-text-field
      v-model="password"
      :counter="16"
      :rules="passwordRules"
      label="密码（6~16 个字符）"
      type="password"
      required
    ></v-text-field>
    <v-text-field
      v-model="confirm_password"
      :counter="16"
      :rules="confirmPasswordRules"
      label="确认密码"
      type="password"
      required
    ></v-text-field>
    <v-btn
      block
      color="primary mt-3"
      :disabled="!valid"
      @click="submit"
    >注册</v-btn>
    <div class="text-xs-center mt-3">
      <router-link to="/account/signin" class="body-2 grey--text">还没有登录？马上去登录！</router-link>
    </div>
    <v-snackbar
      v-if="info != null"
      :timeout="5000"
      :color="snackbarColor"
      bottom
      v-model="show"
    >
      {{ info.msg }}
      <v-btn dark flat @click.native="show = false">Close</v-btn>
    </v-snackbar>
  </v-form>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data: () => ({
    username: null,
    email: null,
    password: null,
    confirm_password: null,

    valid: true,
    show: false
  }),
  computed: {
    usernameRules () {
      return [
        v => !!v || '请输入用户名',
      ]
    },
    emailRules () {
      return [
        v => !!v || '请输入邮箱',
        v => /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || '请输入有效的邮箱'
      ]
    },
    passwordRules () {
      return [
        v => !!v || '请输入密码',
        v => (v && v.length >= 6 && v.length <= 16) || '注意密码的长度'
      ]
    },
    confirmPasswordRules () {
      return [
        v => !!v || '请确认密码',
        v => v === this.password || '密码不一致',
        v => (v && v.length >= 6 && v.length <= 16) || '注意密码的长度'
      ]
    },
    ...mapGetters({
      info: 'currentInfo'
    }),
    snackbarColor () {
      return this.info.success ? 'success' : 'error'
    }
  },
  methods: {
    submit () {
      if (this.$refs.form.validate()) {
        this.$store.dispatch('signup', {
          user: {
            username: this.username,
            email: this.email,
            password: this.password
          },
          redirct: () => this.$router.push('/account/signin')
        })
        this.show = true
      }
    }
  }
}
</script>

<style scoped>
a {
  text-decoration: none;
}
</style>
